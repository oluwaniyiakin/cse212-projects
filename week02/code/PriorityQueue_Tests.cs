using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add one item, dequeue it
    // Expected Result: "A" is returned
    // Defect(s) Found: None. This basic enqueue and dequeue operation passed with the fixed code.
    public void TestPriorityQueue_OneItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);

        var result = pq.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Add two items, different priorities
    // Expected Result: Item with highest priority ("B") is dequeued first
    // Defect(s) Found: Originally, if both had equal priority, wrong item could be chosen.
    // Fixed by ensuring item with highest priority is dequeued.
    public void TestPriorityQueue_TwoItemsDifferentPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Add two items, same priorities
    // Expected Result: The one added first ("A") is dequeued first
    // Defect(s) Found: Original version could return either item if priorities matched.
    // Fixed by preserving enqueue order among equal priority items.
    public void TestPriorityQueue_TwoItemsSamePriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 3);
        pq.Enqueue("B", 3);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Add several items with varying priorities
    // Expected Result: Items dequeued in correct priority order: "C", "B", "A"
    // Defect(s) Found: None after fix. Dequeue now properly finds first item with highest priority.
    public void TestPriorityQueue_ThreeItems()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 5);

        Assert.AreEqual("C", pq.Dequeue());  // Highest priority
        Assert.AreEqual("B", pq.Dequeue());  // Next highest
        Assert.AreEqual("A", pq.Dequeue());  // Lowest priority
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Throws InvalidOperationException with appropriate message
    // Defect(s) Found: None. Error handling works correctly.
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Complex scenario with multiple items of same and different priorities
    // Expected Result: Items are dequeued based on highest priority, preserving insertion order when tied.
    // Defect(s) Found: Original logic didn't always preserve order when multiple items had the same highest priority.
    // Fixed by ensuring the first among tied highest priorities is removed.
    public void TestPriorityQueue_MultipleSameHighPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 5); // same priority as A
        pq.Enqueue("D", 2);

        Assert.AreEqual("A", pq.Dequeue());  // A first among tied highest
        Assert.AreEqual("C", pq.Dequeue());  // then C
        Assert.AreEqual("B", pq.Dequeue());  // next highest
        Assert.AreEqual("D", pq.Dequeue());  // lowest
    }
}
