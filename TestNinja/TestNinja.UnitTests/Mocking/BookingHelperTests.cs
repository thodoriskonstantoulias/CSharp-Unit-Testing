using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;
using System.Linq;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class BookingHelperTests
    {
        private Booking _booking;
        private Mock<IBookingRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _booking = new Booking { Id = 2, ArrivalDate = ArriveOn(2017, 1, 15), DepartureDate = DepartOn(2017, 1, 20), Reference = "a" };

            _repository = new Mock<IBookingRepository>();
            _repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
            {
                _booking
            }.AsQueryable());
        }
        [Test]
        public void OverlappingBookingsExist_BookingStartAndFinishBeforeExistingBooking_ReturnsEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_booking.ArrivalDate,days: 2),
                DepartureDate = Before(_booking.ArrivalDate),
                Reference = "a"
            }, _repository.Object);

            Assert.That(result, Is.Empty);
        }
        [Test]
        public void OverlappingBookingsExist_BookingStartBeforeAndFinishInTheMiddleOfExistingBooking_ReturnsReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_booking.ArrivalDate),
                DepartureDate = After(_booking.ArrivalDate),
                Reference = "a"
            }, _repository.Object);

            Assert.That(result, Is.EqualTo(_booking.Reference));
        }

        private DateTime Before(DateTime dateTime,int days = 1)
        {
            return dateTime.AddDays(-days);
        }
        private DateTime After(DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }

        private DateTime ArriveOn(int year,int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }
        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
    }
}
