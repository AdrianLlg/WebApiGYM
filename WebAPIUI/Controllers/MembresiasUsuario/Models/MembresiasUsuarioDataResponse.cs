﻿using System;
using System.Collections.Generic;
using WebAPIBusiness.Entities.Membresia;
using System.Linq;
using System.Web;
using WebAPIUI.CustomExceptions.MembresiasUsuario;

namespace WebAPIUI.Controllers.MembresiasUsuario.Models
{
    public class MembresiasUsuarioDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public MembresiasUsuarioResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<MembresiaEntity> Content { get; set; }

    }
}