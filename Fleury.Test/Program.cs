using System;
using Fleury.Determine;
using Fleury.Determine.Text;

namespace Fleury.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("127.0.0.1".IsHost());
            Console.WriteLine("127.0.0.1:2333".IsHost());
            Console.WriteLine("127.0.0.1:12333".IsHost());
            Console.WriteLine("1227.0.0.1:12333".IsHost());
            Console.WriteLine("localhost:12333".IsHost());
            Console.WriteLine("127.0.0.1:2a333".IsHost());
        }
    }
}