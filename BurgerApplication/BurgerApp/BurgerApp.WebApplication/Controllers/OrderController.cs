using BurgerApp.DataAccess;
using BurgerApp.DataAccess.Interfaces;
using BurgerApp.Domain;
using BurgerApp.Dtos.Dto;
using BurgerApp.Services;
using BurgerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.WebApplication.Controllers
{

    public class OrderController : Controller
    {
        private readonly BurgerAppDbContext _db;
        private readonly IOrderService _orderService;
        private readonly IBurgerService _burgerService;


        public OrderController(BurgerAppDbContext db, IBurgerService burgerService, IOrderService orderService)
        {
            _db = db;
            _orderService = orderService;
            _burgerService = burgerService;
        }


        public IActionResult Index()
        {
            IEnumerable<Order> objOrderList = _db.Order;
            return View(objOrderList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var burgers = _db.Burger
        .Select(b => new { Value = b.Id, Text = b.Name })
        .ToList();

            ViewBag.Burger = burgers;
            return View();
        }


        [HttpPost]
        public IActionResult Create(Order obj)
        {
            if (ModelState.IsValid)
            {
                _db.Order.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Order created successfully!";
                return RedirectToAction("Index");
            }
            var burgers = _db.Burger
                .Select(b => new { Value = b.Id, Text = b.Name })
                .ToList();
            ViewBag.Burger = burgers;
            return View(obj);
        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var orderFromDb = _db.Order.Find(id);
            if (orderFromDb == null)
            {
                return NotFound();
            }
            var burgers = _db.Burger
       .Select(b => new { Value = b.Id, Text = b.Name })
       .ToList();

            ViewBag.Burger = burgers;

            return View(orderFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Order obj)
        {
            if (ModelState.IsValid)
            {
                _db.Order.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Order edited successfully!";

                return RedirectToAction("Index");
            }
            return View(obj);
        }



        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var orderFromDb = _db.Order.Find(id);
            if (orderFromDb == null)
            {
                return NotFound();
            }
            return View(orderFromDb);
        }
        [HttpPost]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Order.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Order.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Order deleted successfully!";

            return RedirectToAction("Index");
        }
    }
}