using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.ConsultaHorarios;
using WebAPIUI.Controllers.ConsultaHorarios.Models;
using WebAPIUI.Controllers.CRUDRConsultaHorarios.Models;
using WebAPIUI.CustomExceptions.ConsultaHorarios;

namespace WebAPIUI.Controllers
{ 
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Salas.
    /// </summary>
    public class ConsultaHorariosController : BaseAPIController
    {
        private void ValidatePostRequest(ConsultaHorariosDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionConsultaHorarios(ConsultaHorariosResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Consulta los Salas de la base 
        /// </summary>
        private List<ConsultaHorariosModel> consultarHorarios(ConsultaHorariosDataRequest dataRequest)
        {
            ConsultaHorariosBO bo = new ConsultaHorariosBO();
            List<string> messages = new List<string>();
            List<ConsultaHorariosModel> response = new List<ConsultaHorariosModel>();
            List<SalaEntity> salasDB = dataRequest.Salas;

            try
            {
                response = bo.getHorarios(dataRequest.fechaInicio,dataRequest.fechaFin,dataRequest.Salas);
            }
            catch (ValidationAndMessageException ConsultaHorariosException)
            {
                messages.Add(ConsultaHorariosException.Message);
                ThrowHandledExceptionConsultaHorarios(ConsultaHorariosResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionConsultaHorarios(ConsultaHorariosResponseType.Error, ex);
            }

            return response;
        }

        

        

        /// <summary>
        /// CRUD de Salas para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ConsultaHorariosDataResponse Post(ConsultaHorariosDataRequest dataRequest)
        {
            ConsultaHorariosDataResponse response = new ConsultaHorariosDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);




                List<ConsultaHorariosModel> model = new List<ConsultaHorariosModel>();
                model = consultarHorarios(dataRequest);

                if (model.Count > 0)
                {
                    response.ResponseCode = ConsultaHorariosResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.ContentIndex = model;
                }
                else
                {
                    response.ResponseCode = ConsultaHorariosResponseType.InvalidParameters;
                    response.ResponseMessage = "Fallo en la ejecución.";
                    response.ContentIndex = null;
                }


            }
            catch (ConsultaHorariosException ConsultaHorariosException)
            {
                SetResponseAsExceptionConsultaHorarios(ConsultaHorariosException.Type, response, ConsultaHorariosException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ConsultaHorarios.";
                SetResponseAsExceptionConsultaHorarios(ConsultaHorariosResponseType.Error, response, message);
            }

            return response;
        }
    }
}