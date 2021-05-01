using Alura.ListaLeitura.App.HTML.Utils;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosLogica
    {
        //metodo para exibir detalhes de um livro
        public static Task ExibeDetalhes(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);
            livro.Detalhes();
            return context.Response.WriteAsync(livro.Detalhes());
        }

        //metodo para exibir livros na lista ParaLer
        public static Task ParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var htmlLido = HtmlUtils.CarregaHTML("paraler");
            foreach (var item in _repo.ParaLer.Livros)
            {
                htmlLido = htmlLido.Replace("#NOVO-ITEM", $"<li>{item.Autor} - {item.Titulo}</li>#NOVO-ITEM");
            }
            htmlLido = htmlLido.Replace("#NOVO-ITEM", "");
            return context.Response.WriteAsync(htmlLido);
        }

        //metodo para exibir livros na lista Lendo
        public static Task Lendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var htmllido = HtmlUtils.CarregaHTML("lendo");

            foreach (var livro in _repo.Lendo.Livros)
            {
                htmllido = htmllido.Replace("#NOVO-LIVRO", $"<li>{livro.Autor} - {livro.Titulo}</li>#NOVO-LIVRO");
            }
            htmllido = htmllido.Replace("#NOVO-LIVRO", "");
            return context.Response.WriteAsync(htmllido);
        }

        //metodo para exibir livros na lista Lido
        public static Task Lidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var htmllido = HtmlUtils.CarregaHTML("lidos");
            foreach (var livro in _repo.Lidos.Livros)
            {
                htmllido = htmllido.Replace("#NOVO-LIVRO", $"<li>{livro.Autor} - {livro.Titulo}</li>#NOVO-ITEM");
            }
            htmllido = htmllido.Replace("#NOVO-ITEM", "");
            return context.Response.WriteAsync(htmllido);
        }

        public static Task ProcessaFormulario(HttpContext context)
        {
            var livro = new Livro
            {
                Titulo = context.Request.Form["titulo"].First(),
                Autor = context.Request.Form["autor"].First()
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return context.Response.WriteAsync("Livro Incluido com sucesso.");
        }

        public static Task ExibirFormulario(HttpContext context)
        {
            var html = HtmlUtils.CarregaHTML("formulario");
            return context.Response.WriteAsync(html);
        }
    }
}