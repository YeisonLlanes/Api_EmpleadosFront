using Microsoft.AspNetCore.Mvc;

namespace primerApiFront.Controllers
{
    public class EmpleadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
