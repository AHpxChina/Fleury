using System;
using System.Text.Json.Serialization;
using Fleury.Determine;
using Fleury.Determine.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Fleury.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = JsonConvert.SerializeObject(new[]
            {
                new
                {
                    awd = "awd"
                }
            });

            Console.WriteLine(json);
            Console.WriteLine((json).IsJObject());
            Console.WriteLine((json).IsJson());
            Console.WriteLine((json).IsJArray());
        }
    }
}