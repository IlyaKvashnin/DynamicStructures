namespace DynamicStructure.DynamicStructure.Core.Third;
using System;
using System.Collections.Generic;
public class ShortestPathFinder
{

    public ShortestPathFinder(int[,] matrix, int matrixSize) //Конструктор (передаем все внешние даннные в класс ShortestPathFinder)
    {
            Matrix = matrix;
            MatrixSize = matrixSize;
    }
        private int[,] Matrix { get; } 
        private int MatrixSize { get; }
        
        
        
        
    public void MatrixPrint()
    {
            Console.WriteLine("Ваша исходная матрица : ");
            Console.WriteLine();
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3}", Matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
    }
    private int MinDistance(int[] dist, bool[] sptSet)
    {
            var min = int.MaxValue;
            var minIndex = -1;

            for (int i = 0; i < MatrixSize; i++)
            {
                if (sptSet[i] == false && dist[i] <= min)
                {
                    min = dist[i];
                    minIndex = i;
                }
            }

            return minIndex;
    } 
    public void Dijkstra(int[,] matrix, int root)
    {
            var dist = new int[MatrixSize];

            var path = new int[MatrixSize];

            var checkPoint = new bool[MatrixSize];

            for (int i = 0; i < MatrixSize; i++) //Заполняем масив кратчайших путей и посещенных точек
            {
                dist[i] = int.MaxValue;
                checkPoint[i] = false;
            }

            dist[root] = 0;

            for (int i = 0; i < MatrixSize - 1; i++)
            {
                var minDist = MinDistance(dist, checkPoint);

                checkPoint[minDist] = true;

                for (int j = 0; j < MatrixSize; j++)
                {
                    if (!checkPoint[j] && matrix[minDist, j] != 0 && dist[minDist] != int.MaxValue && dist[minDist] + matrix[minDist, j] < dist[j])
                    {
                        dist[j] = dist[minDist] + matrix[minDist, j];
                        path[j] = minDist; //Заполняется массив предков
                    }
                }
            }

            

            Console.WriteLine("Данные о путях(по Дейкстре):");
            Console.WriteLine();
            Console.WriteLine($"Наша начальная точка 1");
            
            for (int i = 1; i < MatrixSize; i++)
            {
                if (path[i] == 0)
                    Console.WriteLine($"Кратчайший путь: из 1 -> {i + 1} прямой | Мин.Расстояние: {dist[i]}");
                else
                {
                    DynamicStructure.Core.Stack.Stack<int> stack = new DynamicStructure.Core.Stack.Stack<int>();
                    stack.Push(path[i] + 1);
                    
                    Console.Write($"Кратчайший путь: из 1 -> ");

                    for (int j = path[i]; j != 0; j = path[j])
                    {
                        if (path[j] == 0)
                            break;
                        else
                        {
                            stack.Push(path[j]);
                            j = path[j];
                        }
                        
                    }

                    for (int j = 0; j <= stack.Count(); j++)
                    {
                        if (j == stack.Count())
                            Console.Write($"{i + 1} | Мин.Расстояние: {dist[i]}");
                        else
                        {
                            Console.Write(stack.Pop() + " -> ");
                            j = -1;
                        }
                    }

                    Console.WriteLine();
                    
                }
            }
    } 
    public static int[,] FillingMatrix(string[] sizeOfMatrix, int[,] matrix)
    {
        for (int i = 0; i < sizeOfMatrix.Length; i++)
        {
            var temp = sizeOfMatrix[i].Split(' ');
            for (int j = 0; j < temp.Length; j++)
                try
                {
                    matrix[i, j] = Convert.ToInt32(temp[j]);
                }
                catch (Exception)
                {
                    Console.WriteLine("в вашей матрице есть неверные типы данных");
                    Environment.Exit(0);
                }
        }

        return matrix;
    }
}
