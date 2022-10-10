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
        /// <summary>
        /// Property to hold pointer to next ListNode - Self containing object
        /// </summary>

        public ListNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        /// <summary>
        /// Property to hold value into the Node
        /// </summary>

        public T Item
        {
            get { return item; }
            set { item = value; }
        }

        /// <summary>
        /// Constructor with item init
        /// </summary>
        /// <param name="item"></param>

        public ListNode(T item)
        : this(item, null)
        {
        }

        /// <summary>
        /// Constructor with item and the next node specified
        /// </summary>
        /// <param name="item"></param>
        /// <param name="next"></param>

        public ListNode(T item, ListNode<T> next)
        {
            this.item = item;
            this.next = next;
        }

        /// <summary>
        /// Overriding ToString to return a string value for the item in the node
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            if (item == null)
                return string.Empty;
            return item.ToString();
        }
    }
}
