using DynamicStructure.DynamicStructure.Core.SinglyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DynamicStructure.DynamicStructure.Core.DoubleLinkedList
{
    public class DoublyListNode<T>
    {
        private DoublyListNode<T>? next;
        private DoublyListNode<T>? previous;
        private T data;

        public DoublyListNode<T>? Next { get => next; set => next = value; }
        public DoublyListNode<T>? Previous { get => previous; set => previous = value; }
        public T Data { get => data; set => data = value; }
        public DoublyListNode()
        {
           
        }
        public DoublyListNode(T data) : this(data, null, null)
        {
        }
        public DoublyListNode(T data, DoublyListNode<T> next, DoublyListNode<T> prev)
        {
            this.data = data;
            this.next = next;
            this.previous = prev;
        }
        public T? First()
        {
            return Data;
        }
        public T? Last()
        {
            DoublyListNode<T> currentItem = this;
            while (currentItem.Next != null)
            {
                currentItem = currentItem.Next;
            }
            return currentItem.Data;
        }
    }
}
