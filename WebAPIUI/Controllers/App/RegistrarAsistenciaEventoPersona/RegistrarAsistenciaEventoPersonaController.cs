using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.App.RegistrarAsistenciaEventoPersona.Models;
using WebAPIUI.CustomExceptions.RegistrarAsistenciaEventoPersona;
using WebAPIUI.Helpers;

namespace WebAPIUI.Controllers.App.RegistrarAsistenciaEventoPersona

{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Eventos.
    /// </summary>
    public class RegistrarAsistenciaEventoPersonaController : BaseAPIController
    {
        private void ValidatePostRequest(RegistrarAsistenciaEventoPersonaDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionRegistrarAsistenciaEventoPersonaException(RegistrarAsistenciaEventoPersonaResponseType.InvalidParameters, messages);
            }


        }



        /// <summary>
        /// Consulta los Eventos de la base 
        /// </summary>
        private string RegistrarAsitencia(int eventoID, int personaID)
        {
            RegistrarAsistenciaEventoPersonaBO bo = new RegistrarAsistenciaEventoPersonaBO();
            List<string> messages = new List<string>();
            string response = string.Empty;

            try
            {
                response = bo.registrarAsistenciaPersona(eventoID, personaID);
            }
            catch (ValidationAndMessageException RegistrarAsistenciaEventoPersonaException)
            {
                messages.Add(RegistrarAsistenciaEventoPersonaException.Message);
                ThrowHandledExceptionRegistrarAsistenciaEventoPersonaException(RegistrarAsistenciaEventoPersonaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionRegistrarAsistenciaEventoPersonaException(RegistrarAsistenciaEventoPersonaResponseType.Error, ex);
            }

            return response;
        }




        /// <summary>
        /// CRUD de Eventos para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public RegistrarAsistenciaEventoPersonaDataResponse Post(RegistrarAsistenciaEventoPersonaDataRequest dataRequest)
        {
            RegistrarAsistenciaEventoPersonaDataResponse response = new RegistrarAsistenciaEventoPersonaDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);  

                response.ResponseCode = RegistrarAsistenciaEventoPersonaResponseType.Ok;
                response.ResponseMessage = RegistrarAsitencia(dataRequest.eventoID,dataRequest.personaID);

            }
            catch (RegistrarAsistenciaEventoPersonaException RegistrarAsistenciaEventoPersonaException)
            {
                SetResponseAsExceptionRegistrarAsistenciaEventoPersonaException(RegistrarAsistenciaEventoPersonaException.Type, response, RegistrarAsistenciaEventoPersonaException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar RegistrarAsistenciaEventoPersona.";
                SetResponseAsExceptionRegistrarAsistenciaEventoPersonaException(RegistrarAsistenciaEventoPersonaResponseType.Error, response, message);
            }

            return response;
        }
    }
}