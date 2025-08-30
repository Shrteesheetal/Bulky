using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product . GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully.";
                return RedirectToAction("Index");

            }
            return View();

        }

        public IActionResult Edit(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {

                return NotFound();
            }
            Product productFromDb = _unitOfWork.Product.Get(p => p.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            Product productFromDb = _unitOfWork.Product.Get(p => p.Id == id);
            if (productFromDb == null)
            {

                return NotFound();
            }

            return View(productFromDb);

        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(Guid id)
        {  
            
                Product obj = _unitOfWork.Product.Get(p => p.Id == id);
                if (obj == null)
                {
                    return NotFound();
                }

                _unitOfWork.Product.Remove(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product deleted successfully.";
                return RedirectToAction("Index");

        }


        }

    }
