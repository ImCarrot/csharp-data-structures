using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace csharp_data_structures.BinaryTrees
{
    public class Traversals<T> where T : IComparable<T>
    {

        public IReadOnlyList<T> PreorderTraversal(BinaryTree<T> bTree)
        {

            if (bTree.Count == 0)
                return null;

            ICollection<T> toReturn = new List<T>();

            Stack<BinaryTreeNode<T>> processStack = new Stack<BinaryTreeNode<T>>();

            processStack.Push(bTree.Root);

            while(processStack.Count > 0)
            {
                var current = processStack.Pop();

                toReturn.Add(current.Value);

                if (current.RightNode != null)
                    processStack.Push(current.RightNode);
                
                if (current.LeftNode != null)
                    processStack.Push(current.LeftNode);
            }
            

            return toReturn.ToImmutableList();
        }

        public IReadOnlyList<T> InorderTraversal(BinaryTree<T> bTree)
        {
            if (bTree.Count == 0)
                return null;

            ICollection<T> toReturn = new List<T>();

            Stack<BinaryTreeNode<T>> processStack = new Stack<BinaryTreeNode<T>>();

            BinaryTreeNode<T> current = bTree.Root;
            while (current != null || processStack.Count > 0)
            {
                // traverse to the left most node of tree
                while (current != null)
                {
                    processStack.Push(current);
                    current = current.LeftNode;
                }

                current = processStack.Pop();

                toReturn.Add(current.Value);

                // Now go to the right side of the tree
                current = current.RightNode;
            }

            return toReturn.ToImmutableList();
        }

        public IReadOnlyList<T> PostorderTraversal(BinaryTree<T> bTree)
        {
            if (bTree.Count == 0)
                return null;

            ICollection<T> toReturn = new List<T>();

            Stack<BinaryTreeNode<T>> s1 = new Stack<BinaryTreeNode<T>>();
            Stack<BinaryTreeNode<T>> s2 = new Stack<BinaryTreeNode<T>>();

            // Push root to first stack 
            s1.Push(bTree.Root);

            // Run while first stack is not empty 
            while (s1.Count > 0)
            {
                // Pop an item from s1 and Push it to s2 
                var current = s1.Pop();

                s2.Push(current);

                // Push left and right children and removed item to s1 
                if (current.LeftNode != null)
                    s1.Push(current.LeftNode);
                
                if (current.RightNode != null)
                    s1.Push(current.RightNode);
            }

            while (s2.Count > 0)
            {
                var temp = s2.Pop();
                toReturn.Add(temp.Value);
            }

            return toReturn.ToImmutableList();
        }
    }
}
