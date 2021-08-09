using System;
using System.Runtime.Serialization;
using Fleury.Determine;
using Fleury.Determine.Text;
using Xunit;

namespace Fleury.UnitTest
{
    public class StringExtensionsShould
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void IndicateCorrectEmpty1(string s)
        {
            Assert.True(s.Is().Empty().Value);
        }
        
        [Theory]
        [InlineData("awd")]
        [InlineData(" ")]
        public void IndicateCorrectEmpty2(string s)
        {
            Assert.False(s.Is().Empty(false).Value);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("   ")]
        [InlineData("    ")]
        [InlineData("     ")]
        [InlineData("      ")]
        [InlineData("       ")]
        [InlineData("        ")]
        public void IndicateCorrectWhiteSpace1(string s)
        {
            Assert.True(s.Is().Empty().Value);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("   ")]
        public void ThrowException(string s)
        {
            Assert.Throws<MyException>(() =>
            {
                s.Is().Empty().Throw(new MyException("Test"));
            });
        }
        
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        public void ThrowException2(string s)
        {
            var a = s.Is().Empty().Throw(new MyException("test"));

            Assert.Equal(a, s);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("   ")]
        public void ThrowExceptionIf(string s)
        {
            Assert.Throws<MyException>(() =>
            {
                s.ThrowIf(s1 => s1.IsEmpty(), new MyException("Test"));
            });
        }
        
        
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        public void ThrowExceptionIf2(string s)
        {
            Assert.Throws<MyException>(() =>
            {
                s.ThrowIf(s1 => s1.Length == 1, new MyException("Test"));
            });
        }
        
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        public void ThrowExceptionIf3(string s)
        {
            var a = s.ThrowIf(s1 => s1.Length != 1, new MyException("Test"));

            Assert.Equal(a, s);
        }

        [Serializable]
        public class MyException : Exception
        {
            //
            // For guidelines regarding the creation of new exception types, see
            //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
            // and
            //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
            //

            public MyException()
            {
            }

            public MyException(string message) : base(message)
            {
            }

            public MyException(string message, Exception inner) : base(message, inner)
            {
            }

            protected MyException(
                SerializationInfo info,
                StreamingContext context) : base(info, context)
            {
            }
        }
    }
}