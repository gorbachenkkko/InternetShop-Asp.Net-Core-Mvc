using InternetShop.Domain.Entity;
using InternetShop.Domain.Enum;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Clothes> Clothes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Basket> Baskets {get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("Users").HasKey(x => x.Id);

                builder.HasData(new User()
                {
                    Id = 1,
                    Name = "Igor",
                    Role = Role.Admin,
                    Password = "igor123"
                });
            });

            modelBuilder.Entity<Clothes>(builder=>
            { 
                builder.ToTable("Clothes").HasKey(x => x.Id);
                
                builder.HasData(new Clothes()
                {
                    Id = 1,
                    Color = Color.Black,
                    Gender = Gender.Man,
                    ImageUrl = "https://morningstar.com.ua/imgproxy/4SqvkRa9F_vRhXDnahFDYfu0_XUlVBBrGjmNlgSGTZk/rs:fit:620:808:0/f:webp/dpr:1/g:sm/aHR0cHM6Ly9tb3JuaW5nc3Rhci5jb20udWEvbWVkaWEvY2F0YWxvZy9wcm9kdWN0L2Qvcy9kc2NmMzA0OV8xLmpwZw",
                    Size = Size.XL,
                    Name = "Шорты Cargo",
                    СlothingType = СlothingType.Shorts,
                    Price = 550,
                    Description = "text text text text text text text text text text text text text text text text text text text text text text text text " +
                    "text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text " +
                    "text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text "
                });
                builder.HasData(new Clothes()
                {
                    Id = 2,
                    Color = Color.Black,
                    Gender = Gender.Woman,
                    ImageUrl = "https://morningstar.com.ua/imgproxy/6cbEMX4kVLmMhmSY5ovM16HGSVGxRpzAtnb2bjQM3r8/rs:fit:620:808:0/f:webp/dpr:1/g:sm/aHR0cHM6Ly9tb3JuaW5nc3Rhci5jb20udWEvbWVkaWEvY2F0YWxvZy9wcm9kdWN0L2kvbS9pbWdvbmxpbmUtY29tLXVhLWNvbXByZXNzZWQtY2JkOWtta2lsbV8xLmpwZw",
                    Size = Size.S,
                    Name = "Джинсы MOM Graphite",
                    СlothingType = СlothingType.Pants,
                    Price = 1250,
                    Description = "text text text text text text text text text text text text text text text text text text text text text text text text " +
                    "text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text " +
                    "text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text "
                });
                builder.HasData(new Clothes()
                {
                    Id = 3,
                    Color = Color.Black,
                    Gender = Gender.Man,
                    ImageUrl = "https://morningstar.com.ua/imgproxy/zKRZsrMxppTjtV4RFP7RarTOcTcGQ2p6c32U8znyOmY/rs:fit:620:808:0/f:webp/dpr:1/g:sm/aHR0cHM6Ly9tb3JuaW5nc3Rhci5jb20udWEvbWVkaWEvY2F0YWxvZy9wcm9kdWN0LzIvMC8yMDIyLTEyLTExXzE2LjA4LjA4XzEuanBn",
                    Size = Size.XL,
                    Name = "Куртка MS Stone",
                    СlothingType = СlothingType.Jacket,
                    Price = 2350,
                    Description = "text text text text text text text text text text text text text text text text text text text text text text text text " +
                    "text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text " +
                    "text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text "
                });
                builder.HasData(new Clothes()
                {
                    Id = 4,
                    Color = Color.Red,
                    Gender = Gender.Woman,
                    ImageUrl = "https://morningstar.com.ua/imgproxy/Vbla5kiir_1C5zU0gScEnk6n1UW5Pu2ejCQZz4Mzj7U/rs:fit:620:808:0/f:webp/dpr:1/g:sm/aHR0cHM6Ly9tb3JuaW5nc3Rhci5jb20udWEvbWVkaWEvY2F0YWxvZy9wcm9kdWN0LzEvMi8xMjM0NS5wbmc",
                    Size = Size.L,
                    Name = "Футболка MS Classic",
                    СlothingType = СlothingType.T_shirt,
                    Price = 450,
                    Description = "text text text text text text text text text text text text text text text text text text text text text text text text " +
                    "text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text " +
                    "text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text "+
                    "text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text "
                });
                builder.HasData(new Clothes()
                {
                    Id = 5,
                    Color = Color.Blue,
                    Gender = Gender.Man,
                    ImageUrl = "https://morningstar.com.ua/imgproxy/ObyITGKcKokbdhgyAmWBpSavwn0eFffoMO5yfNyrHrY/rs:fit:620:808:0/f:webp/dpr:1/g:sm/aHR0cHM6Ly9tb3JuaW5nc3Rhci5jb20udWEvbWVkaWEvY2F0YWxvZy9wcm9kdWN0L2kvbS9pbWdvbmxpbmUtY29tLXVhLUNvbXByZXNzZWQtTjNGSnpkbjltVXpoY2FHXzEuanBn",
                    Size = Size.L,
                    Name = "Джинсы MS Summer",
                    СlothingType = СlothingType.Pants,
                    Price = 1050,
                    Description = "text text text text text text text text text text text text text text text text text text text text text text text text " +
                    "text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text " +
                    "text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text " +
                    "text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text \"                    \"text text text text text text text text "
                });
            });
        }
    }
}
