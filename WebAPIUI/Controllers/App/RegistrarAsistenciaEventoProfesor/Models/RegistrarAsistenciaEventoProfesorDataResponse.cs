using WebAPIUI.CustomExceptions.RegistrarAsistenciaEventoProfesor;

namespace WebAPIUI.Controllers.App.RegistrarAsistenciaEventoProfesor.Models
{
    public class RegistrarAsistenciaEventoProfesorDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public RegistrarAsistenciaEventoProfesorResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        public  bool content { get; set; }


    }
}