using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ratingsAPI.DataModel
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

        public virtual DbSet<Movierating> Movieratings { get; set; }

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

            modelBuilder.Entity<Movierating>(entity =>
            {
                entity.HasKey(e => e.Movie)
                    .HasName("PK__movierat__0FDB8F016A6FEC87");

                entity.ToTable("movierating");

                entity.Property(e => e.Movie)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("movie");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Rating).HasColumnName("rating");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
