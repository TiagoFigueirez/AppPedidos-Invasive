using AppPedidos.Context;
using AppPedidos.Models;
using AppPedidos.Repository.Interface;

namespace AppPedidos.Repository
{   
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AppDbContext _AppDbContext;

        public PacienteRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public IEnumerable<Paciente> GetAllPaciente => _AppDbContext.Paciente.OrderBy(p => p.NomePaciente);
    }
}
