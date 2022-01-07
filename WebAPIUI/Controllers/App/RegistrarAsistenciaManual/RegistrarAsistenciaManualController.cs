using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.App.ListaAsitenciaManual;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.App.RegistrarAsistenciaManual.Models;
using WebAPIUI.CustomExceptions.RegistrarAsistenciaManual;
using WebAPIUI.Helpers;

namespace WebAPIUI.Controllers.App.RegistrarAsistenciaManual

{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Eventos.
    /// </summary>
    public class RegistrarAsistenciaManualController : BaseAPIController 
    {
        private void ValidatePostRequest(RegistrarAsistenciaManualDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionRegistrarAsistenciaManualException(RegistrarAsistenciaManualResponseType.InvalidParameters, messages);
            }


        }



        /// <summary>
        /// Consulta los Eventos de la base 
        /// </summary>
        private bool RegistrarAsitencia(List<ListaAsitenciaManualEntity> listaAsitenciaManual)
        {
            RegistrarAsistenciaManualBO bo = new RegistrarAsistenciaManualBO();
            List<string> messages = new List<string>();
            bool response = false;
             
            try
            {
                response = bo.insertAsistenciaManual(listaAsitenciaManual);
            }
            catch (ValidationAndMessageException RegistrarAsistenciaManualException)
            {
                messages.Add(RegistrarAsistenciaManualException.Message);
                ThrowHandledExceptionRegistrarAsistenciaManualException(RegistrarAsistenciaManualResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionRegistrarAsistenciaManualException(RegistrarAsistenciaManualResponseType.Error, ex);
            }

            return response;
        }




        /// <summary>
        /// CRUD de Eventos para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public RegistrarAsistenciaManualDataResponse Post(RegistrarAsistenciaManualDataRequest dataRequest)
        {
            RegistrarAsistenciaManualDataResponse response = new RegistrarAsistenciaManualDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);
                if (dataRequest.listaAsistencia!=null) {
                    response.ResponseCode = RegistrarAsistenciaManualResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con exito";
                    response.content = RegistrarAsitencia(dataRequest.listaAsistencia);
                }
                else {
                    response.ResponseCode = RegistrarAsistenciaManualResponseType.Error;
                    response.ResponseMessage = "Fallo al ejecutar el método ";
                    response.content = RegistrarAsitencia(dataRequest.listaAsistencia);
                }
                

            }
            catch (RegistrarAsistenciaManualException RegistrarAsistenciaManualException)
            {
                SetResponseAsExceptionRegistrarAsistenciaManualException(RegistrarAsistenciaManualException.Type, response, RegistrarAsistenciaManualException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar RegistrarAsistenciaManual.";
                SetResponseAsExceptionRegistrarAsistenciaManualException(RegistrarAsistenciaManualResponseType.Error, response, message);
            }

            return response;
        }
    }
}