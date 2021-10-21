using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.EventoAdmin;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.CRUDEventoAdmin.Models;
using WebAPIUI.Controllers.CRUDREventoAdmin.Models;
using WebAPIUI.CustomExceptions.EventoAdmin;
using WebAPIUI.Helpers;
using WebAPIUI.Models.EventoAdmin;

namespace WebAPIUI.ContEventolers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Eventos.
    /// </summary>
    public class CRUDEventoAdminController : BaseAPIController
    {
        private void ValidatePostRequest(CRUDEventoAdminDataRequest dataRequest)
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

        /// <summary>
        /// Insertar un nuevo Evento en la BD
        /// </summary>
        private bool InsertarNuevaEvento(string claseID,string horarioMID,string fecha,string salaID,string aforoMax,string aforoMin)
        {
            EventoAdminBO bo = new EventoAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertEvento(claseID, horarioMID, fecha, salaID, aforoMax, aforoMin);
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
        /// Consulta los Eventos de la base 
        /// </summary>
        private List<EventoAdminEntity> ConsultarEventos()
        {
            EventoAdminBO bo = new EventoAdminBO();
            List<string> messages = new List<string>();
            List<EventoAdminEntity> response = new List<EventoAdminEntity>();

            try
            {
                response = bo.getEventos();
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
        /// Modificar Evento
        /// </summary>
        private bool ModificarEvento(int eventoID,string claseID, string horarioMID, string fecha, string salaID, string aforoMax, string aforoMin)
        {
            EventoAdminBO bo = new EventoAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifyEvento( eventoID, claseID,  horarioMID,fecha, salaID, aforoMax,aforoMin);
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
        private EventoAdminEntity DetalleEvento(int eventoID)
        {
            EventoAdminBO bo = new EventoAdminBO();
            List<string> messages = new List<string>();
            EventoAdminEntity response = new EventoAdminEntity();

            try
            {
                response = bo.consultarEvento(eventoID);
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
        /// CRUD de Eventos para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public EventoAdminDataResponse Post(CRUDEventoAdminDataRequest dataRequest)
        {
            EventoAdminDataResponse response = new EventoAdminDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;               

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de membresias
                if (dataRequest.flujoID == 0)
                {
                    List<EventoAdminModel> model = new List<EventoAdminModel>();
                    List<EventoAdminEntity> items = ConsultarEventos();

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.EventosEntityToModel(items);
                        response.ResponseCode = EventoAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = EventoAdminResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarNuevaEvento(dataRequest.claseID, dataRequest.horarioMID, dataRequest.fecha, dataRequest.salaID, dataRequest.aforoMax, dataRequest.aforoMin);

                    if (resp)
                    {
                        response.ResponseCode = EventoAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = EventoAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarEvento(dataRequest.eventoID, dataRequest.claseID, dataRequest.horarioMID, dataRequest.fecha, dataRequest.salaID, dataRequest.aforoMax, dataRequest.aforoMin);

                    if (resp)
                    {
                        response.ResponseCode = EventoAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = EventoAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }  
                //Detalle de persona
                else if (dataRequest.flujoID == 3)
                {
                    EventoAdminEntity resp = new EventoAdminEntity();
                    EventoAdminModel model = new EventoAdminModel();

                    resp = DetalleEvento(dataRequest.eventoID);

                    if (resp.eventoID > 0)
                    {
                        model = EntitesHelper.EventosInfoEntityToModel(resp);
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

            }
            catch (EventoAdminException EventoAdminException)
            {
                SetResponseAsExceptionEventoAdmin(EventoAdminException.Type, response, EventoAdminException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar CRUDEventoAdmin.";
                SetResponseAsExceptionEventoAdmin(EventoAdminResponseType.Error, response, message);
            }

            return response;
        }
    }
}