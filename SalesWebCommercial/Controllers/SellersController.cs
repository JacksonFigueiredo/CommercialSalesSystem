using Microsoft.AspNetCore.Mvc;

namespace SalesWebCommercial.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
