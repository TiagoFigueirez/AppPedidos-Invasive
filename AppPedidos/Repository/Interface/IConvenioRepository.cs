using AppPedidos.Models;

namespace AppPedidos.Repository.Interface
{
    public interface IConvenioRepository
    {
        IEnumerable<Convenio> GetAllConvenios {  get; }
    }
}
