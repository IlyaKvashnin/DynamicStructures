using DynamicStructure.DynamicStructure.ConsoleUI;
using DynamicStructure.DynamicStructure.Core.Stack;
using DynamicStructure.DynamicStructure.FileWorker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

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