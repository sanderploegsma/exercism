using System;
using System.Collections.Generic;
using System.Linq;

public class BowlingGame
{
    private const int NumberOfFrames = 10;

    private readonly List<Frame> _frames = new List<Frame>();
    private Frame _currentFrame;

    public void Roll(int pins)
    {
        if (_frames.Count == NumberOfFrames)
            throw new ArgumentException("Game is already finished");

        switch (_currentFrame)
        {
            case null when _frames.Count == NumberOfFrames - 1:
                _currentFrame = new FinalFrame(pins);
                break;
            case null:
                _currentFrame = new Frame(pins);
                break;
            default:
                _currentFrame.AddRoll(pins);
                break;
        }

        if (_currentFrame.IsFull)
        {
            _frames.Add(_currentFrame);
            _currentFrame = null;
        }
    }

    public int? Score()
    {
        if (_frames.Count < NumberOfFrames)
            throw new ArgumentException("Game is not yet finished");

        var score = 0;

        for (var frameIndex = 0; frameIndex < 10; frameIndex++)
        {
            var frame = _frames[frameIndex];
            var nextRolls = _frames.Skip(frameIndex + 1).SelectMany(f => f.Rolls);

            if (frame is FinalFrame || frame.IsOpen)
            {
                score += frame.Rolls.Sum();
            }
            else if (frame.IsStrike)
            {
                score += 10 + nextRolls.Take(2).Sum();
            }
            else if (frame.IsSpare)
            {
                score += 10 + nextRolls.First();
            }
        }

        return score;
    }
}

internal class Frame
{
    protected readonly List<int> _rolls = new List<int>();

    public Frame(int firstRoll)
    {
        if (!IsValidRoll(firstRoll))
            throw new ArgumentException("Invalid number of pins");

        _rolls.Add(firstRoll);
    }

    public IReadOnlyCollection<int> Rolls => _rolls;

    public virtual void AddRoll(int roll)
    {
        if (IsFull)
            throw new ArgumentException("Cannot roll in a full frame");

        if (!IsValidRoll(roll))
            throw new ArgumentException("Invalid number of pins");
        
        if (_rolls[0] + roll > 10)
            throw new ArgumentException("Invalid number of pins");

        _rolls.Add(roll);
    }

    public virtual bool IsFull => IsStrike || _rolls.Count == 2;

    public bool IsStrike => _rolls[0] == 10;

    public bool IsSpare => _rolls.Count == 2 && _rolls[0] + _rolls[1] == 10;

    public bool IsOpen => !IsStrike && !IsSpare;

    protected static bool IsValidRoll(int roll) => roll >= 0 && roll <= 10;
}

internal class FinalFrame : Frame
{
    public FinalFrame(int firstRoll) : base(firstRoll) { }

    public override bool IsFull => _rolls.Count == 3 || (_rolls.Count == 2 && !IsStrike && !IsSpare);

    public override void AddRoll(int roll)
    {
        if (IsFull)
            throw new ArgumentException("Cannot roll in a full frame");

        if (!IsValidRoll(roll))
            throw new ArgumentException("Invalid number of pins");

        if (IsStrike && _rolls.Count == 2 && _rolls[1] < 10 && _rolls[1] + roll > 10)
            throw new ArgumentException("Invalid number of pins");

        _rolls.Add(roll);
    }
}