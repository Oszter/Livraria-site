using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Mvc
{
    public class RoteamentoPadrao
    {
        public static Task DefaultHandler(HttpContext context)
        {
            var classe = Convert.ToString(context.GetRouteValue("classe"));
            var nomeMetodo = Convert.ToString(context.GetRouteValue("nomeMetodo"));
            var nomeSolucao = $"Alura.ListaLeitura.App.Controller.{classe}Controller";
            var tipo = Type.GetType(nomeSolucao);
            var metodo = tipo.GetMethods().Where(m => m.Name == nomeMetodo).First();
            var requestDelegate = (RequestDelegate)Delegate.CreateDelegate(typeof(RequestDelegate), metodo);

            return requestDelegate.Invoke(context);
        }
    }
}