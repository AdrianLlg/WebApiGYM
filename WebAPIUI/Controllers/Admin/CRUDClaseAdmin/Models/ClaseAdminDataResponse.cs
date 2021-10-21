using System.Collections.Generic;
using WebAPIUI.CustomExceptions.ClasesAdmin;
using WebAPIUI.Models.ClaseAdmin;

namespace WebAPIUI.Controllers.CRUDRClaseAdmin.Models
{
    public class ClaseAdminDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ClasesAdminResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<ClaseAdminModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public ClaseAdminModel ContentDetail { get; set; }
    }
}