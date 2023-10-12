using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using primerApiFront.Models;

namespace primerApiFront.Controllers
{
    public class DepartamentoController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7209/api");
        private readonly HttpClient _client;

        public DepartamentoController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Departamento> departamento = new List<Departamento>();
            HttpResponseMessage response = _client.GetAsync(baseAddress + "/Departamento/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                departamento = JsonConvert.DeserializeObject<List<Departamento>>(data);
            }

            return View(departamento);
        }
    }
}
