using Ecommerce.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infastructure.Data
{

    public class ApplicationDbContext : IdentityDbContext<LocalUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
               .Property(p => p.Rating)
               .HasColumnType("decimal(18,2)");

            

            modelBuilder.Entity<Genre>().HasData(
                  new Genre
                  {
                      Id = 1,
                      Name = "Action",
                      Description = "Movies filled with intense scenes and high energy"
                  },
                  new Genre
                  {
                      Id = 2,
                      Name = "Comedy",
                      Description = "Movies designed to make audiences laugh"
                  },
                  new Genre
                  {
                      Id = 3,
                      Name = "Drama",
                      Description = "Movies with strong emotional themes"
                  }
              );

            // Seed Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Mad Max: Fury Road",
                    Description = "In a post-apocalyptic wasteland, Max teams up with Furiosa to flee from cult leader Immortan Joe.",
                    Rating = 8.1m,
                    Image = "madmax.jpg",
                    GenreId = 1
                },
                new Movie
                {
                    Id = 2,
                    Title = "Superbad",
                    Description = "Two high school friends' quest for a wild night before graduation.",
                    Rating = 7.6m,
                    Image = "superbad.jpg",
                    GenreId = 2
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Shawshank Redemption",
                    Description = "A man imprisoned for a crime he didn't commit forms a friendship and finds hope.",
                    Rating = 9.3m,
                    Image = "shawshank.jpg",
                    GenreId = 3
                }

    );

            modelBuilder.Entity<LocalUser>().HasData(
                        new LocalUser { FirstName = "ghada", LastName = "nofal", Address = "Idna" },
                        new LocalUser { FirstName = "manal", LastName = "amro", Address = "Idna" }
                    );



            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, LocalUserId = 1, OrderSatutus = "Completed", OrderDate = DateTime.Now },
                new Order { Id = 2, LocalUserId = 1, OrderSatutus = "Pending", OrderDate = DateTime.Now }
            );

            
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }

        // public DbSet <IdentityUser> User { get; set; }


    }
}
