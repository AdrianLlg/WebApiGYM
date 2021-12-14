using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.SalaRecursoEspecial;
using WebAPIUI.Controllers.CRUDSalaRecursoEspecial.Models;
using WebAPIUI.Controllers.CRUDSalaRecursoEspecialEspecial.Models;
using WebAPIUI.CustomExceptions.SalaRecursoEspecial;
using WebAPIUI.Helpers;
using WebAPIUI.Models.SalaRecursoEspecial;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Salas.
    /// </summary>
    public class CRUDSalaRecursoEspecialController : BaseAPIController
    {
        private void ValidatePostRequest(CRUDSalaRecursoEspecialDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty; 

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType.InvalidParameters, messages);
            }


        }

        /// <summary>
        /// Insertar un nuevo Sala en la BD
        /// </summary>
        private bool InsertarSalaRecursoEspecial( int salaID, int recursoEspecialID,string estadoRegistro)
        {
            salaRecursoEspecialBO bo = new salaRecursoEspecialBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {

                response = bo.insertsalaRecursoEspecial(salaID, recursoEspecialID,estadoRegistro);
            }
            catch (ValidationAndMessageException SalaRecursoEspecialException)
            {
                messages.Add(SalaRecursoEspecialException.Message);
                ThrowHandledExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta los Salas de la base 
        /// </summary>
        private List<SalaRecursoEspecialEntity> ConsultarSalaRecursoEspecials()
        {
            salaRecursoEspecialBO bo = new salaRecursoEspecialBO();
            List<string> messages = new List<string>();
            List<SalaRecursoEspecialEntity> response = new List<SalaRecursoEspecialEntity>();

            try
            {
                response = bo.getsalaRecursoEspecials();
            }
            catch (ValidationAndMessageException SalaRecursoEspecialException)
            {
                messages.Add(SalaRecursoEspecialException.Message);
                ThrowHandledExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar Sala
        /// </summary>
        private bool SalaRecursoEspecialDelete(int salaRecursoEspecialID)
        {
            salaRecursoEspecialBO bo = new salaRecursoEspecialBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.eliminarSalaREcursoEspecial(salaRecursoEspecialID);
            }
            catch (ValidationAndMessageException SalaRecursoEspecialException)
            {
                messages.Add(SalaRecursoEspecialException.Message);
                ThrowHandledExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar Sala
        /// </summary>
        private bool SalaRecursoEspecialInactivar(int salaRecursoEspecialID)
        {
            salaRecursoEspecialBO bo = new salaRecursoEspecialBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.inactivarSala(salaRecursoEspecialID);
            }
            catch (ValidationAndMessageException SalaRecursoEspecialException)
            {
                messages.Add(SalaRecursoEspecialException.Message);
                ThrowHandledExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar Sala
        /// </summary>
        private bool ModificarSalaRecursoEspecial( int salaRecursoEspecialID, int salaID, int recursoEspecialID,string estadoRegistro)
        {
            salaRecursoEspecialBO bo = new salaRecursoEspecialBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifysalaRecursoEspecial( salaRecursoEspecialID, salaID, recursoEspecialID,estadoRegistro);
            }
            catch (ValidationAndMessageException SalaRecursoEspecialException)
            {
                messages.Add(SalaRecursoEspecialException.Message);
                ThrowHandledExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Consultar Sala
        /// </summary>
        private SalaRecursoEspecialEntity DetalleSalaRecursoEspecial(int salaRecursoID)
        {
            salaRecursoEspecialBO bo = new salaRecursoEspecialBO();
            List<string> messages = new List<string>();
            SalaRecursoEspecialEntity response = new SalaRecursoEspecialEntity();

            try
            {
                response = bo.consultarsalaRecursoEspecial(salaRecursoID);
            }
            catch (ValidationAndMessageException SalaRecursoEspecialException)
            {
                messages.Add(SalaRecursoEspecialException.Message);
                ThrowHandledExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// CRUD de Salas para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public SalaRecursoEspecialDataResponse Post(CRUDSalaRecursoEspecialDataRequest dataRequest)
        {
            SalaRecursoEspecialDataResponse response = new SalaRecursoEspecialDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de membresias
                if (dataRequest.flujoID == 0)
                {
                    List<SalaRecursoEspecialModel> model = new List<SalaRecursoEspecialModel>();
                    List<SalaRecursoEspecialEntity> items = ConsultarSalaRecursoEspecials();

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.SalaRecursoEspecialsEntityToModel(items);
                        response.ResponseCode = SalaRecursoEspecialResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = SalaRecursoEspecialResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarSalaRecursoEspecial(dataRequest.salaID,dataRequest.recursoEspecialID,dataRequest.estadoRegistro);

                    if (resp)
                    {
                        response.ResponseCode = SalaRecursoEspecialResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = SalaRecursoEspecialResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarSalaRecursoEspecial(dataRequest.salaRecursoEspecialID,dataRequest.salaID,dataRequest.recursoEspecialID,dataRequest.estadoRegistro);

                    if (resp)
                    {
                        response.ResponseCode = SalaRecursoEspecialResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = SalaRecursoEspecialResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }
                //Detalle de Sala Recurso Especial
                else if (dataRequest.flujoID == 3)
                {
                    SalaRecursoEspecialEntity resp = new SalaRecursoEspecialEntity();
                    SalaRecursoEspecialModel model = new SalaRecursoEspecialModel();

                    resp = DetalleSalaRecursoEspecial(dataRequest.salaID);

                    if (resp.salaID > 0)
                    {
                        model = EntitesHelper.SalaRecursoEspecialInfoEntityToModel(resp);
                        response.ResponseCode = SalaRecursoEspecialResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = SalaRecursoEspecialResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

                //Eliminar Sala Recurso Especial
                else if (dataRequest.flujoID == 4)
                {
                    bool resp = false;
                    SalaRecursoEspecialModel model = new SalaRecursoEspecialModel();

                    resp = SalaRecursoEspecialDelete(dataRequest.salaRecursoEspecialID);

                    if (resp==true)
                    {
                        
                        response.ResponseCode = SalaRecursoEspecialResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = SalaRecursoEspecialResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

                //Inactivar de Sala Recurso Especial
                else if (dataRequest.flujoID == 5)
                {
                    bool resp = false;
                    SalaRecursoEspecialModel model = new SalaRecursoEspecialModel();

                    resp = SalaRecursoEspecialInactivar(dataRequest.salaRecursoEspecialID);

                    if (resp==true )
                    {
                        
                        response.ResponseCode = SalaRecursoEspecialResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = SalaRecursoEspecialResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }
            }
            catch (SalaRecursoEspecialException SalaRecursoEspecialException)
            {
                SetResponseAsExceptionSalaRecursoEspecial(SalaRecursoEspecialException.Type, response, SalaRecursoEspecialException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar CRUDSalaRecursoEspecial.";
                SetResponseAsExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType.Error, response, message);
            }

            return response;
        }
    }
}