using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.ConsultaPerfil;
using WebAPIUI.Controllers.ConsultaPerfil.Models;
using WebAPIUI.CustomExceptions.ConsultaPerfil;
using WebAPIUI.Helpers;
using WebAPIUI.Models.ConsultaPerfilModel;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Salas.
    /// </summary>
    public class ConsultaPerfilController : BaseAPIController
    {
        private void ValidatePostRequest(ConsultaPerfilDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionConsultaPerfil(ConsultaPerfilResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Consulta los Salas de la base 
        /// </summary>
        private List<ConsultaPerfilModel> consultarPerfil(ConsultaPerfilDataRequest dataRequest)
        {
            ConsultaPerfilBO bo = new ConsultaPerfilBO();
            List<string> messages = new List<string>();
            List<ConsultaPerfilModel> response = new List<ConsultaPerfilModel>();
            List<ConsultaPerfilEntity> aux = new List<ConsultaPerfilEntity>();


            try
            {
                aux = bo.getPerfil(dataRequest.personaID);
                response =EntitesHelper.EntityToModelConsultaPerfil(aux) ;
            }
            catch (ValidationAndMessageException ConsultaPerfilException) 
            {
                messages.Add(ConsultaPerfilException.Message);
                ThrowHandledExceptionConsultaPerfil(ConsultaPerfilResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionConsultaPerfil(ConsultaPerfilResponseType.Error, ex);
            }

            return response;
        }





        /// <summary>
        /// CRUD de Salas para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ConsultaPerfilDataResponse Post(ConsultaPerfilDataRequest dataRequest)
        {
            ConsultaPerfilDataResponse response = new ConsultaPerfilDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                List<ConsultaPerfilModel> model = new List<ConsultaPerfilModel>();
                model = consultarPerfil(dataRequest);

                if (model.Count > 0)
                {
                    response.ResponseCode = ConsultaPerfilResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.ContentIndex = model;
                }
                else
                {
                    response.ResponseCode = ConsultaPerfilResponseType.InvalidParameters;
                    response.ResponseMessage = "Fallo en la ejecución.";
                    response.ContentIndex = null;
                }


            }
            catch (ConsultaPerfilException ConsultaPerfilException)
            {
                SetResponseAsExceptionConsultaPerfil(ConsultaPerfilException.Type, response, ConsultaPerfilException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ConsultaPerfil.";
                SetResponseAsExceptionConsultaPerfil(ConsultaPerfilResponseType.Error, response, message);
            }

            return response;
        }
    }
}