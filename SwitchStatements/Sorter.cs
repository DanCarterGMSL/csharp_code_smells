namespace SwitchStatements;

public enum SortKind
{
    Bubble,
    Quick,
    Insertion
}

public class Swapper
{
    public void Swap(int[] input, int index1, int index2)
    {
        int first = input[index1];
        int second = input[index2];
        input[index1] = second;
        input[index2] = first;
    }
}

public interface ISorter
{
    void Sort(int[] input);
}

public class BubbleSorter : ISorter
{
    public BubbleSorter(Swapper swapper)
    {
        Swapper = swapper;
    }

    public Swapper Swapper { get; }

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
                    this.Swapper.Swap(input, i, i + 1);
                    sorted = false;
                }
            }
        }
    }
}

public class QuickSorter : ISorter
{
    public QuickSorter(Swapper swapper)
    {
        Swapper = swapper;
    }

    public Swapper Swapper { get; }

    private static void QuicksortRecurse(int[] input, int left, int right, Swapper swapper)
    {
        int i = left, j = right;
        int pivot = input[(left + right) / 2];
        int k = i;
        while (k <= j)
        {
            while (input[k] < pivot)
                k++;
            while (input[j] > pivot)
                j--;
            if (k <= j)
            {
                swapper.Swap(input, k, j);
                k++;
                j--;
            }
        }

        i = k;
        int index = i;
        if (left < index - 1)
        {
            QuicksortRecurse(input, left, index - 1, swapper);
        }
        if (index < right)
        {
            QuicksortRecurse(input, index, right, swapper);
        }
    }

    public void Sort(int[] input)
    {
        var swapper = this.Swapper;
        QuickSorter.QuicksortRecurse(input, 0, input.Length - 1, swapper);
    }
}

public class InsertionSorter : ISorter
{
    public InsertionSorter(Swapper swapper)
    {
        Swapper = swapper;
    }

    public Swapper Swapper { get; }

    public void Sort(int[] input)
    {
        var swapper = this.Swapper;
        for (int i = 0; i < input.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (input[j] < input[j - 1])
                {
                    swapper.Swap(input, j, j - 1);
                }
            }
        }
    }
}

public class Sorter
{
    private readonly Swapper _swapper = new Swapper();

    public int[] Sort(ISorter sorter, int[] input)
    {
        sorter.Sort(input);
        return input;
    }
}