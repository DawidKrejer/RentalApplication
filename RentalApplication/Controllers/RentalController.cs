using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentalApplication.Models;

namespace RentalApplication.Controllers
{
    public class RentalController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RentalController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var rentals = _db.Rental.Include(r => r.Car).Include(r => r.Customer).ToList();
            return View(rentals);
        }

        public ActionResult Create()
        {
            ViewBag.Cars = new SelectList(_db.Cars, "CarId", "Make");
            ViewBag.Customers = new SelectList(_db.Customers, "CustomerId", "FirstName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Rental rental)
        {
            if (ModelState.IsValid)
            {
                _db.Rental.Add(rental);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cars = new SelectList(_db.Cars, "CarId", "Make");
            ViewBag.Customers = new SelectList(_db.Customers, "CustomerId", "FirstName");
            return View(rental);
        }

        public ActionResult Edit(int id)
        {
            var rental = _db.Rental.Find(id);
            ViewBag.Cars = new SelectList(_db.Cars, "CarId", "Make", rental.CarId);
            ViewBag.Customers = new SelectList(_db.Customers, "CustomerId", "FirstName", rental.CustomerId);
            return View(rental);
        }

        [HttpPost]
        public ActionResult Edit(Rental rental)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(rental).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cars = new SelectList(_db.Cars, "CarId", "Make", rental.CarId);
            ViewBag.Customers = new SelectList(_db.Customers, "CustomerId", "FirstName", rental.CustomerId);
            return View(rental);
        }

        public ActionResult Details(int id)
        {
            var rental = _db.Rental.Include(r => r.Car).Include(r => r.Customer).FirstOrDefault(r => r.RentalId == id);
            return View(rental);
        }

        public ActionResult Delete(int id)
        {
            var rental = _db.Rental.Find(id);
            return View(rental);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var rental = _db.Rental.Find(id);
            _db.Rental.Remove(rental);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
