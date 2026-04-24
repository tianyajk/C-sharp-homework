using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace work_3_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello world");

            PrimeTask task = new PrimeTask();
            int batchSize = 10;

            Console.WriteLine("请输入起始数字：");
            int firstNumber = task.input();

            Console.WriteLine("请输入结束数字：");
            int lastNumber = task.input();

            for (int i = firstNumber; i <= lastNumber; i++)
            {
                task.checkNumber(i);
            }

            PrimeTask.PrintListByBatch(task.array, batchSize);
            
        }
    }

    class PrimeTask
    {
        public List<int> array = new List<int>();

        public bool isPrime(int num)
        {
            if (num <= 1) return false;

            int limit = (int)Math.Sqrt(num);
            for (int i = 2; i <= limit; i++)
            {
                if (num % i == 0) return false;
            }

            return true;
        }

        public void checkNumber(int num)
        {
            if (isPrime(num))
            {
                array.Add(num);
            }
        }

        public int input()
        {
            while (true)
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int result))
                {
                    return result;
                }
                Console.WriteLine("输入无效，请输入整数：");
            }
        }

        public static void PrintListByBatch(List<int> list, int batchSize)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("List为空，无内容可输出！");
                return;
            }

            int currentCount = 0;
            foreach (int num in list)
            {
                Console.Write(num + " ");
                currentCount++;

                if (currentCount % batchSize == 0)
                {
                    Console.WriteLine();
                }
            }

            if (currentCount % batchSize != 0)
            {
                Console.WriteLine();
            }
        }
    }
}
