using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ComedyEvents.Domain.Models
{
    public partial class APIComedyContext : DbContext
    {
        public APIComedyContext()
        {
        }

        public APIComedyContext(DbContextOptions<APIComedyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comedian> Comedian { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Gig> Gig { get; set; }
        public virtual DbSet<Venue> Venue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("User ID=sa;password=Eustache24;server=DESKTOP-6V218SJ;Initial Catalog=APIComedy;Integrated security=true;Connect Timeout=30;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comedian>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                //entity.HasOne(d => d.Venue)
                //    .WithMany(p => p.Event)
                //    .HasForeignKey(d => d.VenueId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Events_Events.Venue");
            });

            modelBuilder.Entity<Gig>(entity =>
            {
                entity.HasIndex(e => new { e.ComedianId, e.EventId })
                    .HasName("IX_Gig")
                    .IsUnique();

                //entity.HasOne(d => d.Comedian)
                //    .WithMany(p => p.Gig)
                //    .HasForeignKey(d => d.ComedianId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Gigs_Gigs.Comedian");

                //entity.HasOne(d => d.Event)
                //    .WithMany(p => p.Gig)
                //    .HasForeignKey(d => d.EventId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Gigs_Gigs.Event");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
