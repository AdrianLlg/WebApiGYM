using WebAPIUI.CustomExceptions.GenerarQRInstructor;

namespace WebAPIUI.Controllers.App.GenerarQRInstructor.Models
{
    public class GenerarQRInstructorDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public GenerarQRInstructorResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }



        public  bool content { get; set; }
         



    }
}