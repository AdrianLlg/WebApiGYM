using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBusiness.Entities.RegistroAdmin;
using WebAPIUI.CustomExceptions.RegisterPerson;
using WebAPIUI.CustomExceptions.RegistroAdmin;

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
        public List<UsuariosRegistradosEntity> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }


    }
}