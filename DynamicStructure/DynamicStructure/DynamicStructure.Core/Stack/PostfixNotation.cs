using DynamicStructure.DynamicStructure.Core.Stack;

class PostfixNotation
{

    static public double Calculate(string v)//"входной" метод класса
    {
        string input = сonvertString(v);
        string output = GetExpression(input);//преобразование выражения в постфиксную запись
        double result = Counting(output);//решение выражения
        return result;

    }



    static public string GetExpression(string v)//метод перевода выражения в постфиксную запись
    {
        string input = сonvertString(v);
        string output = string.Empty; //Строка для хранения выражения
        //Stack<char> operStack = new Stack<char>(); //Стек для хранения операторов
        DynamicStructure.DynamicStructure.Core.Stack.Stack<string> operStack = new DynamicStructure.DynamicStructure.Core.Stack.Stack<string>();

        for (int i = 0; i < input.Length; i++) //Для каждого символа в входной строке
        {

            //Разделители пропускаем
            if (IsDelimeter(input[i]))
                continue; //Переходим к следующему символу



            //проверка на отрицательное число: если знак "-" в начале строки или перед знаком "-" нет числа 
            if (input[i] == '-' && ((i > 0 && !Char.IsDigit(input[i - 1])) || i == 0))
            {
                i++;
                output += "-";//в переменную для чисел добавляется знак "-"    
            }


            //Если символ - цифра, то считываем все число
            if (Char.IsDigit(input[i])) //Если цифра
            {
                //Читаем до разделителя или оператора, что бы получить число
                while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                {
                    output += input[i]; //Добавляем каждую цифру числа к нашей строке
                    i++; //Переходим к следующему символу

                    if (i == input.Length) break; //Если символ - последний, то выходим из цикла
                }

                output += " "; //Дописываем после числа пробел в строку с выражением
                i--; //Возвращаемся на один символ назад, к символу перед разделителем
            }

            //Если символ - оператор
            if (IsOperator(input[i]) || IsFunction(input[i].ToString())) //Если оператор
            {

                if (input[i] == '(') //Если символ - открывающая скобка
                    operStack.Push(input[i].ToString()); //Записываем её в стек
                else if (input[i] == ')') //Если символ - закрывающая скобка
                {
                    //Выписываем все операторы до открывающей скобки в строку
                    string s = operStack.Pop();

                    while (s != "(")
                    {
                        output += s.ToString() + ' ';

                        s = operStack.Pop();
                    }
                }
               
                else //Если любой другой оператор
                {
                    if (operStack.Count() > 0) //Если в стеке есть элементы
                        if (GetPriority(input[i].ToString()) <= GetPriority(operStack.Top())) //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                            output += operStack.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением

                    operStack.Push((input[i].ToString())); //Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека

                }
            }
        }

        //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
        while (operStack.Count() > 0)
            output += operStack.Pop() + " ";

        return output; //Возвращаем выражение в постфиксной записи

    }

