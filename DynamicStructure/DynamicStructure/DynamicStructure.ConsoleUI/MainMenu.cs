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
                    new MenuApplicationStack("Удалить элемент из стека",methods.PrintPop),
                    new MenuApplicationStack("Вывести вершину стека",methods.PrintTop),
                    new MenuApplicationStack("Вывести содержимое стека",methods.PrintStack),
                    new MenuApplicationMeasurements("Cгенерировать файл",methods.WriteDataFile),
                    new MenuApplicationMeasurements("Тестирование",methods.ExecuteMeasurements),
                    new ReturnMenu("Вернуться назад")
                }),
                new MenuCategory("Работа с постфиксной записью", new MenuItem[]
                {
                    new MenuApplicationPostfixNotation("Вычислить постфиксное выражение, введенное с клавиатуры", PostfixNotationLogic.CalculatePostfixNotation),
                    new MenuApplicationPostfixNotation("Вычислить выражение из файла", PostfixNotationLogic.CalculatePostfixNotationFromFile),
                    new MenuApplicationPostfixNotation("Вычислить инфиксное выражение с переводом в постфиксную",PostfixNotationLogic.CalculateInfixNotation),
                    new ReturnMenu("Вернуться назад"),
                }),
                 new MenuCategory("Queue", new MenuItem[]
                {
                    new MenuApplicationPostfixNotation("Вывести содержимое очереди", QueueActions.PrintQueue),
                    new MenuApplicationPostfixNotation("Добавить данные в очередь", QueueActions.PrintEnqueue),
                    new MenuApplicationPostfixNotation("Удалить элемент из очереди", QueueActions.PrintDequeue),
                    new MenuApplicationPostfixNotation("Вывести первый элемент очереди", QueueActions.PrintFirstItemQueue),
                    new ReturnMenu("Вернуться назад"),
                }),
                new MenuCategory("Примеры задач с применением динамических структур", new MenuItem[]
                {
                    new MenuApplicationDynamicStructures("Задача на очередь",DynamicStructuresActions.PrintTastQueue),
                    new MenuApplicationDynamicStructures("Задача на деревья",DynamicStructuresActions.PrintTaskTree),
                    new MenuApplicationDynamicStructures("Задача на стек",DynamicStructuresActions.PrintTaskStack),
                    new MenuApplicationDynamicStructures("Задача на листы",DynamicStructuresActions.PrintTaskList),
                    new ReturnMenu("Вернуться назад"),
                }),
                 new MenuCategory("Функции листов", new MenuItem[]
                {
                    new MenuApplicationDynamicStructures("Функция, которая переворачивает список",ListActions.PrintReverse), //1
                    new MenuApplicationDynamicStructures("Функция, которая переносит в начало (в конец) непустого списка L его последний (первый) элемент",ListActions.PrintSecond), //2
                    new MenuApplicationDynamicStructures("Функция, которая подсчитывает количество уникальных цифр",ListActions.PrintCountDistinct), //3
                    new MenuApplicationDynamicStructures("Вставка листа в сам лист после первого вхождения X",ListActions.PrintInsertListAfterX), //5
                    new MenuApplicationDynamicStructures("Функция, которая вставляет в непустой список L, элементы которого упорядочены по не убыванию, новый элемент Е так, чтобы сохранилась упорядоченность.",ListActions.PrintOrderedInsert), //6
                    new MenuApplicationDynamicStructures("Функция, которая удаляет все элементы \"E\" из листа",ListActions.PrintDeleteAllItemsE), //7
                    new MenuApplicationDynamicStructures("Функция, которая вставляет в список L новый элемент F перед первым вхождением элемента Е",ListActions.PrintInsertIntot), //7
                    new MenuApplicationDynamicStructures("Функция, которая удаляет из списка L второй из двух одинаковых элементов",ListActions.PrintDeleteDublicate), //8
                    new MenuApplicationDynamicStructures("Функция дописывает к списку L список E. ",ListActions.PrintInsertListToList), //9
                    new MenuApplicationDynamicStructures("Функция, которая разбивает список на две части",ListActions.PrintSplit), // 10
                    new MenuApplicationDynamicStructures("Функция удваивает список, т.е. приписывает в конец списка себя самого",ListActions.PrintDoubledList), // 11
                    new MenuApplicationDynamicStructures("Функция, которая меняет местами два элемента",ListActions.PrintChangingPlaces), // 12
                    new ReturnMenu("Вернуться назад"),
                }),
                new ReturnMenu("Выход")
            });
    }
}
