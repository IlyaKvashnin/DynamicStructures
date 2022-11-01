using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.Core.SinglyLinkedList
{
    public class SinglyLinkedList<T> : ICollection<T>
    {
        #region private variables

        private string strListName;

        private ListNode<T> firstNode;
        private ListNode<T> lastNode;

        private int count;

        #endregion
        public ListNode<T> FirstNode
        {
            get { return firstNode; }
        }
        public ListNode<T> LastNode
        {
            get { return lastNode; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0)
                    throw new ArgumentOutOfRangeException();

                ListNode<T> currentNode = firstNode;
                for (int i = 0; i < index; i++)
                {
                    if (currentNode.Next == null)
                        throw new ArgumentOutOfRangeException();
                    currentNode = currentNode.Next;
                }
                return currentNode.Item;
            }
        }
        public int Count
        {
            get { return count; }
        }

        public bool IsEmpty
        {
            get
            {
                lock (this)
                {
                    return firstNode == null;
                }
            }
        }

        public SinglyLinkedList(string strListName)
        {
            this.strListName = strListName;
            count = 0;
            firstNode = lastNode = null;
        }

        public SinglyLinkedList() : this("MyList") { }

        public void InsertAtFront(T item)
        {
            lock (this)
            {
                if (IsEmpty)
                    firstNode = lastNode = new ListNode<T>(item);
                else
                    firstNode = new ListNode<T>(item, firstNode);
                count++;
            }
        }

        public void InsertAtBack(T item)
        {
            lock (this)
            {
                if (IsEmpty)
                    firstNode = lastNode = new ListNode<T>(item);
                else
                    lastNode = lastNode.Next = new ListNode<T>(item);
                count++;
            }
        }

        public object RemoveFromFront()
        {
            lock (this)
            {
                if (IsEmpty)
                    throw new ApplicationException("list is empty");
                object removedData = firstNode.Item;
                if (firstNode == lastNode)
                    firstNode = lastNode = null;
                else
                    firstNode = firstNode.Next;
                count--;
                return removedData;
            }
        }
        public object RemoveFromBack()
        {
            lock (this)
            {
                if (IsEmpty)
                    throw new ApplicationException("list is empty");
                object removedData = lastNode.Item;
                if (firstNode == lastNode)
                    firstNode = lastNode = null;
                else
                {
                    ListNode<T> currentNode = firstNode;
                    while (currentNode.Next != lastNode)
                        currentNode = currentNode.Next;
                    lastNode = currentNode;
                    currentNode.Next = null;
                }
                count--;
                return removedData;
            }
        }

        public void InsertAt(int index, T item)
        {
            lock (this)
            {
                if (index > count || index < 0)
                    throw new ArgumentOutOfRangeException();
                if (index == 0)
                    InsertAtFront(item);
                else if (index == (count - 1))
                    InsertAtBack(item);
                else
                {
                    ListNode<T> currentNode = firstNode;
                    for (int i = 0; i < index - 1; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    ListNode<T> newNode = new ListNode<T>(item, currentNode.Next);
                    currentNode.Next = newNode;
                    count++;
                }
            }
        }
        public object RemoveAt(int index)
        {
            lock (this)
            {
                if (index > count || index < 0)
                    throw new ArgumentOutOfRangeException();
                object removedData;
                if (index == 0)
                    removedData = RemoveFromFront();
                else if (index == (count - 1))
                    removedData = RemoveFromBack();
                else
                {
                    ListNode<T> currentNode = firstNode;
                    for (int i = 0; i < index; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    removedData = currentNode.Item;
                    currentNode.Next = currentNode.Next.Next;
                    count--;
                }
                return removedData;
            }
        }
        public bool Update(T oldItem, T newItem)
        {
            lock (this)
            {
                ListNode<T> currentNode = firstNode;
                while (currentNode != null)
                {
                    if (currentNode.ToString().Equals(oldItem.ToString()))
                    {
                        currentNode.Item = newItem;
                        return true;
                    }
                    currentNode = currentNode.Next;
                }
                return false;
            }
        }
        public void Clear()
        {
            firstNode = lastNode = null;
            count = 0;
        }

        public void Reverse()
        {
            if (firstNode == null || firstNode.Next == null)
                return;

            lastNode = firstNode;

            ListNode<T> prevNode = null;
            ListNode<T> currentNode = firstNode;
            ListNode<T> nextNode = firstNode.Next;

            while (currentNode != null)
            {
                currentNode.Next = prevNode;
                if (nextNode == null)
                    break;
                prevNode = currentNode;
                currentNode = nextNode;
                nextNode = nextNode.Next;
            }

            firstNode = currentNode;
        }
        public string GetListContents()
        {
            string strListItems = String.Empty;
            ListNode<T> currentNode = firstNode;
            while (currentNode != null)
            {
                strListItems += currentNode.Item.ToString() + "-->";
                currentNode = currentNode.Next;
            }
            return strListItems;
        }

        #region ICollection<T> Members

        /// <summary>
        /// Add to the back of the list. Acts as an append operation
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            InsertAtBack(item);
        }

        /// <summary>
        /// Returns true if list contains the input item else false
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            lock (this)
            {
                ListNode<T> currentNode = firstNode;
                while (currentNode != null)
                {
                    if (currentNode.Item.ToString().Equals(item.ToString()))
                    {
                        return true;
                    }
                    currentNode = currentNode.Next;
                }
                return false;
            }
        }

        /// <summary>
        /// Interface member not implemented as of now
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Irrelevant for now
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the input item if exists and returns true else false
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            if (firstNode.Item.ToString().Equals(item.ToString()))
            {
                RemoveFromFront();
                return true;
            }
            else if (lastNode.Item.ToString().Equals(item.ToString()))
            {
                RemoveFromBack();
                return true;
            }
            else
            {

                ListNode<T> currentNode = firstNode;

                while (currentNode.Next != null)
                {
                    if (currentNode.Next.Item.ToString().Equals(item.ToString()))
                    {
                        currentNode.Next = currentNode.Next.Next;
                        count--;
                        if (currentNode.Next == null)
                            lastNode = currentNode;
                        return true;
                    }
                    currentNode = currentNode.Next;
                }
            }
            return false;
        }

        #endregion

        #region IEnumerable<T> Members

        /// <summary>
        /// Custom GetEnumerator method to traverse through the list and yield the current value
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> currentNode = firstNode;
            while (currentNode != null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
        public override string ToString()
        {
            if (IsEmpty)
                return string.Empty;
            StringBuilder returnString = new StringBuilder();
            foreach (T item in this)
            {
                if (returnString.Length > 0)
                    returnString.Append("->");
                returnString.Append(item);
            }
            return returnString.ToString();
        }

        public bool HasCycle()
        {
            ListNode<T> currentNode = firstNode;
            ListNode<T> iteratorNode = firstNode;

            for (; iteratorNode != null && iteratorNode.Next != null; iteratorNode = iteratorNode.Next)
            {
                if (currentNode.Next == null || currentNode.Next.Next == null) return false;
                if (currentNode.Next == iteratorNode || currentNode.Next.Next == iteratorNode) return true;
                currentNode = currentNode.Next.Next;
            }
            return false;
        }
        public ListNode<T> GetMiddleItem()
        {
            ListNode<T> currentNode = firstNode;
            ListNode<T> iteratorNode = firstNode;

            for (; iteratorNode != null && iteratorNode.Next != null; iteratorNode = iteratorNode.Next)
            {
                if (currentNode.Next == null || currentNode.Next.Next == null) return iteratorNode;
                if (currentNode.Next == iteratorNode || currentNode.Next.Next == iteratorNode) return null;
                currentNode = currentNode.Next.Next;
            }
            return firstNode;
        }
        public void CreateCycleInListToTest()
        {
            ListNode<T> currentNode = firstNode;
            ListNode<T> midNode = GetMiddleItem();
            lastNode.Next = midNode;
        }

        public static void SwapElements(SinglyLinkedList<T> list, int index1, int index2)
        {
            var temp = list.ElementAt<T>(index1);
            list.RemoveAt(index1);
            list.InsertAt(index1, list.ElementAt<T>(index2 - 1));
            list.RemoveAt(index2);
            list.InsertAt(index2, temp);

        }

        public static SinglyLinkedList<T> Split(SinglyLinkedList<T> linkedList, T num)
        {
            SinglyLinkedList<T> newLinkedList = new SinglyLinkedList<T>();
            SinglyLinkedList<T> returnLinkedList = new SinglyLinkedList<T>();
            for (int i = 0; i < linkedList.Count(); i++)
            {
                if (linkedList.ElementAt(i).Equals(num))
                {
                    newLinkedList.Add(linkedList.ElementAt(i));
                    break;
                }
                newLinkedList.Add(linkedList.ElementAt(i));
            }

            for (int j = newLinkedList.Count(); j < linkedList.Count(); j++)
            {
                returnLinkedList.Add(linkedList.ElementAt(j));
            }

            linkedList.Clear();
            for (int i = 0; i < newLinkedList.Count(); i++)
            {
                linkedList.Add(newLinkedList.ElementAt(i));
            }

            return returnLinkedList;

        }

        public static void InsertInto(SinglyLinkedList<T> linkedList, T newElem, T elem)
        {
            int index = 0;
            for (int i = 0; i < linkedList.Count(); i++)
            {
                if (linkedList.ElementAt<T>(i).Equals(elem))
                {
                    index = i;
                    break;
                }
            }
            linkedList.InsertAt(index, newElem);
        }
    }

}
