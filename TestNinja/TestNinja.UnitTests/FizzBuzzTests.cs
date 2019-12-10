using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class FizzBuzzTests
    {
        [Test]
        public void GetOutput_NumberDividesByThreeAndFive_ReturnsFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("Fizz Buzz"));
        }
        [Test]
        public void GetOutput_NumberDividesByThree_ReturnsFizz()
        {
            var result = FizzBuzz.GetOutput(6);

            Assert.That(result, Is.EqualTo("Fizz"));
        }
        [Test]
        public void GetOutput_NumberDividesByFive_ReturnsBuzz()
        {
            var result = FizzBuzz.GetOutput(10);

            Assert.That(result, Is.EqualTo("Buzz"));
        }
        [Test]
        public void GetOutput_NumberDoesNotDividesByThreeOrFive_ReturnsNumber()
        {
            var result = FizzBuzz.GetOutput(11);

            Assert.That(result, Is.EqualTo("11"));
        }
    }
}
