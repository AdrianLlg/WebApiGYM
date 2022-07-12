using System;
using System.Collections.Generic;
using WebAPIBusiness.Entities.Login;
using System.Linq;
using System.Web;
using WebAPIUI.CustomExceptions.Login;
using WebAPIUI.CustomExceptions.App.ModificacionDatosPersonales;

namespace WebAPIUI.Controllers.App.ModificacionDatosPersonales.Models
{
    public class ModificacionDatosPersonalesDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ModificacionDatosPersonalesResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public bool ContentPassword { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public bool ContentPersonalInfo { get; set; }

    }
}