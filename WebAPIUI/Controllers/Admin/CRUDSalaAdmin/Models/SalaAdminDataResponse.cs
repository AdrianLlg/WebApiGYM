using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIUI.CustomExceptions.MembresiasAdmin;
using WebAPIUI.CustomExceptions.SalaAdmin;
using WebAPIUI.Models.MembresiasAdmin;
using WebAPIUI.Models.RegistroAdmin;
using WebAPIUI.Models.SalaAdmin;

namespace WebAPIUI.Controllers.CRUDRSalaAdmin.Models
{
    public class SalaAdminDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public SalaAdminResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<SalaAdminModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public SalaAdminModel ContentDetail { get; set; }
    }
}