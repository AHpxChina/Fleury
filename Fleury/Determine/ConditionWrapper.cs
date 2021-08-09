using System;
using Fleury.Data.Determine;

namespace Fleury.Determine
{
    public static class ConditionWrapper
    {
        public static Condition<string, string> Is(this string s)
        {
            return new()
            {
                Value = s,
                Last = null,
                HasLastValue = false
            };
        }
    }
}