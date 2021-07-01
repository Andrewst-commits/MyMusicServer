using Microsoft.EntityFrameworkCore;
using Server_nw.AuthorizationApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationApplication
{
    public partial class AuthorizationDbContext : DbContext
    {
        public AuthorizationDbContext()
        {

        }

        public AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Band> Bands { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<Listener> Listeners { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<LoginModel> LoginModel { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasOne(e => e.Role)
                     .WithMany(e => e.Users)
                     .HasForeignKey(e => e.RoleId)
                     .HasConstraintName("Role/Users");

                entity.HasOne(c => c.LoginModel)
                     .WithOne(c => c.User);

            });


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

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.HasOne(e => e.Band)
                     .WithMany(e => e.Members)
                     .HasForeignKey(e => e.UserId)
                     .HasConstraintName("Band/Members"); 
            });

            modelBuilder.Entity<LoginModel>(entity =>
            {
                entity.ToTable("LoginModel");
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
