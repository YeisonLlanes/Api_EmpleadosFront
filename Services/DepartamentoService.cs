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

        public async Task<Departamento> GetDptoById(int idDepartamento)
        {
            Departamento departamento = new Departamento();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Departamento/GetDptoById/" + idDepartamento).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                departamento = JsonConvert.DeserializeObject<Departamento>(data);
            }

            return departamento;
        }

        public async Task<bool> CreateDpto(Departamento dpto)
        {
            bool respuesta = false;
            var content = new StringContent(JsonConvert.SerializeObject(dpto), Encoding.UTF8, "application/json");


            HttpResponseMessage response = await _client.PostAsync(_client.BaseAddress + "/Departamento/CreateDpto/", content);

            if (response.IsSuccessStatusCode)
            {
                //string data = response.Content.ReadAsStringAsync().Result;
                //departamento = JsonConvert.DeserializeObject<Departamento>(data);
                respuesta = true;
            }

            return respuesta;
        }


        public async Task<bool> EditDpto(int id,Departamento dpto)
        {
            bool respuesta = false;
            var content = new StringContent(JsonConvert.SerializeObject(dpto), Encoding.UTF8, "application/json");


            HttpResponseMessage response = await _client.PutAsync(_client.BaseAddress + "/Departamento/UpdateDpto/" + id, content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> DeleteDpto(int idDepartamento)
        {
            bool respuesta = false;
            
            HttpResponseMessage response = await _client.DeleteAsync(_client.BaseAddress + "/Departamento/DeleteDpto/" + idDepartamento);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }


       
    }
}
