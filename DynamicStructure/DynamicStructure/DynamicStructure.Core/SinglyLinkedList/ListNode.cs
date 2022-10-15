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

        public ListNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        public T Item
        {
            get { return item; }
            set { item = value; }
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
    }
}
