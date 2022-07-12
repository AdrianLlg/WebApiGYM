using System.Collections.Generic;
using WebAPIUI.CustomExceptions.EventoAdmin;
using WebAPIUI.Models.EventoAdmin;

namespace WebAPIUI.Controllers.CRUDREventoAdmin.Models
{
    public class EventoAdminDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public EventoAdminResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<EventoAdminModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public EventoAdminModel ContentDetail { get; set; }
    }
}