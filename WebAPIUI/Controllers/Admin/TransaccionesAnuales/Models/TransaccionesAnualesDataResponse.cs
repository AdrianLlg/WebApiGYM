using System.Collections.Generic;
using WebAPIUI.CustomExceptions.TransaccionesAnuales;
using WebAPIUI.Models.TransaccionesAnuales;

namespace WebAPIUI.Controllers.TransaccionesAnuales.Models
{
    public class TransaccionesAnualesDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public TransaccionesAnualesResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<TransaccionesAnualesModel> ContentIndex { get; set; }

    }
}