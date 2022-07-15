using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CineplusAPI.DataModel
{
    public partial class TheatersContext : DbContext
    {
        public TheatersContext()
        {
        }

        public TheatersContext(DbContextOptions<TheatersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Cinema> Cinemas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Theaters;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Movie)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("movie");

                entity.Property(e => e.NoOfTickets).HasColumnName("No_of_Tickets");

                entity.Property(e => e.Phno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phno");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Theater)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("theater");

                entity.Property(e => e.Time)
                    .HasColumnType("date")
                    .HasColumnName("time_");
            });

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.ToTable("cinema");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Movie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("movie");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Theatername)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("theatername");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
