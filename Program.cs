using csharp_data_structures.LinkedList;

namespace csharp_data_structures
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
        }
    }
}
