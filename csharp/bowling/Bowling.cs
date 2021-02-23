using System;
using System.Collections.Generic;
using System.Linq;

public class BowlingGame
{
    private const int NumberOfFrames = 10;
    private const int NumberOfPins = 10;

    private readonly List<Frame> _frames = new List<Frame>();
    private readonly List<int> _rolls = new List<int>();

    public void Roll(int pins)
    {
        if (IsFinished)
            throw new ArgumentException("Game is already finished");

        if (pins < 0 || pins > NumberOfPins)
            throw new ArgumentException("Invalid number of pins");

        var type = ValidateRoll(pins);
        if (type.HasValue)
        {
            _frames.Add(new Frame(type.Value, _rolls.Append(pins).ToList()));
            _rolls.Clear();
        }
        else
        {
            _rolls.Add(pins);
        }
    }

    public int? Score()
    {
        if (!IsFinished)
            throw new ArgumentException("Game is not yet finished");

        return _frames
            .Select((frame, i) => ScoreFrame(frame, _frames.Skip(i + 1).SelectMany(f => f.Rolls)))
            .Sum();
    }

    private static int ScoreFrame(Frame frame, IEnumerable<int> nextRolls) =>
        frame.Type switch
        {
            FrameType.Strike => 10 + nextRolls.Take(2).Sum(),
            FrameType.Spare => 10 + nextRolls.First(),
            _ => frame.Rolls.Sum()
        };

    private bool IsFinished => _frames.Count == NumberOfFrames;

    private FrameType? ValidateRoll(int roll) => _frames.Count == NumberOfFrames - 1
        ? ValidateFinalFrameRoll(roll)
        : ValidateNormalFrameRoll(roll);

    private FrameType? ValidateNormalFrameRoll(int roll) =>
        (_rolls.Count + 1) switch
        {
            // When the first roll is not a strike, the first and second roll cannot exceed the number of pins
            2 when _rolls[0] + roll > NumberOfPins => throw new ArgumentException(),
            
            1 when roll == NumberOfPins => FrameType.Strike,
            2 when _rolls[0] + roll == NumberOfPins => FrameType.Spare,
            2 when _rolls[0] + roll < NumberOfPins => FrameType.Open,
            _ => null
        };

    private FrameType? ValidateFinalFrameRoll(int roll) =>
        (_rolls.Count + 1) switch
        {
            // When the first roll is not a strike, the first and second roll cannot exceed the number of pins
            2 when _rolls[0] < NumberOfPins && _rolls[0] + roll > NumberOfPins => throw new ArgumentException(),
            
            // When the first roll is a strike and the second is not, the second and third roll cannot exceed the number of pins
            3 when _rolls[0] == NumberOfPins && _rolls[1] < NumberOfPins && _rolls[1] + roll > NumberOfPins => throw new ArgumentException(),
            
            2 when _rolls[0] + roll < NumberOfPins => FrameType.Final,
            3 => FrameType.Final,
            _ => null
        };

    private class Frame
    {
        public FrameType Type { get; }
        public IEnumerable<int> Rolls { get; }

        public Frame(FrameType type, IEnumerable<int> rolls)
        {
            Type = type;
            Rolls = rolls;
        }
    }

    private enum FrameType
    {
        Strike,
        Spare,
        Open,
        Final
    }
}