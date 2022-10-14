using DynamicStructure.DynamicStructure.ConsoleUI;
using DynamicStructure.DynamicStructure.Core.Stack;
using DynamicStructure.DynamicStructure.Test;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace DynamicStructure
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //MenuLogic mainMenu = new MenuLogic(MainMenu.mainMenu);
            //mainMenu.Run();
            FileGenerator fileGenerator = new FileGenerator();
            File.AppendAllText("../../../DynamicStructure.Test/stack.txt", fileGenerator.GenerateFile(10000).ToString());
            string[] file = File.ReadAllLines("../../../DynamicStructure.Test/stack.txt");
            DynamicStructure.Core.Stack.Stack<string> stack = new DynamicStructure.Core.Stack.Stack<string>();

            foreach (var item in file)
            {
                foreach (var elem in item.Split(" "))
                {
                    if (elem.Contains(","))
                    {
                        stack.Push(elem.Substring(elem.IndexOf(",") + 1));
                    }
                    else
                    {
                        switch (elem)
                        {
                            case "2":
                                stack.Pop();
                                break;
                            case "3":
                                stack.Top();
                                break;
                            case "4":
                                stack.IsEmpty();
                                break;
                            case "5":
                                stack.Print();
                                break;
                        }
                    }
                }
            }
            Console.WriteLine("_____________");
            stack.Print();
        }



    }
}