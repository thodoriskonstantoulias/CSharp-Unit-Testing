//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    //[TestClass]
    [TestFixture]
    public class ReservationTests
    {
        //[TestMethod]
        //public void CanBeCancelled_UserIsAdmin_ReturnsTrue()
        //{
        //    User user = new User() { IsAdmin = true};
        //    Reservation reservation = new Reservation();

        //    var result = reservation.CanBeCancelled(user);

        //    Assert.IsTrue(result);
        //}

        //[TestMethod]
        //public void CanBeCancelled_UserIsCreator_ReturnsTrue()
        //{
        //    User user = new User();           
        //    Reservation reservation = new Reservation();
        //    reservation.MadeBy = user;

        //    var result = reservation.CanBeCancelled(user);

        //    Assert.IsTrue(result);
        //}

        //[TestMethod]
        //public void CanBeCancelled_UserIsDifferent_ReturnsFalse()
        //{
        //    User user = new User();
        //    Reservation reservation = new Reservation();

        //    var result = reservation.CanBeCancelled(user);

        //    Assert.IsFalse(result);
        //}

        //Refactoring for running NUnit Tests

        [Test]
        public void CanBeCancelled_UserIsAdmin_ReturnsTrue()
        {
            User user = new User() { IsAdmin = true };
            Reservation reservation = new Reservation();

            var result = reservation.CanBeCancelled(user);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelled_UserIsCreator_ReturnsTrue()
        {
            User user = new User();
            Reservation reservation = new Reservation();
            reservation.MadeBy = user;

            var result = reservation.CanBeCancelled(user);

            //Assert.IsTrue(result);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelled_UserIsDifferent_ReturnsFalse()
        {
            User user = new User();
            Reservation reservation = new Reservation();

            var result = reservation.CanBeCancelled(user);

            Assert.IsFalse(result);
        }
    }
}
