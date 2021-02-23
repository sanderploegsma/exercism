using System;
using System.Collections.Generic;
using System.Linq;

public class BowlingGame
{
    private const int NumberOfFrames = 10;
    private const int NumberOfPins = 10;

    private readonly List<Frame> _frames = new List<Frame>();
    private readonly List<int> _rolls = new List<int>();
    private int _pinsLeft = NumberOfPins;

    public void Roll(int pins)
    {
        if (IsFinished)
            throw new ArgumentException("Game is already finished");

        if (pins < 0 || pins > _pinsLeft)
            throw new ArgumentException("Invalid number of pins");

        var type = CheckIfEndOfFrame(pins);
        if (type.HasValue)
        {
            _frames.Add(new Frame(type.Value, _rolls.Append(pins).ToList()));
            _rolls.Clear();
            _pinsLeft = NumberOfPins;
        }
        else
        {
            _rolls.Add(pins);
            var pinsLeft = _pinsLeft - pins;
            _pinsLeft = pinsLeft <= 0 ? NumberOfPins : pinsLeft;
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

    private FrameType? CheckIfEndOfFrame(int roll) => _frames.Count == NumberOfFrames - 1
        ? CheckIfEndOfFinalFrame(roll)
        : CheckIfEndOfNormalFrame(roll);

    private FrameType? CheckIfEndOfNormalFrame(int roll) =>
        (_rolls.Count + 1) switch
        {
            1 when roll == NumberOfPins => FrameType.Strike,
            2 when _rolls[0] + roll == NumberOfPins => FrameType.Spare,
            2 when _rolls[0] + roll < NumberOfPins => FrameType.Open,
            _ => null
        };

    private FrameType? CheckIfEndOfFinalFrame(int roll) =>
        (_rolls.Count + 1) switch
        {
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