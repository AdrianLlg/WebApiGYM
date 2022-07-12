using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIUI.CustomExceptions.App.ConsultaHorariosDeportista;
using WebAPIBusiness.Entities.App.ConsultaEventosDeportista;

namespace WebAPIUI.Controllers.App.ConsultaHorariosDeportista.Models
{
    public class ConsultaHorariosDeportistaDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ConsultaHorariosDeportistaResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<EventosDeportistaEntity> Content { get; set; }

    }
}