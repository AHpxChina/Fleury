using System;
using Fleury.Determine;
using Fleury.Determine.Text;

namespace Fleury.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("".ThrowIf(s => s.IsEmpty(), new Exception("Test")));
        }
    }
}