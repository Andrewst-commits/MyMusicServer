using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
           Database.EnsureDeleted();
           Database.EnsureCreated();
        }

        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<User> Users { get; set; }

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

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate)
                    .IsRequired();
        
                entity.HasMany(c => c.Users)
                      .WithMany(c => c.Performers)
                      .UsingEntity(j => j.ToTable("UserPerformerRealations"));
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("Song");

                entity.HasIndex(e => e.PerformerId, "IX_Song_PerformerId");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DurationMs)
                    .IsRequired();

                entity.Property(e => e.ProductionDate)
                    .IsRequired();

                entity.Property(e => e.PerformerNickName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Performer)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.PerformerId)
                    .HasConstraintName("SongsPerformer");

                entity.HasMany(d => d.Users)
                    .WithMany(d => d.Songs)
                    .UsingEntity(j => j.ToTable("UserSongRealations"));
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate)
                    .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    
            
    }
}
