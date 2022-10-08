using DynamicStructure.DynamicStructure.Console;
using System;
using System.Collections;

namespace DynamicStructure
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuLogic mainMenu = new MenuLogic(MainMenu.mainMenu);
            mainMenu.Run();
            Stack s = new System.Collections.Stack();
            s.Push(1);
        }
    }
}