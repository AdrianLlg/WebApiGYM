using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.EventoAdmin;
using WebAPIBusiness.Entities.EventosSerializados;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.EventosSerializados.Models;
using WebAPIUI.CustomExceptions.EventosSerializados;
using WebAPIUI.Helpers;

namespace WebAPIUI.ContEventolers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Eventos.
    /// </summary>
    public class EventosSerializadosController : BaseAPIController
    {
        private void ValidatePostRequest(EventosSerializadosDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionEventosSerializados(EventosSerializadosResponseType.InvalidParameters, messages);
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
        private bool InsertarNuevaEvento(List<EventoAdminEntity> listaEventos)
        {
            EventosSerializadosBO bo = new EventosSerializadosBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertEvento(listaEventos);
            }
            catch (ValidationAndMessageException EventosSerializadosException)
            {
                messages.Add(EventosSerializadosException.Message);
                ThrowHandledExceptionEventosSerializados(EventosSerializadosResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionEventosSerializados(EventosSerializadosResponseType.Error, ex);
            }

            return response;
        }


       


        /// <summary>
        /// CRUD de Eventos para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public EventosSerializadosDataResponse Post(EventosSerializadosDataRequest dataRequest)
        {
            EventosSerializadosDataResponse response = new EventosSerializadosDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;               

                ValidatePostRequest(dataRequest); 

                
                //Crear
                if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarNuevaEvento(dataRequest.listaEventos);

                    if (resp)
                    {
                        response.ResponseCode = EventosSerializadosResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = EventosSerializadosResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                
                

            }
            catch (EventosSerializadosException EventosSerializadosException)
            {
                SetResponseAsExceptionEventosSerializados(EventosSerializadosException.Type, response, EventosSerializadosException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar EventosSerializados.";
                SetResponseAsExceptionEventosSerializados(EventosSerializadosResponseType.Error, response, message);
            }

            return response;
        }
    }
}