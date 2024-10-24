using AppPedidos.Models;

namespace AppPedidos.Repository.Interface
{
    public interface IProdutosRepository
    {
        public IEnumerable<CategoriaProduto> GetAllProdutos {  get; }
    }
}
