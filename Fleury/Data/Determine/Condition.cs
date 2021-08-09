namespace Fleury.Data.Determine
{
    public class Condition<TSource, TLast>
    {
        public TSource Value { get; set; }

        internal TLast Last { get; set; }

        internal bool? HasLastValue { get; set; }

        internal Condition(TSource value = default, TLast last = default)
        {
            Value = value;
            Last = last;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        /// <summary>
        /// basically equals to call Is method
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static implicit operator Condition<TSource, TLast>(TSource c)
        {
            return new(c);
        }
        
        public static implicit operator TSource(Condition<TSource, TLast> c)
        {
            return c.Value;
        }
    }
}