using X.PagedList;
using AppPedidos.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace AppPedidos.Controllers
{
    public class ConvenioController : Controller
    {
        private readonly IConvenioRepository _convenioRepository;

        public ConvenioController(IConvenioRepository convenioRepository)
        {
            _convenioRepository = convenioRepository;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = page ?? 1;

            var convenios = _convenioRepository.GetAllConvenios.OrderBy(c => c.NomeConvenio).ToPagedList(pageNumber, pageSize);

            return View(convenios);
        }
    }
}
