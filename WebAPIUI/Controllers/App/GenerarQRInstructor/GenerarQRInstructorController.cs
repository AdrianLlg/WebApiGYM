using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.App.GenerarQRInstructor.Models;
using WebAPIUI.CustomExceptions.GenerarQRInstructor;
using WebAPIUI.Helpers;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Eventos.
    /// </summary>
    public class GenerarQRInstructorController : BaseAPIController
    {
        private void ValidatePostRequest(GenerarQRInstructorDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionGenerarQRInstructorException(GenerarQRInstructorResponseType.InvalidParameters, messages);
            }


        }



        /// <summary>
        /// Consulta los Eventos de la base 
        /// </summary>
        private bool GenerarQRInstructor(int eventoID)
        {
            RegistrarAsistenciaEventoPersonaBO bo = new RegistrarAsistenciaEventoPersonaBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.GenerarQRInstructor(eventoID);
            }
            catch (ValidationAndMessageException GenerarQRInstructorException)
            {
                messages.Add(GenerarQRInstructorException.Message);
                ThrowHandledExceptionGenerarQRInstructorException(GenerarQRInstructorResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionGenerarQRInstructorException(GenerarQRInstructorResponseType.Error, ex);
            }

            return response;
        }




        /// <summary>
        /// CRUD de Eventos para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public GenerarQRInstructorDataResponse Post(GenerarQRInstructorDataRequest dataRequest)
        {
            GenerarQRInstructorDataResponse response = new GenerarQRInstructorDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);
                if (GenerarQRInstructor(dataRequest.eventoID))
                {
                    response.ResponseCode = GenerarQRInstructorResponseType.Ok;
                    response.ResponseMessage = "Si es posible generar el código QR";
                    response.content = GenerarQRInstructor(dataRequest.eventoID);
                }
                else {
                    response.ResponseCode = GenerarQRInstructorResponseType.Error;
                    response.ResponseMessage = "No es posible generar el código QR";
                    response.content = GenerarQRInstructor(dataRequest.eventoID); 
                }

                

            }
            catch (GenerarQRInstructorException GenerarQRInstructorException)
            {
                SetResponseAsExceptionGenerarQRInstructorException(GenerarQRInstructorException.Type, response, GenerarQRInstructorException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar GenerarQRInstructor.";
                SetResponseAsExceptionGenerarQRInstructorException(GenerarQRInstructorResponseType.Error, response, message);
            }

            return response;
        }
    }
}