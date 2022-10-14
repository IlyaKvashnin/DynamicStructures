using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.Test
{
    internal class FileGenerator
    {
        /// <summary>
        /// Метод для генерации данных для пушей
        /// </summary>
        /// <param name="countWords">Количество слов, которые будут сгенерированы</param>
        /// <param name="lengthLetters">Длина слова</param>
        /// <param name="countNumbers">Количество чисел, которые будут сгенерированы</param>
        /// <param name="maxNumber">Предельное число для рандомайзера</param>
        /// <returns></returns>
        private string[] generatePushData(int countWords,int lengthLetters, int countNumbers, int maxNumber)
        {
            StringBuilder strItems = new StringBuilder();
            // Создаем массив букв, которые мы будем использовать.
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

            // Создаем генератор случайных чисел.
            Random rand = new Random();

            // Делаем слова.
            for (int i = 1; i <= countWords; i++)
            {
                // Сделайте слово.
                string word = "";
                for (int j = 1; j <= lengthLetters; j++)
                {
                    // Выбор случайного числа для выбора буквы из массива букв.
                    int letter_num = rand.Next(0, letters.Length - 1);

                    // Добавить букву.
                    word += letters[letter_num];
                }

                // Добавьте слово в список.
                strItems.Append(word);
                strItems.Append(" ");
            }

            for (int i = 0; i < countNumbers; i++)
            {
                strItems.Append(rand.Next(0,maxNumber).ToString());
                if ((i != countNumbers - 1))
                {
                    strItems.Append(" ");
                }

            }

            return strItems.ToString().Split(" ");
        }

        public StringBuilder GenerateFile(int countOperation)
        {
            StringBuilder sb = new StringBuilder();

            Random rand = new Random();

            string[] data = generatePushData((int)(countOperation / 1.5), 10, countOperation, 999); ;

            for (int i = 0; i < countOperation; i++)
            {
                int value = rand.Next(1, 5);
                if (value == 1)
                {
                    sb.Append("1,");
                    sb.Append(data[i]);
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(value.ToString());
                    sb.Append(" ");
                }
            }
            return sb;
        }
    }
}
