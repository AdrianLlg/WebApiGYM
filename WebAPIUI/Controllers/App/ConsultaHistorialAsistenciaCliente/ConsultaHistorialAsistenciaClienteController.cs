using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.App.ConsultaHistorialAsistenciaCliente;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.App.ConsultaHistorialAsistenciaCliente.Models;
using WebAPIUI.CustomExceptions.ConsultaHistorialAsistenciaCliente;
using WebAPIUI.Helpers;
using WebAPIUI.Models.ConsultaHistorialAsitenciaCliente;

namespace WebAPIUI.ContEventolers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Eventos.
    /// </summary>
    public class ConsultaHistorialAsistenciaClienteController : BaseAPIController
    {
        private void ValidatePostRequest(ConsultaHistorialAsistenciaClienteDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionConsultaHistorialAsitenciaClienteException(ConsultaHistorialAsistenciaClienteResponseType.InvalidParameters, messages);
            }

        
        }

     

        /// <summary>
        /// Consulta los Eventos de la base 
        /// </summary>
        private List<ConsultaHistorialAsistenciaClienteEntity> ConsultarHistorial(int personaID)
        {
            ConsultaHistorialAsistenciaClienteBO bo = new ConsultaHistorialAsistenciaClienteBO();
            List<string> messages = new List<string>();
            List<ConsultaHistorialAsistenciaClienteEntity> response = new List<ConsultaHistorialAsistenciaClienteEntity>();

            try
            {
                response = bo.getHistorialAsistencia(personaID);
            }
            catch (ValidationAndMessageException ConsultaHistorialAsistenciaClienteException)
            {
                messages.Add(ConsultaHistorialAsistenciaClienteException.Message);
                ThrowHandledExceptionConsultaHistorialAsitenciaClienteException(ConsultaHistorialAsistenciaClienteResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionConsultaHistorialAsitenciaClienteException(ConsultaHistorialAsistenciaClienteResponseType.Error, ex);
            }

            return response;
        }

     

    
        /// <summary>
        /// CRUD de Eventos para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ConsultaHistorialAsistenciaClienteDataResponse Post(ConsultaHistorialAsistenciaClienteDataRequest dataRequest)
        {
            ConsultaHistorialAsistenciaClienteDataResponse response = new ConsultaHistorialAsistenciaClienteDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

               
                    List<ConsultaHistorialAsistenciaClienteModel> model = new List<ConsultaHistorialAsistenciaClienteModel>();
                    List<ConsultaHistorialAsistenciaClienteEntity> items = ConsultarHistorial(dataRequest.personaID);

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.ConsultaHistorialAsitenciaClienteEntityToModel(items);
                        response.ResponseCode = ConsultaHistorialAsistenciaClienteResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = ConsultaHistorialAsistenciaClienteResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                
            }
            catch (ConsultaHistorialAsistenciaClienteException ConsultaHistorialAsistenciaClienteException)
            {
                SetResponseAsExceptionConsultaHistorialAsitenciaClienteException(ConsultaHistorialAsistenciaClienteException.Type, response, ConsultaHistorialAsistenciaClienteException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ConsultaHistorialAsistenciaCliente.";
                SetResponseAsExceptionConsultaHistorialAsitenciaClienteException(ConsultaHistorialAsistenciaClienteResponseType.Error, response, message);
            }

            return response;
        }
    }
}