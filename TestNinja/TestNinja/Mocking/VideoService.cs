using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IFileReader _fileReader;
        private readonly IVideoRepository _videoRepository;

        public VideoService(IFileReader fileReader, IVideoRepository videoRepository)
        {
            _fileReader = fileReader;
            _videoRepository = videoRepository;
        }
        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null) return "Error parsing the video";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videosId = new List<int>();
            var videos = _videoRepository.GetUnprocessedVideos();            
            foreach (var v in videos)
            {
                videosId.Add(v.Id);
            }

            return String.Join(",", videosId);
            
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }
}
