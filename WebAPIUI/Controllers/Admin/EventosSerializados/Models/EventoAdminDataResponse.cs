using System.Collections.Generic;
using WebAPIBusiness.Entities.EventosSerializados;
using WebAPIUI.CustomExceptions.EventosSerializados;


namespace WebAPIUI.Controllers.EventosSerializados.Models
{
    public class EventosSerializadosDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public EventosSerializadosResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        
        public bool ContentCreate { get; set; }

    }
}