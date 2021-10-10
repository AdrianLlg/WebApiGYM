using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.RolAdmin;
using WebAPIUI.Controllers.CRUDRolAdmin.Models;
using WebAPIUI.CustomExceptions.RolAdmin;
using WebAPIUI.Helpers;
using WebAPIUI.Models.RolAdmin;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de roles.
    /// </summary>
    public class CRUDRolAdminController : BaseAPIController
    {
        private void ValidatePostRequest(CRUDRolAdminDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionRolAdmin(RolAdminResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.nombres))
            //{
            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }

        /// <summary>
        /// Insertar un nuevo rol en la BD
        /// </summary>
        private bool InsertarNuevoRol(string nombre, string descripcion)
        {
            RolAdminBO bo = new RolAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertRol(nombre, descripcion);
            }
            catch (ValidationAndMessageException RolAdminException)
            {
                messages.Add(RolAdminException.Message);
                ThrowHandledExceptionRolAdmin(RolAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionRolAdmin(RolAdminResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta los roles de la base 
        /// </summary>
        private List<RolAdminEntity> ConsultarRoles()
        {
            RolAdminBO bo = new RolAdminBO();
            List<string> messages = new List<string>();
            List<RolAdminEntity> response = new List<RolAdminEntity>();

            try
            {
                response = bo.getRoles();
            }
            catch (ValidationAndMessageException RolAdminException)
            {
                messages.Add(RolAdminException.Message);
                ThrowHandledExceptionRolAdmin(RolAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionRolAdmin(RolAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar rol
        /// </summary>
        private bool ModificarRol(int rolID, string nombre, string descripcion)
        {
            RolAdminBO bo = new RolAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifyRol(rolID, nombre, descripcion);
            }
            catch (ValidationAndMessageException RolAdminException)
            {
                messages.Add(RolAdminException.Message);
                ThrowHandledExceptionRolAdmin(RolAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionRolAdmin(RolAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Consultar rol
        /// </summary>
        private RolAdminEntity DetalleRol(int rolID)
        {
            RolAdminBO bo = new RolAdminBO();
            List<string> messages = new List<string>();
            RolAdminEntity response = new RolAdminEntity();

            try
            {
                response = bo.consultarRol(rolID);
            }
            catch (ValidationAndMessageException RolAdminException)
            {
                messages.Add(RolAdminException.Message);
                ThrowHandledExceptionRolAdmin(RolAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionRolAdmin(RolAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// CRUD de Roles para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public RolAdminDataResponse Post(CRUDRolAdminDataRequest dataRequest)
        {
            RolAdminDataResponse response = new RolAdminDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;               

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de membresias
                if (dataRequest.flujoID == 0)
                {
                    List<RolAdminModel> model = new List<RolAdminModel>();
                    List<RolAdminEntity> items = ConsultarRoles();

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.RolesEntityToModel(items);
                        response.ResponseCode = RolAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = RolAdminResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarNuevoRol(dataRequest.nombre, dataRequest.descripcion);

                    if (resp)
                    {
                        response.ResponseCode = RolAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = RolAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar (se incluye modificacion para inhabilitar a la persona)
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarRol(dataRequest.rolID, dataRequest.nombre, dataRequest.descripcion);

                    if (resp)
                    {
                        response.ResponseCode = RolAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = RolAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }  
                //Detalle de persona
                else if (dataRequest.flujoID == 3)
                {
                    RolAdminEntity resp = new RolAdminEntity();
                    RolAdminModel model = new RolAdminModel();

                    resp = DetalleRol(dataRequest.rolID);

                    if (resp.rolePID > 0)
                    {
                        model = EntitesHelper.RolInfoEntityToModel(resp);
                        response.ResponseCode = RolAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = RolAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

            }
            catch (RolAdminException RolAdminException)
            {
                SetResponseAsExceptionRolAdmin(RolAdminException.Type, response, RolAdminException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar CRUDRolAdmin.";
                SetResponseAsExceptionRolAdmin(RolAdminResponseType.Error, response, message);
            }

            return response;
        }
    }
}