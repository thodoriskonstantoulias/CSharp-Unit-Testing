using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.Mocking
{
    class Program
    {
        public static void Main()
        {
            //var service = new VideoService();

            //Dependency injection via method parameters
            //var title = service.ReadVideoTitle(new FileReader());

            //Dependency injection via properties
            //var title = service.ReadVideoTitle();

            //Dependency injection via constructor
            var service = new VideoService(new FileReader());
            var title = service.ReadVideoTitle();
        }
    }
}
