﻿namespace ImplementetionLibrary;
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
    protected T[] Merge<T>(T[] sequence, int leftIndex, int middleIndex, int rightIndex, IComparer<T> comparer, SortOrder sortOrder)
    {
        var leftLenght = middleIndex - leftIndex + 1;
        var rightLenght = rightIndex - middleIndex;

        var leftSubseq = sequence.Skip(leftIndex).Take(leftLenght).ToArray();
        var rightSubseq = leftLenght > 0 ? sequence.Skip(middleIndex + 1).Take(rightLenght).ToArray() : new T[0];
 
        int i = 0, j = 0;       
        for(int k = leftIndex; k <= rightIndex; k++)
        {
            if(leftLenght - i > 0 && (rightLenght - j == 0 || comparer.Compare(leftSubseq[i], rightSubseq[j]) * (int)sortOrder <= 0))
            {
                sequence[k] = leftSubseq[i];
                i++;
            }
            else if (rightLenght - j > 0)
            {

                sequence[k] = rightSubseq[j];
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
    private T[] MergeSort<T>(T[] sequence, int left, int right,  IComparer<T> comparer, SortOrder sortOrder)
    {
        if(left < right)
        {
            var middle = (left + right) / 2;

            MergeSort(sequence, left, middle, comparer, sortOrder);
            MergeSort(sequence, middle + 1, right, comparer, sortOrder);

            return Merge(sequence, left, middle, right, comparer, sortOrder);
        }
        else if (left > right)
        {
            throw new ArgumentException($"{nameof(left)} should be less then {nameof(right)}");
        }

        return sequence;
    }

    private int GetRightIndex<T>(T[] sequence)
    {
        return sequence.Length > 0 ? sequence.Length - 1 : 0;
    }


    /// <summary>
    /// Sorts elements of the sequence in ascending order and has computational complexity = Θ(n*log(n))
    /// </summary>
    /// <param name="sequence">Source sequence</param>
    /// <returns>Sorted sequence</returns>
    public IEnumerable<int> MergeSort(IEnumerable<int> sequence)
    {
        if(sequence == null)
        {
            throw new ArgumentNullException(nameof(sequence));
        }
        // clone sequence
        var sequenceCopy = sequence.ToArray();
        return MergeSort(sequenceCopy, 0, GetRightIndex(sequenceCopy), Comparer<int>.Default, SortOrder.Asc);
    }

    /// <summary>
    /// Sorts elements of the sequence in ascending order and has computational complexity = Θ(n*log(n))
    /// </summary>
    /// <param name="sequence">Source sequence</param>
    /// <returns>Sorted sequence</returns>
    public IEnumerable<int> MergeSortDesc(IEnumerable<int> sequence)
    {
        if(sequence == null)
        {
            throw new ArgumentNullException(nameof(sequence));
        }
        // clone sequence
        var sequenceCopy = sequence.ToArray();
        return MergeSort(sequenceCopy, 0, GetRightIndex(sequenceCopy), Comparer<int>.Default, SortOrder.Desc);
    }
}
