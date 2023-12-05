using System.Collections.Concurrent;

namespace QuickSortLib;
public class Core
{

    private int Partion<T>(T[] sequnce, int p, int r, Comparer<T> comparer)
    {
        var x = sequnce[r];
        var i = p - 1;
        for (var j = p; j < r; j++)
        { 
            if(comparer.Compare(sequnce[j], x) <= 0)
            {
                i++;
                (sequnce[j], sequnce[i]) = (sequnce[i], sequnce[j]);
            }
        }

        (sequnce[i + 1], sequnce[r]) = (sequnce[r], sequnce[i + 1]);
        return i + 1;
    }

    private void QuickSort<T>(T[] sequnce, int p, int r, Comparer<T> comparer)
    {
        if(p < r)
        {
            var q = Partion(sequnce, p, r, comparer);
            QuickSort(sequnce, p, q - 1, comparer);
            QuickSort(sequnce, q + 1, r, comparer);
        }   
    }

    public IEnumerable<int> QuickSort(IEnumerable<int> sequnce)
    {
        var sequnceCopy = sequnce.ToArray();
        QuickSort(sequnceCopy, 0, sequnceCopy.Length - 1, Comparer<int>.Default);
        return sequnceCopy;
    }
}
