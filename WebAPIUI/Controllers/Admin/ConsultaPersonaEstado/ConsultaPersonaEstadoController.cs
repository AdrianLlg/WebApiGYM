using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.ConsultaPersonaEstado;
using WebAPIUI.Controllers.ConsultaPersonaEstado.Models;
using WebAPIUI.CustomExceptions.ConsultaPersonaEstado;
using WebAPIUI.Helpers;
using WebAPIUI.Models.ConsultaPersonaEstado;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Salas.
    /// </summary>
    public class ConsultaPersonaEstadoController : BaseAPIController
    {
        private void ValidatePostRequest(ConsultaPersonaEstadoDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionConsultaPersonaEstado(ConsultaPersonaEstadoResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Consulta los Salas de la base 
        /// </summary>
        private List<ConsultaPersonaEstadoModel> consultarEventos(ConsultaPersonaEstadoDataRequest dataRequest)
        {
            ReportePersonasEstadoBO bo = new ReportePersonasEstadoBO();
            List<string> messages = new List<string>();
            List<ConsultaPersonaEstadoModel> response = new List<ConsultaPersonaEstadoModel>();
            List<ConsultaPersonaEstadoEntity> aux = new List<ConsultaPersonaEstadoEntity>();
            

            try
            {   
                response =  EntitesHelper.EntityToModelConsultaPersonaEstado(bo.getPersonas());
            }
            catch (ValidationAndMessageException ConsultaPersonaEstadoException)
            {
                messages.Add(ConsultaPersonaEstadoException.Message);
                ThrowHandledExceptionConsultaPersonaEstado(ConsultaPersonaEstadoResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionConsultaPersonaEstado(ConsultaPersonaEstadoResponseType.Error, ex);
            }

            return response;
        }





        /// <summary>
        /// CRUD de Salas para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ConsultaPersonaEstadoDataResponse Post(ConsultaPersonaEstadoDataRequest dataRequest)
        {
            ConsultaPersonaEstadoDataResponse response = new ConsultaPersonaEstadoDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);




                List<ConsultaPersonaEstadoModel> model = new List<ConsultaPersonaEstadoModel>();
                model = consultarEventos(dataRequest);

                if (dataRequest.flujoID == 0)
                {
                    if (model.Count > 0)
                    {
                        response.ResponseCode = ConsultaPersonaEstadoResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = ConsultaPersonaEstadoResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }


            }
            catch (ConsultaPersonaEstadoException ConsultaPersonaEstadoException)
            {
                SetResponseAsExceptionConsultaPersonaEstado(ConsultaPersonaEstadoException.Type, response, ConsultaPersonaEstadoException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ConsultaPersonaEstado.";
                SetResponseAsExceptionConsultaPersonaEstado(ConsultaPersonaEstadoResponseType.Error, response, message);
            }

            return response;
        }
    }
}