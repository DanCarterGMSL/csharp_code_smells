namespace Comments;

public class MarsRover
{
    private const string North = "N";
    private const string East = "E";
    private const string South = "S";
    private const string West = "W";
    private const int TurnRight = 'R';
    private const int TurnLeft = 'L';
    private const int MoveForward = 'F';
    private const int MoveBackward = 'B';
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
        if (instruction == TurnRight)
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

            Facing = North;
        }

        if (instruction == TurnLeft)
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

        if (instruction == MoveForward)
        {
            if (Facing == North)
            {
                // Y + 1
                Coordinates[1] = Coordinates[1] + 1;
            }

            if (Facing == East)
            {
                // X + 1
                Coordinates[0] = Coordinates[0] + 1;
            }

            if (Facing == South)
            {
                // Y - 1
                Coordinates[1] = Coordinates[1] - 1;
            }

            if (Facing == West)
            {
                // X - 1
                Coordinates[0] = Coordinates[0] - 1;
            }
        }

        if (instruction == MoveBackward)
        {
            if (Facing == North)
            {
                // Y - 1
                Coordinates[1] = Coordinates[1] - 1;
            }

            if (Facing == East)
            {
                // X - 1
                Coordinates[0] = Coordinates[0] - 1;
            }

            if (Facing == South)
            {
                // Y + 1
                Coordinates[1] = Coordinates[1] + 1;
            }

            if (Facing == West)
            {
                // X + 1
                Coordinates[0] = Coordinates[0] + 1;
            }
        }
    }
}