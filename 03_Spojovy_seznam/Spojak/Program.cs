using System.ComponentModel;

namespace Spojak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList spojak = new LinkedList();
            spojak.AddToEnd(3);
            spojak.AddToEnd(4);
            spojak.AddToEnd(5);
            spojak.AddToEnd(6);

            spojak.Print();
        }
    }
    class Node
    {
        // konstruktor
        public Node(int value) 
        { 
            Value = value;
            Next = null; 
        }
        public int Value { get; set; }
        public Node Next { get; set; }
    }

    class LinkedList
    {
        public Node Head { get; set; }
        public void AddToEnd(int value)
        {
            if(Head == null)
            {
                Head = new Node(value);
            }
            else
            {
                Node currentNode = Head;
                while(currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = new Node(value);
            }
        }
    
        public void Print()
        {
            Node node = Head;
            while ( node!=null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
            
        }

        // TODO: Najít maximum

        // TODO: odebrat prvek z konce

        // TODO: najít prvek a vrátit True nebo False, jestli tam je
    }
}
