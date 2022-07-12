using System.Collections.Generic;
using WebAPIUI.CustomExceptions.ReporteGeneralAsistencia;
using WebAPIUI.Models.ReporteGeneralAsistencia;

namespace WebAPIUI.Controllers.ReporteGeneralAsistencia.Models
{
    public class ReporteGeneralAsistenciaDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ReporteGeneralAsistenciaResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<ReporteGeneralAsistenciaModel> ContentIndex { get; set; }

    }
}