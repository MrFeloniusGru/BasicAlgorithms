namespace QueueWithPriorityLib;
public class PriorityQueue<T>
{
    struct HeapItem 
    {
        public int Key { get; set; }
        public T Value { get; init; }
    }

    struct Heap
    {
        public Heap()
        {
            _sequence = new List<HeapItem>();
        }

        private List<HeapItem> _sequence;
        public int HeapSize => _sequence.Count;

        public HeapItem this[int index]
        { 
            get => _sequence[index];
            set => _sequence[index] = value;    
        }

        public void Add(HeapItem item)
        {
            _sequence.Add(item);
        }

        public void RemoveAt(int idx)
        {
            _sequence.RemoveAt(idx);
        }
    }

    private readonly Comparer<int> _comparer;
    private Heap _heap;

    public PriorityQueue()
    {
        _comparer = Comparer<int>.Default;
        _heap = new Heap();
    }

    private static int Parent(int idx)
    {
        return idx / 2;
    }

    private static int Left(int idx)
    {
        return idx * 2 + 1;
    }

    private static int Right(int idx)
    {
        return (idx * 2) + 2;
    }

    private void MaxHeapify(Heap heap, int idx)
    {
        var l = Left(idx);
        var r = Right(idx);

        var largest = l <= heap.HeapSize - 1 && _comparer.Compare(heap[l].Key, heap[idx].Key) > 0 ? l : idx;

        if (r <= heap.HeapSize - 1 && _comparer.Compare(heap[r].Key, heap[largest].Key) > 0)
        {
            largest = r;
        }

        if (largest != idx)
        {
            (heap[idx], heap[largest]) = (heap[largest], heap[idx]);
            MaxHeapify(heap, largest);
        }
    }

    private void HeapIncraseKey(int i, int key)
    {
        if(_comparer.Compare(key, _heap[i].Key) < 0)
        {
            throw new Exception("Key is less than current key");
        }

        var iItem = _heap[i];
        iItem.Key = key;
        _heap[i] = iItem;

        while(i > 0 && _comparer.Compare(_heap[Parent(i)].Key, _heap[i].Key) < 0)
        {
            (_heap[i], _heap[Parent(i)]) = (_heap[Parent(i)], _heap[i]);
            i = Parent(i);
        }
    }

    // O(lg2(n))
    public void Enqueue(int priority, T value)
    {
        _heap.Add(new HeapItem{Key = int.MinValue, Value = value});
        HeapIncraseKey(_heap.HeapSize - 1, priority);
    }

    // O(lg2(n))
    public T? Dequeue()
    {
        if(_heap.HeapSize < 1)
        {
            return default;
        }

        var max = _heap[0];
        _heap[0] = _heap[_heap.HeapSize - 1];
        _heap.RemoveAt(_heap.HeapSize - 1);
        MaxHeapify(_heap, 0);

        return max.Value;
    }

    // O(1)
    public T? Peek()
    {
        return _heap.HeapSize > 0 ? _heap[0].Value : default;
    }
}
