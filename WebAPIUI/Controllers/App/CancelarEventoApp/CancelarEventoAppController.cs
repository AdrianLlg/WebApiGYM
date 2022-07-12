using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore.App;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers.CancelarEventoApp.Models;
using WebAPIUI.Controllers.CRUDRCancelarEventoApp.Models;
using WebAPIUI.CustomExceptions.CancelarEventoApp;

namespace WebAPIUI.Controllers.App
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Eventos.
    /// </summary>
    public class CancelarEventoAppController : BaseAPIController
    {
        private void ValidatePostRequest(CancelarEventoAppDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionCancelarEventoAppException(CancelarEventoAppResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.nombres))
            //{
            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }


        private bool InactivarEvento(int eventoID, int personaID, string motivo, string posibleHorarioRecuperacion)
        {
            CancelarEventoAppBO bo = new CancelarEventoAppBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.inactivarEvento(eventoID, personaID, motivo, posibleHorarioRecuperacion);
            }
            catch (ValidationAndMessageException CancelarEventoAppException)
            {
                messages.Add(CancelarEventoAppException.Message);
                ThrowHandledExceptionCancelarEventoAppException(CancelarEventoAppResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionCancelarEventoAppException(CancelarEventoAppResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Consultar Evento
        /// </summary>

        /// <summary>
        /// POST INACTIVAR
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public CancelarEventoAppDataResponse Post(CancelarEventoAppDataRequest dataRequest)
        {
            CancelarEventoAppDataResponse response = new CancelarEventoAppDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);


                bool resp = false;
                

                resp = InactivarEvento(dataRequest.eventoID, dataRequest.personaID, dataRequest. motivo, dataRequest. posibleHorarioRecuperacion);

                if (resp)
                {

                    response.ResponseCode = CancelarEventoAppResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.Content = resp;
                }
                else
                {
                    response.ResponseCode = CancelarEventoAppResponseType.Error;
                    response.ResponseMessage = "Fallo en la ejecución.";
                    response.Content = resp;
                }



            }
            catch (CancelarEventoAppException CancelarEventoAppException)
            {
                SetResponseAsExceptionCancelarEventoAppException(CancelarEventoAppException.Type, response, CancelarEventoAppException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar CancelarEventoApp.";
                SetResponseAsExceptionCancelarEventoAppException(CancelarEventoAppResponseType.Error, response, message);
            }

            return response;
        }
    }
}