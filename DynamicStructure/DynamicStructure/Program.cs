using DynamicStructure.DynamicStructure.ConsoleUI;
using System;
using System.Collections.Generic;

namespace DynamicStructure
{
    public class Program
    {
        public static void Main(string[] args)
        {

            MenuLogic mainMenu = new MenuLogic(MainMenu.mainMenu);
            mainMenu.Run();
        }

        

    }
}