using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DbWarehouse.Models;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbWarehouse
{
    public class WarehouseContext: DbContext
    {
        public WarehouseContext()
            : base("WarehouseContext") {
          
         //   this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Shelf> Shelfs { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // PostgreSQL uses the public schema by default - not dbo.
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<Product>().Property(p => p.Length).HasPrecision(15, 2);
            modelBuilder.Entity<Product>().Property(p => p.Width).HasPrecision(15, 2);
            modelBuilder.Entity<Product>().HasMany(p => p.Locations).WithRequired(p=>p.Product);


            base.OnModelCreating(modelBuilder);

           
        }
    }

    public class WarehouseDbInitializer : DropCreateDatabaseIfModelChanges<WarehouseContext>
    {

        protected override void Seed(WarehouseContext db)
        {

            try
            {
                Product product1 = new Product { Name = "Product", Material = "Material", Length = 23.00m, Width = 23.00m };
                Producer producer1 = new Producer { Name = "Producer1", City = "City1" };
                Shelf shelf1 = new Shelf { Name = "Shelf1", Position = "Position1" };

                db.Products.Add(product1);
                db.Producers.Add(producer1);
                db.Shelfs.Add(shelf1);
                db.SaveChanges();

                Location location = new Location { Product = product1, Producer = producer1, Shelf = shelf1, Count = 50 };
                db.Locations.Add(location);
                db.SaveChanges();

                base.Seed(db);
                Debug.WriteLine("Прошла инициализация:\n");
            }
            catch (Exception ex)
            {
                // Если при создании БД возникла ошибка, 
                // отобразим ее в окне отладчика
                Debug.WriteLine("Инициализация не выполнена. Ошибка: ");
                Debug.WriteLine(ex.Message);
            }
        }
    }

    internal enum Tables
    {
        Product=1,
        Producer,
        Shelf,
        Location
    }
}