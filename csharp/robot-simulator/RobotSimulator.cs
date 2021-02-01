using System;
using System.Collections.Generic;
using System.Linq;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    public RobotSimulator(Direction direction, int x, int y)
    {
        Direction = direction;
        X = x;
        Y = y;
    }

    public Direction Direction { get; private set; }

    public int X { get; private set; }

    public int Y { get; private set; }

    public void Move(string instructions)
    {
        foreach (var instruction in instructions)
        {
            Move(instruction);
        }
    }

    private void Move(char instruction)
    {
        switch (instruction)
        {
            case 'A':
                Advance();
                break;
            case 'R':
                Rotate(Rotation.Right);
                break;
            case 'L':
                Rotate(Rotation.Left);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(instruction), instruction, "Invalid instruction");
        }
    }

    private void Advance()
    {
        switch (Direction)
        {
            case Direction.North:
                Y += 1;
                break;
            case Direction.East:
                X += 1;
                break;
            case Direction.South:
                Y -= 1;
                break;
            case Direction.West:
                X -= 1;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Rotate(Rotation rotation)
    {
        Direction NextDirection(IEnumerable<Direction> order) =>
            order.SkipWhile(d => d != Direction).Skip(1).First();

        var directions = new[] {Direction.North, Direction.East, Direction.South, Direction.West, Direction.North};
        Direction = rotation == Rotation.Right ? NextDirection(directions) : NextDirection(directions.Reverse());
    }

    private enum Rotation { Left, Right }
}