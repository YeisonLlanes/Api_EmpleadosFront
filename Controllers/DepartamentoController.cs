using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using primerApiFront.Models;
using primerApiFront.Services;

namespace primerApiFront.Controllers
{
    public class DepartamentoController : Controller
    {
        //Uri baseAddress = new Uri("https://localhost:7209/api");
        private readonly HttpClient _client;
        private readonly IDepartamento _departamentoService;

        public DepartamentoController(HttpClient client, IDepartamento departamentoService)
        {
            _client = client;
            //_client.BaseAddress = baseAddress;
            _departamentoService = departamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Lista = await _departamentoService.GetDptos();//Por medio de una interface / servicio 
            return View(Lista);
        }
    }
}
