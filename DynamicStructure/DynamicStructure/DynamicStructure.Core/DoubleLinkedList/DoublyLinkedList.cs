using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DynamicStructure.DynamicStructure.ConsoleUI;
using DynamicStructure.DynamicStructure.Core.SinglyLinkedList;

namespace DynamicStructure.DynamicStructure.Core.DoubleLinkedList
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        private DoublyListNode<T> head;
        private DoublyListNode<T> tail;
        private int count;

        public DoublyListNode<T> Head { get => head; set => head = value; }
        public DoublyListNode<T> Tail { get => tail; set => tail = value; }
        public int Count { get => count; set => count = value; }

        bool ICollection<T>.IsReadOnly => false;

        public void Add(T data)
        {
            DoublyListNode<T> node = new(data);

            if (Count == 0) { Head = node; }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }

            Tail = node;
            Count++;
        }
        public void AddToStart(T data)
        {
            DoublyListNode<T> node = new(data);
            DoublyListNode<T> temp = Head;

            Head = node;
            Head.Next = temp;
            if (Count == 0) { Tail = Head; }
            else { temp.Previous = Head; }
            Count++;
        }
        public DoublyLinkedList<T> AddCollection(IEnumerable<T> collection)
        {
            foreach (T data in collection)
            {
                Add(data);
            }
            return this;
        }
        public DoublyLinkedList<T> AddCollection(DoublyLinkedList<T> list)
        {
            foreach (T data in list)
            {
                Add(data);
            }
            return this;
        }
        public void Insert(int index, T data, string message)
        {

            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), message);
            }
            DoublyListNode<T> node = new(data);
            int currentIndex = 0;
            DoublyListNode<T>? currentItem = Head;
            DoublyListNode<T>? prevItem = null;
            while (currentIndex < index)
            {
                prevItem = currentItem;
                currentItem = currentItem.Next;
                currentIndex++;
            }
            if (index == 0)
            {
                AddToStart(data);
            }
            else if (index == Count - 1)
            {
                Add(data);
            }
            else
            {
                node.Next = prevItem.Next;
                prevItem.Next = node;
                currentItem.Previous = node;
                node.Previous = currentItem.Previous;
                Count++;
            }
        }
        public DoublyLinkedList<T> InsertCollection(int index, DoublyLinkedList<T> list)
        {
            foreach (T data in list)
            {
                Insert(index, data, "The index is out of bounds!");
            }
            return this;
        }
        public DoublyLinkedList<T> InsertCollection(int index, IEnumerable<T> collection)
        {
            foreach (T data in collection)
            {
                Insert(index, data, "The index is out of bounds!");
            }
            return this;
        }
        public bool Remove(T data)
        {
            DoublyListNode<T>? previous = null;
            DoublyListNode<T>? current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null) { Tail = previous; }
                        else { current.Next.Previous = previous; }
                        Count--;
                    }

                    else
                    {
                        Head = Head.Next;
                        Count--;
                        if (Count == 0) { Tail = null; }
                        else { Head.Previous = null; }
                    }
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }
        public bool RemoveAt(int index)
        {
            int marker = 0;
            DoublyListNode<T>? previous = null;
            DoublyListNode<T>? current = Head;
            while (current != null)
            {
                if (marker == index)
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null) { Tail = previous; }
                        else { current.Next.Previous = previous; }
                        Count--;
                    }

                    else
                    {
                        Head = Head.Next;
                        Count--;
                        if (Count == 0) { Tail = null; }
                        else { Head.Previous = null; }
                    }
                    return true;
                }

                marker++;
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public int IndexOf(T data)
        {
            DoublyListNode<T>? temp = Head;
            int index = 0;
            while (temp != null)
            {
                if (temp.Data.Equals(data)) return index;
                temp = temp.Next;
                index++;
            }
            return -1;
        }
        public bool Contains(T data)
        {
            if (IndexOf(data) == -1) return false;
            else return true;
        }

        public void Reverse()
        {
            DoublyListNode<T>? temp = Head;
            DoublyListNode<T>? node = temp.Next;
            temp.Next = null;
            temp.Previous = node;
            while (node != null)
            {
                node.Previous = node.Next;
                node.Next = temp;
                temp = node;
                node = node.Previous;
                Head = temp;
            }
        }
        public void Sort()
        {
            for (DoublyListNode<T>? current = Head; current.Next != null; current = current.Next)
            {
                for (DoublyListNode<T>? index = current.Next; index != null; index = index.Next)
                {
                    if (Comparer<T>.Default.Compare(current.Data, index.Data) > 0)
                    {
                        (current.Data, index.Data) = (index.Data, current.Data);
                    }
                }
            }
        }

        public void Clear()
        {
            foreach (T data in this)
            {
                Remove(data);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            DoublyListNode<T>? current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public void PrintList()
        {
            DoublyListNode<T>? temp = Head;
            while (temp != null)
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void FirstToLast()
        {
            DoublyListNode<T>? temp = Head;
            DoublyListNode<T>? node = temp.Next;
            temp.Next = null;
            temp.Previous = node;
            
        }
    }
}
