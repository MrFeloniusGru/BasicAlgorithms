namespace XorMissNumberCore;

public class Core
{

    private int AriphmeticProgressionSum(int a1, int a2)
    {
        return (a1 + a2) * (a2 - a1 + 1) / 2;
    }

    // O(1)
    public int? MissOneNumber(int [] numbers)
    {
        if(numbers == null)
        {
            return null;
        }

        return AriphmeticProgressionSum(1, numbers.Length + 1) - numbers.Sum();
    }

    // O(n)
    public int[]? MissTwoNumbers(int[] numbers)
    { 
        if(numbers == null)
        {
            return [];
        }

        // MissOne + MissTwo
        var sumTwoNumbers = AriphmeticProgressionSum(1, numbers.Length + 2) - numbers.Sum();
        
        // MissOne ^ MissTwo
        var xorTwoNumbers = numbers.Aggregate((x, y) => x ^ y) ^ Enumerable.Range(1, numbers.Length + 2).Aggregate((x, y) => x ^ y);

        for (int i = 1; i < numbers.Length + 3; i++)
        {
            // j = MissOne ^ MissOne ^ MissTwo  =>  0 ^ MissTwo  =>  MissTwo
            var j = i ^ xorTwoNumbers;
            // MissTwo == MissOne + MissTwo - i => i = MissOne
            if (j == sumTwoNumbers - i)
            {
                return [i, j];
            }
        }

        return [];
    }
}
