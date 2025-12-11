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

public class BubbleSorter
{
    public BubbleSorter(Swapper swapper)
    {
        Swapper = swapper;
    }

    public Swapper Swapper { get; }
}

public class Sorter
{
    private readonly Swapper _swapper = new Swapper();

    public int[] Sort(SortKind kind, int[] input)
    {
        switch (kind)
        {
            case SortKind.Bubble:
                BubbleSort(input, new BubbleSorter(_swapper));
                break;
            case SortKind.Quick:
                QuickSort(input);
                break;
            case SortKind.Insertion:
                InsertionSort(input);
                break;
        }
        return input;
    }

    private void QuickSort(int[] input)
    {
        QuicksortRecurse(input, 0, input.Length - 1);
    }

    private void BubbleSort(int[] input, BubbleSorter bubbleSorter)
    {
        var swapper = bubbleSorter.Swapper;
        bool sorted = false;
        while (!sorted)
        {
            sorted = true;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] > input[i + 1])
                {
                    swapper.Swap(input, i, i + 1);
                    sorted = false;
                }
            }
        }
    }

    private void InsertionSort(int[] input)
    {
        for (int i = 0; i < input.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (input[j] < input[j - 1])
                {
                    _swapper.Swap(input, j, j - 1);
                }
            }
        }
    }

    private void QuicksortRecurse(int[] input, int left, int right)
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
                _swapper.Swap(input, k, j);
                k++;
                j--;
            }
        }

        i = k;
        int index = i;
        if (left < index - 1)
        {
            QuicksortRecurse(input, left, index - 1);
        }
        if (index < right)
        {
            QuicksortRecurse(input, index, right);
        }
    }
}