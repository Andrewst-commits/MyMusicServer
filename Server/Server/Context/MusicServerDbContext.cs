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
        public virtual DbSet<Account> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<LoginModel> Logins { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

           // string adminEmail = "admin@mail.ru";
           // string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { RoleId = 1, Name = adminRoleName };
            Role userRole = new Role { RoleId = 2, Name = userRoleName };

            Account adminUser = new Account 
            {
                UserId = Guid.NewGuid(),
                Name = "Andrew",
                Surname = "Stelmach",
                LastName = "Alex",
                BirthDate = DateTime.Now,
                IsDeleted = false,
              //  Login = adminEmail, 
              //  Password = adminPassword, 
                RoleId = adminRole.RoleId };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<Account>().HasData(new Account[] { adminUser });

            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
            });

            modelBuilder.Entity<LoginModel>(entity =>
            {
                entity.ToTable("Login");
                entity.HasKey(k => k.UserId);

            });

            modelBuilder.Entity<Account>().HasOne(e => e.Login)
                                       .WithOne(e => e.User);

            modelBuilder.Entity<Performer>(entity =>
            {
                entity.ToTable("Performer");

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate)
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

                entity.HasOne(d => d.Performer)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.PerformerId)
                    .HasConstraintName("SongsPerformer");

                entity.HasMany(d => d.Users)
                    .WithMany(d => d.Songs)
                    .UsingEntity(j => j.ToTable("UserSongRealations"));
            });

            modelBuilder.Entity<Account>(entity =>
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
