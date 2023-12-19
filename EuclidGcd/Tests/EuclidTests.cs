using EuclidGcdLib;
using Xunit;

namespace Tests;

public class EuclidTests
{
    
    [Theory]
    [InlineData( 30, 21, 3 )]
    [InlineData( 10, 0, 10 )]
    [InlineData( 1, 1, 1 )]
    [InlineData( 21, 30, 3 )]
    [InlineData( 144, 12, 12 )]
    public void Gcd(int a, int b, int answer)
    {
        var core = new Core();
        Assert.Equal(answer, core.Gcd(a, b));
    }

    [Theory]
    [InlineData( 99, 78, 3, -11, 14 )]
    public void GcdExtended(int a, int b, int d, int x, int y)
    {
        var core = new Core();
        Assert.Equal((d, x, y), core.GcdExtended(a, b));
    }
}
