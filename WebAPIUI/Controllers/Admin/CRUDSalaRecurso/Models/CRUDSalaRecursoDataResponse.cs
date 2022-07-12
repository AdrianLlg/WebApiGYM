using System.Collections.Generic;
using WebAPIUI.CustomExceptions.SalaRecurso;
using WebAPIUI.Models.SalaRecurso;

namespace WebAPIUI.Controllers.CRUDSalaRecurso.Models
{
    public class SalaRecursoDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public SalaRecursoResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<SalaRecursoModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public SalaRecursoModel ContentDetail { get; set; }
    }
}