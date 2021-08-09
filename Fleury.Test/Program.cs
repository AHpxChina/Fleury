using System;
using Fleury.Determine;
using Fleury.Determine.Text;

namespace Fleury.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!".Is().Empty().Value);
        }
    }
}