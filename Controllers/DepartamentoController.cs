using Microsoft.AspNetCore.Mvc;

namespace primerApiFront.Controllers
{
    public class DepartamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
