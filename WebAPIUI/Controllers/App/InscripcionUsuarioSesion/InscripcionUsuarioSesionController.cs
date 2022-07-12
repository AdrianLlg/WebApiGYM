using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.BusinessCore.App;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.App.ConsultaEventosDeportista;
using WebAPIBusiness.Entities.EventoAdmin;
using WebAPIUI.Controllers.App.InscripcionUsuarioSesion.Models;
using WebAPIUI.CustomExceptions.App.InscripcionUsuarioSesion;

namespace WebAPIUI.Controllers.App.InscripcionUsuarioSesion
{
    public class InscripcionUsuarioSesionController : BaseAPIController
    {
        private void ValidatePostRequest(InscripcionUsuarioSesionDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionInscripcionUsuarioSesion(InscripcionUsuarioSesionResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Inserta al usuario en el evento recibido
        /// </summary>
        private bool InscripcionUsuario(int personaID, int eventoID, string estado, int recursoAsignadoID, bool recursosEvento) 
        { 
            EventoAdminBO bo = new EventoAdminBO();
            List<string> messages = new List<string>();
            bool resp = false;

            try
            {
                resp = bo.RegisterEventUser(personaID, eventoID, estado, recursoAsignadoID, recursosEvento);
            }
            catch (ValidationAndMessageException InscripcionUsuarioSesionException)
            {
                messages.Add(InscripcionUsuarioSesionException.Message);
                ThrowHandledExceptionInscripcionUsuarioSesion(InscripcionUsuarioSesionResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionInscripcionUsuarioSesion(InscripcionUsuarioSesionResponseType.Error, ex);
            }

            return resp;
        }



        /// <summary>
        /// Inscribe a la persona en la sesion proporcionada
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public InscripcionUsuarioSesionDataResponse Post(InscripcionUsuarioSesionDataRequest dataRequest)
        {
            InscripcionUsuarioSesionDataResponse response = new InscripcionUsuarioSesionDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                bool resp = InscripcionUsuario(dataRequest.personaID, dataRequest.eventoID, dataRequest.estado, dataRequest.recursoAsignado, dataRequest.recursosEvento);

                if (resp)
                {
                    response.ResponseCode = InscripcionUsuarioSesionResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.Content = true;
                }
                else
                {
                    response.ResponseCode = InscripcionUsuarioSesionResponseType.Error;
                    response.ResponseMessage = "Error en la ejecución";
                    response.Content = false;
                }

            }
            catch (InscripcionUsuarioSesionException InscripcionUsuarioSesionException)
            {
                SetResponseAsExceptionInscripcionUsuarioSesion(InscripcionUsuarioSesionException.Type, response, InscripcionUsuarioSesionException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar InscripcionUsuarioSesion.";
                SetResponseAsExceptionInscripcionUsuarioSesion(InscripcionUsuarioSesionResponseType.Error, response, message);
            }

            return response;
        }
    }
}