using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.Core.Queue
{
    public class QueueNode<T>
    {
        public QueueNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public QueueNode<T> Next { get; set; }
    }
}
