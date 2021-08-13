using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Fleury.Extensions.Json;
using Fleury.Extensions.String;
using Newtonsoft.Json;
using Xunit;

namespace Fleury.UnitTest
{
    public class StringExtensionsShould
    {
        #region empty

        [Theory]
        [Trait("empty", nameof(IsEmpty))]
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
        [Trait("empty", nameof(IsEmpty1))]
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

        [Theory]
        [Trait("empty", nameof(IsNotEmpty))]
        [InlineData("a")]
        [InlineData("bawdawdawd")]
        [InlineData("cawdkljlj wdak wldj awlkdj alwkdj awldk jawd lkjawd lakjwd alwkd alwdkj ")]
        [InlineData(
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus urna elit, tempor eu suscipit sed, semper pharetra elit. In imperdiet elementum nulla, vitae fermentum velit feugiat et. Sed at tristique tortor, quis dictum augue. Mauris condimentum augue sit amet iaculis luctus. In faucibus ex et commodo consectetur. Integer vehicula diam vitae lorem malesuada consectetur. Aenean non laoreet elit. In sodales mi risus, eu venenatis tellus finibus sit amet. Phasellus eu purus lacinia ante faucibus faucibus. Suspendisse potenti. Suspendisse potenti. Vivamus suscipit interdum lorem id mollis. Nulla in pellentesque velit.")]
        public void IsNotEmpty(string s)
        {
            Assert.True(s.IsNotEmpty());
        }

        [Theory]
        [Trait("empty", nameof(IsNotEmpty1))]
        [InlineData(" ")]
        [InlineData("    ")]
        [InlineData("                    ")]
        [InlineData("                                       ")]
        public void IsNotEmpty1(string s)
        {
            Assert.True(s.IsNotEmpty(false));
        }

        [Theory]
        [Trait("empty", nameof(IsEmptyOrThrow))]
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
        public void IsEmptyOrThrow(string s)
        {
            if (s.IsEmpty())
            {
                var s1 = s.IsEmptyOrThrow(exception: new MyException("my"));

                Assert.Equal(s1, s);
            }
            else
            {
                Assert.Throws<MyException>(() => { _ = s.IsEmptyOrThrow(exception: new MyException("my")); });
            }
        }

        [Theory]
        [Trait("empty", nameof(IsNotEmptyOrThrow))]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("   ")]
        [InlineData("    ")]
        [InlineData("     ")]
        [InlineData("      ")]
        [InlineData("       ")]
        [InlineData("        ")]
        public void IsNotEmptyOrThrow(string s)
        {
            var s1 = s.IsNotEmptyOrThrow(true, exception: new MyException("my"));

            Assert.Equal(s1, s);
        }

        #endregion

        #region json

        [Fact]
        [Trait("json",nameof(IsJson))]
        public void IsJson()
        {
            var json = new
            {
                Test1 = "awd"
            }.ToJsonString();

            Assert.True(json.IsJson());
            Assert.True("{}".IsJson());
            Assert.True("[]".IsJson());
            Assert.False("{awd}".IsJson());
            Assert.False("[awd]".IsJson());
            Assert.False("awd".IsJson());
        }

        [Fact]
        [Trait("json",nameof(IsJsonOrThrow))]
        public void IsJsonOrThrow()
        {
            Assert.Throws<MyException>(() =>
            {
                _ = "awdaw".IsJsonOrThrow(new MyException("my"));
            });
        }

        [Fact]
        public void IsJObject()
        {
            var json = new
            {
                Test1 = "awd"
            }.ToJsonString();

            Assert.True(json.IsJObject());
            Assert.True(json.IsJson());
            Assert.False(json.IsJArray());
        }

        [Fact]
        public void IsJObjectOrThrow()
        {
            
        }
        
        [Fact]
        public void IsJArray()
        {
            var json = new[]
            {
                new
                {
                    Test1 = "awd"
                }
            }.ToJsonString();

            Assert.False(json.IsJObject());
            Assert.True(json.IsJson());
            Assert.True(json.IsJArray());
        }

        #endregion

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