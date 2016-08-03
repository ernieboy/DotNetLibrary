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
    }
}
