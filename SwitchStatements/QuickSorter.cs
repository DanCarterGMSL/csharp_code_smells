namespace SwitchStatements;

public class QuickSorter : ISorter
{
    private static void QuicksortRecurse(int[] input, int left, int right)
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
                Swapper.Swap(input, k, j);
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

    public void Sort(int[] input)
    {
        QuickSorter.QuicksortRecurse(input, 0, input.Length - 1);
    }
}