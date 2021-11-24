using System.Collections.Generic;
using WebAPIUI.CustomExceptions.ConsultaVentasMembresias;
using WebAPIUI.Models.ConsultaVentasMembresias;

namespace WebAPIUI.Controllers.ConsultaVentasMembresias.Models
{
    public class ConsultaVentasMembresiasDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ConsultaVentasMembresiasResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<ConsultaVentasMembresiasModel> ContentIndex { get; set; }

    }
}