﻿namespace csharp_data_structures.LinkedList
{
    public class LLNode<T>
    {
        public LLNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public LLNode<T> Next { get; set; }

    }
}