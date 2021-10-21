using Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Produto;
using System.Threading.Tasks;

namespace AplicacaoWeb.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<IActionResult> Index([FromRoute]string id)
        {
            var produtos = await _produtoService.BuscarProdutosPorCategoria(id);

            return View(produtos);
        }


        public  async Task<IActionResult> ViewProduto([FromRoute] string id)
        {
            var produto = await _produtoService.BuscarProdutoPorId(id);
            return View(produto);
        }
    }
}
