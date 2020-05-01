using System.Collections;
using System.Collections.Generic;

namespace csharp_data_structures.LinkedLists
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        public DLLNode<T> Head { get; set; }

        public DLLNode<T> Tail { get; set; }

        public void AddToFront(T item)
        {
            var newNode = new DLLNode<T>(item);

            if (Count == 0)
            {
                Head = newNode;
                Tail = newNode;
                Count++;
                return;
            }

            var currentHead = Head;
            Head = newNode;
            Head.Next = currentHead;
            currentHead.Previous = Head;
            Count++;
        }

        public void AddToBack(T item)
        {
            if (Count == 0)
            {
                // since it's the fist node.
                this.AddToFront(item);
                return;
            }

            var newNode = new DLLNode<T>(item) { Previous = Tail };

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

            // if there was only one element (meaning Head.Next == null) after removing it, clear the Tail pointer.
            if (Count == 0)
                Tail = null;
        }

        public void RemoveLast()
        {
            if (Count == 0)
                return;

            Tail = Tail.Previous;
            Count--;

            // if there was only one element (meaning Tail.Previous == null) after removing it, clear the Head pointer.
            if (Count == 0)
                Head = null;
        }


        #region IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            DLLNode<T> current = Head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            DLLNode<T> current = Head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        #endregion IEnumerable


        #region ICollection

        public int Count { get; set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            this.AddToFront(item);
        }

        public void Clear()
        {
            this.Head = null;
            this.Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (Count == 0)
                return false;

            DLLNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            DLLNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            if (Count == 0)
                return false;

            DLLNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    // link the next pointer of the previous node to the next node of the current node.
                    current.Previous.Next = current.Next;

                    // link the previous pointer of the next node to the previous of the current node.
                    current.Next.Previous = current.Previous;
                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        #endregion ICollection

    }
}
