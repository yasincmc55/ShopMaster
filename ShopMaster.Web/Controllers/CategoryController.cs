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
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match The Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
