using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.RecursoEspecialAdmin;
using WebAPIUI.Controllers.CRUDRecursoEspecialAdmin.Models;
using WebAPIUI.CustomExceptions.RecursoEspecialAdmin;
using WebAPIUI.Helpers;
using WebAPIUI.Models.RecursoEspecialAdmin;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de recursos.
    /// </summary>
    public class CRUDRecursoEspecialAdminController : BaseAPIController
    {
        private void ValidatePostRequest(CRUDRecursoEspecialAdminDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionRecursoEspecialAdmin(RecursoEspecialAdminResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.nombres))
            //{
            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }

        /// <summary>
        /// Insertar un nuevo recurso en la BD
        /// </summary>
        private bool InsertarNuevoRecurso(string nombre, string descripcion)
        {
            RecursoEspecialAdminBO bo = new RecursoEspecialAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertRecursoEspecial(nombre, descripcion);
            }
            catch (ValidationAndMessageException RecursoEspecialAdminException)
            {
                messages.Add(RecursoEspecialAdminException.Message);
                ThrowHandledExceptionRecursoEspecialAdmin(RecursoEspecialAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionRecursoEspecialAdmin(RecursoEspecialAdminResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta los recursos de la base 
        /// </summary>
        private List<RecursoEspecialAdminEntity> ConsultarRecursosEspeciales()
        {
            RecursoEspecialAdminBO bo = new RecursoEspecialAdminBO();
            List<string> messages = new List<string>();
            List<RecursoEspecialAdminEntity> response = new List<RecursoEspecialAdminEntity>();

            try
            {
                response = bo.getRecursoEspeciales();
            }
            catch (ValidationAndMessageException RecursoEspecialAdminException)
            {
                messages.Add(RecursoEspecialAdminException.Message);
                ThrowHandledExceptionRecursoEspecialAdmin(RecursoEspecialAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionRecursoEspecialAdmin(RecursoEspecialAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar recurso
        /// </summary>
        private bool ModificarRecursoEspecial(int recursoEspecialID, string nombre, string descripcion)
        {
            RecursoEspecialAdminBO bo = new RecursoEspecialAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifyRecursoEspecial(recursoEspecialID, nombre, descripcion);
            }
            catch (ValidationAndMessageException RecursoEspecialAdminException)
            {
                messages.Add(RecursoEspecialAdminException.Message);
                ThrowHandledExceptionRecursoEspecialAdmin(RecursoEspecialAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionRecursoEspecialAdmin(RecursoEspecialAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Consultar recurso
        /// </summary>
        private RecursoEspecialAdminEntity DetalleRecursoEspecial(int recursoEspecialID)
        {
            RecursoEspecialAdminBO bo = new RecursoEspecialAdminBO();
            List<string> messages = new List<string>();
            RecursoEspecialAdminEntity response = new RecursoEspecialAdminEntity();

            try
            {
                response = bo.consultarRecursoEspecial(recursoEspecialID);
            }
            catch (ValidationAndMessageException RecursoEspecialAdminException)
            {
                messages.Add(RecursoEspecialAdminException.Message);
                ThrowHandledExceptionRecursoEspecialAdmin(RecursoEspecialAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionRecursoEspecialAdmin(RecursoEspecialAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// CRUD de recursos para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public RecursoEspecialAdminDataResponse Post(CRUDRecursoEspecialAdminDataRequest dataRequest)
        {
            RecursoEspecialAdminDataResponse response = new RecursoEspecialAdminDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;               

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de membresias
                if (dataRequest.flujoID == 0)
                {
                    List<RecursoEspecialAdminModel> model = new List<RecursoEspecialAdminModel>();
                    List<RecursoEspecialAdminEntity> items = ConsultarRecursosEspeciales();

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.RecursoEspecialsEntityToModel(items);
                        response.ResponseCode = RecursoEspecialAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = RecursoEspecialAdminResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarNuevoRecurso(dataRequest.nombre, dataRequest.descripcion);

                    if (resp)
                    {
                        response.ResponseCode = RecursoEspecialAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = RecursoEspecialAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarRecursoEspecial(dataRequest.recursoEspecialID, dataRequest.nombre, dataRequest.descripcion);

                    if (resp)
                    {
                        response.ResponseCode = RecursoEspecialAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = RecursoEspecialAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }  
                //Detalle de persona
                else if (dataRequest.flujoID == 3)
                {
                    RecursoEspecialAdminEntity resp = new RecursoEspecialAdminEntity();
                    RecursoEspecialAdminModel model = new RecursoEspecialAdminModel();

                    resp = DetalleRecursoEspecial(dataRequest.recursoEspecialID);

                    if (resp.recursoEspecialID > 0)
                    {
                        model = EntitesHelper.RecursoEspecialInfoEntityToModel(resp);
                        response.ResponseCode = RecursoEspecialAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = RecursoEspecialAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

            }
            catch (RecursoEspecialAdminException RecursoEspecialAdminException)
            {
                SetResponseAsExceptionRecursoEspecialAdmin(RecursoEspecialAdminException.Type, response, RecursoEspecialAdminException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar CRUDRecursoEspecialAdmin.";
                SetResponseAsExceptionRecursoEspecialAdmin(RecursoEspecialAdminResponseType.Error, response, message);
            }

            return response;
        }
    }
}