using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Helpers;
using WebAPIUI.CustomExceptions.EventoRecursoEspecial;
using WebAPIUI.Models.EventoRecursoEspecial;
using WebAPIBusiness.Entities.EvetoRecursoEspecial;
using WebAPIUI.Controllers.EventoRecursoEspecial.Models;
using WebAPIUI.Controllers.EventosRecursoEspecial.Models;

namespace WebAPIUI.Controllers
{
    public class EventoRecursoEspecialController : BaseAPIController
    {
        private void ValidatePostRequest(EventoRecursoEspecialRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionEventoRecursoEspecial(EventoRecursoEspecialResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Busca las EventoRecursoEspecial de esa persona
        /// </summary>
        private List<EventoRecursoEspecialEntity> recursoUser(string personaID,string eventoID)
        {
            EventoRecursoEspecialBO bo = new EventoRecursoEspecialBO();
            List<string> messages = new List<string>();
            List<EventoRecursoEspecialEntity> EventoRecursoEspecial = new List<EventoRecursoEspecialEntity>();

            try
            {
                EventoRecursoEspecial = bo.ConsultarRecursoEspecial(personaID,eventoID);
            }
            catch (ValidationAndMessageException ConsultaRepositorioImagenesException)
            {
                messages.Add(ConsultaRepositorioImagenesException.Message);
                ThrowHandledExceptionEventoRecursoEspecial(EventoRecursoEspecialResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionEventoRecursoEspecial(EventoRecursoEspecialResponseType.Error, ex);
            }

            return EventoRecursoEspecial;
        }

        /// <summary>
        /// Insertar un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public EventoRecursoEspecialResponse Post(EventoRecursoEspecialRequest dataRequest)
        {
            EventoRecursoEspecialResponse response = new EventoRecursoEspecialResponse();

            try
            {
                List<EventoRecursoEspecialModel> resp = new List<EventoRecursoEspecialModel>();
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                List<EventoRecursoEspecialEntity> EventoRecursoEspecial = recursoUser(dataRequest.personaID,dataRequest.eventoID);

                if (EventoRecursoEspecial.Count > 0)
                {
                    resp = EntitesHelper.EventoRecursoEspecialEntityToModel(EventoRecursoEspecial);
                    response.ResponseCode = EventoRecursoEspecialResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.Content = resp;
                }
                else
                {
                    response.ResponseCode = EventoRecursoEspecialResponseType.Ok;
                    response.ResponseMessage = "No existen registros.";
                    response.Content = null;
                }

            }
            catch (EventoRecursoEspecialException EventoRecursoEspecialException)
            {
                SetResponseAsExceptionEventoRecursoEspecial(EventoRecursoEspecialException.Type, response, EventoRecursoEspecialException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar RegistrarPersona.";
                SetResponseAsExceptionEventoRecursoEspecial(EventoRecursoEspecialResponseType.Error, response, message);
            }

            return response;
        }
    }
}