using System;
using System.Collections.Generic;
using WebAPIBusiness.Entities.Login;
using System.Linq;
using System.Web;
using WebAPIUI.CustomExceptions.Login;

namespace WebAPIUI.Controllers.Login.Models
{
    public class LoginDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public LoginResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public UsuarioEntity Content { get; set; }

    }
}