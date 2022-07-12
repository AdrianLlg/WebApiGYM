using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.App.ConsultaEventosDeportista;
using WebAPIBusiness.Entities.App.ConsultaFichaPersona;
using WebAPIUI.Controllers.ConsultaFichaPersona.Models;
using WebAPIUI.CustomExceptions.ConsultaFichaPersona;

namespace WebAPIUI.Controllers.App.ConsultaFichaPersona
{
    public class ConsultaFichaPersonaController : BaseAPIController
    {
        private void ValidatePostRequest(ConsultaFichaPersonaDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionConsultaFichaPersonaException(ConsultaFichaPersonaResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Obtiene los horarios disponibles en el dia especificado
        /// </summary>
        private  ConsultaFichaPersonaEntity ObtenerFicha(int personaID) 
        { 
            ConsultaFichaPersonaAppBO bo = new ConsultaFichaPersonaAppBO();
            List<string> messages = new List<string>();
            ConsultaFichaPersonaEntity resp = new ConsultaFichaPersonaEntity();

            try
            {
                resp = bo.consultarFichaPersona(personaID);
            }
            catch (ValidationAndMessageException ConsultaFichaPersonaException)
            {
                messages.Add(ConsultaFichaPersonaException.Message);
                ThrowHandledExceptionConsultaFichaPersonaException(ConsultaFichaPersonaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionConsultaFichaPersonaException(ConsultaFichaPersonaResponseType.Error, ex);
            }

            return resp;
        }



        /// <summary>
        /// Consulta los horarios disponibles para la fecha especificada
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns> 
        [HttpPost]
        public ConsultaFichaPersonaDataResponse Post(ConsultaFichaPersonaDataRequest dataRequest)
        {
            ConsultaFichaPersonaDataResponse response = new ConsultaFichaPersonaDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                ConsultaFichaPersonaEntity resp = ObtenerFicha(dataRequest.personaID);

                if (resp !=null)
                {
                    response.ResponseCode = ConsultaFichaPersonaResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.ContentIndex = resp;
                }
                else
                {
                    response.ResponseCode = ConsultaFichaPersonaResponseType.Error;
                    response.ResponseMessage = "Error en la ejecución";
                    response.ContentIndex = null;
                }

            }
            catch (ConsultaFichaPersonaException ConsultaFichaPersonaException)
            {
                SetResponseAsExceptionConsultaFichaPersonaException(ConsultaFichaPersonaException.Type, response, ConsultaFichaPersonaException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ConsultaFichaPersona.";
                SetResponseAsExceptionConsultaFichaPersonaException(ConsultaFichaPersonaResponseType.Error, response, message);
            }

            return response;
        }
    }
} 