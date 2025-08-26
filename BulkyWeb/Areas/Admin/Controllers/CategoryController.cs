using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")] 
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       
        public IActionResult Index()
        {
           
            List<Category> objCategoryList = _unitOfWork.CategoryRepository.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder?.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)//to check is model is valid or not by going into the Category
            {
                _unitOfWork.CategoryRepository.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Created Successfully.";
                return RedirectToAction("Index");

            }
            return View();

        }

        [HttpGet]
        public IActionResult Edit(Guid ?id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            /* Category categoryFromDb = _db.Categories.Find(id);*///work only for primary key so we'll not be able to do any modification
            Category? categoryFromDb = _unitOfWork.CategoryRepository.Get(c => c.Id == id); //this will work for any field
            if (categoryFromDb == null)
            {
                return NotFound();
            }


            return View(categoryFromDb);
        }

        [HttpPost]//updating look for client side validation
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Edited Successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Delete(Guid ?id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.CategoryRepository.Get(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")] //to avoid confusion with delete method
        public IActionResult DeletePOST(Guid id)
        {
            Category ?obj = _unitOfWork.CategoryRepository.Get(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Successfully .";
            return RedirectToAction("Index");


        }

    }

}

