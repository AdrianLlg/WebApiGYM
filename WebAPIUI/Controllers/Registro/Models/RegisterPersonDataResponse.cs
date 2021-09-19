using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIUI.CustomExceptions.RegisterPerson;

namespace WebAPIUI.Controllers.Login.Models
{
    public class RegisterPersonDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public RegisterPersonResponseType ResponseCode { get; set; }

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