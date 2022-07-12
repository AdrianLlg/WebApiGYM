using System.Collections.Generic;
using WebAPIBusiness.Entities.MembresiaAdmin;
using WebAPIUI.CustomExceptions.MembresiaPersonaDisciplina;
using WebAPIUI.CustomExceptions.MembresiaPersonaDisciplinaAdmin;
using WebAPIUI.Models.MembresiaPersonaDisciplina;

namespace WebAPIUI.Controllers.MembresiaPersonaDisciplina.Models
{
    public class MembresiaPersonaDisciplinaDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public MembresiaPersonaDisciplinaResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<MembresiaPersonaDisciplinaEntity> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public MembresiaPersonaDisciplinaEntity ContentDetail { get; set; } 
    }
}