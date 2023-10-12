using Microsoft.AspNetCore.Mvc;

namespace primerApiFront.Controllers
{
    public class CargoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
