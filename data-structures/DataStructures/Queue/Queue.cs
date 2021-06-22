using System;
using System.Collections.Generic;

namespace DataStructures.Queue
{
    // A First In First Out collection
    public class Queue<T>
    {
        private readonly LinkedList<T> list = new LinkedList<T>();

        public int Count
        {
            get => list.Count;
        }

        // Adds an item to the back of the queue
        public void Enqueue(T item)
        {
            list.AddLast(item);
        }

        // Removes and returns the front item from the queue
        public T Dequeue()
        {
            if (list.Count == 0) throw new InvalidOperationException("The queue is empty.");

            var value = list.First.Value;

            list.RemoveFirst();

            return value;
        }

        // Returns the front item from the queue without removing it from the queue
        public T Peek()
        {
            if (list.Count == 0) throw new InvalidOperationException("The queue is empty.");

            return list.First.Value;
        }

        public void Clear()
        {
            list.Clear();
        }
    }
}