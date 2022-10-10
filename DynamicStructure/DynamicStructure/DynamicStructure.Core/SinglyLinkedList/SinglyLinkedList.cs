using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.Core.SinglyLinkedList
{
    /// <summary>
    /// A simple basic implementation of singly linked list in C#. The List class implements Add, Find and Delete funcationality without using built-in .NET classes.
    /// </summary> 
    internal class SinglyLinkedList<T>
    {   private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }
        }

        private Node head;
        private Node current;//This will have latest node
        public int Count;

        public SinglyLinkedList()
        {
            head = new Node();
            current = head;
        }
        public void AddAtLast(T data)
        {
            Node newNode = new Node();

            newNode.Element = data;
            current.Next = newNode;
            current = newNode;
            Count++;
        }

        public void AddAtStart(T data)
        {
            Node newNode = new Node() { Element = data };
            newNode.Next = head.Next;//new node will have reference of head's next reference
            head.Next = newNode;//and now head will refer to new node
            Count++;
        }

        public void RemoveFromStart()
        {
            if (Count > 0)
            {
                head.Next = head.Next.Next;
                Count--;
            }
            else
            {
                Console.WriteLine("No element exist in this linked list.");
            }
        }

        public void PrintAllNodes()
        {
            //Traverse from head
            Console.Write("Head ->");
            Node curr = head;
            while (curr.Next != null)
            {
                curr = curr.Next;
                Console.Write(curr.Element);
                Console.Write("->");
            }
            Console.Write("NULL");
        }
    }
}
