namespace Comments;

public class MarsRover
{
    private const string North = "N";
    private const string East = "E";
    private const string South = "S";
    private const string West = "W";

    private const int TurnRightInstruction = 'R';
    private const int TurnLeftInstruction = 'L';
    private const int MoveForwardInstruction = 'F';
    private const int MoveBackwardInstruction = 'B';

    public string Facing { get; private set; }
    public int[] Coordinates { get; }

    public MarsRover(string facing, int[] coordinates)
    {
        Facing = facing;
        Coordinates = coordinates;
    }

    public void Go(string instructions)
    {
        foreach (var instruction in instructions.ToCharArray())
        {
            Execute(instruction);
        }
    }

    private void Execute(char instruction)
    {
        if (instruction == TurnRightInstruction)
        {
            TurnRight();
        }

        if (instruction == TurnLeftInstruction)
        {
            TurnLeft();
        }

        if (instruction == MoveForwardInstruction)
        {
            MoveForward();
        }

        if (instruction == MoveBackwardInstruction)
        {
            MoveBackward();
        }
    }

    private void TurnLeft()
    {
        switch (Facing)
        {
            case North:
                Facing = West;
                break;
            case West:
                Facing = South;
                break;
            case South:
                Facing = East;
                break;
            default:
                Facing = North;
                break;
        }
    }

    private void MoveBackward()
    {
        if (Facing == North)
        {
            DecrementY();
        }

        if (Facing == East)
        {
            DecrementX();
        }

        if (Facing == South)
        {
            IncrementY();
        }

        if (Facing == West)
        {
            IncrementX();
        }
    }

    private void MoveForward()
    {
        if (Facing == North)
        {
            IncrementY();
        }

        if (Facing == East)
        {
            IncrementX();
        }

        if (Facing == South)
        {
            DecrementY();
        }

        if (Facing == West)
        {
            DecrementX();
        }
    }

    private void TurnRight()
    {
        var facingDirection = CreateFacingDirection();

        Facing = facingDirection.TurnRight();
    }

    private IFacingDirection CreateFacingDirection() =>
        Facing switch
        {
            North => new FacingNorth(),
            East => new FacingEast(),
            South => new FacingSouth(),
            West => new FacingWest(),
            _ => throw new InvalidOperationException()
        };

    private void DecrementX()
    {
        Coordinates[0] -= 1;
    }

    private void IncrementX()
    {
        Coordinates[0] += 1;
    }

    private void DecrementY()
    {
        Coordinates[1] -= 1;
    }

    private void IncrementY()
    {
        Coordinates[1] += 1;
    }

    private interface IFacingDirection
    {
        public string TurnRight();
    }

    private class FacingNorth : IFacingDirection
    {
        public string TurnRight() => East;
    }

    private class FacingEast : IFacingDirection
    {
        public string TurnRight() => South;
    }

    private class FacingSouth : IFacingDirection
    {
        public string TurnRight() => West;
    }

    private class FacingWest : IFacingDirection
    {
        public string TurnRight() => North;
    }
}