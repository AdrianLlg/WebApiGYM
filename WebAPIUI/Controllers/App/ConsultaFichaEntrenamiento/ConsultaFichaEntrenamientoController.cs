using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.App.ConsultaEventosDeportista;
using WebAPIBusiness.Entities.App.ConsultaFichaEntrenamiento;
using WebAPIUI.Controllers.ConsultaFichaEntrenamiento.Models;
using WebAPIUI.CustomExceptions.ConsultaFichaEntrenamiento;

namespace WebAPIUI.Controllers.App.ConsultaFichaEntrenamiento
{
    public class ConsultaFichaEntrenamientoController : BaseAPIController
    {
        private void ValidatePostRequest(ConsultaFichaEntrenamientoDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionConsultaFichaEntrenamientoException(ConsultaFichaEntrenamientoResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Obtiene los horarios disponibles en el dia especificado
        /// </summary>
        private  List<ConsultaFichaEntrenamientoEntity> ObtenerFichas(int personaID,int disciplinaID) 
        { 
            ConsultaFichasEntrenamientoAppBO bo = new ConsultaFichasEntrenamientoAppBO();
            List<string> messages = new List<string>();
            List<ConsultaFichaEntrenamientoEntity> resp = new List<ConsultaFichaEntrenamientoEntity>();

            try
            {
                resp = bo.consultarFichaEntrenamiento(personaID,disciplinaID);
            }
            catch (ValidationAndMessageException ConsultaFichaEntrenamientoException)
            {
                messages.Add(ConsultaFichaEntrenamientoException.Message);
                ThrowHandledExceptionConsultaFichaEntrenamientoException(ConsultaFichaEntrenamientoResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionConsultaFichaEntrenamientoException(ConsultaFichaEntrenamientoResponseType.Error, ex);
            }

            return resp;
        }



        /// <summary>
        /// Consulta los horarios disponibles para la fecha especificada
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ConsultaFichaEntrenamientoDataResponse Post(ConsultaFichaEntrenamientoDataRequest dataRequest)
        {
            ConsultaFichaEntrenamientoDataResponse response = new ConsultaFichaEntrenamientoDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                List<ConsultaFichaEntrenamientoEntity> resp = ObtenerFichas(dataRequest.personaID,dataRequest.disciplinaID);

                if (resp !=null)
                {
                    response.ResponseCode = ConsultaFichaEntrenamientoResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.ContentIndex = resp;
                }
                else
                {
                    response.ResponseCode = ConsultaFichaEntrenamientoResponseType.Error;
                    response.ResponseMessage = "Error en la ejecución";
                    response.ContentIndex = null;
                }

            }
            catch (ConsultaFichaEntrenamientoException ConsultaFichaEntrenamientoException)
            {
                SetResponseAsExceptionConsultaFichaEntrenamientoException(ConsultaFichaEntrenamientoException.Type, response, ConsultaFichaEntrenamientoException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ConsultaFichaEntrenamiento.";
                SetResponseAsExceptionConsultaFichaEntrenamientoException(ConsultaFichaEntrenamientoResponseType.Error, response, message);
            }

            return response;
        }
    }
}