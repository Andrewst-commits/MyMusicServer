using Microsoft.EntityFrameworkCore;
using Server_nw.MusicApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication
{
    public partial class MusicServiceDbContext : DbContext
    {

        public MusicServiceDbContext()
        {

        }

        public MusicServiceDbContext(DbContextOptions<MusicServiceDbContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Band> Bands { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<Listener> Listeners { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Performer>(entity =>
            {
                entity.ToTable("Performer");
                
            });

            modelBuilder.Entity<Listener>(entity =>
            {
                entity.ToTable("Listener");
            });

            modelBuilder.Entity<Band>(entity =>
            {
                entity.ToTable("Band");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("Song");

                entity.HasOne(e => e.Album)
                    .WithMany(e => e.Songs)
                    .HasForeignKey(e => e.AlbumId)
                    .HasConstraintName("Album/Songs");

                entity.HasOne(e => e.Band)
                    .WithMany(e => e.Songs)
                    .HasForeignKey(e => e.UserId)
                    .HasConstraintName("Band/Songs");

                entity.HasOne(e => e.Performer)
                    .WithMany(e => e.Songs)
                    .HasForeignKey(e => e.UserId)
                    .HasConstraintName("Performer/Songs");

                entity.HasMany(d => d.Listeners)
                    .WithMany(d => d.Songs)
                    .UsingEntity(j => j.ToTable("ListenerSongLibrary"));
            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");

                entity.HasOne(e => e.Performer)
                    .WithMany(e => e.Albums)
                    .HasForeignKey(e => e.UserId)
                    .HasConstraintName("Performer/Albums");

                entity.HasOne(e => e.Band)
                    .WithMany(e => e.Albums)
                    .HasForeignKey(e => e.UserId)
                    .HasConstraintName("Band/Albums");

                entity.HasMany(d => d.Listeners)
                   .WithMany(d => d.Albums)
                   .UsingEntity(j => j.ToTable("ListenerAlbumLibrary"));
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



    }
}
