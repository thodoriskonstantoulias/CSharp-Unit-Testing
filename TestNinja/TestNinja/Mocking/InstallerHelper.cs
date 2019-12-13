using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private readonly IFileDownloader _fileDownloader;
        private string _setupDestionationFile;
        public InstallerHelper(IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
        }
        public bool DownloadInstaller(string customerName,string installerName)
        {           
            try
            {
                _fileDownloader.DownloadFile(string.Format("http://example.com/{0}/{1}", customerName, installerName), _setupDestionationFile);
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}
