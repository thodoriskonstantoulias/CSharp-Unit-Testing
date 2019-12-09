using System;

namespace TestNinja.Fundamentals
{
    public class Reservation
    {
        public User MadeBy { get; set; }
        
        public bool CanBeCancelled(User user)
        {
            //if (user.IsAdmin || MadeBy == user) return true;
            //return false;

            //Refactoring and check with tests if we broke anything
            return (user.IsAdmin || MadeBy == user);
        }
    }
}
