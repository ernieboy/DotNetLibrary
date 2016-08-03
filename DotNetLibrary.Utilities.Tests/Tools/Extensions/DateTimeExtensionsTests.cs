using System;
using DotNetLibrary.Utilities.Tools.Extensions;
using NUnit.Framework;

namespace DotNetLibrary.Utilities.Tests.Tools.Extensions
{
    public class DateTimeExtensionsTests
    {
        [Test]
        public void ParseBritishDateFromShortAmericanDateStringTest()   
        {
            DateTime parsed = DateTime.MinValue;
            parsed = parsed.ParseBritishDateFromShortAmericanDateString("11/19/08");
            Assert.That(parsed != DateTime.MinValue);
            Assert.That(parsed.Year, Is.EqualTo(2008));
        }

        [Test]
        public void ParseBritishDateFromAmericanDateStringTest()
        {
            DateTime parsed = DateTime.MinValue;
            parsed = parsed.ParseBritishDateFromAmericanDateString("11/19/2008");
            Assert.That(parsed != DateTime.MinValue);
            Assert.That(parsed.Year, Is.EqualTo(2008));
        }

        [Test]
        public void ParseBritishDateFromStringTest()
        {
            DateTime parsed = DateTime.MinValue;
            parsed = parsed.ParseBritishDateFromString("19/11/2008");
            Assert.That(parsed != DateTime.MinValue);
            Assert.That(parsed.Year, Is.EqualTo(2008));
        }
    }
}
