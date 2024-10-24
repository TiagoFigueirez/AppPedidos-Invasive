using AppPedidos.Models;

namespace AppPedidos.Repository.Interface
{
    public interface IHospitalRepository
    {
        IEnumerable<Hospital> GetAllHospital { get; }
    }
}
