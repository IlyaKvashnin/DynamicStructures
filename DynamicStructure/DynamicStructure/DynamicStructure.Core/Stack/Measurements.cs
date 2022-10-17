using DynamicStructure.DynamicStructure.FileWorker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.Core.Stack
{
    public class Measurements
    {
        //Алгоритм тестирования:
        //здесь меняется (i / 100) - шаг через который пишутся данные
        //в filelogic меняются в константах приписывается количество на котором тестируется
        public void ExecuteMeasurements(string pathToFileData, string pathToFileMemory, string pathToFileTime)
        {
            List<string> outputDataMemory = new();
            outputDataMemory.Add(new string("Memory"));
            List<string> outputDataTime = new();
            outputDataTime.Add(new string("Time"));

            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            outputDataMemory.Add(ramCounter.RawValue.ToString());

            DynamicStructure.Core.Stack.Stack<string> stack = new DynamicStructure.Core.Stack.Stack<string>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var item in FileLogic.ReadFile(pathToFileData))
            {
                var items = item.Split(" ");
                for (int i = 0; i < items.Count(); i++)
                {

                    if (i % 2000000 == 0)
                    {
                        outputDataTime.Add(stopwatch.Elapsed.TotalMilliseconds.ToString());
                        outputDataMemory.Add(ramCounter.RawValue.ToString());
                    }
                    if (items[i].Contains(","))
                    {
                        stack.Push(items[i].Substring(items[i].IndexOf(",") + 1));
                    }
                    else
                    {
                        switch (items[i])
                        {
                            case "2":
                                stack.Pop();
                                break;
                            case "3":
                                stack.Top();
                                break;
                            case "4":
                                stack.IsEmpty();
                                break;
                            case "5":
                                stack.Print();
                                break;
                        }
                    }
                }
            }
            File.AppendAllLines(pathToFileMemory, outputDataMemory);
            File.AppendAllLines(pathToFileTime, outputDataTime);
            stopwatch.Stop();
        }

        //public void ExecuteMeasurementsTime(string pathToFile)
        //{
        //    Stopwatch stopwatch = new Stopwatch();
        //    stopwatch.Start();

        //    executeMeasurements(FileLogic.PathToGeneratedData);

        //    stopwatch.Stop();
        //    TimeSpan ts = stopwatch.Elapsed;
        //    File.AppendAllText(pathToFile, ts.TotalMilliseconds.ToString());
        //}

        //public void ExecuteMeasurementsMemory(string pathToFile)
        //{
            
        //    executeMeasurements(FileLogic.PathToGeneratedData);
        //    while (isWorking)
        //    {
                

        //        outputData.Add(ramCounter.NextValue().ToString());
        //    }
        //    File.AppendAllLines(pathToFile, outputData);
        //}
    }
}
