using DynamicStructure.DynamicStructure.Core.Stack;

namespace DynamicStructure.DynamicStructure.ConsoleUI
{
    public class MainMenu
    {
        static PrintStackLogic stack = new PrintStackLogic();

        public static MenuCategory mainMenu = new MenuCategory("Главное меню", new MenuItem[]
            {
                new MenuCategory("Stack",new MenuItem[]
                {
                    new MenuApplicationStackPush("Положить данные в стек",stack.PushItem),
                    new ReturnMenu("Вернуться назад")
                }),
                new ReturnMenu("Выход")
            });
    }
}
