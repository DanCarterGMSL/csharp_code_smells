namespace SwitchStatements.Test;

public class SorterTests
{
    private static readonly int[] SortedArray = new[] { 1, 2, 3 };

    [Test]
    public void BubblesortPutsArrayInAscendingOrder() {
        int[] array = {3,1,2};
        array = new Sorter().Sort(new BubbleSorter(new Swapper()), array);
        Assert.That(array, Is.EqualTo(SortedArray));
    }
	
    [Test]
    public void QuicksortPutsArrayInAscendingOrder() {
        int[] array = {3,1,2};
        array = new Sorter().Sort(new QuickSorter(new Swapper()), array);
        Assert.That(array, Is.EqualTo(SortedArray));
    }
	
    [Test]
    public void InsertionsortPutsArrayInAscendingOrder() {
        int[] array = {3,1,2};
        array = new Sorter().Sort(new InsertionSorter(new Swapper()), array);
        Assert.That(array, Is.EqualTo(SortedArray));
    }
}