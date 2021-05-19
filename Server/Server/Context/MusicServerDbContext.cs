using Microsoft.EntityFrameworkCore;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Context
{
    public partial class MusicServerDbContext : DbContext
    {
        public MusicServerDbContext()
        {
        }

        public MusicServerDbContext(DbContextOptions<MusicServerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Listening> Listenings { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=laptop-o5fg9v0m\\sqlexpress;Database=CodeFirstDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Listening>(entity =>
            {
                entity.HasKey(e => new { e.PerformersPerformerId, e.UsersUserId });

                entity.ToTable("Listening");

                entity.HasIndex(e => e.UsersUserId, "IX_Listening_UsersUserId");

                entity.HasOne(d => d.PerformersPerformer)
                    .WithMany(p => p.Listenings)
                    .HasForeignKey(d => d.PerformersPerformerId);

                entity.HasOne(d => d.UsersUser)
                    .WithMany(p => p.Listenings)
                    .HasForeignKey(d => d.UsersUserId);
            });

            modelBuilder.Entity<Performer>(entity =>
            {
                entity.ToTable("Performer");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("Song");

                entity.HasIndex(e => e.PerformerId, "IX_Song_PerformerId");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Performer)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.PerformerId)
                    .HasConstraintName("SongsPerformer");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    
            
    }
}
