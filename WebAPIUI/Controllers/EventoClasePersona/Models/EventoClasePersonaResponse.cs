using System.Collections.Generic;
using WebAPIUI.CustomExceptions.EventoClasePersona;
using WebAPIUI.Models.EventoClasePersona;

namespace WebAPIUI.Controllers.EventoClasePersona.Models
{
    public class EventoClasePersonaResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public EventoClasePersonaResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<EventoClasePersonaModel> Content { get; set; }

    }
}