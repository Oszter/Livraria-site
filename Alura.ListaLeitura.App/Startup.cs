using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    internal class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            var routerBuilder = new RouteBuilder(app);
            routerBuilder.MapRoute("livros/paraler", ParaLer);
            routerBuilder.MapRoute("livros/lendo", Lendo);
            routerBuilder.MapRoute("livros/lidos", Lidos);
            routerBuilder.MapRoute("cadastro/novolivro/{titulo}/{autor}", NovoLivroParaLer);
            routerBuilder.MapRoute("livros/detalhes/{id:int}", ExibeDetalhes);
            var rotas = routerBuilder.Build();
            app.UseRouter(rotas);
        }

        private Task ExibeDetalhes(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);
            livro.Detalhes();
            return context.Response.WriteAsync(livro.Detalhes());
        }

        private Task NovoLivroParaLer(HttpContext context)
        {
            var livro = new Livro
            {
                Titulo = Convert.ToString(context.GetRouteValue("titulo")),
                Autor = Convert.ToString(context.GetRouteValue("autor"))
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            
            return context.Response.WriteAsync("Livro Incluido com sucesso.");
        }

        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddRouting();
        }

        public Task ParaLer(HttpContext context)
        {
            var _paraLer = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_paraLer.ParaLer.ToString());
        }

        public Task Lendo(HttpContext context)
        {
            var _paraLer = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_paraLer.Lendo.ToString());
        }

        public Task Lidos(HttpContext context)
        {
            var _paraLer = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_paraLer.Lidos.ToString());
        }
    }
}