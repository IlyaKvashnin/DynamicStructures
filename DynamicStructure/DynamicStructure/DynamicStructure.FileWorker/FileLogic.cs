using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.FileWorker
{
    public class FileLogic
    {
        public const string PathToGeneratedData = "../../../DynamicStructure.FileWorker/stack115kk.txt";
        public const string PathToTimeFile = "../../../DynamicStructure.FileWorker/stack_time115kk.txt";
        public const string PathToMemoryFile = "../../../DynamicStructure.FileWorker/stack_memory115kk.txt";

        public static string[] ReadFile(string pathToFile)
        {
            return File.ReadAllLines(pathToFile);
        }

        public static void WriteFile(string pathToFile, BigInteger countOperations )
        {
            FileGenerator fileGenerator = new FileGenerator();
            File.AppendAllText(pathToFile, fileGenerator.GenerateFile(countOperations).ToString());
        }
    }
}
