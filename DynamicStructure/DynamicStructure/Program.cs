using DynamicStructure.DynamicStructure.ConsoleUI;
using DynamicStructure.DynamicStructure.Core.Queue;
using System;
using System.Threading.Channels;
using DynamicStructure.DynamicStructure.Core.DoubleLinkedList;
using DynamicStructure.DynamicStructure.Core.SinglyLinkedList;
using DynamicStructure.DynamicStructure.Core.Third;
using DynamicStructure.DynamicStructure.Core.Third.Queue;

namespace DynamicStructure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = @"C:\Users\PC-\Desktop\matrix.txt"; //путь
            var sizeOfMatrix = File.ReadAllLines(path); //Считывание всех строк из файла
            var matrica = new int[sizeOfMatrix.Length, sizeOfMatrix[0].Split(' ').Length]; //Инициализация двумерного массива
            var matrixSize = sizeOfMatrix.Length; //Размер матрицы
            matrica = ShortestPathFinder.FillingMatrix(sizeOfMatrix, matrica);//Заполнение матрицы
            ShortestPathFinder matrix = new ShortestPathFinder(matrica, matrixSize);
           
            matrix.Dijkstra(matrica,0);
            Console.WriteLine(matrix);
            
        }
        



    }
}