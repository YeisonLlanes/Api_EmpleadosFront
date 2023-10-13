using primerApiFront.Models;

namespace primerApiFront.Services
{
    public interface IDepartamento
    {
        Task<List<Departamento>> GetDptos();

        Task<Departamento> GetDptoById(int idDepartamento);

        Task<bool> CreateDpto(Departamento dpto);

        Task<bool> EditDpto(Departamento dpto);

        Task<bool> DeleteDepartamentoAsync(int idDepartamento);
    }
}
