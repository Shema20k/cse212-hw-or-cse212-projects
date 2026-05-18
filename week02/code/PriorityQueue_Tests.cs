using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Highest priority is removed
    // Expected: B (priority 5)
    public void TestPriorityQueue_HighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        var result = pq.Dequeue();

        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: FIFO tie-break for same priority
    // Expected: A first (same priority as B)
    public void TestPriorityQueue_FIFO_TieBreaker()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        var result = pq.Dequeue();

        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Empty queue throws exception
    // Expected: InvalidOperationException
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            pq.Dequeue();
        });
    }
}