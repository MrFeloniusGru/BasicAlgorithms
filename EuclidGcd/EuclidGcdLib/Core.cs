namespace EuclidGcdLib;

public class Core
{
    // O(lg(b))
    public int Gcd(int a, int b)
    {
        while(b > 0)
        {
            (b, a) = (a % b, b);
        }

        return a;
    }

    public (int, int, int) GcdExtended(int a, int b)
    {
        if(b == 0)
        {
            return (a, 1, 0);
        }
        
        int d, x, y;
        (d, x, y) = GcdExtended(b, a % b);
        return (d, y, x - a / b * y);
    }
}
