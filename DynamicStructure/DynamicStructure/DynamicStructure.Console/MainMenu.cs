using DynamicStructure.DynamicStructure.Core.Stack;

namespace DynamicStructure.DynamicStructure.ConsoleUI
{
    public class MainMenu
    {
        static StackActions methods = new StackActions();

        public static MenuCategory mainMenu = new MenuCategory("Главное меню", new MenuItem[]
            {
                new MenuCategory("Stack",new MenuItem[]
                {
                    new MenuApplicationStack("Положить данные в стек",methods.PrintPush),
                    new MenuApplicationStack("Удалить данные из стека",methods.PrintPop),
                    new MenuApplicationStack("Вывести вершину стека",methods.PrintTop),
                    new MenuApplicationStack("Вывести содержимое стека",methods.PrintStack),
                    new MenuApplicationMeasurements("Cгенерировать файл",methods.WriteDataFile),
                    new MenuApplicationMeasurements("Тестирование",methods.ExecuteMeasurements),
                    new ReturnMenu("Вернуться назад")
                }),
                new ReturnMenu("Выход")
            });
    }
}
