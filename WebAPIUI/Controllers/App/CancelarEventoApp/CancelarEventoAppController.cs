using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.EventoAdmin;
using WebAPIUI.Controllers.CancelarEventoApp.Models;
using WebAPIUI.Controllers.CRUDREventoAdmin.Models;
using WebAPIUI.CustomExceptions.EventoAdmin;
using WebAPIUI.Helpers;
using WebAPIUI.Models.EventoAdmin;

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
                ThrowHandledExceptionEventoAdmin(EventoAdminResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.nombres))
            //{
            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }


        private bool InactivarEvento(int eventoID)
        {
            EventoAdminBO bo = new EventoAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.inactivarEvento(eventoID);
            }
            catch (ValidationAndMessageException EventoAdminException)
            {
                messages.Add(EventoAdminException.Message);
                ThrowHandledExceptionEventoAdmin(EventoAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionEventoAdmin(EventoAdminResponseType.Error, ex);
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
        public EventoAdminDataResponse Post(CancelarEventoAppDataRequest dataRequest)
        {
            EventoAdminDataResponse response = new EventoAdminDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);


                bool resp = false;
                EventoAdminModel model = new EventoAdminModel();

                resp = InactivarEvento(dataRequest.eventoID);

                if (resp == true)
                {

                    response.ResponseCode = EventoAdminResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.ContentDetail = model;
                }
                else
                {
                    response.ResponseCode = EventoAdminResponseType.Error;
                    response.ResponseMessage = "Fallo en la ejecución.";
                    response.ContentDetail = null;
                }



            }
            catch (EventoAdminException EventoAdminException)
            {
                SetResponseAsExceptionEventoAdmin(EventoAdminException.Type, response, EventoAdminException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar CancelarEventoApp.";
                SetResponseAsExceptionEventoAdmin(EventoAdminResponseType.Error, response, message);
            }

            return response;
        }
    }
}