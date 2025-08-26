using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        // Constructor to initialize the database context
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(Guid? id)
        {
            // Fix for CS0019: Operator '!=' cannot be applied to operands of type 'Guid?' and 'int'
            // Fix for CS1525: Invalid expression term '}'
            // Fix for CS1002: ; expected
            if (id != null && id != Guid.Empty)
            {
                // Logic to handle the case when id is not null and not empty
                Category = _db.Categories.FirstOrDefault(c => c.Id == id);
            }
        }
        public IActionResult OnPost()
        { if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");

            }
            return Page();// If the model state is invalid, return the same page to show validation errors


        }
    }
}
