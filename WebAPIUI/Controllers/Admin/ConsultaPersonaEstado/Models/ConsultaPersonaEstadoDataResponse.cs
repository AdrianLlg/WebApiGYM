using System.Collections.Generic;
using WebAPIUI.CustomExceptions.ConsultaPersonaEstado;
using WebAPIUI.Models.ConsultaPersonaEstado;

namespace WebAPIUI.Controllers.ConsultaPersonaEstado.Models
{
    public class ConsultaPersonaEstadoDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ConsultaPersonaEstadoResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<ConsultaPersonaEstadoModel> ContentIndex { get; set; }

    }
}