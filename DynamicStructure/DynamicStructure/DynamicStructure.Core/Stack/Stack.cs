using DynamicStructure.DynamicStructure.ConsoleUI;
using DynamicStructure.DynamicStructure.Core.SinglyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.Core.Stack
{
    public class Stack<T> : IStack<T>
    {
        SinglyLinkedList<T> list;

        public Stack()
        {
            this.list = null;
        }
        internal void Push()
        {
            var value = Console.ReadLine();
            list.AddAtStart((T)Convert.ChangeType(value,typeof(T)));
            Console.WriteLine("{0} pushed to stack", value);
        }




    }
}
