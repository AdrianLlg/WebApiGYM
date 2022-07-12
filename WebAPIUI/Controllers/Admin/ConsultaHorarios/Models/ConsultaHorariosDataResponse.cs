using System.Collections.Generic;
using WebAPIBusiness.Entities.ConsultaHorarios;
using WebAPIUI.CustomExceptions.ConsultaHorarios;
using WebAPIBusiness.Entities.ConsultaHorarios;

namespace WebAPIUI.Controllers.CRUDRConsultaHorarios.Models
{
    public class ConsultaHorariosDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ConsultaHorariosResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<ConsultaHorariosModel> ContentIndex { get; set; }

    }
}