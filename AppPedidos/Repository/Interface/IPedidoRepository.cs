using AppPedidos.Models;
using AppPedidos.ViewModel;

namespace AppPedidos.Repository.Interface
{
    public interface IPedidoRepository
    {
        public  int EnviarPedido(ItensEnvioViewModel model);
        public bool EnviarEMail(ItensEnvioViewModel model, int numeroPedido, DateTime dataProcedimento);
         public string CorpoEMail(ItensEnvioViewModel model, DateTime dataProcedimento);
    }
}
