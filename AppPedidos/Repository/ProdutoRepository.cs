using AppPedidos.Context;
using AppPedidos.Models;
using AppPedidos.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AppPedidos.Repository
{
    public class ProdutoRepository : IProdutosRepository
    {
        private readonly AppDbContext _AppDbContext;

        public ProdutoRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public IEnumerable<CategoriaProduto> GetAllProdutos => _AppDbContext.CategoriaProduto.Include(s => s.Subcategorias).ThenInclude(p=>p.Produtos);
    }
}
