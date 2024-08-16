using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.WebApplication.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
