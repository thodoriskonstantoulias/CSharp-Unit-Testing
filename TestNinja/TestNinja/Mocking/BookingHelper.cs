﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestNinja.Mocking
{
    public static class BookingHelper
    {
        public static string OverlappingBookingsExist(Booking booking, IBookingRepository bookingRepository)
        {
            if (booking.Status == "Cancelled") return string.Empty;

            var bookings = bookingRepository.GetActiveBookings(booking.Id);

            var overlappingBooking = bookings.FirstOrDefault(b =>
                                     booking.ArrivalDate >= b.ArrivalDate &&
                                     booking.ArrivalDate < b.DepartureDate ||
                                     booking.DepartureDate > b.ArrivalDate &&
                                     booking.DepartureDate <= b.DepartureDate);

            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }
    }
}
