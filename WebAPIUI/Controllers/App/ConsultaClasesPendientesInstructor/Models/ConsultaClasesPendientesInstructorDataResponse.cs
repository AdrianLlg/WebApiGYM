using System.Collections.Generic;
using WebAPIUI.CustomExceptions.ConsultaClasesPendientesInstructor;
using WebAPIUI.Models.ConsultaClasesPendientesInstructor;
using WebAPIUI.Models.ConsultaHistorialAsitenciaCliente;

namespace WebAPIUI.Controllers.App.ConsultaClasesPendientesInstructor.Models
{
    public class ConsultaClasesPendientesInstructorDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ConsultaClasesPendientesInstructorResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<ConsultaClasesPendientesInstructorModel> ContentIndex { get; set; }
        

    }
}