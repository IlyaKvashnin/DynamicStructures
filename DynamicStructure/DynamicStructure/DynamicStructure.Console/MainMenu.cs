using DynamicStructure.DynamicStructure.Core.Stack;

namespace DynamicStructure.DynamicStructure.ConsoleUI
{
    public class MainMenu
    {
        public static MenuCategory mainMenu = new MenuCategory("Главное меню", new Menu[]
            {
                new MenuCategory("Stack",new Menu[]
                {
                 //   new MenuApplicationStackPush("Положить данные в стек"),
                    new ReturnMenu("Вернуться назад")
                }),
                new ReturnMenu("Выход")
            });
    }
}
