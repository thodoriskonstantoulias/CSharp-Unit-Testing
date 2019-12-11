using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestNinja.Mocking
{
    public class FileReader : IFileReader
    {
        public string Read(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
}
