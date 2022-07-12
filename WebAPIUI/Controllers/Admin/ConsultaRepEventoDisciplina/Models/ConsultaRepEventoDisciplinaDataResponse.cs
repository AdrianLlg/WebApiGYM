using System.Collections.Generic;
using WebAPIUI.CustomExceptions.ConsultaRepEventoDisciplina;
using WebAPIUI.Models.ConsultaRepEventoDisciplina;

namespace WebAPIUI.Controllers.ConsultaRepEventoDisciplina.Models
{
    public class ConsultaRepEventoDisciplinaDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ConsultaRepEventoDisciplinaResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<ConsultaRepEventoDisciplinaModel> ContentIndex { get; set; }

    }
}