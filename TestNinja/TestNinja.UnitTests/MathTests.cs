using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        //We use the SetUp attribute to call a method before each test executes - common code added here
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnsSum()
        {
            var result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_FirstIsGreater_ReturnsFirst()
        {
            var result = _math.Max(2, 1);

            Assert.That(result, Is.EqualTo(2));
        }
        [Test]
        public void Max_SecondIsGreater_ReturnsSecond()
        {
            var result = _math.Max(1, 3);

            Assert.That(result, Is.EqualTo(3));
        }
        [Test]
        public void Max_ArgumentsAreEqual_ReturnsSameArgument()
        {
            var result = _math.Max(3, 3);

            Assert.That(result, Is.EqualTo(3));
        }
    }
}
