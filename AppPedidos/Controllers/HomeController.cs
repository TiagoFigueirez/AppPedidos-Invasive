using Microsoft.AspNetCore.Mvc;

namespace AppPedidos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
