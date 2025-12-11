namespace SwitchStatements;

public class InsertionSorter : ISorter
{
    public void Sort(int[] input)
    {
        for (int i = 0; i < input.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (input[j] < input[j - 1])
                {
                    Swapper.Swap(input, j, j - 1);
                }
            }
        }
    }
}