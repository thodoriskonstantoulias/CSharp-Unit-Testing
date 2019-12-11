using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    class FakeFileReader : IFileReader
    {
        public string Read(string filename)
        {
            return "";
        }
    }
}
