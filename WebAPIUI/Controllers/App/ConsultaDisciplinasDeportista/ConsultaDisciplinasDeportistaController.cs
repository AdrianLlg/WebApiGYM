using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.App.ConsultaDisciplinasDeportista;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.App.ConsultaDisciplinasDeportista.Models;
using WebAPIUI.CustomExceptions.ConsultaDisciplinasDeportista;
using WebAPIUI.Helpers;
using WebAPIUI.Models.ConsultaDisciplinasDeportista;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Eventos.
    /// </summary>
    public class ConsultaDisciplinasDeportistaController : BaseAPIController
    {
        private void ValidatePostRequest(ConsultaDisciplinasDeportistaDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionConsultaDisciplinasDeportistaException(ConsultaDisciplinasDeportistaResponseType.InvalidParameters, messages);
            }

        
        }

     

        /// <summary>
        /// Consulta los Eventos de la base 
        /// </summary>
        private List<ConsultaDisciplinasDeportistaEntity> ConsultaDisciplinasDeportista(int flujoID)
        {
            ConsultaDisciplinasDeportistaBO bo = new ConsultaDisciplinasDeportistaBO();
            List<string> messages = new List<string>();
            List<ConsultaDisciplinasDeportistaEntity> response = new List<ConsultaDisciplinasDeportistaEntity>();

            try
            {
                response = bo.getListaDisciplinas();
            }
            catch (ValidationAndMessageException ConsultaDisciplinasDeportistaException)
            {
                messages.Add(ConsultaDisciplinasDeportistaException.Message);
                ThrowHandledExceptionConsultaDisciplinasDeportistaException(ConsultaDisciplinasDeportistaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionConsultaDisciplinasDeportistaException(ConsultaDisciplinasDeportistaResponseType.Error, ex);
            }

            return response;
        }

     

    
        /// <summary>
        /// CRUD de Eventos para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ConsultaDisciplinasDeportistaDataResponse Post(ConsultaDisciplinasDeportistaDataRequest dataRequest)
        {
            ConsultaDisciplinasDeportistaDataResponse response = new ConsultaDisciplinasDeportistaDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

               
                    List<ConsultaDisciplinasDeportistaModel> model = new List<ConsultaDisciplinasDeportistaModel>();
                    List<ConsultaDisciplinasDeportistaEntity> items = ConsultaDisciplinasDeportista(dataRequest.flujoID);

                if (dataRequest.flujoID==0) {
                    if (items.Count > 0)
                    {
                        model = EntitesHelper.ConsultaDisciplinasDeportistaEntityToModel(items);
                        response.ResponseCode = ConsultaDisciplinasDeportistaResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = ConsultaDisciplinasDeportistaResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                
            }
            catch (ConsultaDisciplinasDeportistaException ConsultaDisciplinasDeportistaException)
            {
                SetResponseAsExceptionConsultaDisciplinasDeportistaException(ConsultaDisciplinasDeportistaException.Type, response, ConsultaDisciplinasDeportistaException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ConsultaDisciplinasDeportista.";
                SetResponseAsExceptionConsultaDisciplinasDeportistaException(ConsultaDisciplinasDeportistaResponseType.Error, response, message);
            }

            return response;
        }
    }
}