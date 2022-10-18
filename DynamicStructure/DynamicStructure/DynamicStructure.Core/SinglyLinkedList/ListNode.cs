using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.Core.SinglyLinkedList
{
    public class ListNode<T>
    {
        private ListNode<T> next;
        private T item;

        public ListNode<T>? Next
        {
            get {return next;}
            set { next = value;}
        }

        public T Item
        {
            get {return item;}
            set { item = value;}
        }

        public ListNode(T item)
        : this(item, null)
        {
        }

        public ListNode(T item, ListNode<T> next)
        {
            this.item = item;
            this.next = next;
        }

        public override string ToString()
        {
            if (item == null)
                return string.Empty;
            return item.ToString();
        }
    
        public T? First()
        {
            return Item;
        }
        public T? Last()
        {
            ListNode<T> currentItem = this;
            while (currentItem.Next != null)
            {
                currentItem = currentItem.Next;
            }
            return currentItem.Item;
        }
        public T? ElementAt(uint index)
        {
            ListNode<T> currentItem = this;
            for (int i = 0; i < index;i++)
            {
                if (currentItem.Next != null)
                    currentItem = currentItem.Next;
            }
            return currentItem.Item;
        }
    }
}
