using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace Alura.ListaLeitura.App
{
    internal class Startup
    {
        //metodo necessario para criação de rotas
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseExceptionHandler();
            app.UseMvcWithDefaultRoute();
        }
    }
}