using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Produto
{
    public interface IProdutoService
    {
        Task<IEnumerable<Dominio.Model.Produto>> BuscarProdutosPorCategoria(string idCategoria);
        Task<Dominio.Model.Produto> BuscarProdutoPorId(string idProduto);
    }
}
