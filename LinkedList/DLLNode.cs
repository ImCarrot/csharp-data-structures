namespace csharp_data_structures.LinkedList
{
    public class DLLNode<T>
    {
        public DLLNode<T> Previous { get; set; }

        public T Value { get; }

        public DLLNode<T> Next { get; set; }


        public DLLNode(T value)
        {
            Value = value;
        }
    }
}
