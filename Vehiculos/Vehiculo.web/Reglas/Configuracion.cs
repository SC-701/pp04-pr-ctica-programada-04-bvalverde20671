using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.Extensions.Configuration;

namespace Reglas
{
    public class Configuracion : IConfiguracion
    {
        private readonly IConfiguration _configuration;

        public Configuracion(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ObtenerMetodo(string seccion, string nombre)
        {
            APIEndPoint? apiEndpoint = _configuration.GetSection(seccion).Get<APIEndPoint>();

            if (apiEndpoint is null)
            {
                throw new InvalidOperationException($"No se encontró la sección '{seccion}' en appsettings.");
            }

            if (string.IsNullOrWhiteSpace(apiEndpoint.UrlBase))
            {
                throw new InvalidOperationException($"No se encontró UrlBase en la sección '{seccion}'.");
            }

            if (apiEndpoint.Metodos is null || !apiEndpoint.Metodos.Any())
            {
                throw new InvalidOperationException($"No se encontraron métodos en la sección '{seccion}'.");
            }

            Metodo? metodo = apiEndpoint.Metodos.FirstOrDefault(m => m.Nombre == nombre);

            if (metodo is null)
            {
                throw new InvalidOperationException($"No se encontró el método '{nombre}' en la sección '{seccion}'.");
            }

            if (string.IsNullOrWhiteSpace(metodo.Valor))
            {
                throw new InvalidOperationException($"El método '{nombre}' no tiene valor configurado.");
            }

            string urlBase = apiEndpoint.UrlBase.TrimEnd('/');
            string valorMetodo = metodo.Valor.TrimStart('/');

            return $"{urlBase}/{valorMetodo}";
        }

        private string ObtenerUrlBase(string seccion)
        {
            APIEndPoint? apiEndpoint = _configuration.GetSection(seccion).Get<APIEndPoint>();

            if (apiEndpoint is null || string.IsNullOrWhiteSpace(apiEndpoint.UrlBase))
            {
                throw new InvalidOperationException($"No se encontró UrlBase en la sección '{seccion}'.");
            }

            return apiEndpoint.UrlBase;
        }

        public string obtenerValor(string llave)
        {
            string? valor = _configuration.GetSection(llave).Value;

            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new InvalidOperationException($"No se encontró valor para la llave '{llave}'.");
            }

            return valor;
        }
    }
}