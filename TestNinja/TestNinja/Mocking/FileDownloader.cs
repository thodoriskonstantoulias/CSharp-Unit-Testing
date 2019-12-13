using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TestNinja.Mocking
{
    public class FileDownloader : IFileDownloader
    {
        public void DownloadFile(string url, string path)
        {
            using var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }
}
