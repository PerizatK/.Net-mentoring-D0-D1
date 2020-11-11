using System;
using m3t2;

namespace m3t2Execute
{
    class Program
    {
        static void Main(string[] args)
        {
            StrToInt strToInt = new StrToInt();
            while (1 == 1)
            {
                Console.WriteLine("Please enter your string");
                string str = Console.ReadLine();
                try
                {
                    strToInt.DoParse(str, out int outputNum);
                    Console.WriteLine("Parsed: " + outputNum);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("One more time? Press Yes: Y, No: N");
                if (Console.ReadLine() == "N")
                {
                    break;
                }

            }
        }
    }
}
