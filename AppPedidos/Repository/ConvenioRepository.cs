using AppPedidos.Context;
using AppPedidos.Models;
using AppPedidos.Repository.Interface;

namespace AppPedidos.Repository
{
    public class ConvenioRepository : IConvenioRepository
    {
        AppDbContext _AppDbContext;

        public ConvenioRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public IEnumerable<Convenio> GetAllConvenios => _AppDbContext.Convenio.OrderBy(c => c.NomeConvenio);
    }
}
