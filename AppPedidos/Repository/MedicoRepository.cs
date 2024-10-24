using AppPedidos.Context;
using AppPedidos.Models;
using AppPedidos.Repository.Interface;

namespace AppPedidos.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly AppDbContext _AppDbContext;

        public MedicoRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public IEnumerable<Medico> GetAllMedicos => _AppDbContext.Medico.OrderBy(m => m.NomeMedico);
    }
}
