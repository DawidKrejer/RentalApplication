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
            return RedirectToAction("Index", "Car");
        }

        public IActionResult Customer()
        {
            return RedirectToAction("Index", "Customer");
        }

        public IActionResult Rental()
        {
            return RedirectToAction("Index", "Rental");
        }
        public IActionResult Register()
        {
            return RedirectToAction("Register", "Account");
        }
        public IActionResult Login()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}
