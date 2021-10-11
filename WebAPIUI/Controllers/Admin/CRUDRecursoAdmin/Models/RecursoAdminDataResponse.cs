using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIUI.CustomExceptions.RecursoAdmin;
using WebAPIUI.Models.RecursoAdmin;

namespace WebAPIUI.Controllers.CRUDRecursoAdmin.Models
{
    public class RecursoAdminDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public RecursoAdminResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<RecursoAdminModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public RecursoAdminModel ContentDetail { get; set; }
    }
}