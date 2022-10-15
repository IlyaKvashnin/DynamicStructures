using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.Core.SinglyLinkedList
{
    public class ListNode<T>
    {
        public ListNode()
        {

        }
        private ListNode<T>? next;
        private T? item;
        /// <summary>
        /// Property to hold pointer to next ListNode - Self containing object
        /// </summary>

        public ListNode<T>? Next
        {
            get {return next;}
            set { next = value;}
        }
 
        /// <summary>
        /// Property to hold value into the Node
        /// </summary>

        public T? Item
        {
            get {return item;}
            set { item = value;}
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
