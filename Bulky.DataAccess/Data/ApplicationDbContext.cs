using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ Seed Categories first
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.Parse("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
                    Name = "Books",
                    DisplayOrder = "1"
                },
                new Category
                {
                    Id = Guid.Parse("9f8c6d1a-3b4f-4cde-8f8b-123456789abc"),
                    Name = "Novels",
                    DisplayOrder = "2"
                },
                new Category
                {
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    Name = "Stories",
                    DisplayOrder = "3"
                },
                new Category
                {
                    Id = Guid.Parse("7d444840-9dc0-11d1-b245-5ffdce74fad2"),
                    Name = "Kids",
                    DisplayOrder = "4"
                },
                new Category
                {
                    Id = Guid.Parse("6ba7b810-9dad-11d1-80b4-00c04fd430c8"),
                    Name = "Comics",
                    DisplayOrder = "5"
                },
                new Category
                {
                    Id = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"),
                    Name = "Magazines",
                    DisplayOrder = "6"
                }
            );

            // ✅ Seed Products with matching CategoryId
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.Parse("e33ee91c-3f37-4925-86c2-0aab32d0ce49"),
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero...",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = Guid.Parse("f47ac10b-58cc-4372-a567-0e02b2c3d479") // Books
                },
                new Product
                {
                    Id = Guid.Parse("7e555a2f-9781-44b1-8806-5e29dcd174b0"),
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero...",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = Guid.Parse("9f8c6d1a-3b4f-4cde-8f8b-123456789abc") // Novels
                },
                new Product
                {
                    Id = Guid.Parse("0f178d9b-7af7-4e86-a0aa-807545643fad"),
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero...",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6") // Stories
                },
                new Product
                {
                    Id = Guid.Parse("0ed69ce4-7543-4929-b587-257a096c8600"),
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero...",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = Guid.Parse("7d444840-9dc0-11d1-b245-5ffdce74fad2") // Kids
                },
                new Product
                {
                    Id = Guid.Parse("1cbdc10d-9361-4cf3-8313-8f3e55c98b3e"),
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero...",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = Guid.Parse("6ba7b810-9dad-11d1-80b4-00c04fd430c8") // Comics
                },
                new Product
                {
                    Id = Guid.Parse("fcca6130-b209-4305-bc08-4ec3cdd402e1"),
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero...",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d") // Magazines
                }
            );
        }

    }

}
