using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.ConsultaRepEventoSala;
using WebAPIUI.Controllers.ConsultaRepEventoSala.Models;
using WebAPIUI.CustomExceptions.ConsultaRepEventoSala;
using WebAPIUI.Helpers;
using WebAPIUI.Models.ConsultaRepEventoSala;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Salas.
    /// </summary>
    public class ConsultaRepEventoSalaController : BaseAPIController
    {
        private void ValidatePostRequest(ConsultaRepEventoSalaDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionConsultaRepEventoSala(ConsultaRepEventoSalaResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Consulta los Salas de la base 
        /// </summary>
        private List<ConsultaRepEventoSalaModel> consultarEventos(ConsultaRepEventoSalaDataRequest dataRequest)
        {
            ReporteNoEventosSalaBO bo = new ReporteNoEventosSalaBO();
            List<string> messages = new List<string>();
            List<ConsultaRepEventoSalaModel> response = new List<ConsultaRepEventoSalaModel>();
            List<ConsultaRepEventoSalaEntity> aux = new List<ConsultaRepEventoSalaEntity>();
            

            try
            {   
                response =  EntitesHelper.EntityToModelConsultaRepEventoSala(bo.getEventos(dataRequest.fechaInicio, dataRequest.fechaFin));
            }
            catch (ValidationAndMessageException ConsultaRepEventoSalaException)
            {
                messages.Add(ConsultaRepEventoSalaException.Message);
                ThrowHandledExceptionConsultaRepEventoSala(ConsultaRepEventoSalaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionConsultaRepEventoSala(ConsultaRepEventoSalaResponseType.Error, ex);
            }

            return response;
        }





        /// <summary>
        /// CRUD de Salas para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ConsultaRepEventoSalaDataResponse Post(ConsultaRepEventoSalaDataRequest dataRequest)
        {
            ConsultaRepEventoSalaDataResponse response = new ConsultaRepEventoSalaDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);




                List<ConsultaRepEventoSalaModel> model = new List<ConsultaRepEventoSalaModel>();
                model = consultarEventos(dataRequest);

                if (model.Count > 0)
                {
                    response.ResponseCode = ConsultaRepEventoSalaResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.ContentIndex = model;
                }
                else
                {
                    response.ResponseCode = ConsultaRepEventoSalaResponseType.InvalidParameters;
                    response.ResponseMessage = "Fallo en la ejecución.";
                    response.ContentIndex = null;
                }


            }
            catch (ConsultaRepEventoSalaException ConsultaRepEventoSalaException)
            {
                SetResponseAsExceptionConsultaRepEventoSala(ConsultaRepEventoSalaException.Type, response, ConsultaRepEventoSalaException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ConsultaRepEventoSala.";
                SetResponseAsExceptionConsultaRepEventoSala(ConsultaRepEventoSalaResponseType.Error, response, message);
            }

            return response;
        }
    }
}