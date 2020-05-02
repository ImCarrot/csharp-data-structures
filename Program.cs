using csharp_data_structures.BinaryTrees;
using csharp_data_structures.LinkedLists;
using csharp_data_structures.Stacks;
using System.Collections.Generic;

namespace csharp_data_structures
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("LinkList Sample");

            SinglyLinkedList<int> primeNumbers = new SinglyLinkedList<int>();

            // first we'll add the middle element. Then try the AddToFront with 3 and then try the AddToBack with 7
            // generating the final sequence as 3, 5, 7
            
            primeNumbers.AddToFront(5);
            primeNumbers.AddToFront(3);
            primeNumbers.AddToBack(7);
            primeNumbers.AddToBack(9);
            primeNumbers.AddToBack(8);
            primeNumbers.AddToBack(7);
            primeNumbers.Remove(8);
            primeNumbers.RemoveLast();

            PrintHelpers.PrintFromNode(primeNumbers.Head);


            System.Console.WriteLine("Stack Sample: ");

            PostfixCalculator postfixCalculator = new PostfixCalculator();
            int result = postfixCalculator.calculate("5 6 7 * + 1 -");
            System.Console.WriteLine($"The postfix expression result is: {result}");


            System.Console.WriteLine("Binary Search Tree Sample:");

            BinaryTree<int> binaryTree = new BinaryTree<int>();

            binaryTree.Add(3);
            binaryTree.Add(7);
            binaryTree.Add(5);
            binaryTree.Add(4);
            binaryTree.Add(6);
            binaryTree.Add(8);
            binaryTree.Add(11);
            binaryTree.Add(1);

            System.Console.WriteLine($"Contains 5: {binaryTree.Contains(5)}");
            System.Console.WriteLine($"Contains 6: {binaryTree.Contains(6)}");
            System.Console.WriteLine($"Contains 1: {binaryTree.Contains(1)}");

            System.Console.WriteLine($"Remove 9 op result: {binaryTree.Remove(9)}");
            System.Console.WriteLine($"Remove 7 op result: {binaryTree.Remove(7)}");

            System.Console.WriteLine("Traversal Outputs:");

            Traversals<int> traversals = new Traversals<int>();

            IReadOnlyCollection<int> preOrder = traversals.PreorderTraversal(binaryTree);
            IReadOnlyCollection<int> inOrder = traversals.InorderTraversal(binaryTree);
            IReadOnlyCollection<int> postOrder = traversals.PostorderTraversal(binaryTree);

            System.Console.WriteLine($"Postorder: {string.Join(", ", preOrder)}");
            System.Console.WriteLine($"Inorder: {string.Join(", ", inOrder)}");
            System.Console.WriteLine($"Postorder: {string.Join(", ", postOrder)}");

        }
    }
}
