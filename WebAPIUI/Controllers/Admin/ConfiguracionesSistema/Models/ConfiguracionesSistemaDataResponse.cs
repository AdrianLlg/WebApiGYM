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
using WebAPIBusiness.Entities.ConfiguracionesSistemaAdmin;
using WebAPIUI.Models.ConfiguracionesSistema;
using WebAPIUI.CustomExceptions.ConfiguracionesSistema;

namespace WebAPIUI.Controllers.ConfiguracionesSistema.Models
{
    public class ConfiguracionesSistemaDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ConfiguracionesSistemaResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<ConfiguracionesSistemaModel> Content { get; set; }
        /// <summary>
        /// Respuesta modificacion 
        /// </summary>
        public bool ContentModify { get; set; }

    }
}