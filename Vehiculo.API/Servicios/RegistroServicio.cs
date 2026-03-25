using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Registro;
using Microsoft.Identity.Client;
using System;
using System.Net.Http;
using System.Text.Json;

namespace Servicios
{

    public class RegistroServicio : IRegistroServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;

        public RegistroServicio(IConfiguracion configuracion, IHttpClientFactory
            httpClient)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
        }

        public async Task<Propietario> Obtener(string placa)
        {
            var endpoint = _configuracion.ObtenerMetodo("ApiEndPointsRegistro",
                "ObtenerRegistro");
            string urlFinal = string.Format(endpoint, placa);
            var servicioRegistro = _httpClient.CreateClient("ServicioRegistro");
            var respuesta = await servicioRegistro.GetAsync(endpoint);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive =
                true
            };
            var resultadoDeserializado = JsonSerializer.Deserialize<List<Propietario>>(resultado,
                opciones);
            return resultadoDeserializado.FirstOrDefault();
        }
    }
}
