using System;

namespace MyLIb
{
    public class Person
    {
        public string GetValue(string name)
        {
            DateTime now = DateTime.Now;
            return $"{now:T} Hello, {name}";
        }


    }
}
