using DynamicStructure.DynamicStructure.ConsoleUI;
using DynamicStructure.DynamicStructure.Core.DoubleLinkedList;
using DynamicStructure.DynamicStructure.Core.Queue;
using DynamicStructure.DynamicStructure.Core.SinglyLinkedList;
using DynamicStructure.DynamicStructure.Core.Third;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DynamicStructure
{
    public class Program
    {
        public static void Main(string[] args)
        {

            MenuLogic mainMenu = new MenuLogic(MainMenu.mainMenu);
            mainMenu.Run();

            ////3
            //DoublyLinkedList<int> list = new DoublyLinkedList<int> { };
            //list.Add(1);
            //list.Add(3);
            //list.Add(1);
            //list.Add(4);
            //list.Add(5);
            //list.Add(6);
            //list.PrintList();
            //Console.WriteLine();
            //list.DeleteDublicate().PrintList();

            //5
            //DoublyLinkedList<int> list = new DoublyLinkedList<int> { };
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            //list.PrintList();
            //Console.WriteLine("\n");
            //list.InsertListAfterX(2).PrintList();

            //7
            //DoublyLinkedList<int> list = new DoublyLinkedList<int> { };
            //list.Add(1);
            //list.Add(2);
            //list.Add(2);
            //list.Add(3);
            //list.Add(2);
            //list.PrintList();
            //Console.WriteLine("\n");
            //list.DeleteAllItemsE(2);
            //list.PrintList();

            //9
            //DoublyLinkedList<int> list = new DoublyLinkedList<int> { };
            //foreach (var item in list.InsertListToList("../../../DynamicStructure.Core/DoubleLinkedList/lists.txt"))
            //{
            //    Console.WriteLine(item);
            //}

        }




    }
}