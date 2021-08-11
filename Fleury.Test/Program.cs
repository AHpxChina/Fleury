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
            Console.WriteLine("123456".Empty("123"));
            Console.WriteLine("a/b/d/c.awad".NormalizePath());
        }
    }
}