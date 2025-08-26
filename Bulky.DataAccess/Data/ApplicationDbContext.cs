
using Bulky.Models;

using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    { //add constructor with ctor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {
            
        }
        // prop Dbset to create table iat databse
        public DbSet<Category> Categories { get; set; }
        //to  seed data in database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.Parse("b92d2e07-5c92-4e2c-8f4d-7b9d7ec8f1ce"),
                    Name = "MS",
                    DisplayOrder = "1"
                }
            );
        }

    }
}
