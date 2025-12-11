namespace SwitchStatements;

public class BubbleSorter : ISorter
{
    public void Sort(int[] input)
    {
        bool sorted = false;
        while (!sorted)
        {
            sorted = true;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] > input[i + 1])
                {
                    Swapper.Swap(input, i, i + 1);
                    sorted = false;
                }
            }
        }
    }
}