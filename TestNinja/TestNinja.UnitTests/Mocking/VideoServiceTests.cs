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
        private Mock<IVideoRepository> _repository;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            _mockFileReader = new Mock<IFileReader>();
            _repository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_mockFileReader.Object, _repository.Object);
        }
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnsErrorMessage()
        {
            //Using Moc for testing methods with dependencies
            
            _mockFileReader.Setup(fr => fr.Read("video.txt")).Returns("");            

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnsEmptyString()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }
        [Test]
        public void GetUnprocessedVideosAsCsv_SomeVideosAreProcessed_ReturnsStringWithIds()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>() 
            {
                new Video{Id = 1},
                new Video{Id = 2},
                new Video{Id = 3}
            });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
