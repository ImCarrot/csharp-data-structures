using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace csharp_data_structures.BinaryTrees
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {

        public BinaryTreeNode<T> Root { get; private set; }

        public int Count { get; private set; }


        public void Add(T item)
        {
            if (Count == 0)
            {
                Root = new BinaryTreeNode<T>(item);
                Count++;
                return;
            }

            var current = Root;

            // we can use recursion too for finding the node under which the new item will be setup.
            // but we've used a while loop since it's less complicated and it's easy to figure out the 
            // runtime iterations of a while loop as compared to a recursive loop.
            while(current != null)
            {
                int comparisonResult = item.CompareTo(current.Value);

                if (comparisonResult == 0)
                    throw new InvalidOperationException("A binary tree can only contain unique elements");

                if (comparisonResult < 0)
                {
                    if (current.LeftNode == null)
                    {
                        current.LeftNode = new BinaryTreeNode<T>(item);
                        Count++;
                        break;
                    }

                    current = current.LeftNode;
                }
                else
                {

                    if (current.RightNode == null)
                    {
                        current.RightNode = new BinaryTreeNode<T>(item);
                        Count++;
                        break;
                    }

                    current = current.RightNode;
                }
            }
        }


        public bool Contains(T item)
        {
            if (Count == 0)
                return false;

            var current = Root;

            while(current != null)
            {
                int comparisonResult = item.CompareTo(current.Value);

                if (comparisonResult == 0)
                    return true;

                if (comparisonResult < 0)
                    current = current.LeftNode;

                else if (comparisonResult > 0)
                    current = current.RightNode;
            }

            return false;
        }

        public bool Remove(T item)
        {
            if (Count == 0)
                return false;

            BinaryTreeNode<T> parent = null;
            var current = Root;
            var wasLeftNode = false;
            var wasElementFound = false;
            while (current != null)
            {
                int comparisonResult = item.CompareTo(current.Value);

                if (comparisonResult == 0)
                {
                    wasElementFound = true;
                    break;
                }
                    

                parent = current;

                if (comparisonResult < 0)
                {
                    current = current.LeftNode;
                    wasLeftNode = true;
                }
                else if (comparisonResult > 0)
                { 
                    current = current.RightNode;
                    wasLeftNode = false;
                }
            }

            if (!wasElementFound)
                return false;

            // now that we have the current node and the parent of the current node,
            // we need to traverse to either the left side to the right most leaf node
            // or the right side to the left most leaf node to find the successor.

            // here we'll pick the left side, you can pick the right if wanted.
            BinaryTreeNode<T> successorParent = null;
            var successor = current.LeftNode;
            
            while(successor != null)
            {
                if (successor.RightNode == null)
                    break;
                successorParent = successor;
                successor = successor.RightNode;
            }

            // now we have the right most leaf node on the left side (meaning the heighest value that's smaller to the node to remove)

            // set the parent's right most node on the left side to null
            successorParent.RightNode = null;

            if (wasLeftNode)
                parent.LeftNode = successor;
            else
                parent.RightNode = successor;

            // and join the downward tree to the successor
            successor.RightNode = current.RightNode;

            // meaning the left node of the node to remove wasn't the leaf node.
            if (!current.LeftNode.Value.Equals(successor.Value))
                successor.LeftNode = current.LeftNode;
            
            Count--;
            return true;
        }

        
        #region IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return InorderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return InorderTraversal();
        }

        public IEnumerator<T> InorderTraversal()
        {
            if (Count == 0)
                yield return default;

            Stack<BinaryTreeNode<T>> processStack = new Stack<BinaryTreeNode<T>>();

            BinaryTreeNode<T> current = Root;
            while (current != null || processStack.Count > 0)
            {
                // traverse to the left most node of tree
                while (current != null)
                {
                    processStack.Push(current);
                    current = current.LeftNode;
                }

                current = processStack.Pop();

               yield return current.Value;

                // Now go to the right side of the tree
                current = current.RightNode;
            }
        }

        #endregion IEnumerable
    }
}
