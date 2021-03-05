using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

public class HangmanState
{
    public string MaskedWord { get; }
    public ImmutableHashSet<char> GuessedChars { get; }
    public int RemainingGuesses { get; }

    public HangmanState(string maskedWord, ImmutableHashSet<char> guessedChars, int remainingGuesses)
    {
        MaskedWord = maskedWord;
        GuessedChars = guessedChars;
        RemainingGuesses = remainingGuesses;
    }
}

public class TooManyGuessesException : Exception
{
}

public class Hangman
{
    private readonly string _word;
    private readonly BehaviorSubject<HangmanState> _state;

    public Hangman(string word)
    {
        _word = word;

        var initialState = new HangmanState(MaskWord(Array.Empty<char>()), ImmutableHashSet<char>.Empty, 9);
        _state = new BehaviorSubject<HangmanState>(initialState);
    }
    
    public IObservable<HangmanState> StateObservable => _state.AsObservable();
    
    public IObserver<char> GuessObserver => Observer.Create<char>(OnNextGuess);

    private void OnNextGuess(char guess)
    {
        if (_state.Value.RemainingGuesses == 0)
        {
            _state.OnError(new TooManyGuessesException());
            return;
        }

        var currentState = _state.Value;
        var remaining = currentState.GuessedChars.Contains(guess) || !_word.Contains(guess)
            ? currentState.RemainingGuesses - 1
            : currentState.RemainingGuesses;
        
        var guessed = currentState.GuessedChars.Add(guess);
        var masked = MaskWord(guessed);
        
        if (masked == _word)
            _state.OnCompleted();
        else
            _state.OnNext(new HangmanState(masked, guessed, remaining));
    }

    private string MaskWord(IReadOnlyCollection<char> guesses) =>
        string.Concat(_word.Select(c => guesses.Contains(c) ? c : '_'));
}
