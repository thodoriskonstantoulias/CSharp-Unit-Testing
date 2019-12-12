using Microsoft.EntityFrameworkCore;
using System;

namespace TestNinja.Mocking
{
    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get;  set; }
    }
}