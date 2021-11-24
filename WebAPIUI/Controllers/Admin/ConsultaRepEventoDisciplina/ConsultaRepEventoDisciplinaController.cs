using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.ConsultaRepEventoDisciplina;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.ConsultaRepEventoDisciplina.Models;
using WebAPIUI.CustomExceptions.ConsultaRepEventoDisciplina;
using WebAPIUI.Helpers;
using WebAPIUI.Models.ConsultaRepEventoDisciplina;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Salas.
    /// </summary>
    public class ConsultaRepEventoDisciplinaController : BaseAPIController
    {
        private void ValidatePostRequest(ConsultaRepEventoDisciplinaDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionConsultaRepEventoDisciplina(ConsultaRepEventoDisciplinaResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Consulta los Salas de la base 
        /// </summary>
        private List<ConsultaRepEventoDisciplinaModel> consultarEventos(ConsultaRepEventoDisciplinaDataRequest dataRequest)
        {
            ReporteNoEventosDisciplinaBO bo = new ReporteNoEventosDisciplinaBO();
            List<string> messages = new List<string>();
            List<ConsultaRepEventoDisciplinaModel> response = new List<ConsultaRepEventoDisciplinaModel>();
            List<ConsultaRepEventoDisciplinaEntity> aux = new List<ConsultaRepEventoDisciplinaEntity>();
            

            try
            {   
                response =  EntitesHelper.EntityToModelConsultaRepEventoDisciplina(bo.getEventos(dataRequest.fechaInicio, dataRequest.fechaFin));
            }
            catch (ValidationAndMessageException ConsultaRepEventoDisciplinaException)
            {
                messages.Add(ConsultaRepEventoDisciplinaException.Message);
                ThrowHandledExceptionConsultaRepEventoDisciplina(ConsultaRepEventoDisciplinaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionConsultaRepEventoDisciplina(ConsultaRepEventoDisciplinaResponseType.Error, ex);
            }

            return response;
        }





        /// <summary>
        /// CRUD de Salas para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ConsultaRepEventoDisciplinaDataResponse Post(ConsultaRepEventoDisciplinaDataRequest dataRequest)
        {
            ConsultaRepEventoDisciplinaDataResponse response = new ConsultaRepEventoDisciplinaDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);




                List<ConsultaRepEventoDisciplinaModel> model = new List<ConsultaRepEventoDisciplinaModel>();
                model = consultarEventos(dataRequest);

                if (model.Count > 0)
                {
                    response.ResponseCode = ConsultaRepEventoDisciplinaResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.ContentIndex = model;
                }
                else
                {
                    response.ResponseCode = ConsultaRepEventoDisciplinaResponseType.InvalidParameters;
                    response.ResponseMessage = "Fallo en la ejecución.";
                    response.ContentIndex = null;
                }


            }
            catch (ConsultaRepEventoDisciplinaException ConsultaRepEventoDisciplinaException)
            {
                SetResponseAsExceptionConsultaRepEventoDisciplina(ConsultaRepEventoDisciplinaException.Type, response, ConsultaRepEventoDisciplinaException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ConsultaRepEventoDisciplina.";
                SetResponseAsExceptionConsultaRepEventoDisciplina(ConsultaRepEventoDisciplinaResponseType.Error, response, message);
            }

            return response;
        }
    }
}