﻿using System;
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

        _rolls.Add(pins);
        if (IsEndOfFrame(out var frame))
        {
            _frames.Add(frame);
            _rolls.Clear();
            _pinsLeft = NumberOfPins;
        }
        else
        {
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

    private bool IsEndOfFrame(out Frame frame) => _frames.Count == NumberOfFrames - 1
        ? IsEndOfFinalFrame(out frame)
        : IsEndOfNormalFrame(out frame);

    private bool IsEndOfNormalFrame(out Frame frame)
    {
        switch (_rolls.Count)
        {
            case 1 when _rolls[0] == NumberOfPins:
                frame = new Frame(FrameType.Strike, _rolls.ToArray());
                return true;
            case 2 when _rolls[0] + _rolls[1] == NumberOfPins:
                frame = new Frame(FrameType.Spare, _rolls.ToArray());
                return true;
            case 2 when _rolls[0] + _rolls[1] < NumberOfPins:
                frame = new Frame(FrameType.Open, _rolls.ToArray());
                return true;
            default:
                frame = null;
                return false;
        }
    }

    private bool IsEndOfFinalFrame(out Frame frame)
    {
        switch (_rolls.Count)
        {
            case 2 when _rolls[0] + _rolls[1] < NumberOfPins:
            case 3:
                frame = new Frame(FrameType.Final, _rolls.ToArray());
                return true;
            default:
                frame = null;
                return false;
        }
    }

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