using System.Collections.Generic;
using WebAPIUI.CustomExceptions.ConsultaRepEventoSala;
using WebAPIUI.Models.ConsultaRepEventoSala;

namespace WebAPIUI.Controllers.ConsultaRepEventoSala.Models
{
    public class ConsultaRepEventoSalaDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ConsultaRepEventoSalaResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<ConsultaRepEventoSalaModel> ContentIndex { get; set; }

    }
}