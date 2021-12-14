using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.EventoPersona;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.CRUDREventoPersona.Models;
using WebAPIUI.Controllers.EventoPersona.Models;
using WebAPIUI.CustomExceptions.EventoPersona;
using WebAPIUI.Helpers;
using WebAPIUI.Models.EventoPersona;

namespace WebAPIUI.ContEventolers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Eventos.
    /// </summary>
    public class EventoPersonaController : BaseAPIController
    {
        private void ValidatePostRequest(EventoPersonaDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionEventoPersona(EventoPersonaResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.nombres))
            //{
            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }

        /// <summary>
        /// Insertar un nuevo Evento en la BD
        /// </summary>
        private bool InsertarNuevoEventoPersona(int eventoID, int personaID, int asistencia)
        {
            EventoPersonaBO bo = new EventoPersonaBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertEventoPersona(eventoID, personaID, asistencia);
            }
            catch (ValidationAndMessageException EventoPersonaException)
            {
                messages.Add(EventoPersonaException.Message);
                ThrowHandledExceptionEventoPersona(EventoPersonaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionEventoPersona(EventoPersonaResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta los Eventos de la base 
        /// </summary>
        private List<EventoPersonaEntity> ConsultarEventos()
        {
            EventoPersonaBO bo = new EventoPersonaBO();
            List<string> messages = new List<string>();
            List<EventoPersonaEntity> response = new List<EventoPersonaEntity>();

            try
            {
                response = bo.getEventoPersona();
            }
            catch (ValidationAndMessageException EventoPersonaException)
            {
                messages.Add(EventoPersonaException.Message);
                ThrowHandledExceptionEventoPersona(EventoPersonaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionEventoPersona(EventoPersonaResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar Evento
        /// </summary>
        private bool ModificarEventoPersona(int evento_personaID, int eventoID,int personaID,int asistencia)
        {
            EventoPersonaBO bo = new EventoPersonaBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifyEventoPersona(evento_personaID,eventoID, personaID, asistencia);
            }
            catch (ValidationAndMessageException EventoPersonaException)
            {
                messages.Add(EventoPersonaException.Message);
                ThrowHandledExceptionEventoPersona(EventoPersonaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionEventoPersona(EventoPersonaResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Modificar Evento
        /// </summary>
        private bool EliminarEventoPersona(int evento_personaID)
        {
            EventoPersonaBO bo = new EventoPersonaBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.eliminarEventoPersona(evento_personaID);
            }
            catch (ValidationAndMessageException EventoPersonaException)
            {
                messages.Add(EventoPersonaException.Message);
                ThrowHandledExceptionEventoPersona(EventoPersonaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionEventoPersona(EventoPersonaResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Consultar Evento
        /// </summary>
        private EventoPersonaEntity DetalleEvento(int evento_personaID)
        {
            EventoPersonaBO bo = new EventoPersonaBO();
            List<string> messages = new List<string>();
            EventoPersonaEntity response = new EventoPersonaEntity();

            try
            {
                response = bo.consultarEventoPersona(evento_personaID);
            }
            catch (ValidationAndMessageException EventoPersonaException)
            {
                messages.Add(EventoPersonaException.Message);
                ThrowHandledExceptionEventoPersona(EventoPersonaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionEventoPersona(EventoPersonaResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// CRUD de Eventos para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public EventoPersonaDataResponse Post(EventoPersonaDataRequest dataRequest)
        {
            EventoPersonaDataResponse response = new EventoPersonaDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;               

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de membresias
                if (dataRequest.flujoID == 0)
                {
                    List<EventoPersonaModel> model = new List<EventoPersonaModel>();
                    List<EventoPersonaEntity> items = ConsultarEventos();

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.EventoPersonaEntityToModel(items);
                        response.ResponseCode = EventoPersonaResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = EventoPersonaResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarNuevoEventoPersona(dataRequest.eventoID, dataRequest.personaID, dataRequest.asistencia);


                    if (resp)
                    {
                        response.ResponseCode = EventoPersonaResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = EventoPersonaResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarEventoPersona(dataRequest.evento_personaID, dataRequest.eventoID, dataRequest.personaID, dataRequest.asistencia);

                    if (resp)
                    {
                        response.ResponseCode = EventoPersonaResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = EventoPersonaResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }  
                //Detalle de persona
                else if (dataRequest.flujoID == 3)
                {
                    EventoPersonaEntity resp = new EventoPersonaEntity();
                    EventoPersonaModel model = new EventoPersonaModel();

                    resp = DetalleEvento(dataRequest.eventoID);

                    if (resp.eventoID > 0)
                    {
                        model = EntitesHelper.EventoPersonaInfoEntityToModel(resp);
                        response.ResponseCode = EventoPersonaResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = EventoPersonaResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }
                //Modificar
                else if (dataRequest.flujoID == 4)
                {
                    bool resp = EliminarEventoPersona(dataRequest.evento_personaID);

                    if (resp)
                    {
                        response.ResponseCode = EventoPersonaResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = EventoPersonaResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    } 
                }
            }
            catch (EventoPersonaException EventoPersonaException)
            {
                SetResponseAsExceptionEventoPersona(EventoPersonaException.Type, response, EventoPersonaException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar EventoPersona.";
                SetResponseAsExceptionEventoPersona(EventoPersonaResponseType.Error, response, message);
            }

            return response;
        }
    }
}