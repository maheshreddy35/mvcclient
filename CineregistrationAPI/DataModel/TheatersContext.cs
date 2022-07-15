using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CineregistrationAPI.DataModel
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

        public virtual DbSet<Register> Registers { get; set; }

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

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.Phoneno)
                    .HasName("PK__Register__960E13C6CA3788BE");

                entity.ToTable("Register");

                entity.Property(e => e.Phoneno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phoneno");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
