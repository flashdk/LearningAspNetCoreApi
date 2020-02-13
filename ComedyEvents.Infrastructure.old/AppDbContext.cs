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

        public DbSet<Event> Events { get; set; }
        public DbSet<Comedian> Comedian { get; set; }
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Comedian>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Events.Venue");
            });

            modelBuilder.Entity<Gigs>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.ComedianId });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Comedian)
                    .WithMany(p => p.Gigs)
                    .HasForeignKey(d => d.ComedianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gigs_Gigs.Comedian");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Gigs)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gigs_Gigs.Event");
            });

            modelBuilder.Entity<Venues>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }

    }
}
