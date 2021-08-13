using System;
using Newtonsoft.Json;

namespace Fleury.Extensions.Json
{
    public static class JsonExtensions
    {
        public static string ToJsonString(this object source, Formatting formatting = Formatting.Indented, JsonSerializerSettings jsonSerializerSettings = null)
        {
            try
            {
                return JsonConvert.SerializeObject(source, formatting, jsonSerializerSettings);
            }
            catch (Exception e)
            {
                throw new JsonSerializationException($"Specific object {source} can't serialize to json!", e);
            }
        }
    }
}