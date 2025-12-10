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
            if (Facing == North)
            {
                Facing = East;
                return;
            }

            if (Facing == East)
            {
                Facing = South;
                return;
            }

            if (Facing == South)
            {
                Facing = West;
                return;
            }

            if (Facing == West)
            {
                Facing = North;
            }
        }

        if (instruction == TurnLeftInstruction)
        {
            if (Facing == North)
            {
                Facing = West;
                return;
            }

            if (Facing == West)
            {
                Facing = South;
                return;
            }

            if (Facing == South)
            {
                Facing = East;
                return;
            }

            Facing = North;
        }

        if (instruction == MoveForwardInstruction)
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

        if (instruction == MoveBackwardInstruction)
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
    }

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
}