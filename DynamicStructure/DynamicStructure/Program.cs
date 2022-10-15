using DynamicStructure.DynamicStructure.ConsoleUI;
using DynamicStructure.DynamicStructure.Core.Queue;
using System;

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