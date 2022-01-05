using WebAPIBusiness.Entities.App.ConsultaFichaPersona;
using WebAPIUI.CustomExceptions.ConsultaFichaPersona;
using WebAPIUI.Models.ConsultaFichaPersona;

namespace WebAPIUI.Controllers.ConsultaFichaPersona.Models
{
    public class ConsultaFichaPersonaDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ConsultaFichaPersonaResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public ConsultaFichaPersonaEntity ContentIndex { get; set; }

    }
}