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
        public int CountItems { get; private set; }
        public int MaxLengthItems { get; private set; } = 5;

        public T[] stackItems = new T[0];

        int size;

        public void Push(T value)
        {
            tail = new ListNode<T>(value, tail);
            initArray(value);
            CountItems++;

            if (tail.Item.ToString().Length > MaxLengthItems)
            {
                MaxLengthItems = tail.Item.ToString().Length;
            }

            //Console.WriteLine("Pushed " + tail.Item);
        }
        public T Pop()
        {
            if (tail == null)
            {
                //Console.WriteLine("Stack is empty");
                return default(T);
            }
            var node = tail;
            tail = tail.Next;
            CountItems--;

            size--;
            stackItems[size] = default(T);
            //Console.WriteLine("Popped " + node.Item);

            return node.Item;
        }

        public T Top()
        {
            if (tail == null)
            {
                return default(T);
            }

            return tail.Item;
        }

        public void Print()
        {
            foreach (var item in stackItems)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public bool IsEmpty()
        {
            if (CountItems == 0)
            {
                //Console.WriteLine("Empty");
                return true;
            }
            //Console.WriteLine("Not empty");
            return false;
        }

        private void initArray(T value)
        {
            if (size == stackItems.Count())
            {
                int newlength = size == 0 ? 4 : size * 2;
                T[] newarray = new T[newlength]; // array with new size   
                stackItems.CopyTo(newarray, 0);
                stackItems = newarray;
            }
            stackItems[size] = value;
            size++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> current = tail;
            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}