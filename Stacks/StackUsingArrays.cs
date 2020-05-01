using System.Collections;
using System.Collections.Generic;

namespace csharp_data_structures.Stacks
{
    public class StackUsingArrays<T> : IEnumerable<T>
    {

        T[] dataStore;

        // not the length of the array but the number of elements in the stack
        int size;

        public StackUsingArrays()
        {
            // to avoid null checks and make the code readable
            dataStore = new T[0];
        }

        public void Push(T item)
        {
            // meaning we need more space in the array
            if (size == dataStore.Length)
            {
                // we start with a initial size of 4 then keep doubling the space
                int newLength = size == 0 ? 4 : size * 2;

                T[] newDataStore = new T[newLength];

                dataStore.CopyTo(newDataStore, 0);
                dataStore = newDataStore;
            }

            // since arrays are 0 indexed, we can store new value to the value of size index (lastIndex = size - 1)
            dataStore[size] = item;
            size++;
        }

        public T Pop()
        {
            if (size == 0)
                return default;

            var toReturn = dataStore[size - 1];

            // to allow GC to collect it
            dataStore[size - 1] = default;

            size--;
            // just return the last element of the array
            return toReturn;
        }

        public T Peek()
        {
            if (size == 0)
                return default;

            return dataStore[size - 1];
        }

        public int Count()
        {
            return size;
        }

        public void Clear()
        {
            // clear everything up by setting the array space to 0
            dataStore = new T[0];
            size = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            // we enumerate backwards since it's a pop (LIFO) fashion
            for (int i = size - 1 ; i >= 0; i++)
            {
                yield return dataStore[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
