using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using primerApiFront.Models;
using System.Text.Json.Serialization;

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
