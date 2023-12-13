using System.Collections.Concurrent;

namespace QuickSortLib;
public class Core
{

    private int Partion<T>(T[] sequence, int p, int r, Comparer<T> comparer)
    {
        var x = sequence[r];
        var i = p - 1;
        for (var j = p; j < r; j++)
        { 
            if(comparer.Compare(sequence[j], x) <= 0)
            {
                i++;
                (sequence[j], sequence[i]) = (sequence[i], sequence[j]);
            }
        }

        (sequence[i + 1], sequence[r]) = (sequence[r], sequence[i + 1]);
        return i + 1;
    }

    private void QuickSort<T>(T[] sequence, int p, int r, Comparer<T> comparer)
    {
        if(p < r)
        {
            var q = Partion(sequence, p, r, comparer);
            QuickSort(sequence, p, q - 1, comparer);
            QuickSort(sequence, q + 1, r, comparer);
        }   
    }

    // O(nlg2(n))
    public IEnumerable<int> QuickSort(IEnumerable<int> sequence)
    {
        var sequenceCopy = sequence.ToArray();
        QuickSort(sequenceCopy, 0, sequenceCopy.Length - 1, Comparer<int>.Default);
        return sequenceCopy;
    }
}
