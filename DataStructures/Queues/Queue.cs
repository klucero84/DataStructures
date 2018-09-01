using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    /// <summary>
    /// A _queue implementation.
    /// </summary>
    public class Queue<T> : IEnumerable<T>
    {
        private readonly IQueue<T> _queue;

        /// <summary>
        /// The number of items in the _queue.
        /// </summary>
        public int Count => _queue.Count;

        /// <summary>
        /// Initializes a new queue. Time complexity: O(1) if initial is empty otherwise O(n).
        /// </summary>
        /// <param name="items">Starting items</param>
        /// <param name="type">Underlying implementation</param>
        public Queue(IEnumerable<T> items = null,QueueType type = QueueType.Array)
        {
            if (type == QueueType.Array)
            {
                _queue = new ArrayQueue<T>();
            }
            else
            {
                _queue = new LinkedListQueue<T>();
            }

            if (items == null)
            {
                return;
            }

            foreach(T item in items)
            {
                _queue.Enqueue(item);
            }
        }

        /// <summary>
        /// Time complexity:O(1).
        /// </summary>
        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
        }

        /// <summary>
        /// Time complexity:O(1).
        /// </summary>
        public T De_queue()
        {
            return _queue.Dequeue();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _queue.GetEnumerator();
        }
    }

    internal interface IQueue<T> : IEnumerable<T>
    {
        int Count { get; }
        void Enqueue(T item);
        T Dequeue();
    }

    /// <summary>
    /// The Queue implementation types.
    /// </summary>
    public enum QueueType
    {
        Array = 0,
        LinkedList = 1
    }

}
