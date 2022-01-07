using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.BusinessCore.App;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.App.ConsultaClasesPendientesInstructor;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.App.ConsultaClasesPendientesInstructor.Models;
using WebAPIUI.CustomExceptions.ConsultaClasesPendientesInstructor;
using WebAPIUI.Helpers;
using WebAPIUI.Models.ConsultaClasesPendientesInstructor;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Eventos.
    /// </summary>
    public class ConsultaClasesPendientesInstructorController : BaseAPIController
    {
        private void ValidatePostRequest(ConsultaClasesPendientesInstructorDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionConsultaClasesPendientesInstructorException(ConsultaClasesPendientesInstructorResponseType.InvalidParameters, messages);
            }

        
        }

     

        /// <summary>
        /// Consulta los Eventos de la base 
        /// </summary>
        private List<ConsultaClasesPendientesInstructorEntity> ConsultarHistorial(int personaID)
        {
            ConsultaClasesPendientesInstructorBO bo = new ConsultaClasesPendientesInstructorBO();
            List<string> messages = new List<string>();
            List<ConsultaClasesPendientesInstructorEntity> response = new List<ConsultaClasesPendientesInstructorEntity>();

            try
            {
                response = bo.getClasesPendientes(personaID);
            }
            catch (ValidationAndMessageException ConsultaClasesPendientesInstructorException)
            {
                messages.Add(ConsultaClasesPendientesInstructorException.Message);
                ThrowHandledExceptionConsultaClasesPendientesInstructorException(ConsultaClasesPendientesInstructorResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionConsultaClasesPendientesInstructorException(ConsultaClasesPendientesInstructorResponseType.Error, ex);
            }

            return response;
        }

     

    
        /// <summary>
        /// CRUD de Eventos para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ConsultaClasesPendientesInstructorDataResponse Post(ConsultaClasesPendientesInstructorDataRequest dataRequest)
        {
            ConsultaClasesPendientesInstructorDataResponse response = new ConsultaClasesPendientesInstructorDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

               
                    List<ConsultaClasesPendientesInstructorModel> model = new List<ConsultaClasesPendientesInstructorModel>();
                    List<ConsultaClasesPendientesInstructorEntity> items = ConsultarHistorial(dataRequest.personaID);

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.ConsultaClasesPendientesEntityToModel(items);
                        response.ResponseCode = ConsultaClasesPendientesInstructorResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = ConsultaClasesPendientesInstructorResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                
            }
            catch (ConsultaClasesPendientesInstructorException ConsultaClasesPendientesInstructorException)
            {
                SetResponseAsExceptionConsultaClasesPendientesInstructorException(ConsultaClasesPendientesInstructorException.Type, response, ConsultaClasesPendientesInstructorException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ConsultaClasesPendientesInstructor.";
                SetResponseAsExceptionConsultaClasesPendientesInstructorException(ConsultaClasesPendientesInstructorResponseType.Error, response, message);
            }

            return response;
        }
    }
}