﻿using DynamicStructure.DynamicStructure.Core.DoubleLinkedList;
using DynamicStructure.DynamicStructure.Core.SinglyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.ConsoleUI
{
    internal class ListActions
    {
        public static void PrintReverse()
        {
            ConsoleHelper.ClearScreen();
            DoublyLinkedList<int> list = new DoublyLinkedList<int> { };
            list.Add(1);
            list.Add(4);
            list.Add(6);
            Console.WriteLine("Содержимое листа :");
            list.PrintList();
            list.Reverse();
            Console.WriteLine("\n");
            Console.WriteLine("Содержимое листа после выполнения функции :");
            list.PrintList();
        }

        public static void PrintNumberNoRepeatingElements()
        {
            ConsoleHelper.ClearScreen();
            DoublyLinkedList<int> list = new DoublyLinkedList<int> { };
            list.Add(1);
            list.Add(1);
            list.Add(3);
            list.Add(3);
            list.Add(2);
            list.Add(2);
            Console.WriteLine("Содержимое листа :");
            list.PrintList();
            Console.WriteLine("\n");
            Console.WriteLine($"Количество уникальных цифр: {list.NumberNoRepeatingElements()}");
        }

        public static void PrintInsertListAfterItem()
        {
            ConsoleHelper.ClearScreen();
            DoublyLinkedList<int> list = new DoublyLinkedList<int> { };
            list.Add(1);
            list.Add(2);
            list.Add(3);
            //list.Add(4);
            //list.Add(5);
            Console.WriteLine("Содержимое листа :");
            list.PrintList();
            Console.WriteLine("\n");
            Console.WriteLine("Введите число после которого хотите сделать вставку");
            var value = Console.ReadLine();
            Console.WriteLine("Содержимое листа после вставки :");
            list.InsertListAfterItem(int.Parse(value));
            Console.WriteLine();
            list.PrintList();
        }

        public static void PrintDeleteAllItems()
        {
            ConsoleHelper.ClearScreen();
            DoublyLinkedList<int> list = new DoublyLinkedList<int> {1,2,3,4,5 };
            Console.WriteLine("Содержимое листа :");
            list.PrintList();
            Console.WriteLine("\n");
            Console.WriteLine("Введите число которое хотите удалить");
            var value = Console.ReadLine();
            list.DeleteAllItems(int.Parse(value);
            Console.WriteLine("Содержимое листа после удаления :");
            list.PrintList();
        }

        public static void PrintChangeLastAndFirstItem()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>() { 1, 2, 3, 4, 5 };
            ConsoleHelper.ClearScreen();
            Console.WriteLine("Меняем последний элемент с первым");
            list.PrintList();
            list.ChangeLastAndFirstItem();
            Console.WriteLine("\n");
            list.PrintList();
        }

        public static void PrintSwapElements()
        {
            ConsoleHelper.ClearScreen();
            var test = new DoublyLinkedList<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine("Элементы, которые содержит список :");
            test.PrintList();
            Console.WriteLine();
         
            Console.WriteLine("Введите первый элемента, который хотите поменять местами");
            var v1 = Console.ReadLine();
            Console.WriteLine("Введите второй элемента, который хотите поменять местами");
            var v2 = Console.ReadLine();
            test.SwapElements(int.Parse(v1),int.Parse(v2));
            Console.WriteLine($"Измененный список :");
            test.PrintList();
        }

        public static void PrintSplit()
        {
            ConsoleHelper.ClearScreen();
            var test = new DoublyLinkedList<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Содержимое списка :");
            test.PrintList();
            Console.WriteLine();
            Console.WriteLine("Введите число по которому хотите разбить список");
            var value = Console.ReadLine();
            var returnedList = test.Split(int.Parse(value));
            Console.WriteLine($"Первая часть:");
            returnedList.Item1.PrintList();
            Console.WriteLine();
            Console.WriteLine($"Вторая часть:");
            returnedList.Item2.PrintList();
        }
        
        public static void PrintInsertIntoList()
        {
            ConsoleHelper.ClearScreen();
            DoublyLinkedList<int> list = new DoublyLinkedList<int> { };
            Console.WriteLine("Список, из двух списков, считанных из файла:");
            list.InsertIntoList("../../../DynamicStructure.Core/DoubleLinkedList/lists.txt").PrintList();
        }

        public static void PrintInsertItself()
        {
            ConsoleHelper.ClearScreen();
            DoublyLinkedList<string> list = new DoublyLinkedList<string> {"a","b","c","e","f" };
            Console.WriteLine("Содержимое листа :");
            list.PrintList();
            Console.WriteLine("\n");
            Console.WriteLine("Содержимое листа после вставки в самого себя :");
            list.InsertItself();
            list.PrintList();
        }

        public static void PrintOrderedInsert()
        {
            ConsoleHelper.ClearScreen();
            var test = new DoublyLinkedList<int>() { 0, 2, 5 };
            Console.WriteLine("Введите число, которое хотите добавить в список");
            var value = Console.ReadLine();
            test.OrderedInsert(test, int.Parse(value));
            Console.WriteLine("Список с добавленным значением :");
            test.PrintList();
        }

        public static void PrintInsertInto()
        {
            ConsoleHelper.ClearScreen();
            var test = new DoublyLinkedList<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Содержимое списка :");
            test.PrintList();
            Console.WriteLine();
            Console.WriteLine("Введите число, которое хотите добавить в список");
            var value = Console.ReadLine();
            Console.WriteLine("Введите число, перед которым вы хотите добавить новое значение добавить в список");
            var value1 = Console.ReadLine();
            test.InsertInto(int.Parse(value), int.Parse(value1));
            Console.WriteLine($"Измененный список :");
            test.PrintList();
        }

        public static void PrintDeleteDublicate()
        {
            ConsoleHelper.ClearScreen();
            DoublyLinkedList<int> list = new DoublyLinkedList<int> { };
            list.Add(1);
            list.Add(3);
            list.Add(5);
            list.Add(3);
            list.Add(9);
            list.Add(1);
            list.Add(3);
            Console.WriteLine("Содержимое списка :");
            list.PrintList();
            Console.WriteLine("\n");
            Console.WriteLine($"Содержимое списка после удаления вторых элементов из двух одинаковых элементов : ");
            list.DeleteDublicate();
            list.PrintList();
        }
    }
}
