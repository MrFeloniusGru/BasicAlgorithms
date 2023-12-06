namespace BlobSortLib;
public class Core
{
    private T[] BlobSort<T>(T[] sequence, Comparer<T> comparer)
    {
        for (int i = 1; i < sequence.Length; i++)
        {
            var key = sequence[i];
            var j = i - 1;
            while(j > -1 && comparer.Compare(sequence[j], key) > 0)
            {
                sequence[j + 1] = sequence[j];
                j--;
            }
            sequence[j + 1] = key;
        }

        return sequence;
    }

    public IEnumerable<int> BlobSort(IEnumerable<int> sequence)
    {
        var sequenceCopy = sequence.ToArray();
        return BlobSort<int>(sequenceCopy, Comparer<int>.Default);
    }
}
