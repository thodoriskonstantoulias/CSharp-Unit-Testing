using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IsZero_ReturnsNotFound()
        {
            var customer = new CustomerController();

            var result = customer.GetCustomer(0);

            //Not found
            Assert.That(result, Is.TypeOf<NotFound>());
            //Not found or one of its derivatives
            //Assert.That(result, Is.InstanceOf<NotFound>());
        }
    }
}
