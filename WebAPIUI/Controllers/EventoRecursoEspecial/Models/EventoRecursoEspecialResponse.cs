using System.Collections.Generic;
using WebAPIUI.CustomExceptions.EventoRecursoEspecial;
using WebAPIUI.Models.EventoRecursoEspecial;

namespace WebAPIUI.Controllers.EventosRecursoEspecial.Models
{
    public class EventoRecursoEspecialResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public EventoRecursoEspecialResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<EventoRecursoEspecialModel> Content { get; set; }

    }
}