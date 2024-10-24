using AppPedidos.Repository.Interface;
using AppPedidos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AppPedidos.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutosRepository _produtosRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IConvenioRepository _convenioRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IProdutosRepository produtosRepository, IMedicoRepository medicoRepository,
            IHospitalRepository hospitalRepository, IConvenioRepository convenioRepository,
            IPacienteRepository pacienteRepository, IPedidoRepository pedidoRepository)
        {
            _produtosRepository = produtosRepository;
            _medicoRepository = medicoRepository;
            _hospitalRepository = hospitalRepository;
            _convenioRepository = convenioRepository;
            _pacienteRepository = pacienteRepository;
            _pedidoRepository = pedidoRepository;
        }

        public IActionResult Index()
        {
            var categorias = _produtosRepository.GetAllProdutos;
            var hospital = _hospitalRepository.GetAllHospital;
            var paciente = _pacienteRepository.GetAllPaciente;
            var convenios = _convenioRepository.GetAllConvenios;
            var pacientes = _pacienteRepository.GetAllPaciente;
            var medicos = _medicoRepository.GetAllMedicos;

            var viewModel = new ItensEnvioViewModel()
            {
                Categorias = categorias,
                Pacientes = paciente,
                Medicos = medicos,
                Convenios = convenios,
                Hospitais = hospital,
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EnviarPedido(ItensEnvioViewModel model)
        {
            if (model.Emergencial == false && String.IsNullOrEmpty(model.DataProcedimento))
            {
                ModelState.AddModelError("DataProcedimento", "*Informe a data do procedimento");
            }

            if (model.Emergencial == false && String.IsNullOrEmpty(model.HoraProcedimento))
            {
                ModelState.AddModelError("HoraProcedimento", "*Informe a hora do procedimento");
            }

            if (model.HospitalSelecionado.HospitalId == 0)
            {
                ModelState.AddModelError("HospitalSelecionado.NomeHospital", "*Informe o hospital");
            }

            if (model.PacienteSelecionado.PacienteId == 0)
            {
                ModelState.AddModelError("PacienteSelecionado.NomePaciente", "*Informe o paciente");
            }

            if (model.MedicoSelecionado.MedicoId == 0)
            {
                ModelState.AddModelError("MedicoSelecionado.NomeMedico", "*Informe o médico");
            }

            if (model.ConvenioSelecionado.ConvenioId == 0)
            {
                ModelState.AddModelError("ConvenioSelecionado.NomeConvenio", "*Informe o convênio");
            }

            if (model.ProdutoSelecionados.All(p => p.Quantidade <= 0))
            {
                ModelState.AddModelError("ProdutoSelecionados", "*Informe a quantidade de ao menos um produto");
            }

            if (!ModelState.IsValid)
            {
                model.Hospitais = _hospitalRepository.GetAllHospital;
                model.Medicos = _medicoRepository.GetAllMedicos;
                model.Convenios = _convenioRepository.GetAllConvenios;
                model.Pacientes = _pacienteRepository.GetAllPaciente;
                model.Categorias = _produtosRepository.GetAllProdutos;

                return View("Index", model);
            }

            int numeroPedido = _pedidoRepository.EnviarPedido(model);
            

            if (numeroPedido > 0)
            {
                TempData["SucessMessage"] = "Pedido enviado com sucesso";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Não foi possível realizar o pedido tente novamente ou fale com o adm do sistema";
            }

            return View("Index");
        }
    }
}