    static public double Counting(string v)//метод решения OPN
    {
        string output = сonvertString(v);
        string result;

        string[] mas = output.Split(' ');

        for (int i = 0; i < mas.Length; i++)

            switch (mas[i])
            {
                case "+"://если найдена операция сложения
                    result = (double.Parse(mas[i - 2]) + double.Parse(mas[i - 1])).ToString();//выполняем сложение и переводим ее в строку
                    mas[i - 2] = result;//на место 1-ого операнда записывается результат (как если бы a=a+b)
                    for (int j = i - 1; j < mas.Length - 2; j++)//удаляем из массива второй операнд и знак арифм действия
                        mas[j] = mas[j + 2];
                    Array.Resize(ref mas, mas.Length - 2);//обрезаем массив элементов на 2 удаленнх элемента
                    i -= 2;
                    break;


                case "√"://далее все аналогично
                    result = Math.Sqrt(double.Parse(mas[i - 1])).ToString();
                    mas[i - 1] = result;
                    for (int j = i; j < mas.Length - 1; j++)
                        mas[j] = mas[j + 1];
                    Array.Resize(ref mas, mas.Length - 1);
                    i -= 1;
                    break;

                case "s"://далее все аналогично
                    result = Math.Sin(double.Parse(mas[i - 1])).ToString();
                    mas[i - 1] = result;
                    for (int j = i; j < mas.Length - 1; j++)
                        mas[j] = mas[j + 1];
                    Array.Resize(ref mas, mas.Length - 1);
                    i -= 1;
                    break;

                case "c"://далее все аналогично
                    result = Math.Cos(double.Parse(mas[i - 1])).ToString();
                    mas[i - 1] = result;
                    for (int j = i; j < mas.Length - 1; j++)
                        mas[j] = mas[j + 1];
                    Array.Resize(ref mas, mas.Length - 1);
                    i -= 1;
                    break;

                case "l":
                    result = (Math.Log(double.Parse(mas[i - 2]), double.Parse(mas[i - 1]))).ToString();
                    mas[i - 2] = result;
                    for (int j = i - 1; j < mas.Length - 2; j++)
                        mas[j] = mas[j + 2];
                    Array.Resize(ref mas, mas.Length - 2);
                    i -= 2;
                    break;

                case "-"://далее все аналогично
                    result = (double.Parse(mas[i - 2]) - double.Parse(mas[i - 1])).ToString();
                    mas[i - 2] = result;
                    for (int j = i - 1; j < mas.Length - 2; j++)
                        mas[j] = mas[j + 2];
                    Array.Resize(ref mas, mas.Length - 2);
                    i -= 2;
                    break;

                case "*":
                    result = (double.Parse(mas[i - 2]) * double.Parse(mas[i - 1])).ToString();
                    mas[i - 2] = result;
                    for (int j = i - 1; j < mas.Length - 2; j++)
                        mas[j] = mas[j + 2];
                    Array.Resize(ref mas, mas.Length - 2);
                    i -= 2;
                    break;

                case "/":
                    result = (double.Parse(mas[i - 2]) / double.Parse(mas[i - 1])).ToString();
                    mas[i - 2] = result;
                    for (int j = i - 1; j < mas.Length - 2; j++)
                        mas[j] = mas[j + 2];
                    Array.Resize(ref mas, mas.Length - 2);
                    i -= 2;
                    break;


                case "^":
                    result = (Math.Pow(double.Parse(mas[i - 2]), double.Parse(mas[i - 1]))).ToString();
                    mas[i - 2] = result;
                    for (int j = i - 1; j < mas.Length - 2; j++)
                        mas[j] = mas[j + 2];
                    Array.Resize(ref mas, mas.Length - 2);
                    i -= 2;
                    break;


            }
        return double.Parse(mas[0]);
    }






    //Метод возвращает приоритет оператора
    static private byte GetPriority(string s)
    {
        switch (s)
        {
            case "√": return 0;
            case "s": return 1;
            case "c": return 2;
            case "l": return 3;
            case "(": return 4;
            case ")": return 5;
            case "+": return 6;
            case "-": return 7;
            case "*": return 8;
            case "/": return 9;
            case "^": return 10;
            default: return 11;
        }
    }
    //Метод возвращает true, если проверяемый символ - оператор
    static private bool IsOperator(char с)
    {
        if (("+-/*^()".IndexOf(с) != -1))
            return true;
        return false;
    }

    static private bool IsFunction(string с)
    {
        if (("√".IndexOf(с) != -1)) return true;
        if (("s".IndexOf(с) != -1)) return true;
        if (("c".IndexOf(с) != -1)) return true;
        if (("l".IndexOf(с) != -1)) return true;
        return false;
    }

    //Метод возвращает true, если проверяемый символ - разделитель ("пробел" или "равно")
    static private bool IsDelimeter(char c)
    {
        if ((" =".IndexOf(c) != -1))
            return true;
        return false;
    }

    static private string сonvertString(string str)
    {
        string newString = "";

        foreach(var c in str.Split(" ")){
            switch (c)
            {
                case "log":
                    newString += "l ";
                    break;
                case "sin":
                    newString += "s ";
                    break;
                case "cos":
                    newString += "c ";
                    break;
                case "sqrt":
                    newString += "√ ";
                    break;
                default:
                    newString += c + " ";
                    break;

            }
        }

        return newString;
    }
}