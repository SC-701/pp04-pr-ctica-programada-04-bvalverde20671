using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Revision;

namespace Reglas
{
    public class RevisionReglas:IRevisionReglas
    {
        private readonly IRevisionServicio _revisionServicio;
        private readonly IConfiguracion _Configuracion;

        public RevisionReglas(IRevisionServicio revisionServicio, IConfiguracion configuracion)
        {
            _revisionServicio = revisionServicio;
            _Configuracion = configuracion;
        }

        public async Task<bool> RevisionEsValida(string placa)
        {
            var resultadoRevision = await _revisionServicio.Obtener(placa);
            if (ValidarEstado(resultadoRevision) && ValidarPeriodo(resultadoRevision.Periodo))
                return true;
            return false;

        }
        private bool ValidarEstado(Revision resultadoRevision)
        {
            String estadoRevision = _Configuracion.ObtenerValor("EstadoRevisionSatisfactorio");
            return resultadoRevision.Resultado == estadoRevision;
        }

        private static string ObtenerPeriodoActual()
        {
            return $"{DateTime.Now.Month:D2}{DateTime.Now.Year}";

        }
        private static bool ValidarPeriodo(string periodo)
        {
            var periodoActual = ObtenerPeriodoActual();
            return periodo == periodoActual;

        }

    }
}
