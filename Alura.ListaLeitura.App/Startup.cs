using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    internal class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(ParaLer);

        }

        public Task ParaLer(HttpContext context)
        {
            var _paraLer = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_paraLer.Lidos.ToString());
        }
    }
}