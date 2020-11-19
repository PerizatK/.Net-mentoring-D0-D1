using System;
using MyLIb;

namespace m1t1v1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Person person = new Person(args[i]);
                Console.WriteLine("Person: " + person.GetGreetingForName());

                Console.WriteLine("PersonUtils: " + PersonUtils.GetGreetingForName(args[i]));
            }
            Console.ReadKey();
        }
    }
}
