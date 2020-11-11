using System;
using MyLIb;

namespace m1t1v1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i< args.Length; i++)
            {
                Person person = new Person();
                //Console.WriteLine($"Hello, {args[i]}");
                Console.WriteLine(person.GetValue(args[i]));
            }
            Console.ReadKey();
        }
    }
}
