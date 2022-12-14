using DynamicStructure.DynamicStructure.Core.Stack;
using System;
using System.Collections.Generic;

namespace DynamicStructure.DynamicStructure.ConsoleUI
{
    public abstract class MenuItem
    {
        public string Name { get; }

        public MenuItem(string name)
        {
            Name = name;
        }
    }

    public class ReturnMenu : MenuItem
    {
        public ReturnMenu(string name) : base(name) { }
    }

    public class MenuCategory : MenuItem
    {
        public MenuItem[] Items { get; }

        public MenuCategory(string name, MenuItem[] items) : base(name)
        {
            Items = items;
        }
    }

    public class MenuAction : MenuItem
    {
        public Action<MenuItem> Action { get; }

        public MenuAction(string name, Action<MenuItem> action) : base(name)
        {
            Action = action;
        }
    }

    public class MenuApplicationStack : MenuItem
    {
        public Action Action { get; }

        public MenuApplicationStack(string name, Action action) : base(name)
        {
            Action = action;
        }
    }
}
