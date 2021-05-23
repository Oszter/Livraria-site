using System.IO;

namespace Alura.ListaLeitura.App.View.Utils
{
    public class HtmlUtils
    {
  
        public static string CarregaHTML(string str)
        {
            var carregaNomeHtml = $"View/{str}.html";
            using (var arquivo = File.OpenText(carregaNomeHtml))
            {
                return arquivo.ReadToEnd();
            }
        }
    }
}
