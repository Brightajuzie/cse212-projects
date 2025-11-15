using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.
//A standard Queue must adhere to the FIFO principle: the first item added is the first item removed.
//The error lies in how the Enqueue method interacts with the Dequeue method, violating the FIFO principle required for a queue.
//To fix the logical error and make it a FIFO Queue while keeping the List<Person> structure, Enqueue must add to the end, and Dequeue must remove from the front
// Use _queue.Add(person);used to add to the end of the list ($O(1)$ time complexity).
//_queue.RemoveAt(0);used to remove the oldest element ($O(n)$ time complexity, but correct for functionality).
//sThe Dequeue method should also be enhanced to throw a proper exception if the queue is empty.
[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
}