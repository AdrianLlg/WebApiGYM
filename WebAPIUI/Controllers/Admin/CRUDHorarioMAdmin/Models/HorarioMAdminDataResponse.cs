using System.Collections.Generic;
using WebAPIUI.CustomExceptions.HorarioMAdmin;
using WebAPIUI.Models.HorarioMAdmin;

namespace WebAPIUI.Controllers.CRUDRHorarioMAdmin.Models
{
    public class HorarioMAdminDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public HorarioMAdminResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<HorarioMAdminModel> ContentIndex { get; set; }

        public bool ContentCreate { get; set; }

        public bool ContentModify { get; set; }

        public HorarioMAdminModel ContentDetail { get; set; }
    }
}