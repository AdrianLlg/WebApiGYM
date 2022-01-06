using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.App.ConsultaListaAsistencia;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.App.ConsultaListaAsistencia.Models;
using WebAPIUI.CustomExceptions.ConsultaListaAsistencia;
using WebAPIUI.Helpers;
using WebAPIUI.Models.ConsultaListaAsistencia;

namespace WebAPIUI.ContEventolers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Eventos.
    /// </summary>
    public class ConsultaListaAsistenciaController : BaseAPIController
    {
        private void ValidatePostRequest(ConsultaListaAsistenciaDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionConsultaListaAsistenciaException(ConsultaListaAsistenciaResponseType.InvalidParameters, messages);
            }

        
        }

     

        /// <summary>
        /// Consulta los Eventos de la base 
        /// </summary>
        private List<ConsultaListaAsistenciaEntity> ConsultarListaAsitencia(int eventoID)
        {
            ConsultaListaAsistenciaBO bo = new ConsultaListaAsistenciaBO();
            List<string> messages = new List<string>();
            List<ConsultaListaAsistenciaEntity> response = new List<ConsultaListaAsistenciaEntity>();

            try
            {
                response = bo.getListaAsistencia(eventoID);
            }
            catch (ValidationAndMessageException ConsultaListaAsistenciaException)
            {
                messages.Add(ConsultaListaAsistenciaException.Message);
                ThrowHandledExceptionConsultaListaAsistenciaException(ConsultaListaAsistenciaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionConsultaListaAsistenciaException(ConsultaListaAsistenciaResponseType.Error, ex);
            }

            return response;
        }

     

    
        /// <summary>
        /// CRUD de Eventos para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ConsultaListaAsistenciaDataResponse Post(ConsultaListaAsistenciaDataRequest dataRequest)
        {
            ConsultaListaAsistenciaDataResponse response = new ConsultaListaAsistenciaDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

               
                    List<ConsultaListaAsistenciaModel> model = new List<ConsultaListaAsistenciaModel>();
                    List<ConsultaListaAsistenciaEntity> items = ConsultarListaAsitencia(dataRequest.eventoID);

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.ConsultaListaAsistenciaEntityToModel(items);
                        response.ResponseCode = ConsultaListaAsistenciaResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = ConsultaListaAsistenciaResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                
            }
            catch (ConsultaListaAsistenciaException ConsultaListaAsistenciaException)
            {
                SetResponseAsExceptionConsultaListaAsistenciaException(ConsultaListaAsistenciaException.Type, response, ConsultaListaAsistenciaException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ConsultaListaAsistencia.";
                SetResponseAsExceptionConsultaListaAsistenciaException(ConsultaListaAsistenciaResponseType.Error, response, message);
            }

            return response;
        }
    }
}