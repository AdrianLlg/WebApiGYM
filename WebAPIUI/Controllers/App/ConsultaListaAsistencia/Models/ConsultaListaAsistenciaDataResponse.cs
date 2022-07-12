using System.Collections.Generic;
using WebAPIUI.CustomExceptions.ConsultaListaAsistencia;
using WebAPIUI.Models.ConsultaListaAsistencia;

namespace WebAPIUI.Controllers.App.ConsultaListaAsistencia.Models
{
    public class ConsultaListaAsistenciaDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ConsultaListaAsistenciaResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Conteo de resultados
        /// </summary>
        public int count { get; set; } 

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<ConsultaListaAsistenciaModel> ContentIndex { get; set; }
       

    }
}