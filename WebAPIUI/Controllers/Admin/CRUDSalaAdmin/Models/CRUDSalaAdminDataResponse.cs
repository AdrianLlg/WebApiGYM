using System.Collections.Generic;
using WebAPIUI.CustomExceptions.SalasAdmin;
using WebAPIUI.Models.SalasAdmin;

namespace WebAPIUI.Controllers.CRUDSalaAdmin.Models
{
    public class CRUDSalaAdminDataResponse
        
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public SalaAdminResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<SalaAdminModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public SalaAdminModel ContentDetail { get; set; }
    }
}