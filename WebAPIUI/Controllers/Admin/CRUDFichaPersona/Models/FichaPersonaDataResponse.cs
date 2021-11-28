using System.Collections.Generic;
using WebAPIUI.CustomExceptions.FichaPersona;
using WebAPIUI.Models.Fichas;

namespace WebAPIUI.Controllers.CRUDFichaPersona.Models
{
    public class FichaPersonaDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public FichaPersonaResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<FichaPersonaModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public FichaPersonaModel ContentDetail { get; set; }
    }
}