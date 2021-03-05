using System;
using System.Collections.Generic;
using System.Linq;

public static class Forth
{
    public static string Evaluate(string[] instructions)
    {
        var userWords = ParseUserWords(instructions.SkipLast(1).Select(x => x.ToLower()));
        var expression = instructions.Last().ToLower().Split(' ');
        var evaluator = new Evaluator(userWords);
        evaluator.Evaluate(expression);
        return evaluator.ToString();
    }

    private static IDictionary<string, string[]> ParseUserWords(IEnumerable<string> userWords)
    {
        var user = new Dictionary<string, string[]>();
        
        foreach (var (word, expression) in userWords.Select(ParseUserWord))
        {
            user[word] = expression
                .SelectMany(w => user.GetValueOrDefault(w, new []{w}))
                .ToArray();
        }

        return user;
    }

    private static (string Word, string[] Expression) ParseUserWord(string word)
    {
        var parts = word.TrimStart(':', ' ').TrimEnd(' ', ';').Split(' ');
        return (parts.First(), parts.Skip(1).ToArray());
    }

    private class Evaluator
    {
        private readonly Stack<int> _stack;
        private readonly IDictionary<string, string[]> _userWords;
        private readonly IDictionary<string, Action> _words;

        public Evaluator(IDictionary<string, string[]> userWords)
        {
            _stack = new Stack<int>();
            _userWords = userWords;
            _words = new Dictionary<string, Action>
            {
                ["+"] = Add,
                ["-"] = Subtract,
                ["*"] = Multiply,
                ["/"] = Divide,
                ["dup"] = Duplicate,
                ["drop"] = Drop,
                ["swap"] = Swap,
                ["over"] = Over
            };
        }

        public void Evaluate(IEnumerable<string> instructions)
        {
            foreach (var word in instructions)
            {
                if (_userWords.TryGetValue(word, out var expression))
                {
                    Evaluate(expression);
                    continue;
                }

                if (_words.TryGetValue(word, out var action))
                {
                    action.Invoke();
                    continue;
                }
                
                if (!int.TryParse(word, out var value))
                    throw new InvalidOperationException($"Unknown operation {word}");
                
                _stack.Push(value);
            }
        }

        private void Add() => Arithmetic((lhs, rhs) => lhs + rhs);

        private void Subtract() => Arithmetic((lhs, rhs) => lhs - rhs);

        private void Multiply() => Arithmetic((lhs, rhs) => lhs * rhs);

        private void Divide() => Arithmetic((lhs, rhs) =>
        {
            if (rhs == 0)
                throw new InvalidOperationException();
            
            return lhs / rhs;
        });

        private void Duplicate()
        {
            if (!_stack.TryPeek(out var value))
                throw new InvalidOperationException();
            
            _stack.Push(value);
        }

        private void Drop()
        {
            if (!_stack.TryPop(out _))
                throw new InvalidOperationException();
        }

        private void Swap()
        {
            if (!_stack.TryPop(out var first) || !_stack.TryPop(out var second))
                throw new InvalidOperationException();
            
            _stack.Push(first);
            _stack.Push(second);
        }

        private void Over()
        {
            if (!_stack.TryPop(out var first) || !_stack.TryPeek(out var second))
                throw new InvalidOperationException();
            
            _stack.Push(first);
            _stack.Push(second);
        }

        private void Arithmetic(Func<int, int, int> arithmetic)
        {
            if (!_stack.TryPop(out var rhs) || !_stack.TryPop(out var lhs))
                throw new InvalidOperationException();

            _stack.Push(arithmetic.Invoke(lhs, rhs));
        }

        public override string ToString() => string.Join(' ', _stack.Reverse());
    }
}