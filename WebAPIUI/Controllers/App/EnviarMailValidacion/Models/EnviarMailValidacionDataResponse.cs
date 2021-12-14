using System;
using System.Collections.Generic;
using WebAPIBusiness.Entities.Login;
using System.Linq;
using System.Web;
using WebAPIUI.CustomExceptions.Login;
using WebAPIUI.CustomExceptions.App.ModificacionDatosPersonales;
using WebAPIUI.CustomExceptions.App.EnviarMailValidacion;

namespace WebAPIUI.Controllers.App.EnviarMailValidacion.Models
{
    public class EnviarMailValidacionDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public EnviarMailValidacionResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public string Content { get; set; }

    }
}