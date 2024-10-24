using AppPedidos.Context;
using AppPedidos.Models;
using AppPedidos.Repository.Interface;

namespace AppPedidos.Repository
{
    public class HospitalRepository : IHospitalRepository
    {
        AppDbContext _AppDbContext;

        public HospitalRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public IEnumerable<Hospital> GetAllHospital => _AppDbContext.Hospital.OrderBy(h => h.NomeHospital);
    }
}
