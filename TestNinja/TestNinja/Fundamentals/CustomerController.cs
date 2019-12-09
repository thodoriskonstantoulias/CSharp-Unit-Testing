using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.Fundamentals
{
    public class CustomerController
    {
        public ActionResult GetCustomer(int id)
        {
            if (id == 0) return new NotFound();
            return new Ok();
        }
    }

    public class Ok : ActionResult
    {
    }

    public class NotFound : ActionResult
    {
    }

    public class ActionResult
    {
    }
}
