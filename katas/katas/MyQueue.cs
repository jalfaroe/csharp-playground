using System;
using System.Collections.Generic;

namespace katas
{
    public class MyQueue
    {
        private readonly LinkedList<int> _linkedList = new LinkedList<int>();

        /**
         * Push element x to the back of queue.
         */
        public void Push(int x)
        {
            _linkedList.AddLast(x);
        }

        /**
         * Removes the element from in front of queue and returns that element.
         */
        public int Pop()
        {
            if (_linkedList.Count == 0) throw new InvalidOperationException("The queue is empty.");

            var element = _linkedList.First.Value;
            _linkedList.RemoveFirst();

            return element;
        }

        /**
         * Get the front element.
         */
        public int Peek()
        {
            if (_linkedList.Count == 0) throw new ArgumentException("The Queue is Empty");

            return _linkedList.First.Value;
        }

        /**
         * Returns whether the queue is empty.
         */
        public bool Empty() => _linkedList.Count == 0;
    }

    /**
     * Your MyQueue object will be instantiated and called as such:
     * MyQueue obj = new MyQueue();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Peek();
     * bool param_4 = obj.Empty();
     */
}