using DynamicStructure.DynamicStructure.ConsoleUI;
using DynamicStructure.DynamicStructure.Core.SinglyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.Core.Stack
{
    public static class Stack<T> 
    {
        public static SinglyLinkedList<T> List = new SinglyLinkedList<T>();

        public static void Push()
        {
            var value = Console.ReadLine();
            List.InsertAtFront((T)Convert.ChangeType(value, typeof(T)));
            Console.WriteLine($"Pushed {0}", value);
        }

    }
}
