namespace ImplementetionLibrary;
public class Core
{
    protected enum SortOrder { Asc = 1 , Desc = -1}
    /// <summary>
    /// The method merges two ordered subsequences [leftIndex...middleIndex], [middleIndex + 1 ... rightIndex] 
    /// into one ordered subsequence [leftIndex ... rightIndex]
    /// </summary>
    /// <typeparam name="T">the type of Data contained in the sequence</typeparam>
    /// <param name="sequence">The source sequence contained two ordered subsequences [leftIndex...middleIndex], [middleIndex + 1 ... rightIndex]</param>
    /// <param name="leftIndex">The start index of the first subsequence</param>
    /// <param name="middleIndex">The end index of the first subsequence. MiddleIndex + 1 is the start index of the second subsequence</param>
    /// <param name="rightIndex">The end index of the second subsequence</param>
    /// <param name="comparer">Compares two objects of T type for equivalence</param>
    /// <param name="sortOrder">Specifies sorting order</param>
    /// <returns></returns>
    protected IList<T> Merge<T>(IList<T> sequence, int leftIndex, int middleIndex, int rightIndex, IComparer<T> comparer, SortOrder sortOrder)
    {
        var leftLenght = middleIndex - leftIndex + 1;
        var rightLenght = rightIndex - middleIndex;

        var leftSubseq = sequence.Skip(leftIndex).Take(leftLenght).ToArray();
        var rightSubseq = leftLenght > 0 ? sequence.Skip(middleIndex + 1).Take(rightLenght).ToArray() : new T[0];

        int i = 0, j = 0;       
        for(int k = leftIndex; k <= rightIndex; k++)
        {
            if(leftLenght - i > 0 && (rightLenght - j == 0 || comparer.Compare(leftSubseq.ElementAt(i), rightSubseq.ElementAt(j)) * (int)sortOrder <= 0))
            {
                sequence[k] = leftSubseq.ElementAt(i);
                i++;
            }
            else if (rightLenght - j > 0)
            {
                sequence[k] = rightSubseq.ElementAt(j);
                j++;
            }
        }

        return sequence;
    }

    /// <summary>
    /// Sorts the sequence in the order specified by sortOrder parameter using divide and conquer sort algorithm.
    /// This method generetes a recursion about log(n) + 1 deep, where a log is a logarithm base 2. 
    /// </summary>
    /// <typeparam name="T">the type of Data contained in the sequence</typeparam>
    /// <param name="sequence">The source sequence</param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="comparer"></param>
    /// <param name="sortOrder">Specifies sorting order</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private IList<T> MergeSort<T>(IList<T> sequnce, int left, int right,  IComparer<T> comparer, SortOrder sortOrder)
    {
        if(left < right)
        {
            var middle = (left + right) / 2;

            MergeSort(sequnce, left, middle, comparer, sortOrder);
            MergeSort(sequnce, middle + 1, right, comparer, sortOrder);

            return Merge(sequnce, left, middle, right, comparer, sortOrder);
        }
        else if (left > right)
        {
            throw new ArgumentException($"{nameof(left)} should be less then {nameof(right)}");
        }

        return sequnce;
    }

    private int GetRightIndex<T>(IList<T> sequnce)
    {
        return sequnce.Count > 0 ? sequnce.Count - 1 : 0;
    }

    private IList<T> GetIList<T>(IEnumerable<T> sequnce)
    {
        return sequnce is IList<T> ? (IList<T>)sequnce : sequnce.ToArray();
    }

    /// <summary>
    /// Sorts elements of the sequence in ascending order and has computational complexity = Θ(n*log(n))
    /// </summary>
    /// <param name="sequnce">Source sequence</param>
    /// <returns>Sorted sequence</returns>
    public IEnumerable<int> MergeSort(IEnumerable<int> sequnce)
    {
        if(sequnce == null)
        {
            throw new ArgumentNullException(nameof(sequnce));
        }

        var list = GetIList(sequnce);
        return MergeSort(list, 0, GetRightIndex(list), Comparer<int>.Default, SortOrder.Asc);
    }

    /// <summary>
    /// Sorts elements of the sequence in ascending order and has computational complexity = Θ(n*log(n))
    /// </summary>
    /// <param name="sequnce">Source sequence</param>
    /// <returns>Sorted sequence</returns>
    public IEnumerable<int> MergeSortDesc(IEnumerable<int> sequnce)
    {
        if(sequnce == null)
        {
            throw new ArgumentNullException(nameof(sequnce));
        }

        var list = GetIList(sequnce);
        return MergeSort(list, 0, GetRightIndex(list), Comparer<int>.Default, SortOrder.Desc);
    }
}
