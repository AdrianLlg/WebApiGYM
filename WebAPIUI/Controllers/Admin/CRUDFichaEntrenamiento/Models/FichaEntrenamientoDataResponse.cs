using System.Collections.Generic;
using WebAPIUI.CustomExceptions.FichaEntrenamiento;
using WebAPIUI.Models.Fichas;

namespace WebAPIUI.Controllers.CRUDFichaEntrenamiento.Models
{
    public class FichaEntrenamientoDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public FichaEntrenamientoResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<FichaEntrenamientoModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public FichaEntrenamientoModel ContentDetail { get; set; }
    }
}