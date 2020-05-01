using System;
using System.Collections;
using System.Collections.Generic;

namespace csharp_data_structures.Stacks
{
    public class StackUsingLL<T> : IEnumerable<T>
    {

        private LinkedList<T> data;

        public int Count => data.Count;

        public bool IsReadOnly => false;

        public StackUsingLL()
        {
            data = new LinkedList<T>();
        }

        public void Push(T item) =>
            data.AddFirst(item);

        public T Pop()
        {

            if (data.Count == 0)
                throw new InvalidOperationException("The stack seems to be empty.");

            var toReturn = data.First;

            data.RemoveFirst();
            return toReturn.Value;
        } 

        public T Peak()
        {
            if (data.Count == 0)
                throw new InvalidOperationException("The stack seems to be empty.");

            return data.First.Value;
        }
        


        public IEnumerator<T> GetEnumerator() =>
            data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            data.GetEnumerator();

        public void Clear()
        {
            data.Clear();
        }
    }
}
