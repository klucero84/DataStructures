using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    /// <summary>
    /// A self expanding array implementation.
    /// </summary>
    /// <typeparam name="T">The datatype of this ArrayList.</typeparam>
    public class ArrayList<T> : IEnumerable<T>
    {
        private readonly int _initialArraySize;
        private int _arraySize;
        private T[] _array;

        public int Length { get; private set; }

        /// <summary>
        /// Initialized a new Array. Time complexity: O(1) if initial is empty otherwise O(n).
        /// </summary>
        /// <param name="initalArraySize">The initial array size.</param>
        /// <param name="initial">Starting items</param>
        public ArrayList(int initalArraySize = 2, IEnumerable<T> items = null)
        {
            if (initalArraySize < 2)
            {
                throw new Exception("Initial array size must be greater than 1");
            }

            _initialArraySize = initalArraySize;
            _arraySize = initalArraySize;
            _array = new T[_arraySize];

            if (items == null)
            {
                return;
            }

            foreach(var item in items)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Time complexity: O(1) if initial is empty otherwise O(n).
        /// </summary>
        /// <param name="initial">Initial values if any.</param>
        public ArrayList(IEnumerable<T> initial) 
            : this (2, initial){ }

        /// <summary>
        /// Indexed access to array.
        /// Time complexity: O(1).
        /// </summary>
        /// <param name="index">The index to write or read.</param>
        public T this[int index]
        {
            get => ItemAt(index);
            set => SetItem(index, value);
        }

        private T ItemAt(int i)
        {
            if (i >= Length)
                throw new System.Exception("Index exeeds array size");

            return _array[i];
        }

        /// <summary>
        /// Add a new item to this array list.
        /// Time complexity: O(1) amortized.
        /// </summary>
        public void Add(T item)
        {
            Grow();

            _array[Length] = item;
            Length++;
        }

        /// <summary>
        /// Insert given item at specified index.
        /// Time complexity: O(1) amortized.
        /// </summary>
        /// <param name="index">The index to insert at.<param>
        /// <param name="item">The item to insert.</param>
        public void InsertAt(int index, T item)
        {
            Grow();

            Shift(index);

            _array[index] = item;
            Length++;
        }

        /// <summary>
        /// Shift the position of elements right by one starting at this index.
        /// Creates a blank field at index.
        /// </summary>
        private void Shift(int index)
        {
            Array.Copy(_array, index, _array, index + 1, Length - index);
        }

        /// <summary>
        /// Clears the array.
        /// Time complexity: O(1).
        /// </summary>
        public void Clear()
        {
            _arraySize = _initialArraySize;
            _array = new T[_arraySize];
            Length = 0;
        }

        private void SetItem(int i, T item)
        {
            if (i >= Length)
                throw new System.Exception("Index exeeds array size");

            _array[i] = item;
        }

        /// <summary>
        /// Remove the item at given index.
        /// Time complexity: O(1) amortized.
        /// </summary>
        /// <param name="i">The index to remove at.</param>
        public void RemoveAt(int i)
        {
            if (i >= Length)
                throw new System.Exception("Index exeeds array size");

            //shift elements
            for (var j = i; j < _arraySize - 1; j++)
            {
                _array[j] = _array[j + 1];
            }

            Length--;

            Shrink();
        }

        private void Grow()
        {
            if (Length != _arraySize)
            {
                return;
            }

            //increase array size exponentially on demand
            _arraySize *= 2;

            var biggerArray = new T[_arraySize];
            Array.Copy(_array, 0, biggerArray, 0, Length);
            _array = biggerArray;
        }

        private void Shrink()
        {
            if (Length != _arraySize / 2 || _arraySize == _initialArraySize)
            {
                return;
            }

            //reduce array by half 
            _arraySize /= 2;

            var smallerArray = new T[_arraySize];
            Array.Copy(_array, 0, smallerArray, 0, Length);
            _array = smallerArray;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _array.Take(Length).GetEnumerator();
        }
    }


}
