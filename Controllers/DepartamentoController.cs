using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using primerApiFront.Models;
using primerApiFront.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;



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

        [HttpGet, ActionName("Edit")]
        public async Task<ActionResult> Edit (int id)
        {
            Departamento departamento = await _departamentoService.GetDptoById(id);
            return View(departamento);
        }

        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDpto([Bind("descripcion")] Departamento dpto)
        {
            if (ModelState.IsValid)
            {
                var str = "";
                bool respuesta = await _departamentoService.CreateDpto(dpto);
                if (respuesta == true)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(dpto);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDpto(int idDepartamento, [Bind("idDepartamento, descripcion")] Departamento dpto)
        {
            if (ModelState.IsValid)
            {
                var str = "";
                bool respuesta = await _departamentoService.EditDpto(idDepartamento, dpto);
                if (respuesta == true)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(dpto);

        }

        [HttpGet, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            Departamento departamento = await _departamentoService.GetDptoById(id);
            return View(departamento);
        }


        [HttpPost, ActionName("DeleteDpto")]
        public async Task<IActionResult> DeleteDpto(int idDepartamento)
        {
            if (ModelState.IsValid)
            {
                var str = "";
                bool respuesta = await _departamentoService.DeleteDpto(idDepartamento);
                if (respuesta == true)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();

        }



    }
}
