using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    /// <summary>
    /// A stack implementation.
    /// </summary>
    public class Stack<T> : IEnumerable<T>
    {
        private readonly IStack<T> _stack;
        private readonly StackType _type;

        /// <summary>
        /// The total number of items in this stack.
        /// </summary>
        public int Count => _stack.Count;

        /// <summary>
        /// Initializes a new stack. Time complexity: O(1) if initial is empty otherwise O(n).
        /// </summary>
        /// <param name="items">Starting items</param>
        /// <param name="type">Underlying implementation</param>
        public Stack(IEnumerable<T> items = null, StackType type = StackType.Array)
        {
            if (type == StackType.Array)
            {
                _stack = new ArrayStack<T>();
            }
            else
            {
               _stack = new LinkedListStack<T>();
            }

            if (items == null)
            {
                return;
            }

            foreach(T item in items)
            {
                _stack.Push(item);
            }
        }
        

        /// <summary>
        /// Time complexity:O(1).
        /// </summary>
        /// <returns>The item popped.</returns>
        public T Pop()
        {
            return _stack.Pop();
        }

        /// <summary>
        /// Time complexity:O(1).
        /// </summary>
        /// <param name="item">The item to push.</param>
        public void Push(T item)
        {
            _stack.Push(item);
        }

        /// <summary>
        /// Peek from stack.
        /// Time complexity:O(1).
        /// </summary>
        /// <returns>The item peeked.</returns>
        public T Peek()
        {
            return _stack.Peek();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _stack.GetEnumerator();
        }
    }

    internal interface IStack<T> : IEnumerable<T>
    {
        int Count { get; }
        T Pop();
        void Push(T item);

        T Peek();
    }

    /// <summary>
    /// The stack implementation types.
    /// </summary>
    public enum StackType
    {
        Array = 0,
        LinkedList = 1
    }

}
