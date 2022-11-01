﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DynamicStructure.DynamicStructure.ConsoleUI;
using DynamicStructure.DynamicStructure.Core.SinglyLinkedList;
using DynamicStructure.DynamicStructure.Core.Third;

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

            if (index > Count || index < 0)
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
            else if (index == Count)
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
                index++;
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

        public int NumberNoRepeatingElements()
        {
            DoublyListNode<T>? temp1 = Head;
            DoublyListNode<T>? temp2 = Head.Next;
            int rcount = 0;
            while (temp1 != null)
            {
                int fcount = 0;
                temp2 = temp1.Next;
                while (temp2 != null)
                {
                    if (temp1.Data.Equals(temp2.Data))
                    {
                        fcount++;
                    }
                    temp2 = temp2.Next;
                }
                if (fcount == 0)
                    rcount++;
                temp1 = temp1.Next;
            }
            return rcount;
        }

        public DoublyLinkedList<T> InsertListAfterItem(T x)
        {
            DoublyListNode<T>? temp = Head;
            var copy = new DoublyLinkedList<T>();
            int counter = 1;
            while (temp != null)
            {
                copy.Add(temp.Data);
                temp = temp.Next;
            }
            temp = Head;
            while (temp != null)
            {
               
                if (temp.Data.Equals(x))
                {
                    InsertCollection(counter, copy);
                    break;
                }
                counter++;
                temp = temp.Next;
            }
            return this;
        }
        public DoublyLinkedList<T> DeleteDublicate()
        {
            DoublyListNode<T>? temp = Head;
            DoublyLinkedList<T> list = new DoublyLinkedList<T>();
            while (temp != null)
            {
                if (list.Contains(temp.Data))
                {
                    temp = temp.Next;
                }
                else
                {
                    list.Add(temp.Data);
                    temp = temp.Next;
                }
                
                temp1 = temp1.Next;
            }
            return list;
        }
        public void DeleteAllItems(T e)
        {
            DoublyListNode<T>? temp = Head;
            while (temp != null)
            {
                if(EqualityComparer<T>.Default.Equals(temp.Data, e))
                {
                    Remove(temp.Data);
                }
                temp = temp.Next;
            }

        }

        public DoublyLinkedList<int> InsertIntoList(string path)
        {
            var file = File.ReadAllLines(path);
            var list1 = new DoublyLinkedList<int>();
            for (int i = 0; i < file.Count(); i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < file[i].Split(" ").Length; j++)
                    {
                        list1.Add(int.Parse(file[i].Split(" ")[j]));
                    }
                }
                else
                {
                    for (int j = 0; j < file[i].Split(" ").Length; j++)
                    {
                        list1.Add(int.Parse(file[i].Split(" ")[j]));
                    }
                }
            }
            return list1;
        }

        public void InsertItself()
        {
            DoublyListNode<T> temp = Head;
            int count = Count;
            for (int i = 0; i < count; i++)
            {
                Add(temp.Data);
                temp = temp.Next;
            }
        }

        public static void OrderedInsert(DoublyLinkedList<T> linkedList, T newElem)
        {
            linkedList.Add(newElem);
            linkedList.Sort();

        }
        public void ChangeLastAndFirstItem()
        {
            var tail = Tail.Data;
            Tail.Data = Head.Data;
            Head.Data = tail;

            //var head = Head;
            //var tail = Tail;

            //Remove(head.Data);
            //Remove(tail.Data);
            //AddToStart(tail.Data);
            //Add(head.Data);
        }
        public void SwapElements(T elem1, T elem2)
        {
            int index1 = IndexOf(elem1);
            int index2 = IndexOf(elem2);

            RemoveAt(index1);
            Count++;
            if (index1 == 0)
            {
                AddToStart(elem2);
                Count--;
            }
            else
            {
                Insert(index1, elem2, "");
                Count--;
            }
            RemoveAt(index2);
            Count++;
            if (index2 == Count)
            {
                Add(elem1);
                Count--;
            }
            else
            {
                Insert(index2, elem1, "");
                Count--;
            }

        }
        public (DoublyLinkedList<T>, DoublyLinkedList<T>) Split(T x)
        {
            DoublyListNode<T> listing = head;
            DoublyLinkedList<T> listing2 = new DoublyLinkedList<T>();

            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(listing.Data, x))
                {
                    listing = listing.Next;
                    for (int j = i; j < count - 1; j++)
                    {
                        listing2.Add(listing.Data);
                        listing = listing.Next;
                    }

                    for (int j = 0; j < listing2.Count; j++)
                    {
                        tail.Previous.Next = tail.Next;
                        tail = tail.Previous;
                    }
                    return (this, listing2);
                }
                listing = listing.Next;
            }
            return (this, listing2);
        }

        public void InsertInto(T newElem, T elem)
        {
            DoublyListNode<T> listing = Head;
            int count = Count;
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(listing.Data, elem))
                {
                    if (IndexOf(elem) == Count - 1)
                    {
                        Count++;
                        Insert(IndexOf(elem), newElem, "");
                    }
                    else
                    {
                        Insert(IndexOf(elem), newElem, "");
                    }
                }
                listing = listing.Next;
            }
        }
    }
}
