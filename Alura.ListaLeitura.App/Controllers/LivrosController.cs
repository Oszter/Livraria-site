using Alura.ListaLeitura.App.Repositorio;
using Alura.ListaLeitura.App.View.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Controllers
{
    public class LivrosController : Controller
    {

        //metodo para exibir detalhes de um livro
        public string Detalhes(int id)
        {
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);
            return livro.Detalhes();
        }

        //metodo para exibir livros na lista ParaLer
        public IActionResult ParaLer()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.ParaLer.Livros;
            return View("paraler");
        }

        //metodo para exibir livros na lista Lendo
        public IActionResult Lendo()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Lendo = _repo.Lendo.Livros;
            return View("lendo");
        }

        //metodo para exibir livros na lista Lido
        public IActionResult Lidos()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Lidos = _repo.Lidos.Livros;
            return View("lidos");
        }
    }
}