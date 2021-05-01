using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.HTML.Utils
{
    public class HtmlUtils
    {
  
        public static string CarregaHTML(string str)
        {
            var carregaNomeHtml = $"HTML/{str}.html";
            using (var arquivo = File.OpenText(carregaNomeHtml))
            {
                return arquivo.ReadToEnd();
            }
        }
    }
}
