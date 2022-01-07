using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.App.ConsultaNoticias;
using WebAPIUI.Controllers.App.ConsultaNoticias.Models;
using WebAPIUI.CustomExceptions.ConsultaNoticias;
using WebAPIUI.Helpers;
using WebAPIUI.Models.ConsultaNoticias;

namespace WebAPIUI.Controllers.App.ConsultaNoticias
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Salas.
    /// </summary>
    public class ConsultaNoticiasController : BaseAPIController
    {
        private void ValidatePostRequest(ConsultaNoticiasDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionConsultaNoticiasException(ConsultaNoticiasResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Consulta los Salas de la base 
        /// </summary>
        private List<ConsultaNoticiaEntity> consultarEventos(ConsultaNoticiasDataRequest dataRequest)
        {
            ConsultaNoticiasAppBO bo = new ConsultaNoticiasAppBO();
            List<string> messages = new List<string>();
            List<ConsultaNoticiaEntity> response = new List<ConsultaNoticiaEntity>();
            List<ConsultaNoticiaEntity> aux = new List<ConsultaNoticiaEntity>();
            

            try
            {   
                response =  bo.getNoticias();
            }
            catch (ValidationAndMessageException ConsultaNoticiasException)
            {
                messages.Add(ConsultaNoticiasException.Message);
                ThrowHandledExceptionConsultaNoticiasException(ConsultaNoticiasResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionConsultaNoticiasException(ConsultaNoticiasResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// CRUD de Salas para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ConsultaNoticiasDataResponse Post(ConsultaNoticiasDataRequest dataRequest)
        {
            ConsultaNoticiasDataResponse response = new ConsultaNoticiasDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);


                List<ConsultaNoticiaEntity> model = new List<ConsultaNoticiaEntity>();
                model = consultarEventos(dataRequest);

                if (dataRequest.flujoID == 0)
                {
                    if (model.Count > 0)
                    {
                        response.ResponseCode = ConsultaNoticiasResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.count = model.Count;
                        response.ContentIndex = model;
                        
                    }
                    else
                    {
                        response.ResponseCode = ConsultaNoticiasResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.count = 0;
                        response.ContentIndex = null;
                        
                    }
                }


            }
            catch (ConsultaNoticiasException ConsultaNoticiasException)
            {
                SetResponseAsExceptionConsultaNoticiasException(ConsultaNoticiasException.Type, response, ConsultaNoticiasException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ConsultaNoticias.";
                SetResponseAsExceptionConsultaNoticiasException(ConsultaNoticiasResponseType.Error, response, message);
            }

            return response;
        }
    }
}