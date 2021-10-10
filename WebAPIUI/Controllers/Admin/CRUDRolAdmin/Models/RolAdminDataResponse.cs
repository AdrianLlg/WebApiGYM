using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIUI.CustomExceptions.MembresiasAdmin;
using WebAPIUI.CustomExceptions.RolAdmin;
using WebAPIUI.Models.MembresiasAdmin;
using WebAPIUI.Models.RegistroAdmin;
using WebAPIUI.Models.RolAdmin;

namespace WebAPIUI.Controllers.CRUDRolAdmin.Models
{
    public class RolAdminDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public RolAdminResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<RolAdminModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public RolAdminModel ContentDetail { get; set; }
    }
}