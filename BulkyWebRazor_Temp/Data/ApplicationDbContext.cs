using BulkyWebRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;


namespace BulkyWebRazor_Temp.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
     
        {
            
        }
        public DbSet<Category> Categories { get; set; }
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
