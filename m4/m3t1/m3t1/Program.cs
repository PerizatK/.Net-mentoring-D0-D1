using System;
using System.Transactions;

namespace m3t1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (1 == 1)
            {
                Console.WriteLine("Please enter your string");
                string str = Console.ReadLine();
                DoAnalyze(str);

                Console.WriteLine("One more time? Press Yes: Y, No: N");
                if (Console.ReadLine() == "N")
                {
                    break;
                }
            }
        }

        private static void DoAnalyze(string str)
        {
            try
            {
                if (str.Length == 0)
                {
                    throw new ArgumentException("Entered string is empty. Try one more time? Press Yes: Y, No: N");
                }
                Console.WriteLine($"First symbol is {str[0]}");
            }
            catch
            {
                Console.WriteLine("Entered string is empty");
            }
        }
    }

}
