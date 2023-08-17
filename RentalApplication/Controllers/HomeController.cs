using Microsoft.AspNetCore.Mvc;

namespace RentalApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Car()
        {
            // Przekierowanie do akcji Index w kontrolerze Car
            return RedirectToAction("Index", "Car");
        }

        public IActionResult Customer()
        {
            // Przekierowanie do akcji Index w kontrolerze Customer
            return RedirectToAction("Index", "Customer");
        }

        public IActionResult Rental()
        {
            // Przekierowanie do akcji Index w kontrolerze Rental
            return RedirectToAction("Index", "Rental");
        }
    }
}
