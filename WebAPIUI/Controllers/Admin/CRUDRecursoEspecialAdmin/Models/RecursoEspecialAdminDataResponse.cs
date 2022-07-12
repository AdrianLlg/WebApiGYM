using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIUI.CustomExceptions.RecursoEspecialAdmin;
using WebAPIUI.Models.RecursoEspecialAdmin;

namespace WebAPIUI.Controllers.CRUDRecursoEspecialAdmin.Models
{
    public class RecursoEspecialAdminDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public RecursoEspecialAdminResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<RecursoEspecialAdminModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public RecursoEspecialAdminModel ContentDetail { get; set; }
    }
}