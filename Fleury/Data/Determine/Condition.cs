namespace Fleury.Data.Determine
{
    public class Condition<TC, TL>
    {
        public TC Value { get; set; }

        internal TL Last { get; set; }

        internal bool? HasLastValue { get; set; }

        internal Condition(TC value = default, TL last = default)
        {
            Value = value;
            Last = last;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}