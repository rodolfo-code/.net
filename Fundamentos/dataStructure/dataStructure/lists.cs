using System;
using System.Collections.Generic;

namespace dataStructure
{
    public class Lists
    {
        public static void Linked()
        {
            LinkedListNode<string> lln = new LinkedListNode<string>("Rodolfo");
            DisplayProperties(lln);




            LinkedList<string> ll = new LinkedList<string>();

            ll.AddLast(lln);
            Console.WriteLine("After adding the node to the empty LinkedList ....");
            DisplayProperties(lln);

            LinkedListNode<string> lln2 = new LinkedListNode<string>("Vinicius");

            ll.AddLast(lln2);

            LinkedListNode<string> lln3 = new LinkedListNode<string>("Geraldo");
            ll.AddLast(lln3);

            DisplayProperties(lln);
            DisplayProperties(lln2);


            string name = "";

            foreach (string no in ll)
            {
                name += no + " ";
            }

            Console.WriteLine($"Meu nome é {name}");



        }

        public static void DisplayProperties(LinkedListNode<String> lln)
        {
            if (lln.List == null)
                Console.WriteLine("   Node is not linked.");
            else
                Console.WriteLine("   Node belongs to a linked list with {0} elements.   ", lln.List.Count);

            if (lln.Previous == null)
                Console.WriteLine("   Previous node is null.");
            else
                Console.WriteLine("   Value of previous node: {0}", lln.Previous.Value);

            Console.WriteLine("   Value of current node:  {0}", lln.Value);

            if (lln.Next == null)
                Console.WriteLine("   Next node is null.");
            else
                Console.WriteLine("   Value of next node:     {0}", lln.Next.Value);

            Console.WriteLine();
        }
    }
}