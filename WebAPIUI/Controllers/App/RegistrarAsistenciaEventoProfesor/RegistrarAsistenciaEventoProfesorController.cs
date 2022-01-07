using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.App.RegistrarAsistenciaEventoProfesor.Models;
using WebAPIUI.CustomExceptions.RegistrarAsistenciaEventoProfesor;
using WebAPIUI.Helpers;

namespace WebAPIUI.Controllers.App.RegistrarAsistenciaEventoProfesor

{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Eventos.
    /// </summary>
    public class RegistrarAsistenciaEventoProfesorController : BaseAPIController
    {
        private void ValidatePostRequest(RegistrarAsistenciaEventoProfesorDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionRegistrarAsistenciaEventoProfesorException(RegistrarAsistenciaEventoProfesorResponseType.InvalidParameters, messages);
            }


        }



        /// <summary>
        /// Consulta los Eventos de la base 
        /// </summary>
        private bool RegistrarAsistenciaEventoProfesor(int eventoID, int personaID)
        {
            RegistrarAsistenciaEventoProfesorBO bo = new RegistrarAsistenciaEventoProfesorBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.RegistrarEventoProfesor(eventoID, personaID); 
            }
            catch (ValidationAndMessageException RegistrarAsistenciaEventoProfesorException)
            {
                messages.Add(RegistrarAsistenciaEventoProfesorException.Message);
                ThrowHandledExceptionRegistrarAsistenciaEventoProfesorException(RegistrarAsistenciaEventoProfesorResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionRegistrarAsistenciaEventoProfesorException(RegistrarAsistenciaEventoProfesorResponseType.Error, ex);
            }

            return response;
        }




        /// <summary>
        /// CRUD de Eventos para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public RegistrarAsistenciaEventoProfesorDataResponse Post(RegistrarAsistenciaEventoProfesorDataRequest dataRequest)
        {
            RegistrarAsistenciaEventoProfesorDataResponse response = new RegistrarAsistenciaEventoProfesorDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;
                ValidatePostRequest(dataRequest);  
                bool resultado = RegistrarAsistenciaEventoProfesor(dataRequest.eventoID, dataRequest.personaID);
                if (resultado) {
                    response.ResponseCode = RegistrarAsistenciaEventoProfesorResponseType.Ok;
                    response.ResponseMessage = "La asistencia del instructor ha sido registrada";
                    response.content = resultado;
                }
                else {
                    response.ResponseCode = RegistrarAsistenciaEventoProfesorResponseType.Ok;
                    response.ResponseMessage = "La asistencia del instructor no ha sido registrada";
                    response.content = resultado;
                }

                

            }
            catch (RegistrarAsistenciaEventoProfesorException RegistrarAsistenciaEventoProfesorException)
            {
                SetResponseAsExceptionRegistrarAsistenciaEventoProfesorException(RegistrarAsistenciaEventoProfesorException.Type, response, RegistrarAsistenciaEventoProfesorException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar RegistrarAsistenciaEventoProfesor.";
                SetResponseAsExceptionRegistrarAsistenciaEventoProfesorException(RegistrarAsistenciaEventoProfesorResponseType.Error, response, message);
            }

            return response;
        }
    }
}