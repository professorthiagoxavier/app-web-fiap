using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.Produto
{
    public class ProdutoService : IProdutoService
    {

        protected static readonly MediaTypeHeaderValue CONTENT_TYPE = new MediaTypeHeaderValue("application/json");
        private readonly IConfiguration _configuration;

        public ProdutoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<IEnumerable<Dominio.Model.Produto>> BuscarProdutosPorCategoria(string idCategoria)
        {
            var httpClient = GetHttp();
            var response = await httpClient.GetAsync($"/products/category/{idCategoria}");

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Dominio.Model.Produto>>(content);
            return result;
        }

        public async Task<Dominio.Model.Produto> BuscarProdutoPorId(string idProduto)
        {
            var httpClient = GetHttp();
            var response = await httpClient.GetAsync($"/products/{idProduto}");

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Dominio.Model.Produto>(content);
            return result;
        }

        private HttpClient GetHttp()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_configuration["ProdutoService:BaseUrl"]);
            return httpClient;
        }
    }
}
