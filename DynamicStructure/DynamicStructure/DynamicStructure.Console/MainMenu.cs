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
                    new MenuApplicationStack("Положить данные в стек",stack.PrintPush),
                    new MenuApplicationStack("Удалить данные из стека",stack.PrintPop),
                    new MenuApplicationStack("Вывести вершину стека",stack.PrintTop),
                    new MenuApplicationStack("Вывести содержимое стека",stack.PrintStack),
                    new ReturnMenu("Вернуться назад")
                }),
                new ReturnMenu("Выход")
            });
    }
}
