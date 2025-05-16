using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add one item, dequeue it
    // Expected Result: "A" is returned
    // Defect(s) Found: None. This basic enqueue and dequeue operation passed with the fixed code.
    public void TestPriorityQueue_OneItem()
    {
        ...
    }

    [TestMethod]
    // Scenario: Add two items, different priorities
    // Expected Result: Item with highest priority ("B") is dequeued first
    // Defect(s) Found: Originally, if both had equal priority, wrong item could be chosen.
    // Fixed by ensuring item with highest priority is dequeued.
    public void TestPriorityQueue_TwoItemsDifferentPriorities()
    {
        ...
    }

    [TestMethod]
    // Scenario: Add two items, same priorities
    // Expected Result: The one added first ("A") is dequeued first
    // Defect(s) Found: Original version could return either item if priorities matched.
    // Fixed by preserving enqueue order among equal priority items.
    public void TestPriorityQueue_TwoItemsSamePriorities()
    {
        ...
    }

    [TestMethod]
    // Scenario: Add several items with varying priorities
    // Expected Result: Items dequeued in correct priority order: "C", "B", "A"
    // Defect(s) Found: None after fix. Dequeue now properly finds first item with highest priority.
    public void TestPriorityQueue_ThreeItems()
    {
        ...
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Throws InvalidOperationException with appropriate message
    // Defect(s) Found: None. Error handling works correctly.
    public void TestPriorityQueue_EmptyQueue()
    {
        ...
    }

    [TestMethod]
    // Scenario: Complex scenario with multiple items of same and different priorities
    // Expected Result: Items are dequeued based on highest priority, preserving insertion order when tied.
    // Defect(s) Found: Original logic didn't always preserve order when multiple items had the same highest priority.
    // Fixed by ensuring the first among tied highest priorities is removed.
    public void TestPriorityQueue_MultipleSameHighPriorities()
    {
        ...
    }
}
