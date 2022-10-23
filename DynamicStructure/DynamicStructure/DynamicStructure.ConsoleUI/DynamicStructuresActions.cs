using DynamicStructure.DynamicStructure.Core.Third;
using DynamicStructure.DynamicStructure.Core.Third.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.ConsoleUI
{
    public class DynamicStructuresActions
    {
        public static void PrintTastQueue()
        {
            ConsoleHelper.ClearScreen();

            Bank ThomastonBankandTrust = new Bank();
            // create a customer
            BankCustomer JP = new BankCustomer("J P Morgan", Bank.BankingActivity.deposit.ToString(), 335445, 30000);
            // add the customer to the TellerLine
            ThomastonBankandTrust.TellerLine.Enqueue(JP);
            BankCustomer Butch = new BankCustomer("Butch Cassidy", Bank.BankingActivity.transferFunds.ToString(), 555445, 3500);
            BankCustomer Sundance = new BankCustomer("Sundance Kid", Bank.BankingActivity.withdrawl.ToString(), 555444, 3500);
            BankCustomer John = new BankCustomer("John Dillinger", Bank.BankingActivity.withdrawl.ToString(), 12345, 2000);
            ThomastonBankandTrust.TellerLine.Enqueue(Sundance);
            ThomastonBankandTrust.TellerLine.Enqueue(Butch);
            ThomastonBankandTrust.TellerLine.Enqueue(John);

            ThomastonBankandTrust.QueuePeek(ThomastonBankandTrust.TellerLine);
            // View the queue using a copy 
            ThomastonBankandTrust.QueueContentsCopy(ThomastonBankandTrust.TellerLine);
            // view the queue through enumeration 
            ThomastonBankandTrust.QueueContentsEnum(ThomastonBankandTrust.TellerLine);

            Console.WriteLine("Count of items in queue after copy & enum :" + ThomastonBankandTrust.TellerLine.Count.ToString());
            do
            {
                BankCustomer nextInLine = new BankCustomer();
                nextInLine = (BankCustomer)ThomastonBankandTrust.TellerLine.Dequeue();
                ThomastonBankandTrust.ProcessCustomerRequest(nextInLine);
            } while (ThomastonBankandTrust.TellerLine.Count != 0);

        }

        public static void PrintTaskTree()
        {
            ConsoleHelper.ClearScreen();
            var trunk = Trees.MainDecisionTree();

            var john = new Trees.Client()
            {
                Name = "John Doe",
                IsLoanNeeded = true,
                Income = 45000,
                YearsInJob = 4,
                UsesCreditCard = true,
                CriminalRecord = false
            };

            trunk.Evaluate(john);
        }

        public static void PrintTaskStack()
        {
            ConsoleHelper.ClearScreen();
            var path = "../../../DynamicStructure.Core/Third/matrix.txt"; //путь
            var sizeOfMatrix = File.ReadAllLines(path); //Считывание всех строк из файла
            var matrica = new int[sizeOfMatrix.Length, sizeOfMatrix[0].Split(' ').Length]; //Инициализация двумерного массива
            var matrixSize = sizeOfMatrix.Length; //Размер матрицы
            matrica = ShortestPathFinder.FillingMatrix(sizeOfMatrix, matrica);//Заполнение матрицы
            ShortestPathFinder matrix = new ShortestPathFinder(matrica, matrixSize);

            matrix.Dijkstra(matrica, 0);
        }

        public static void PrintTaskList()
        {
            ConsoleHelper.ClearScreen();
            Console.WriteLine($"Main Thread Started");
            List<CreditCard> creditCards = CreditCard.GenerateCreditCards(10);
            Console.WriteLine($"Credit Card Generated : {creditCards.Count}");

            List.ProcessCreditCards(creditCards);

            Console.WriteLine($"Main Thread Completed");
        }
    }
}
