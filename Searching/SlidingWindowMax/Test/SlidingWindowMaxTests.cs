namespace Tests;
using Xunit;
using SlidingWindowMax;

public class SlidingWindowMaxTests
{
    [Theory]
    [InlineData(new int[] { 1, 4, 3, 2, 1 })]

    public void SortArrayShouldBeCorrect(int[] data)
    {
        var core = new Core<int>(Comparer<int>.Default);
        Assert.Equal(new [] {4, 4, 3}, core.Max(data, 3));
    }

    [Theory]
    [InlineData(new int[] { 5, 1 })]

    public void SortArrayShouldBeCorrect2(int[] data)
    {
        var core = new Core<int>(Comparer<int>.Default);
        Assert.Equal(new [] {5}, core.Max(data, 3));
    }

    [Theory]
    [InlineData(new int[] { 4, 4, 4, 4 })]

    public void SortArrayShouldBeCorrect3(int[] data)
    {
        var core = new Core<int>(Comparer<int>.Default);
        Assert.Equal(new [] {4, 4}, core.Max(data, 3));
    }
}
