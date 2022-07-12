using System;
using System.Collections.Generic;
using WebAPIBusiness.Entities.HorasDisciplina;
using System.Linq;
using System.Web;
using WebAPIUI.CustomExceptions.HorasDisciplina;

namespace WebAPIUI.Controllers.HorasDisciplina.Models
{
    public class HorasDisciplinaDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public HorasDisciplinaResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<HorasDisciplinaEntity> Content { get; set; }

    }
}