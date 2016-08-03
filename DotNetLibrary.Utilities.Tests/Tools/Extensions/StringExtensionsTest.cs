using DotNetLibrary.Utilities.Tools.Extensions;
using NUnit.Framework;

namespace DotNetLibrary.Utilities.Tests.Tools.Extensions
{
    public class StringExtensionsTest
    {

        [Test]
        public void TestIsNullOrWhiteSpace()
        {
            string myString = null;
            // ReSharper disable once ExpressionIsAlwaysNull
           Assert.That(myString.IsNullOrWhiteSpace(), Is.True );
        }

        [Test]
        public void IsParsableAsValidMsSqlServerDateTest1()
        {
            string someString = "12/09/9999 12:23:55";
            bool result = someString.IsParsableAsValidMsSqlServerDate();
            Assert.That(result, Is.True);
        }
    }
}
