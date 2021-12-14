using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.SalaRecurso;
using WebAPIUI.Controllers.CRUDSalaRecurso.Models;
using WebAPIUI.CustomExceptions.SalaRecurso;
using WebAPIUI.Helpers;
using WebAPIUI.Models.SalaRecurso;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Salas.
    /// </summary>
    public class CRUDSalaRecursoController : BaseAPIController
    {
        private void ValidatePostRequest(CRUDSalaRecursoDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionSalaRecurso(SalaRecursoResponseType.InvalidParameters, messages);
            }


        }

        /// <summary>
        /// Insertar un nuevo Sala en la BD
        /// </summary>
        private bool InsertarNuevaSala(int salaID, string nombreRecurso, int cantidad,string estadoRegistro)
        {
            salaRecursoBO bo = new salaRecursoBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                
                response = bo.insertSalaRecurso(salaID,nombreRecurso,cantidad,estadoRegistro);
            }
            catch (ValidationAndMessageException SalaRecursoException)
            {
                messages.Add(SalaRecursoException.Message);
                ThrowHandledExceptionSalaRecurso(SalaRecursoResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaRecurso(SalaRecursoResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta los Salas de la base 
        /// </summary>
        private List<SalaRecursoEntity> ConsultarSalaRecursos()
        {
            salaRecursoBO bo = new salaRecursoBO();
            List<string> messages = new List<string>();
            List<SalaRecursoEntity> response = new List<SalaRecursoEntity>();

            try
            {
                response = bo.getsalaRecursos();
            }
            catch (ValidationAndMessageException SalaRecursoException)
            {
                messages.Add(SalaRecursoException.Message);
                ThrowHandledExceptionSalaRecurso(SalaRecursoResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaRecurso(SalaRecursoResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar Sala
        /// </summary>
        private bool ModificarSalaRecurso(int salaRecursoID, int salaID, string nombreRecurso, int cantidad,string estadoRegistro)
        {
            salaRecursoBO bo = new salaRecursoBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifysalaRecurso(salaRecursoID, salaID,nombreRecurso,cantidad,estadoRegistro);
            }
            catch (ValidationAndMessageException SalaRecursoException)
            {
                messages.Add(SalaRecursoException.Message);
                ThrowHandledExceptionSalaRecurso(SalaRecursoResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaRecurso(SalaRecursoResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar Sala
        /// </summary>
        private bool EliminarSalaRecurso(int salaRecursoID)
        {
            salaRecursoBO bo = new salaRecursoBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.eliminarSalaRecurso(salaRecursoID);
            }
            catch (ValidationAndMessageException SalaRecursoException)
            {
                messages.Add(SalaRecursoException.Message);
                ThrowHandledExceptionSalaRecurso(SalaRecursoResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaRecurso(SalaRecursoResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar Sala
        /// </summary>
        private bool InactivarSalaRecurso(int salaRecursoID)
        {
            salaRecursoBO bo = new salaRecursoBO();
            List<string> messages = new List<string>();
            bool response = false; 

            try
            {
                response = bo.inactivarSalaRecurso(salaRecursoID);
            }
            catch (ValidationAndMessageException SalaRecursoException)
            {
                messages.Add(SalaRecursoException.Message);
                ThrowHandledExceptionSalaRecurso(SalaRecursoResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaRecurso(SalaRecursoResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consultar Sala
        /// </summary>
        private SalaRecursoEntity DetalleSalaRecurso(int salaRecursoID)
        {
            salaRecursoBO bo = new salaRecursoBO();
            List<string> messages = new List<string>();
            SalaRecursoEntity response = new SalaRecursoEntity();

            try
            {
                response = bo.consultarSalaRecurso(salaRecursoID);
            }
            catch (ValidationAndMessageException SalaRecursoException)
            {
                messages.Add(SalaRecursoException.Message);
                ThrowHandledExceptionSalaRecurso(SalaRecursoResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaRecurso(SalaRecursoResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// CRUD de Salas para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public SalaRecursoDataResponse Post(CRUDSalaRecursoDataRequest dataRequest)
        {
            SalaRecursoDataResponse response = new SalaRecursoDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de membresias
                if (dataRequest.flujoID == 0)
                {
                    List<SalaRecursoModel> model = new List<SalaRecursoModel>();
                    List<SalaRecursoEntity> items = ConsultarSalaRecursos();

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.SalaRecursosEntityToModel(items);
                        response.ResponseCode = SalaRecursoResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = SalaRecursoResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarNuevaSala(dataRequest.salaID,dataRequest.nombreRecurso,dataRequest.cantidad,dataRequest.estadoRegistro);

                    if (resp)
                    {
                        response.ResponseCode = SalaRecursoResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = SalaRecursoResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarSalaRecurso(dataRequest.salaRecursoID, dataRequest.salaID,dataRequest.nombreRecurso,dataRequest.cantidad,dataRequest.estadoRegistro);

                    if (resp)
                    {
                        response.ResponseCode = SalaRecursoResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = SalaRecursoResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }
                //Detalle de persona
                else if (dataRequest.flujoID == 3)
                {
                    SalaRecursoEntity resp = new SalaRecursoEntity();
                    SalaRecursoModel model = new SalaRecursoModel();

                    resp = DetalleSalaRecurso(dataRequest.salaID);

                    if (resp.salaID > 0) 
                    {
                        model = EntitesHelper.SalaRecursoInfoEntityToModel(resp);
                        response.ResponseCode = SalaRecursoResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = SalaRecursoResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

                //Eliminar
                else if (dataRequest.flujoID == 4)
                {
                    bool resp = EliminarSalaRecurso(dataRequest.salaRecursoID);

                    if (resp)
                    {
                        response.ResponseCode = SalaRecursoResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = SalaRecursoResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }
                //Eliminar
                else if (dataRequest.flujoID == 5)
                {
                    bool resp = InactivarSalaRecurso(dataRequest.salaRecursoID);

                    if (resp)
                    {
                        response.ResponseCode = SalaRecursoResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = SalaRecursoResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }

            }
            catch (SalaRecursoException SalaRecursoException)
            {
                SetResponseAsExceptionSalaRecurso(SalaRecursoException.Type, response, SalaRecursoException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar CRUDSalaRecurso.";
                SetResponseAsExceptionSalaRecurso(SalaRecursoResponseType.Error, response, message);
            }

            return response;
        }
    }
}