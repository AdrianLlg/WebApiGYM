using System.Collections.Generic;
using WebAPIBusiness.Entities.App.ConsultaDisciplinasDeportista;
using WebAPIUI.CustomExceptions.ConsultaDisciplinasDeportista;
using WebAPIUI.Models.ConsultaDisciplinasDeportista;

namespace WebAPIUI.Controllers.App.ConsultaDisciplinasDeportista.Models
{
    public class ConsultaDisciplinasDeportistaDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ConsultaDisciplinasDeportistaResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<ConsultaDisciplinasDeportistaEntity> Content { get; set; }
       

    }
}