using Microsoft.VisualStudio.TestTools.UnitTesting;
using m3t2;
using System;
using System.Collections.Generic;
using System.Text;

namespace m3t2.Tests
{
    [TestClass()]
    public class StrToIntTests
    {
        [TestMethod()]
        public void DoParseTest_Letters_ErrorReturned()
        {
            StrToInt strToInt = new StrToInt();
            while (1 == 1)
            {
                Console.WriteLine("Please enter your string");
                string str = Console.ReadLine();
                try
                {
                    int outputInt = strToInt.DoParse(str);
                    Console.WriteLine(outputInt);
                }
                catch
                {
                    Console.WriteLine("Exception in test programm");
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