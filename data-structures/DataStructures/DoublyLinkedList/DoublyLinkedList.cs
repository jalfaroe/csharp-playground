using System.Collections;
using System.Collections.Generic;

namespace DataStructures.DoublyLinkedList
{
    public class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode(T value) => Value = value;

        public T Value { get; set; }

        public DoublyLinkedListNode<T> Next { get; set; }

        public DoublyLinkedListNode<T> Previous { get; set; }
    }

    public class DoublyLinkedList<T> :
        ICollection<T>
    {
        /// <summary>
        ///     The first node in the list or null if empty
        /// </summary>
        public DoublyLinkedListNode<T> Head { get; private set; }

        /// <summary>
        ///     The last node in the list or null if empty
        /// </summary>
        public DoublyLinkedListNode<T> Tail { get; private set; }

        public bool GetHead(out T value)
        {
            if (Count > 0)
            {
                value = Head.Value;
                return true;
            }

            value = default;
            return false;
        }

        public bool GetTail(out T value)
        {
            if (Count > 0)
            {
                value = Tail.Value;
                return true;
            }

            value = default;
            return false;
        }

        #region Add

        /// <summary>
        ///     Adds the specified value to the start of the linked list
        /// </summary>
        public void AddHead(T value)
        {
            AddHead(new DoublyLinkedListNode<T>(value));
        }

        /// <summary>
        ///     Adds the specified node to the start of the link list
        /// </summary>
        public void AddHead(DoublyLinkedListNode<T> node)
        {
            // Save off the head node so we don't lose it
            var temp = Head;

            // Point head to the new node
            Head = node;

            // Insert the rest of the list behind the head
            Head.Next = temp;

            if (Count == 0)
                // if the list was empty then Head and Tail should
                // both point to the new node.
                Tail = Head;
            else
                // Before: Head -------> 5 <-> 7 -> null
                // After:  Head -> 3 <-> 5 <-> 7 -> null

                // temp.Previous was null, now Head
                temp.Previous = Head;

            Count++;
        }

        /// <summary>
        ///     Add the value to the end of the list
        /// </summary>
        public void AddTail(T value)
        {
            AddTail(new DoublyLinkedListNode<T>(value));
        }

        /// <summary>
        ///     Add the node to the end of the list
        /// </summary>
        public void AddTail(DoublyLinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;

                // Before: Head -> 3 <-> 5 -> null
                // After:  Head -> 3 <-> 5 <-> 7 -> null
                // 7.Previous = 5
                node.Previous = Tail;
            }

            Tail = node;
            Count++;
        }

        #endregion

        #region Remove

        /// <summary>
        ///     Removes the first node from the list.
        /// </summary>
        public void RemoveHead()
        {
            if (Count != 0)
            {
                // Before: Head -> 3 <-> 5
                // After:  Head -------> 5

                // Head -> 3 -> null
                // Head ------> null
                Head = Head.Next;

                Count--;

                if (Count == 0)
                    Tail = null;
                else
                    // 5.Previous was 3, now null
                    Head.Previous = null;
            }
        }

        /// <summary>
        ///     Removes the last node from the list
        /// </summary>
        public void RemoveTail()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    // Before: Head --> 3 --> 5 --> 7
                    //         Tail = 7
                    // After:  Head --> 3 --> 5 --> null
                    //         Tail = 5
                    // Null out 5's Next pointer
                    Tail.Previous.Next = null;
                    Tail = Tail.Previous;
                }

                Count--;
            }
        }

        #endregion

        #region ICollection

        /// <summary>
        ///     The number of items currently in the list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     Adds the specified value to the front of the list
        /// </summary>
        public void Add(T item)
        {
            AddHead(item);
        }

        public DoublyLinkedListNode<T> Find(T item)
        {
            var current = Head;
            while (current != null)
            {
                // Head -> 3 -> 5 -> 7
                // Value: 5
                if (current.Value.Equals(item)) return current;

                current = current.Next;
            }

            return null;
        }

        /// <summary>
        ///     Returns true if the list contains the specified item,
        ///     false otherwise.
        /// </summary>
        public bool Contains(T item) => Find(item) != null;

        /// <summary>
        ///     Copies the node values into the specified array.
        /// </summary>
        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        ///     True if the collection is readonly, false otherwise.
        /// </summary>
        public bool IsReadOnly
        {
            get => false;
        }

        /// <summary>
        ///     Removes the first occurrence of the item from the list (searching
        ///     from Head to Tail).
        /// </summary>
        public bool Remove(T item)
        {
            var found = Find(item);
            if (found == null) return false;

            var previous = found.Previous;
            var next = found.Next;

            if (previous == null)
            {
                // we're removing the head node
                Head = next;
                if (Head != null) Head.Previous = null;
            }
            else
            {
                previous.Next = next;
            }

            if (next == null)
            {
                // we're removing the tail
                Tail = previous;
                if (Tail != null) Tail.Next = null;
            }
            else
            {
                next.Previous = previous;
            }

            Count--;

            return true;
        }

        /// <summary>
        ///     Enumerates over the linked list values from Head to Tail
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerable<T> GetReverseEnumerator()
        {
            var current = Tail;
            while (current != null)
            {
                yield return current.Value;
                current = current.Previous;
            }
        }

        /// <summary>
        ///     Removes all the nodes from the list
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        #endregion
    }
}