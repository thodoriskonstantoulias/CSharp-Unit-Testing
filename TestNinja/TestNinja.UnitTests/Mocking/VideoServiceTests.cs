using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class VideoServiceTests
    {
        private Mock<IFileReader> _mockFileReader;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            _mockFileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_mockFileReader.Object);
        }
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnsErrorMessage()
        {
            //Using Moc for testing methods with dependencies
            
            _mockFileReader.Setup(fr => fr.Read("video.txt")).Returns("");            

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
