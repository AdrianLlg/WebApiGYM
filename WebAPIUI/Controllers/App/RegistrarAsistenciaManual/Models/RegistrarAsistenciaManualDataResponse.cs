using WebAPIUI.CustomExceptions.RegistrarAsistenciaManual;

namespace WebAPIUI.Controllers.App.RegistrarAsistenciaManual.Models
{
    public class RegistrarAsistenciaManualDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public RegistrarAsistenciaManualResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }


        /// <summary>
        /// Content
        /// </summary>
        public bool content { get; set; }





    }
}