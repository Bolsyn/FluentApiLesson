using FluentApiLesson.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApiLesson.Data
{
    public class DishesContext : DbContext
    {
        public DishesContext()
        {
            Database.Migrate();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = desktop-9ep80dv; Database = FluentApiLesson; Trusted_Connection = true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("products")
                .Property(product => product.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Product>()
                .HasKey(product => product.Id);

            modelBuilder.Entity<Product>()
                .ToTable("products")
                .Property(product => product.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();
            
            //modelBuilder.Entity<Product>()
            //    .ToTable("products")
            //    .Property(product => product.DishId)
            //    .HasColumnName("dishId");

            //modelBuilder.Entity<Product>()
            //    .HasOne(product => product.Dish)
            //    .WithMany(dish => dish.Products);

            modelBuilder.Entity<Dish>()
                .ToTable("dishes")
                .Property(dish => dish.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Dish>()
                .HasKey(dish => dish.Id);

            modelBuilder.Entity<Dish>()
                .ToTable("dishes")
                .Property(dish => dish.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<DishProducts>()
                .ToTable("dishProducts")
                .Property(dishProduct => dishProduct.DishId)
                .HasColumnName("dishId");

            modelBuilder.Entity<DishProducts>()
                .HasOne(dishProduct => dishProduct.Dish)
                .WithMany(dish => dish.DishProducts);

            modelBuilder.Entity<DishProducts>()
                .HasOne(dishProduct => dishProduct.Product)
                .WithMany(product => product.DishProducts);

            base.OnModelCreating(modelBuilder);
        }
    }
}
