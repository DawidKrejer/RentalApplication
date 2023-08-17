using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentalApplication.Models;


namespace RentalApplication.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CarController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var cars = _db.Cars.ToList();
            return View(cars);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _db.Cars.Add(car);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        public IActionResult Edit(int id)
        {
            var car = _db.Cars.Find(id);
            return View(car);
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(car).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        public IActionResult Details(int id)
        {
            var car = _db.Cars.Find(id);
            return View(car);
        }

        public IActionResult Delete(int id)
        {
            var car = _db.Cars.Find(id);
            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var car = _db.Cars.Find(id);
            _db.Cars.Remove(car);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
