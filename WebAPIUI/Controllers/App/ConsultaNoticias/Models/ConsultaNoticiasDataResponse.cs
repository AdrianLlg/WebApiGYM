using System.Collections.Generic;
using WebAPIBusiness.Entities.App.ConsultaNoticias;
using WebAPIUI.CustomExceptions.ConsultaNoticias;

namespace WebAPIUI.Controllers.App.ConsultaNoticias.Models
{
    public class ConsultaNoticiasDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ConsultaNoticiasResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Conteo de resultados
        /// </summary>
        public int count { get; set; } 

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<ConsultaNoticiaEntity> ContentIndex { get; set; }
       

    }
}