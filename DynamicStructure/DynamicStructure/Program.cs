using DynamicStructure.DynamicStructure.Console;
using System;

namespace DynamicStructure
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuLogic mainMenu = new MenuLogic(MainMenu.mainMenu);
            mainMenu.Run();
        }
    }
}