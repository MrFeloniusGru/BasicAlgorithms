using System;
using System.Collections.Generic;
using System.Linq;

namespace SlidingWindowMax;

public class Core<T>
{
    private readonly IComparer<T> _comparer;
    public Core(IComparer<T> comparer)
    {
        _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
    }

    public T?[]? Max(T[] numbers, int windowLenght)
    {
        if(numbers == null)
        {
            return null;
        }

        if(windowLenght == 1){
            return numbers.ToArray();
        }

        if(windowLenght >= numbers.Length)
        {
            return new[] { numbers.Max(_comparer) };
        }

        var window = new LinkedList<int>();


        var res = new T[numbers.Length - windowLenght + 1];
        for (int i = 0; i < numbers.Length; i++)
        {
            while(window.Any() && window.First != null && window.First.Value < i - windowLenght + 1)
            {
                window.RemoveFirst();
            }
            while(window.Any() && window.Last != null && _comparer.Compare(numbers[i], numbers[window.Last.Value]) > 0)
            {
                window.RemoveLast();
            }

            window.AddLast(i);
            if(i >= windowLenght - 1)
            {
                res[i - windowLenght + 1] = numbers[window.First!.Value];
            }
        }

        return res;
    }
}
