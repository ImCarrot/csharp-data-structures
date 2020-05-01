using System;
using System.Collections;
using System.Collections.Generic;

namespace csharp_data_structures.Queues
{
    public class QueueUsingArrays<T> : IEnumerable<T>
    {

        T[] dataStore;

        int headPointer = 0;

        int tailPointer = -1;

        int size;

        public QueueUsingArrays()
        {
            dataStore = new T[0];
        }

        public void Enqueue(T item)
        {
            // meaning we need more space in the array
            if (size == dataStore.Length)
            {
                // we start with a initial size of 4 then keep doubling the space
                int newLength = size == 0 ? 4 : size * 2;

                T[] newDataStore = new T[newLength];


                if (size > 0)
                {
                    int targetIndex = 0;

                    // meaning a few items were dequeued then then new items were enqueued
                    if (tailPointer < headPointer)
                    {
                        // from Head of Queue to End of Array
                        for (int index = headPointer; index < dataStore.Length; index++)
                        {
                            newDataStore[targetIndex] = dataStore[index];
                            targetIndex++;
                        }

                        // from 0th index of array to Tail
                        for (int index = 0; index <= tailPointer; index++)
                        {
                            newDataStore[targetIndex] = dataStore[index];
                            targetIndex++;
                        }
                    }
                    else
                    {
                        // from Head to Tail
                        for (int index = headPointer; index <= tailPointer; index++)
                        {
                            newDataStore[targetIndex] = dataStore[index];
                            targetIndex++;
                        }
                    }

                    // reset the head to 0
                    headPointer = 0;

                    // set the tail to the iteration count (-1 to handle the extra increment that happens on the last iteration)
                    tailPointer = targetIndex - 1;
                }
                else
                {
                    headPointer = 0;
                    tailPointer = -1;
                }

                // copy the new data store to the main so that the Queue can use the new datastore
                dataStore = newDataStore;
            }

            // wrap the tail pointer to the 0th index since the queue has empty slots from dequeue ops (we know this since the queue size is less than the array size)
            if (tailPointer == dataStore.Length - 1)
                tailPointer = 0;
            else
                tailPointer++;

            dataStore[tailPointer] = item;
            size++;
        }
            


        public T Dequeue()
        {
            if (size == 0)
                return default;

            T value = dataStore[headPointer];

            // wrap it around since it is currently at the last index of the array
            if (headPointer == dataStore.Length - 1)
                headPointer = 0;
            else
                headPointer++;

            size--;
            return value;
        }


        public T Peek()
        {
            if (size == 0)
                return default;

            return dataStore[headPointer];
        }

        public void Clear()
        {
            dataStore = null;
            size = 0;
            headPointer = 0;
            tailPointer = -1;
        }
            


        public int Count() =>
            size;


        #region IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            if (size == 0)
                yield return default;

            if (tailPointer < headPointer)
            {
                // from Head of Queue to End of Array
                for (int index = headPointer; index < dataStore.Length; index++)
                    yield return dataStore[index];

                // from 0th index of array to Tail
                for (int index = 0; index <= tailPointer; index++)
                    yield return dataStore[index];
            }
            else
            {
                // from Head to Tail
                for (int index = headPointer; index <= tailPointer; index++)
                    yield return dataStore[index];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion IEnumerable
    }
}
