namespace BlobSortLib;
public class Core
{
    private T[] BlobSort<T>(T[] sequnce, Comparer<T> comparer)
    {
        for (int i = 1; i < sequnce.Length; i++)
        {
            var key = sequnce[i];
            var j = i - 1;
            while(j > -1 && comparer.Compare(sequnce[j], key) > 0)
            {
                sequnce[j + 1] = sequnce[j];
                j--;
            }
            sequnce[j + 1] = key;
        }

        return sequnce;
    }

    public IEnumerable<int> BlobSort(IEnumerable<int> sequnce)
    {
        var sequnceCopy = sequnce.ToArray();
        return BlobSort<int>(sequnceCopy, Comparer<int>.Default);
    }
}
