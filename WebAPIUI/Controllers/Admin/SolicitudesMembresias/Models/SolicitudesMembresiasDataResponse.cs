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
using WebAPIBusiness.Entities.SolicitudesMembresias;
using WebAPIUI.Models.SolicitudesMembresias;
using WebAPIUI.CustomExceptions.SolicitudesMembresias;

namespace WebAPIUI.Controllers.SolicitudesMembresias.Models
{
    public class SolicitudesMembresiasDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public SolicitudesMembresiasResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<SolicitudesMembresiasModel> Content { get; set; }
        /// <summary>
        /// Respuesta modificacion 
        /// </summary>
        public bool ContentModify { get; set; }

    }
}