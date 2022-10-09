namespace Tests;
using Xunit;
using ImplementetionLibrary;

public class UnitTest1
{
    [Theory]
    [InlineData(new int[]{3, 2, 1})]
    [InlineData(new int[]{2, 3, 1})]
    [InlineData(new int[]{1, 2, 3})]
    [InlineData(new int[]{4, 3, 2, 1})]
    [InlineData(new int[]{4})]
    [InlineData(new int[]{})]
    public void SortArrayShouldBeCorrect(int[] data)
    {
        var core = new Core();
        Assert.Equal(core.MergeSort(data), data.OrderBy(x => x));
    }

    [Theory]
    [InlineData(new int[]{3, 2, 1})]
    [InlineData(new int[]{2, 3, 1})]
    [InlineData(new int[]{1, 2, 3})]
    [InlineData(new int[]{2, 4, 1, 3})]
    public void DescSortArrayShouldBeCorrect(int[] data)
    {
        var core = new Core();
        Assert.Equal(core.MergeSortDesc(data), data.OrderByDescending(x => x));
    }
}