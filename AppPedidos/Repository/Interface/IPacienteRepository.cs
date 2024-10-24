using AppPedidos.Models;

namespace AppPedidos.Repository.Interface
{
    public interface IPacienteRepository
    {
        IEnumerable<Paciente> GetAllPaciente {  get; }
    }
}
