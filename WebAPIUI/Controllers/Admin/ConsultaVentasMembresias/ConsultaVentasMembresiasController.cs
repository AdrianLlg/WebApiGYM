using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.ConsultaVentasMembresias;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.ConsultaVentasMembresias.Models;
using WebAPIUI.CustomExceptions.ConsultaVentasMembresias;
using WebAPIUI.Helpers;
using WebAPIUI.Models.ConsultaVentasMembresias;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Salas.
    /// </summary>
    public class ConsultaVentasMembresiasController : BaseAPIController
    {
        private void ValidatePostRequest(ConsultaVentasMembresiasDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionConsultaVentasMembresias(ConsultaVentasMembresiasResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Consulta los Salas de la base 
        /// </summary>
        private List<ConsultaVentasMembresiasModel> consultarVentas(ConsultaVentasMembresiasDataRequest dataRequest)
        {
            ReporteVentasMembresiasBO bo = new ReporteVentasMembresiasBO();
            List<string> messages = new List<string>();
            List<ConsultaVentasMembresiasModel> response = new List<ConsultaVentasMembresiasModel>();
            List<ConsultaVentasMembresiasEntity> aux = new List<ConsultaVentasMembresiasEntity>();
            

            try
            {   
                response =  EntitesHelper.EntityToModelConsultaVentasMembresias(bo.getVentas(dataRequest.fechaInicio, dataRequest.fechaFin));
            }
            catch (ValidationAndMessageException ConsultaVentasMembresiasException)
            {
                messages.Add(ConsultaVentasMembresiasException.Message);
                ThrowHandledExceptionConsultaVentasMembresias(ConsultaVentasMembresiasResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionConsultaVentasMembresias(ConsultaVentasMembresiasResponseType.Error, ex);
            }

            return response;
        }





        /// <summary>
        /// CRUD de Salas para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ConsultaVentasMembresiasDataResponse Post(ConsultaVentasMembresiasDataRequest dataRequest)
        {
            ConsultaVentasMembresiasDataResponse response = new ConsultaVentasMembresiasDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);




                List<ConsultaVentasMembresiasModel> model = new List<ConsultaVentasMembresiasModel>();
                model = consultarVentas(dataRequest);

                if (model.Count > 0)
                {
                    response.ResponseCode = ConsultaVentasMembresiasResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.ContentIndex = model;
                }
                else
                {
                    response.ResponseCode = ConsultaVentasMembresiasResponseType.InvalidParameters;
                    response.ResponseMessage = "Fallo en la ejecución.";
                    response.ContentIndex = null;
                }


            }
            catch (ConsultaVentasMembresiasException ConsultaVentasMembresiasException)
            {
                SetResponseAsExceptionConsultaVentasMembresias(ConsultaVentasMembresiasException.Type, response, ConsultaVentasMembresiasException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ConsultaVentasMembresias.";
                SetResponseAsExceptionConsultaVentasMembresias(ConsultaVentasMembresiasResponseType.Error, response, message);
            }

            return response;
        }
    }
}