using csharp_data_structures.LinkedList;

namespace csharp_data_structures
{
    public static class PrintHelpers
    {
        public static void PrintFromNode<T>(LLNode<T> firstNode)
        {

            LLNode<T> currentNode = firstNode;
            while (currentNode != null)
            {
                System.Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
    }
}
