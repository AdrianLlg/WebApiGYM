using System.Collections.Generic;
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
        /// Conteo de resultados
        /// </summary>
        public int count { get; set; } 

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<ConsultaDisciplinasDeportistaModel> ContentIndex { get; set; }
       

    }
}