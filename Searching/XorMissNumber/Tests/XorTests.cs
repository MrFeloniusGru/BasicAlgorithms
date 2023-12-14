namespace Tests;
using Xunit;
using XorMissNumberCore;

public class XorTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 5, 7})]


    public void MissTwoNumbersShouldBeCorrect(int[] data)
    {
        var core = new Core();
        Assert.Equal([4,6], core.MissTwoNumbers(data));
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3})]
    public void MissTwoNumbersShouldBeCorrect2(int[] data)
    {
        var core = new Core();
        Assert.Equal([4,5], core.MissTwoNumbers(data));
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 4})]
    public void MissOneNumbersShouldBeCorrect(int[] data)
    {
        var core = new Core();
        Assert.Equal(3, core.MissOneNumber(data));
    }
}
