using System.ComponentModel;

namespace HeapSortLib;
public class Core
{
    struct Heap
    {
        public Heap(int[] sequence)
        {
            _sequence = sequence;
        }

        private int[] _sequence;
        public int HeapSize;

        public int this[int index]
        {
            get => _sequence[index];
            set => _sequence[index] = value;    
        }
    }

    private int Left(int idx)
    {
        return idx * 2 + 1;
    }

    private int Right(int idx)
    {
        return (idx * 2) + 2;
    }

    // O(lg(n)) или O(h), где h - высота поддерева с корнем в idx
    private void MaxHeapify(Heap heap, int idx)
    {
        var l = Left(idx);
        var r = Right(idx);

        var largest = l <= heap.HeapSize - 1 && heap[l] > heap[idx] ? l : idx;

        if (r <= heap.HeapSize - 1 && heap[r] > heap[largest])
        {
            largest = r;
        }

        if (largest != idx)
        {
            (heap[idx], heap[largest]) = (heap[largest], heap[idx]);
            MaxHeapify(heap, largest);
        }
    }

    private Heap BuildMaxHeap(int[] sequence)
    {
        var heap = new Heap(sequence);
        heap.HeapSize = sequence.Length;

        for (int i = heap.HeapSize / 2; i > -1; i--)
        {
            MaxHeapify(heap, i);
        }

        return heap;
    }

    // O(n * Lg(n))
    private void HeapSort(int[] sequence)
    {
        var heap = BuildMaxHeap(sequence);

        for (int i = sequence.Length - 1; i > 0; i--)
        {
            (sequence[0], sequence[i]) = (sequence[i], sequence[0]);
            heap.HeapSize = heap.HeapSize - 1;
            MaxHeapify(heap, 0);
        }
    }

    public int[] HeapSort(IEnumerable<int> sequence)
    {
        var sequenceCopy = sequence.ToArray();

        HeapSort(sequenceCopy);

        return sequenceCopy;
    }
}
