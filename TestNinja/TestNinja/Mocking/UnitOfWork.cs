using System;
using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public class UnitOfWork
    {
        public UnitOfWork()
        {
        }

        public IQueryable<Booking> Query<T>()
        {
            return new List<Booking>().AsQueryable();
        }
    }
}