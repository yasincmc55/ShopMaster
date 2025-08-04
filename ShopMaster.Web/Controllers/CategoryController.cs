using Microsoft.AspNetCore.Mvc;
using ShopMaster.Web.Data;
using ShopMaster.Web.Models;

namespace ShopMaster.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objectCategoryList = _db.Categories.ToList();
            return View(objectCategoryList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        /*
         * Formdan gelen veriler Category nesnesine (obj) otomatik olarak eşlenir.
         */
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Category Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        /*
         * GET için: int? id al, DB’den kendin çek.
         * POST için: Category category alabilirsin, çünkü formdan gelen verileri model binder kendisi doldurur.
         */
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
               return NotFound();
            
            Category? category = _db.Categories.Find(id);
            //Category? category_1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? category_2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();

            if(category == null)
               return NotFound();
            
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Category Name");
            }

            bool isDuplicateDisplayOrder = _db.Categories.Any(c => c.DisplayOrder == obj.DisplayOrder && c.Id != obj.Id);
            if (isDuplicateDisplayOrder)
            {
                ModelState.AddModelError("DisplayOrder", "This order is already assigned to another category");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
