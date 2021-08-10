using System;
using Fleury.Determine;
using Fleury.Determine.Text;

namespace Fleury.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("a".IsInteger());
            Console.WriteLine("1".IsInteger());
            Console.WriteLine("22222222222222222222222222222123123123123123123".IsInteger());
            Console.WriteLine("-222222222222.22222222222222222123123123123123123".IsInteger());
        }
    }
}