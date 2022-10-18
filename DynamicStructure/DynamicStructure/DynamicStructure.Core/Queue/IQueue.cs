using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.Core.Queue
{
    public interface IQueue<T>
    {
        void Enqueue(T item);
        T Dequeue();

        T First { get; }
        T Last { get; }

        bool IsEmpty { get; }
        int Length { get; }

    }
}
