 using Microsoft.AspNetCore.Mvc;

namespace SalesWebCommercial.Controllers
{
    public class SalesRecordsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }       
        public IActionResult SimpleSearch()
        {
            return View();
        }       
        public IActionResult GroupedSearch()
        {
            return View();
        }


    }
}
