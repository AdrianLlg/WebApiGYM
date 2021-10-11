using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIUI.CustomExceptions.DisciplinaAdmin;
using WebAPIUI.Models.DisciplinaAdmin;

namespace WebAPIUI.Controllers.CRUDDisciplinaAdmin.Models
{
    public class DisciplinaAdminDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public DisciplinaAdminResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<DisciplinaAdminModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public DisciplinaAdminModel ContentDetail { get; set; }
    }
}