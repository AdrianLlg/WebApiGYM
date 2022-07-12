using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.ReporteGeneralAsistencia;
using WebAPIUI.Controllers.ReporteGeneralAsistencia.Models;
using WebAPIUI.CustomExceptions.ReporteGeneralAsistencia;
using WebAPIUI.Helpers;
using WebAPIUI.Models.ReporteGeneralAsistencia;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Salas.
    /// </summary>
    public class ReporteGeneralAsistenciaController : BaseAPIController
    {
        private void ValidatePostRequest(ReporteGeneralAsistenciaDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionReporteGeneralAsistencia(ReporteGeneralAsistenciaResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Consulta los Salas de la base 
        /// </summary>
        private List<ReporteGeneralAsistenciaModel> consultarEventos(ReporteGeneralAsistenciaDataRequest dataRequest)
        {
            ReporteGeneralAsistenciaBO bo = new ReporteGeneralAsistenciaBO();
            List<string> messages = new List<string>();
            List<ReporteGeneralAsistenciaModel> response = new List<ReporteGeneralAsistenciaModel>();
            List<ReporteGeneralAsistenciaEntity> aux = new List<ReporteGeneralAsistenciaEntity>();
            

            try
            {    
                response =  EntitesHelper.EntityToModelReporteGeneralAsistencia(bo.getAsistencia(dataRequest.personaID, dataRequest.fechaInicio, dataRequest.fechaFin));
            }
            catch (ValidationAndMessageException ReporteGeneralAsistenciaException)
            {
                messages.Add(ReporteGeneralAsistenciaException.Message);
                ThrowHandledExceptionReporteGeneralAsistencia(ReporteGeneralAsistenciaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionReporteGeneralAsistencia(ReporteGeneralAsistenciaResponseType.Error, ex);
            }

            return response;
        }





        /// <summary>
        /// CRUD de Salas para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ReporteGeneralAsistenciaDataResponse Post(ReporteGeneralAsistenciaDataRequest dataRequest)
        {
            ReporteGeneralAsistenciaDataResponse response = new ReporteGeneralAsistenciaDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);




                List<ReporteGeneralAsistenciaModel> model = new List<ReporteGeneralAsistenciaModel>();
                model = consultarEventos(dataRequest);

                if (model.Count > 0)
                {
                    response.ResponseCode = ReporteGeneralAsistenciaResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.ContentIndex = model;
                }
                else
                {
                    response.ResponseCode = ReporteGeneralAsistenciaResponseType.InvalidParameters;
                    response.ResponseMessage = "Fallo en la ejecución.";
                    response.ContentIndex = null;
                }


            }
            catch (ReporteGeneralAsistenciaException ReporteGeneralAsistenciaException)
            {
                SetResponseAsExceptionReporteGeneralAsistencia(ReporteGeneralAsistenciaException.Type, response, ReporteGeneralAsistenciaException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ReporteGeneralAsistencia.";
                SetResponseAsExceptionReporteGeneralAsistencia(ReporteGeneralAsistenciaResponseType.Error, response, message);
            }

            return response;
        }
    }
}