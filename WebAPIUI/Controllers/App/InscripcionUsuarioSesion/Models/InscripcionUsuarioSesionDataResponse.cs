using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBusiness.Entities.App.ConsultaEventosDeportista;
using WebAPIUI.CustomExceptions.App.InscripcionUsuarioSesion;

namespace WebAPIUI.Controllers.App.InscripcionUsuarioSesion.Models
{
    public class InscripcionUsuarioSesionDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public InscripcionUsuarioSesionResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public bool Content { get; set; }

    }
}