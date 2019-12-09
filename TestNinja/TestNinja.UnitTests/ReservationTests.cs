using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelled_UserIsAdmin_ReturnsTrue()
        {
            User user = new User() { IsAdmin = true};
            Reservation reservation = new Reservation();

            var result = reservation.CanBeCancelled(user);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelled_UserIsCreator_ReturnsTrue()
        {
            User user = new User();           
            Reservation reservation = new Reservation();
            reservation.MadeBy = user;

            var result = reservation.CanBeCancelled(user);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelled_UserIsDifferent_ReturnsFalse()
        {
            User user = new User();
            Reservation reservation = new Reservation();

            var result = reservation.CanBeCancelled(user);

            Assert.IsFalse(result);
        }
    }
}
