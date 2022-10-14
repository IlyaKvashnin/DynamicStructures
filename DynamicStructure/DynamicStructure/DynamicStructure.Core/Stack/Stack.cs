using DynamicStructure.DynamicStructure.ConsoleUI;
using DynamicStructure.DynamicStructure.Core.SinglyLinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicStructure.DynamicStructure.Core.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private ListNode<T> tail;
        public int Count { get; private set; }
        public int Max { get; private set; } = 5;

        public T[] items = new T[0];
        int size;

        public void Push(T value)
        {
            tail = new ListNode<T>(value, tail);
            initArray(value);
            Count++;

            if (tail.Item.ToString().Length > Max)
            {
                Max = tail.Item.ToString().Length;
            }

            Console.WriteLine("Pushed " + tail.Item);
        }
        public T Pop()
        {
            if (tail == null)
            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
            var node = tail;
            tail = tail.Next;
            Count--;

            size--;
            items[size] = default(T);

            Console.WriteLine("Popped " + node.Item);

            return node.Item;
        }
        
        public T Top()
        {
            if (tail == null)
            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }

            Console.WriteLine("Top is " + tail.Item);

            return tail.Item;
        }

        public void Print()
        {
            foreach(var item in items)
            {
                if (item != null)
                {
                    Console.WriteLine("Print " + item);
                }
            }
        }

        public bool IsEmpty()
        {
            if (Count == 0)
            {
                Console.WriteLine("Empty");
                return true;
            }
            Console.WriteLine("Not empty");
            return false;
        }

        private void initArray(T value)
        {
            if (size == items.Count())
            {
                int newlength = size == 0 ? 4 : size * 2;
                T[] newarray = new T[newlength]; // array with new size   
                items.CopyTo(newarray, 0);
                items = newarray;
            }
            items[size] = value;
            size++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
