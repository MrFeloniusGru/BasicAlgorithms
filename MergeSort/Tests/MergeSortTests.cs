namespace Tests;
using Xunit;
using ImplementetionLibrary;

public class MergeSortTests
{
    [Theory]
    [InlineData(new int[]{3, 2, 1})]
    [InlineData(new int[]{2, 3, 1})]
    [InlineData(new int[]{1, 2, 3})]
    [InlineData(new int[]{1, 4, 3, 2})]
    [InlineData(new int[]{4})]
    [InlineData(new int[]{})]
    public void SortArrayShouldBeCorrect(int[] data)
    {
        var core = new Core();
        Assert.Equal(data.OrderBy(x => x), core.MergeSort(data));
    }

    [Theory]
    [InlineData(new int[]{3, 2, 1})]
    [InlineData(new int[]{2, 3, 1})]
    [InlineData(new int[]{1, 2, 3})]
    [InlineData(new int[]{1, 4, 3, 2})]
    [InlineData(new int[]{4})]
    [InlineData(new int[]{})]
    public void DescSortArrayShouldBeCorrect(int[] data)
    {
        var core = new Core();
        Assert.Equal(data.OrderByDescending(x => x), core.MergeSortDesc(data));
    }
}