using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBusiness.Entities.RegistroAdmin;
using WebAPIUI.CustomExceptions.RegisterPerson;
using WebAPIUI.CustomExceptions.RegistroAdmin;
using WebAPIUI.Models.RegistroAdmin;

namespace WebAPIUI.Controllers.CRUDRegistroAdmin.Models
{
    public class RegistroAdminDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public RegistroAdminResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<RegistroAdminModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public RegistroAdminModel ContentDetail { get; set; }
    }
}