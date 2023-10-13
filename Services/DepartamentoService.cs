using primerApiFront.Models;
using Newtonsoft.Json;
using System.Text;

namespace primerApiFront.Services
{
    public class DepartamentoService : IDepartamento
    {
        private readonly HttpClient _client;

        public DepartamentoService(HttpClient client) 
        {
            _client = client;
        }

        public async Task<List<Departamento>> GetDptos()
        {
            List<Departamento> departamento = new List<Departamento>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Departamento/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                departamento = JsonConvert.DeserializeObject<List<Departamento>>(data);
            }

            /* Otra Opcion
             * List<Departamento> departamento = new List<Departamento>();

            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "/Departamento/GetAll");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                departamento = JsonConvert.DeserializeObject<List<Departamento>>(data);
                //dptos = departamento;
            }*/

            return departamento;

        }

        public Task<Departamento> GetDptoById(int idDepartamento)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateDpto(Departamento dpto)
        {
            throw new NotImplementedException();
        }


        public Task<bool> EditDpto(Departamento dpto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDepartamentoAsync(int idDepartamento)
        {
            throw new NotImplementedException();
        }


       
    }
}
