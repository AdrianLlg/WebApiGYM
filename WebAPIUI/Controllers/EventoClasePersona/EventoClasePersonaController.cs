using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers.EventoClasePersona.Models;
using WebAPIUI.Helpers;
using WebAPIBusiness.Entities.EventoClasePersona;
using WebAPIUI.CustomExceptions.EventoClasePersona;
using WebAPIUI.Models.EventoClasePersona;



namespace WebAPIUI.Controllers
{
    public class EventoClasePersonaController : BaseAPIController
    {
        private void ValidatePostRequest(EventoClasePersonaRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionEventoClasePersona(EventoClasePersonaResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Busca las eventoClasePersona de esa persona
        /// </summary>
        private List<EventoClasePersonaEntity> horarioUser(int personaID)
        {
            EventoClasePersonaBO bo = new EventoClasePersonaBO();
            List<string> messages = new List<string>();
            List<EventoClasePersonaEntity> eventoClasePersona = new List<EventoClasePersonaEntity>();

            try
            {
                eventoClasePersona = bo.ConsultarHorario(personaID);
            }
            catch (ValidationAndMessageException ConsultaRepositorioImagenesException)
            {
                messages.Add(ConsultaRepositorioImagenesException.Message);
                ThrowHandledExceptionEventoClasePersona(EventoClasePersonaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionEventoClasePersona(EventoClasePersonaResponseType.Error, ex);
            }

            return eventoClasePersona;
        }

        /// <summary>
        /// Insertar un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public EventoClasePersonaResponse Post(EventoClasePersonaRequest dataRequest)
        {
            EventoClasePersonaResponse response = new EventoClasePersonaResponse();

            try
            {
                List<EventoClasePersonaModel> resp = new List<EventoClasePersonaModel>();
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                List<EventoClasePersonaEntity> eventoClasePersona = horarioUser(dataRequest.personaID);

                if (eventoClasePersona.Count > 0)
                {
                    //resp = EntitesHelper.EventoClasePersonaEntityToModel(eventoClasePersona);
                    response.ResponseCode = EventoClasePersonaResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.Content = eventoClasePersona;
                }
                else
                {
                    response.ResponseCode = EventoClasePersonaResponseType.Ok;
                    response.ResponseMessage = "No existen registros.";
                    response.Content = null;
                }

            }
            catch (EventoClasePersonaException EventoClasePersonaException)
            {
                SetResponseAsExceptionEventoClasePersona(EventoClasePersonaException.Type, response, EventoClasePersonaException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar RegistrarPersona.";
                SetResponseAsExceptionEventoClasePersona(EventoClasePersonaResponseType.Error, response, message);
            }

            return response;
        }
    }
}