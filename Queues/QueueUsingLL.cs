using System.Collections;
using System.Collections.Generic;

namespace csharp_data_structures.Queues
{
    public class QueueUsingLL<T> : IEnumerable<T>
    {
        private LinkedList<T> dataStore;

        public QueueUsingLL()
        {
            this.dataStore = new LinkedList<T>();
        }

        public void Enqueue(T item) =>
            dataStore.AddLast(item);


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
