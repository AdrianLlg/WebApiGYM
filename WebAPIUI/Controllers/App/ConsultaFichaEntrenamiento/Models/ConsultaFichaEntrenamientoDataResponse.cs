using System.Collections.Generic;
using WebAPIBusiness.Entities.App.ConsultaFichaEntrenamiento;
using WebAPIUI.CustomExceptions.ConsultaFichaEntrenamiento;
using WebAPIUI.Models.ConsultaFichaEntrenamiento;

namespace WebAPIUI.Controllers.ConsultaFichaEntrenamiento.Models
{
    public class ConsultaFichaEntrenamientoDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ConsultaFichaEntrenamientoResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary> 
        /// Contenido de respuesta
        /// </summary>
        public List<ConsultaFichaEntrenamientoEntity> ContentIndex { get; set; }

    }
}