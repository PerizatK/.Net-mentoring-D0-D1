using System;

namespace MyLIb
{
    public static class PersonUtils
    {

        public static string GetGreetingForName(string name)
        {
            DateTime now = DateTime.Now;
            return $"{now:T} Hello, {name}";
        }


    }
}
