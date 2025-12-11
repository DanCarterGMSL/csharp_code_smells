namespace SwitchStatements;

public class Sorter
{
    public int[] Sort(ISorter sorter, int[] input)
    {
        sorter.Sort(input);
        return input;
    }
}