using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class DemeritPointsCalculatorTests
    {
        [Test]
        public void CalculateDemeritPoints_NegativeSpeed_ThrowsOutOfRangeException()
        {
            DemeritPointsCalculator demerit = new DemeritPointsCalculator();

            Assert.That(() => demerit.CalculateDemeritPoints(-5), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_BelowSpeedLimit_ReturnsZero()
        {
            DemeritPointsCalculator demerit = new DemeritPointsCalculator();

            var result = demerit.CalculateDemeritPoints(40);

            Assert.That(result,Is.EqualTo(0));
        }

        [Test]
        [TestCase(100,7)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_AboveSpeedLimit_ReturnsDemeritPoints(int speed,int expectedResult)
        {
            DemeritPointsCalculator demerit = new DemeritPointsCalculator();

            var result = demerit.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
