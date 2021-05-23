using Alura.ListaLeitura.App.Models;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Controllers
{
    public class CadastroController
    {
  
        public string Incluir(Livro livro)
        {
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return "Livro Incluido com sucesso.";
        }

        //exibicao de formulario
        public IActionResult ExibeFormulario()
        {
            var html = new ViewResult { ViewName = "ExibeFormulario" };
            return html;

        }
    }
}