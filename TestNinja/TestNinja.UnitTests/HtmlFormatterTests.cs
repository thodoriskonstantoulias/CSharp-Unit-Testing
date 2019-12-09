using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldReturnStringWithStrongElement()
        {
            var htmlFormat = new HTMLFormatter();

            var result = htmlFormat.FormatAsBold("abc");

            //Specific assertion
            Assert.That(result, Is.EqualTo("<strong>abc</strong>"));

            //More general assertion
            Assert.That(result, Does.StartWith("<strong>"));

            //Better 
            Assert.That(result, Does.Contain("abc"));
        }
    }
}
