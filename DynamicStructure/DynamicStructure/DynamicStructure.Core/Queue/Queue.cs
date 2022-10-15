using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructure.DynamicStructure.Core.DoubleLinkedList;
using DynamicStructure.DynamicStructure.Core.SinglyLinkedList;

namespace DynamicStructure.DynamicStructure.Core.Queue
{
    public class Queue<T> : IEnumerable<T>
    {
        QueueNode<T> head; // головной/первый элемент
        QueueNode<T> tail; // последний/хвостовой элемент
        int count;
        // добавление в очередь
        public void Enqueue(T data)
        {
            QueueNode<T> node = new QueueNode<T>(data);
            QueueNode<T> tempNode = tail;
            tail = node;
            if (count == 0)
                head = tail;
            else
                tempNode.Next = tail;
            count++;
        }
        // удаление из очереди
        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            head = head.Next;
            count--;
            return output;
        }
        // получаем первый элемент
        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return head.Data;
            }
        }
        // получаем последний элемент
        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return tail.Data;
            }
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            QueueNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            QueueNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
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
        public void Print()
        {
            Console.WriteLine(ToString()); 
        }

    }
}
