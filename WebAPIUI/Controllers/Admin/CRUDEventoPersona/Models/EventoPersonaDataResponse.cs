using System.Collections.Generic;
using WebAPIUI.CustomExceptions.EventoPersona;
using WebAPIUI.Models.EventoPersona;

namespace WebAPIUI.Controllers.CRUDREventoPersona.Models
{
    public class EventoPersonaDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public EventoPersonaResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<EventoPersonaModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public EventoPersonaModel ContentDetail { get; set; }
    }
}