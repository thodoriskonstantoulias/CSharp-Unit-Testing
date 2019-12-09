using System;

namespace TestNinja.Fundamentals
{
    public class Reservation
    {
        public User MadeBy { get; set; }
        
        public bool CanBeCancelled(User user)
        {
            if (user.IsAdmin) return true;
            if (MadeBy == user) return true;
            return false;
        }
    }
}
