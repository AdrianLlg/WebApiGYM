using System.Collections.Generic;
using WebAPIUI.CustomExceptions.SalaRecursoEspecial;
using WebAPIUI.Models.SalaRecursoEspecial;

namespace WebAPIUI.Controllers.CRUDSalaRecursoEspecialEspecial.Models
{
    public class SalaRecursoEspecialDataResponse
    {
        /// <summary> 
        /// Código de respuesta
        /// </summary>
        public SalaRecursoEspecialResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<SalaRecursoEspecialModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public SalaRecursoEspecialModel ContentDetail { get; set; }
    }
}