using System;
using System.Diagnostics.CodeAnalysis;

namespace csharp_data_structures.BinaryTrees
{
    public class BinaryTreeNode<T> : IComparable<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> LeftNode { get; set; }

        public T Value { get; set; }

        public BinaryTreeNode<T> RightNode { get; set; }

        public BinaryTreeNode(T item)
        {
            Value = item;
        }

        public int CompareTo([AllowNull] T other)
        {
            return Value.CompareTo(other);
        }
    }
}
