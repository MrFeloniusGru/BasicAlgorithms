namespace Tests;
using Xunit;
using QueueWithPriorityLib;

public class QueueWithPriorityTests
{
    [Theory]
    [InlineData(new int[] { 3, 2, 1 })]
    [InlineData(new int[] { 2, 3, 1 })]
    [InlineData(new int[] { 1, 2, 3 })]
    [InlineData(new int[] { 2, 3, 3, 1 })]
    [InlineData(new int[] { 1, 4, 3, 2 })]
    [InlineData(new int[] { 4 })]
    [InlineData(new int[] { })]
    public void DequeueCorrect(int[] data)
    {
        var queue = new PriorityQueue<int>();

        foreach(int i in data)
        {
            queue.Enqueue(i, i);
        }

        var res = new List<int>(data.Length);
        while(true)
        {
            var nextItem = queue.Dequeue();
            if(nextItem == default)
            {
                break;
            }
            res.Add(nextItem);
        }
        Assert.Equal(data.OrderByDescending(x => x), res);
    }
}
