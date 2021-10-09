using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIUI.CustomExceptions.MembresiasAdmin;
using WebAPIUI.Models.MembresiasAdmin;
using WebAPIUI.Models.RegistroAdmin;

namespace WebAPIUI.Controllers.CRUDMembresiasAdmin.Models
{
    public class MembresiaAdminDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public MembresiaAdminResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<MembresiaAdminModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public MembresiaAdminModel ContentDetail { get; set; }
    }
}