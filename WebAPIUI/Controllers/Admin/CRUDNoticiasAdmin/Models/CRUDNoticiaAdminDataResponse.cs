using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIUI.CustomExceptions.MembresiasAdmin;
using WebAPIUI.CustomExceptions.NoticiaAdmin;
using WebAPIUI.Models.MembresiasAdmin;
using WebAPIUI.Models.RegistroAdmin;
using WebAPIUI.Models.NoticiaAdmin;

namespace WebAPIUI.Controllers.CRUDNoticiaAdmin.Models
{
    public class CRUDNoticiaAdminDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public NoticiaAdminResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<NoticiaAdminModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public NoticiaAdminModel ContentDetail { get; set; }
    }
}