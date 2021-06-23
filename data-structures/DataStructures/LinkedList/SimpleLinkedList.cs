namespace DataStructures.LinkedList
{
    public class SimpleLinkedListNode<T>
    {
        public SimpleLinkedListNode(T value) => Value = value;

        public SimpleLinkedListNode<T> Next { get; set; }

        public T Value { get; }
    }

    public class SimpleLinkedList<T>
    {
        private SimpleLinkedListNode<T> _head;
        private SimpleLinkedListNode<T> _tail;

        public T Head
        {
            get => _head.Value;
        }

        public T Tail
        {
            get => _tail.Value;
        }

        public int Count { get; private set; }

        public void AddHead(T value)
        {
            var newNode = new SimpleLinkedListNode<T>(value);

            if (Count == 0)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                var temp = _head;
                newNode.Next = temp;
                _head = newNode;
            }

            Count++;
        }

        public void AddTail(T value)
        {
            var newNode = new SimpleLinkedListNode<T>(value);

            if (Count == 0)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                var temp = _tail;
                newNode.Next = temp;
                _tail = newNode;
            }

            Count++;
        }

        public bool Find(T value)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Value.Equals(value)) return true;

                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }
    }
}