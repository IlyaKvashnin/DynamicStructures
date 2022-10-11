using DynamicStructure.DynamicStructure.ConsoleUI;
using DynamicStructure.DynamicStructure.Core.SinglyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.Core.Stack
{
    public class Stack<T> 
    {
        private ListNode<T> tail;
        public int Count { get; private set; }
        public void Push(T value)
        {
            tail = new ListNode<T>(value, tail);
            Count++;
            Console.WriteLine($"Pushed {value}");
        }
        public T Pop()
        {
            if (tail == null)
                throw new InvalidOperationException("Стек пуст, нечего извлекать.");
            var node = tail;
            tail = tail.Next;
            Count--;
            Console.WriteLine($"Poped {node.Item}");
            return node.Item;
        }
    }
}
