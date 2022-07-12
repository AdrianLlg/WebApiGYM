using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.ConsultaRepEventoDisciplina;
using WebAPIBusiness.Entities.TransaccionesAnuales;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.TransaccionesAnuales.Models;
using WebAPIUI.CustomExceptions.TransaccionesAnuales;
using WebAPIUI.Helpers;
using WebAPIUI.Models.TransaccionesAnuales;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Salas.
    /// </summary>
    public class TransaccionesAnualesController : BaseAPIController
    {
        private void ValidatePostRequest(TransaccionesAnualesDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionTransaccionesAnuales(TransaccionesAnualesResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Consulta los Salas de la base 
        /// </summary>
        private List<TransaccionesAnualesModel> consultarPagos(TransaccionesAnualesDataRequest dataRequest)
        {
            TransaccionesAnualesBO bo = new TransaccionesAnualesBO();
            List<string> messages = new List<string>();
            List<TransaccionesAnualesModel> response = new List<TransaccionesAnualesModel>();
            List<TransaccionesAnualesEntity> aux = new List<TransaccionesAnualesEntity>();
            

            try
            {   
                response =  EntitesHelper.EntityToModelTransaccionesAnuales(bo.getPagos(dataRequest.Anio));
            }
            catch (ValidationAndMessageException TransaccionesAnualesException)
            {
                messages.Add(TransaccionesAnualesException.Message);
                ThrowHandledExceptionTransaccionesAnuales(TransaccionesAnualesResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionTransaccionesAnuales(TransaccionesAnualesResponseType.Error, ex);
            }

            return response;
        }





        /// <summary>
        /// CRUD de Salas para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public TransaccionesAnualesDataResponse Post(TransaccionesAnualesDataRequest dataRequest)
        {
            TransaccionesAnualesDataResponse response = new TransaccionesAnualesDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);




                List<TransaccionesAnualesModel> model = new List<TransaccionesAnualesModel>();
                model = consultarPagos(dataRequest);

                if (model.Count > 0)
                {
                    response.ResponseCode = TransaccionesAnualesResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.ContentIndex = model;
                }
                else
                {
                    response.ResponseCode = TransaccionesAnualesResponseType.InvalidParameters;
                    response.ResponseMessage = "Fallo en la ejecución.";
                    response.ContentIndex = null;
                }


            }
            catch (TransaccionesAnualesException TransaccionesAnualesException)
            {
                SetResponseAsExceptionTransaccionesAnuales(TransaccionesAnualesException.Type, response, TransaccionesAnualesException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar TransaccionesAnuales.";
                SetResponseAsExceptionTransaccionesAnuales(TransaccionesAnualesResponseType.Error, response, message);
            }

            return response;
        }
    }
}