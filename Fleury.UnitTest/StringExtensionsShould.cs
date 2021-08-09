using System;
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
    }
}