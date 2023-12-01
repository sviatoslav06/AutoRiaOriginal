using DataAccess.Data.Entities;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CarDbContext : IdentityDbContext<User>
    {
        public CarDbContext() { }
        public CarDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Autorias;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category() { Id = 1, Name = "Lightweight" },
                new Category() { Id = 2, Name = "Moto" },
                new Category() { Id = 3, Name = "Trucks" },
                new Category() { Id = 4, Name = "Trailers" },
                new Category() { Id = 5, Name = "Special equipment" },
                new Category() { Id = 6, Name = "Agricultural machinery" },
                new Category() { Id = 7, Name = "Buses" },
                new Category() { Id = 8, Name = "Water transport" },
                new Category() { Id = 9, Name = "Air transport" },
                new Category() { Id = 10, Name = "Motorhomes" }
            });

            modelBuilder.Entity<Cars>().HasData(new[]
            {
                new Cars() { Id = 1, Brand = "Mercedes-Benz", CategoryId = 1, City = "Rivne", Color = "Black", Description = "The best car", Engine = 3.5, IsUsed = true, Mail = "samoliuk.sviatoslav@gmail.com", Model = "C-300", Phone = "+380983260910", Price = 20000, State_number = "ВК08384АІ", Year = 2016, ImageUrl = "https://cdn-fastly.thetruthaboutcars.com/media/2022/06/30/8747365/2016-mercedes-benz-c300-review-the-best-benz-you-can-buy-today.jpg?size=720x845&nocrop=1" }
            });
        }

        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
