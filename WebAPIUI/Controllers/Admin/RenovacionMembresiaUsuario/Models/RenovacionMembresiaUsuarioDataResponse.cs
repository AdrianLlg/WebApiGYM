using System;
using System.Collections.Generic;
using WebAPIBusiness.Entities.Membresia;
using System.Linq;
using System.Web;
using WebAPIUI.CustomExceptions.MembresiasUsuario;
using WebAPIUI.Models;
using WebAPIUI.Models.Membresias;
using WebAPIUI.Models.MembresiasAdmin;
using WebAPIUI.CustomExceptions.MembresiasAdmin;

namespace WebAPIUI.Controllers.RenovacionMembresiaUsuario.Models
{
    public class RenovacionMembresiaUsuarioDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public RenovacionMembresiaUsuarioResponseType ResponseCode { get; set; }

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