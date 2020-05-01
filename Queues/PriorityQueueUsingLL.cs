using System;
using System.Collections;
using System.Collections.Generic;

namespace csharp_data_structures.Queues
{
    public class PriorityQueueUsingLL<T> : IEnumerable<T> where T : IComparable<T>
    {

        private LinkedList<T> dataStore;

        public PriorityQueueUsingLL()
        {
            dataStore = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            if (dataStore.Count == 0)
                dataStore.AddLast(item);

            else
            {
                var current = dataStore.First;

                while (current != null && current.Value.CompareTo(item) > 0)
                    current = current.Next;

                // meaning all the elements were of higher priority than the element to add.
                if (current == null)
                    dataStore.AddLast(item);

                // add to the element
                else
                    dataStore.AddBefore(current, item);
            }
        }

        public T Dequeue()
        {
            if (dataStore.Count == 0)
                return default;

            var head = dataStore.First.Value;

            dataStore.RemoveFirst();

            return head;
        }


        public T Peek()
        {
            if (dataStore.Count == 0)
                return default;

            return dataStore.First.Value;
        }

        public void Clear() =>
            dataStore.Clear();


        public int Count() =>
            dataStore.Count;


        #region IEnumerable

        public IEnumerator<T> GetEnumerator() =>
            dataStore.GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator() =>
            dataStore.GetEnumerator();

        #endregion IEnumerable

    }
}
