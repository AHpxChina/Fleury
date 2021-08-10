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
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("   ")]
        [InlineData("    ")]
        [InlineData("     ")]
        [InlineData("      ")]
        [InlineData("       ")]
        [InlineData("        ")]
        public void IsEmpty(string s)
        {
            Assert.True(s.IsEmpty());
        }
        
        [Theory]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("   ")]
        [InlineData("    ")]
        [InlineData("     ")]
        [InlineData("      ")]
        [InlineData("       ")]
        [InlineData("        ")]
        public void IsEmpty1(string s)
        {
            Assert.False(s.IsEmpty(false));
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