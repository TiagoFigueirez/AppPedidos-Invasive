using AppPedidos.Models;

namespace AppPedidos.Repository.Interface
{
    public interface IMedicoRepository
    {
        IEnumerable<Medico> GetAllMedicos { get; }
    }
}
