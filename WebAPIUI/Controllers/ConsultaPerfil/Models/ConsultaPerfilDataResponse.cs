using System.Collections.Generic;
using WebAPIUI.CustomExceptions.ConsultaPerfil;
using WebAPIUI.Models.ConsultaPerfilModel;

namespace WebAPIUI.Controllers.ConsultaPerfil.Models
{
    public class ConsultaPerfilDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ConsultaPerfilResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<ConsultaPerfilModel> ContentIndex { get; set; }

    }
}