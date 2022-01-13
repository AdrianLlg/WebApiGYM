using WebAPIUI.CustomExceptions.CancelarEventoApp;

namespace WebAPIUI.Controllers.CRUDRCancelarEventoApp.Models
{
    public class CancelarEventoAppDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public CancelarEventoAppResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public bool Content{ get; set; }

        

        
    }
}