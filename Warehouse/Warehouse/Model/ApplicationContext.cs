using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Model
{
    class ApplicationContext : DbContext
    {
        public DbSet<History> Histories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Worker> Workers { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-GPDQSFE\SQLEXPRESS;Database=Warezone;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RoomWorker>()
           .HasKey(t => new { t.RoomId, t.WorkerId });

            modelBuilder.Entity<RoomWorker>()
                .HasOne(rw => rw.Room)
                .WithMany(r => r.RoomWorkers)
                .HasForeignKey(rw => rw.RoomId);

            modelBuilder.Entity<RoomWorker>()
                .HasOne(rw => rw.Worker)
                .WithMany(r => r.RoomWorkers)
                .HasForeignKey(rw => rw.WorkerId);
        }
        
        }
    }

