using System;
using System.Text.Json.Serialization;
using Fleury.Extensions.String;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Fleury.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("11-22-33-44-55-66".SubStringAfterLast("-"));
            Console.WriteLine("11-22-33-44-55-66".SubStringAfterLast("-", false));
            Console.WriteLine("11-22-33-44-55-66".SubStringAfterLast("-", 1));
            Console.WriteLine("11-22-33-44-55-66".SubStringAfterLast("-", 1, false));
            Console.WriteLine("11-22-33-44-55-66".SubStringAfterLast("-", 2, false));
            Console.WriteLine("11-22-33-44-55-66".SubStringAfterLast("-", 3, false));
            Console.WriteLine("11-22-33-44-55-66".SubStringAfterLast("-", 4, false));
        }
    }
}