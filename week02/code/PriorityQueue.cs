using System.Collections.Generic;
using System;
using System.Linq;

// A private class to hold the data and its associated priority
public class PriorityItem<T>
{
    public T Value { get; }
    public int Priority { get; }

    public PriorityItem(T value, int priority)
    {
        Value = value;
        Priority = priority;
    }
}

/// <summary>
/// A queue where items are removed based on the highest priority.
/// FIFO is used as a tie-breaker for equal highest priorities.
/// </summary>
public class PriorityQueue<T>
{
    // Using a List to maintain insertion order (the FIFO requirement)
    private readonly List<PriorityItem<T>> _items = new();

    /// <summary>
    /// Adds an item (data and priority) to the back of the queue (FIFO ordering).
    /// </summary>
    /// <param name="value">The data value.</param>
    /// <param name="priority">The priority (higher number is higher priority).</param>
    public void Enqueue(T value, int priority)
    {
        // Requirement 1: Add to the back of the queue.
        _items.Add(new PriorityItem<T>(value, priority));
    }

    /// <summary>
    /// Removes the item with the highest priority. If a tie, the one closest
    /// to the front (earliest added) is removed.
    /// </summary>
    /// <returns>The value of the removed item.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the queue is empty.</exception>
    public T Dequeue()
    {
        if (_items.Count == 0)
        {
            // Requirement 4: Throw exception for empty queue.
            throw new InvalidOperationException("The queue is empty.");
        }

        int highestPriorityIndex = -1;
        int maxPriority = int.MinValue;

        // Iterate through the list to find the item to remove.
        for (int i = 0; i < _items.Count; i++)
        {
            var currentItem = _items[i];

            // Requirement 2: Check for higher priority.
            if (currentItem.Priority > maxPriority)
            {
                maxPriority = currentItem.Priority;
                highestPriorityIndex = i;
            }
            // Requirement 3 (Implicit): FIFO Tie-breaker.
            // If currentItem.Priority == maxPriority, we do nothing. 
            // This preserves the 'highestPriorityIndex' that was found earlier (lower 'i'), 
            // ensuring the item closest to the front is chosen.
        }

        // Remove the item and return its value.
        T valueToReturn = _items[highestPriorityIndex].Value;
        _items.RemoveAt(highestPriorityIndex);

        return valueToReturn;
    }

    public int Count => _items.Count;
}