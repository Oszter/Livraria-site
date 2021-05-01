using Alura.ListaLeitura.App.HTML.Utils;
using Alura.ListaLeitura.App.Logica;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    internal class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            //criacao da variavel routeBuilder, template para defirnir rotas
            var routerBuilder = new RouteBuilder(app);
            //rotas existentes
            routerBuilder.MapRoute("livros/paraler", LivrosLogica.ParaLer);
            routerBuilder.MapRoute("livros/lendo", LivrosLogica.Lendo);
            routerBuilder.MapRoute("livros/lidos", LivrosLogica.Lidos);
            routerBuilder.MapRoute("cadastro/novolivro/{titulo}/{autor}", CadastroLogica.NovoLivroParaLer);
            routerBuilder.MapRoute("livros/detalhes/{id:int}", LivrosLogica.ExibeDetalhes);
            routerBuilder.MapRoute("cadastro/novolivro", LivrosLogica.ExibirFormulario);
            routerBuilder.MapRoute("cadastro/incluir", LivrosLogica.ProcessaFormulario);
            //construcao da rota
            var rotas = routerBuilder.Build();
            //indicando template para uso de rotas
            app.UseRouter(rotas);
        }

        //metodo necessario para criação de rotas
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddRouting();
        }
    }
}