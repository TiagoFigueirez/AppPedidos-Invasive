using AppPedidos.Models;
using System.ComponentModel.DataAnnotations;

namespace AppPedidos.ViewModel
{
    public class ItensEnvioViewModel
    {
        public IEnumerable<CategoriaProduto> Categorias { get; set; }
        public IEnumerable<Medico> Medicos { get; set; }
        public IEnumerable<Paciente> Pacientes { get; set; }
        public IEnumerable<Hospital> Hospitais { get; set; }
        public IEnumerable<Convenio> Convenios { get; set; }

        //modelo para enviar dados ao servidor
        
        public bool Emergencial { get; set; }
        public string DataProcedimento { get; set; }
        public string HoraProcedimento { get; set; }

        public Hospital HospitalSelecionado { get; set; }

        public Paciente PacienteSelecionado { get; set; }

        public Medico MedicoSelecionado { get; set; }

        public Convenio ConvenioSelecionado { get; set; }

        [StringLength(200,ErrorMessage ="as observações não podem passar de 200 caracteres")]
        public string Observacoes { get; set; }

        public List<ProdutoSelecionadoViewModel> ProdutoSelecionados { get; set; }
    }
}
