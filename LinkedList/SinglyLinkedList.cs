using System.Collections;
using System.Collections.Generic;

namespace csharp_data_structures.LinkedList
{
    public class SinglyLinkedList<T> : ICollection<T>
    {
        public LLNode<T> Head { get; private set; }

        public LLNode<T> Tail { get; private set; }

        public void AddToFront(T item)
        {
            var newNode = new LLNode<T>(item);

            if (Count == 0)
            {
                Head = newNode;
                Tail = newNode;
                Count++;
                return;
            }

            newNode.Next = Head;
            Head = newNode;
            Count++;
        }

        public void AddToBack(T item)
        {
            var newNode = new LLNode<T>(item);

            if (Count == 0)
            {
                // since it's the fist node.
                this.AddToFront(item);
                return;
            }

            Tail.Next = newNode;
            Tail = newNode;
            Count++;
        }

        public void RemoveFirst()
        {
            if (Count == 0)
                return;

            Head = Head.Next;
            Count--;

            if (Count == 0)
                Tail = null;
        }

        public void RemoveLast()
        {
            if (Count == 0)
                return;

            if (Count == 1)
            {
                Head = null;
                Tail = null;
                Count--;
                return;
            }


            LLNode<T> previous = Head;
            var start = Head;
            while(start.Next != null)
            {
                previous = start;
                start = start.Next;
            }

            previous.Next = null;
            Tail = previous;
            Count--;
        }


        #region IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            LLNode<T> current = Head;

            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            LLNode<T> current = Head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        #endregion IEnumerable


        #region ICollection

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            this.AddToFront(item);
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(T item)
        {
            if (Count == 0)
                return false;

            LLNode<T> current = Head;

            while(current != null)
            {
                if (current.Value.Equals(item))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            LLNode<T> current = Head;
            while(current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            if (Count == 0)
                return false;

            LLNode<T> previous = null;
            LLNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    previous.Next = current.Next;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        #endregion ICollection
    }
}
