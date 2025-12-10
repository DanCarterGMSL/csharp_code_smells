namespace Comments;

public class MarsRover
{
    private const string North = "N";
    private const string East = "E";
    private const string South = "S";
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
        // R = Turn Right
        if (instruction == 'R')
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
                // W = West
                Facing = "W";
                return;
            }

            Facing = North;
        }

        // L = Turn Left
        if (instruction == 'L')
        {
            if (Facing == North)
            {
                Facing = "W";
                return;
            }

            if (Facing == "W")
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

        // F = Move Forward
        if (instruction == 'F')
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

            if (Facing == "W")
            {
                // X - 1
                Coordinates[0] = Coordinates[0] - 1;
            }
        }

        if (instruction == 'B')
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

            if (Facing == "W")
            {
                // X + 1
                Coordinates[0] = Coordinates[0] + 1;
            }
        }
    }
}