using BuildingManagementSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.Context
{
    public class BMSContext:DbContext
    {

        public BMSContext(DbContextOptions<BMSContext> options) : base(options)
        {

        }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStorage> ProductStorages { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasOne(p => p.Building).WithMany(b => b.Rooms)
            .HasForeignKey(p => p.BuildingID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Storage>().HasOne(p => p.Building).WithMany(b => b.Storages)
            .HasForeignKey(p => p.BuildingID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductStorage>().ToTable("ProductStorage");
            modelBuilder.Entity<Storage>()
                       .HasMany(o => o.Products)
                       .WithMany(of => of.Storages)
                       .UsingEntity<ProductStorage>
                           (oo => oo.HasOne<Product>().WithMany().HasForeignKey(e => e.ProductID),
                           oo => oo.HasOne<Storage>().WithMany().HasForeignKey(e => e.StorageID))
                       .Property(oo => oo.Quantity)
                       .IsRequired();

        }
    }
}
