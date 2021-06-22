using System;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    // A Last In First Out (LIFO) collection implemented as a linked list.
    public class Stack<T>
    {
        private readonly LinkedList<T> _list = new LinkedList<T>();

        public int Count
        {
            get => _list.Count;
        }

        // Adds the specified item to the stack
        public void Push(T item)
        {
            _list.AddFirst(item);
        }

        // Removes and returns the top item from the stack
        public T Pop()
        {
            if (_list.Count == 0) throw new InvalidOperationException("The stack is empty");

            var value = _list.First.Value;
            _list.RemoveFirst();

            return value;
        }

        // Returns the top item from the stack without removing it from the stack
        public T Peek()
        {
            if (_list.Count == 0) throw new InvalidOperationException("The stack is empty");

            return _list.First.Value;
        }

        public void Clear()
        {
            _list.Clear();
        }
    }
}