using System;
using Fleury.Determine;
using Fleury.Determine.Text;

namespace Fleury.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //scenario
            var txt = "".Is()
                .Empty()
                .Throw(new Exception("Invalid value"));

            Console.WriteLine(txt);
        }
    }
}