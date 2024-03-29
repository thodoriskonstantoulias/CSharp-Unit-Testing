﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.Mocking
{
    public class OrderService
    {
        private readonly IStorage _storage;

        public OrderService(IStorage storage)
        {
            _storage = storage;
        }
        public int PlaceOrder(Order order)
        {
            int orderId = _storage.Store(order);

            return orderId;
        }
    }
}
