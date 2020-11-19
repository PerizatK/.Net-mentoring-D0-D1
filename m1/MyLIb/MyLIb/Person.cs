using System;

namespace MyLIb
{
    public class Person
    {
        public readonly string _name;
        public DateTime date;

        public Person(string name)
        {
            _name = name;
            date = DateTime.Now;
        }

        public string GetGreetingForName()
        {
            return $"{date:T} Hello, {_name}";
        }
    }
}
