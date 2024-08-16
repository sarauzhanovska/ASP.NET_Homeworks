using BurgerApp.DataAccess;
using BurgerApp.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.WebApplication.Controllers
{
    public class BurgerController : Controller
    {
        private readonly BurgerAppDbContext _db;

        public BurgerController(BurgerAppDbContext db)
        {
            _db = db;
        }

     
        public IActionResult Index()
        {
            IEnumerable<Burger> objBurgerList = _db.Burger;
            return View(objBurgerList);
        }
    

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Burger obj)
        {
          
                _db.Burger.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Burger created successfully!";
                return RedirectToAction("Index");
     
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var burgerFromDb = _db.Burger.Find(id);
            if(burgerFromDb == null)
            {
                return NotFound();
            }
            return View(burgerFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Burger obj)
        {
            
                _db.Burger.Update(obj);
                TempData["success"] = "Burger edited successfully!";
                _db.SaveChanges();
                return RedirectToAction("Index");
  
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var burgerFromDb = _db.Burger.Find(id);
            if (burgerFromDb == null)
            {
                return NotFound();
            }
            return View(burgerFromDb);
        }
        [HttpPost]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Burger.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Burger.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Burger deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
