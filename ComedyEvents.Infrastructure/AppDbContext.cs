using System;
using Microsoft.EntityFrameworkCore;
//using ComedyEvents.Domain.Models;
using Microsoft.Extensions.Configuration;
using ComedyEvents.Domain.Models;

namespace ComedyEvents.Infrastructure
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<Comedian> Comedian { get; set; }
        public DbSet<Gig> Gig { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<User> User { get; set; }
    }
}
