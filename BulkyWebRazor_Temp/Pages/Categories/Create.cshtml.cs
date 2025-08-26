using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        
        
        public Category Category { get; set; }
        

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            // This method is called when the page is first loaded to display the form  
        }

        // This method is called when the form is submitted  
        // it will save the new category to the database  
        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully"; // Set a success message in TempData
            return RedirectToPage("Index"); // Redirect to the Index page after saving  
        }
    }
}
