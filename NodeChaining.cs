namespace csharp_data_structures
{
    public class Node
    {
        public int Value { get; set; }

        public Node Next { get; set; }

    }

    public class NodeChaining
    {
        public void showCase()
        {
            // +----------+
            // | 3 | null |
            // +----------+

            Node first = new Node() { Value = 3 };

            // +----------+
            // | 5 | null |
            // +----------+
            Node middle = new Node() { Value = 5 };

            // +----------+         +----------+  
            // | 3 | *----+-------> | 5 | null +
            // +----------+         +----------+

            first.Next = middle;

            // +----------+
            // | 7 | null |
            // +----------+
            Node last = new Node() { Value = 7 };


            // +----------+         +----------+         +----------+  
            // | 3 | *----+-------> | 5 | *----+-------> | 7 | null +
            // +----------+         +----------+         +----------+
            middle.Next = last;

            // just take the first node, traverse and print the linkedList
            PrintLinkList(first);
        }

        private static void PrintLinkList(Node firstNode)
        {

            Node currentNode = firstNode;
            while(currentNode != null)
            {
                System.Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
    }
}
