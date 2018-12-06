using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment.WebApi.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Song> Song { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:simran-sqlserver2.database.windows.net;Database=ASP1Data;User ID=Simranjit97;Password=Manthan97");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.ArtistId).HasColumnName("Artist_Id");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.SongId).HasColumnName("Song_Id");

                entity.Property(e => e.Bitrate).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Genere).HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Size).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.ArtistNavigation)
                    .WithMany(p => p.Song)
                    .HasForeignKey(d => d.Artist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Song__Artist__4BAC3F29");
            });
        }
    }
}
