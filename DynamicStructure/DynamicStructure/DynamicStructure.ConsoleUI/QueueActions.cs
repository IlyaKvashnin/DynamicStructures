using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.ConsoleUI
{
    public class QueueActions
    {
        private static DynamicStructure.Core.Queue.Queue<string> queue = new DynamicStructure.Core.Queue.Queue<string>();
        public static void PrintQueue()
        {
            ConsoleHelper.ClearScreen();

            if (queue.IsEmpty)
            {
                Console.WriteLine("Необходимо добавить элементы в очереди.");
                Console.WriteLine("\n");
                return;
            }
            else
            {
                Console.WriteLine("Содержимое очереди :");

                ConsoleHelper.DrawSeparator(queue.MaxLengthItems,1, '╔', '╦', '╗');
                for (int i = -1; i < queue.Count(); i++)
                {
                    if (i == 0)
                    {
                        ConsoleHelper.DrawSeparator(queue.MaxLengthItems,1, '╠', '╬', '╣');
                    }
                    for (int j = 0; j < 1; j++)
                    {
                        Console.Write('║');
                        if (i == -1 )
                        {
                            Console.Write(ConsoleHelper.CenterText($"Queue", queue.MaxLengthItems));
                        }
                        else
                        {
                            Console.Write(ConsoleHelper.CenterText(queue.ToArray()[i], queue.MaxLengthItems));
                        }
                    }
                    Console.WriteLine('║');
                }
                ConsoleHelper.DrawSeparator(queue.MaxLengthItems,1, '╚', '╩', '╝');

                Console.WriteLine("\n");
            }
        }

        public static void PrintEnqueue()
        {
            ConsoleHelper.ClearScreen();

            PrintQueue();

            Console.WriteLine("Введите строку или число, которое нужно положить в очередь.");
            var value = Console.ReadLine();
            int num;
            bool isNum = int.TryParse(value, out num);
            if (isNum)
                queue.Enqueue(num.ToString());
            else
                queue.Enqueue(value);
            Console.WriteLine($"Добавлено значение: {value}");
        }

        public static void PrintDequeue()
        {
            ConsoleHelper.ClearScreen();

            if (!queue.IsEmpty)
            {
                PrintQueue();
                var value = queue.Dequeue();
                Console.WriteLine($"Удалено значение: {value}");
                Console.WriteLine("\n");
                Console.WriteLine("Текущее содержимое очереди :");
            }
            else
            {
                Console.WriteLine("Стек пуст, значение не может быть извлечено.");
            }
        }

        public static void PrintFirstItemQueue()
        {
            ConsoleHelper.ClearScreen();

            if (!queue.IsEmpty)
            {
                Console.WriteLine("Текущее содержимое очереди :");
                PrintQueue();
                var value = queue.First;
                Console.WriteLine($"Вершина очереди: {value}");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Очередь пуста, вершину невозможно отобразить.");
            }

        }
    }
}
