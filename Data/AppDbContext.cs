using Microsoft.EntityFrameworkCore;
using MovieRentalAPI.Models;  

namespace MovieRentalAPI.Data  
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial users
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FullName = "Admin User", EmailAddress = "admin@movierentals.com", Password = "admin123" }
            );

            // Seed initial movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie { 
                    MovieId = 1, 
                    MovieTitle = "You Don't Mess with the Zohan", 
                    MovieDescription = "An Israeli special forces soldier fakes his death and moves to New York City to become a hairstylist.", 
                    IsRented = false, 
                    IsDeleted = false 
                },
                new Movie { 
                    MovieId = 2, 
                    MovieTitle = "Bullet Train", 
                    MovieDescription = "Five assassins aboard a swiftly-moving bullet train find out their missions have something in common.", 
                    IsRented = true, 
                    RentalDate = DateTime.Now.AddDays(-3), 
                    IsDeleted = false 
                },
                new Movie { 
                    MovieId = 3, 
                    MovieTitle = "Kung Fu Hustle", 
                    MovieDescription = "In 1940s China, a wannabe gangster aspires to join the notorious Axe Gang.", 
                    IsRented = false, 
                    IsDeleted = false 
                },
                new Movie { 
                    MovieId = 4, 
                    MovieTitle = "Tick, Tick... Boom!", 
                    MovieDescription = "On the brink of turning 30, a promising theater composer navigates love, friendship, and the pressure to create something great.", 
                    IsRented = true, 
                    RentalDate = DateTime.Now.AddDays(-1), 
                    IsDeleted = false 
                },
                new Movie { 
                    MovieId = 5, 
                    MovieTitle = "Treasure Planet", 
                    MovieDescription = "A young adventurer discovers a map to the greatest pirate treasure in the universe and sets sail aboard a spaceship to find it.", 
                    IsRented = false, 
                    IsDeleted = false 
                },
                new Movie { 
                    MovieId = 6, 
                    MovieTitle = "Scary Movie 4", 
                    MovieDescription = "Cindy finds herself living in a haunted house while alien invaders appear from the skies in this horror spoof.", 
                    IsRented = false, 
                    IsDeleted = true 
                },
                new Movie { 
                    MovieId = 7, 
                    MovieTitle = "The Spongebob Squarepants Movie", 
                    MovieDescription = "SpongeBob SquarePants and his best friend Patrick Star embark on a mission to clear Mr. Krabs' name.", 
                    IsRented = false, 
                    IsDeleted = false 
                }
            );
        }
    }
}