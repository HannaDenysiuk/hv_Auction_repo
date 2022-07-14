using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{ 
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Users { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Step> Steps { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :
          base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasMany(u => u.Lots).WithOne(l => l.User)
                .HasForeignKey(lot => lot.UserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>().HasMany(u => u.Steps).WithOne(l => l.User)
                .HasForeignKey(lot => lot.UserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Lot>().HasOne(u => u.User).WithMany(u => u.Lots)
                .HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Lot>().HasMany(s => s.Steps).WithOne()
                .HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Step>().HasOne(u => u.User).WithMany(u => u.Steps)
                .HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Step>().HasOne(u => u.Lot).WithMany()
                .HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>().ToTable("Users");
            modelBuilder.Entity<Lot>().ToTable("Lots");
            modelBuilder.Entity<Step>().ToTable("Stepts");
        }
    }
}
