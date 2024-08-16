using BurgerApp.DataAccess;
using BurgerApp.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BurgerApp.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly BurgerAppDbContext _db;

        public HomeController(BurgerAppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var locations = _db.Location.ToList();
            return View(locations);
       
        }
      

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
