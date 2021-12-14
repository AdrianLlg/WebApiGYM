using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.ClasesAdmin;
using WebAPIUI.Controllers.CRUDClaseAdmin.Models;
using WebAPIUI.Controllers.CRUDRClaseAdmin.Models;
using WebAPIUI.CustomExceptions.ClasesAdmin;
using WebAPIUI.Helpers;
using WebAPIUI.Models.ClaseAdmin;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Clases.
    /// </summary>
    public class CRUDClaseAdminController : BaseAPIController
    {
        private void ValidatePostRequest(CRUDClaseAdminDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionClaseAdmin(ClasesAdminResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.nombres))
            //{
            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }

        /// <summary>
        /// Insertar un nuevo Clase en la BD
        /// </summary>
        private bool InsertarNuevaClase(int disciplinaID, string nombre, string descripcion,string estadoRegistro)
        {
            ClasesAdminBO bo = new ClasesAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertClase(disciplinaID, nombre, descripcion, estadoRegistro);
            }
            catch (ValidationAndMessageException ClaseAdminException)
            {
                messages.Add(ClaseAdminException.Message);
                ThrowHandledExceptionClaseAdmin(ClasesAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionClaseAdmin(ClasesAdminResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta los Clases de la base 
        /// </summary>
        private List<ClaseAdminEntity> ConsultarClases()
        {
            ClasesAdminBO bo = new ClasesAdminBO();
            List<string> messages = new List<string>();
            List<ClaseAdminEntity> response = new List<ClaseAdminEntity>();

            try
            {
                response = bo.getClases();
            }
            catch (ValidationAndMessageException ClaseAdminException)
            {
                messages.Add(ClaseAdminException.Message);
                ThrowHandledExceptionClaseAdmin(ClasesAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionClaseAdmin(ClasesAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar Clase
        /// </summary>
        private bool ModificarClase(int ClaseID, int disciplinaID, string nombre, string descripcion)
        {
            ClasesAdminBO bo = new ClasesAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifyClase(ClaseID, disciplinaID, nombre, descripcion);
            }
            catch (ValidationAndMessageException ClaseAdminException)
            {
                messages.Add(ClaseAdminException.Message);
                ThrowHandledExceptionClaseAdmin(ClasesAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionClaseAdmin(ClasesAdminResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Eliminar Clase
        /// </summary>
        private bool EliminarClase(int claseID)
        {
            ClasesAdminBO bo = new ClasesAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.eliminarClase(claseID);
            }
            catch (ValidationAndMessageException ClaseAdminException)
            {
                messages.Add(ClaseAdminException.Message);
                ThrowHandledExceptionClaseAdmin(ClasesAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionClaseAdmin(ClasesAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Eliminar Clase
        /// </summary>
        private bool InactivarClase(int claseID)
        {
            ClasesAdminBO bo = new ClasesAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.inactivarClase(claseID);
            }
            catch (ValidationAndMessageException ClaseAdminException)
            {
                messages.Add(ClaseAdminException.Message);
                ThrowHandledExceptionClaseAdmin(ClasesAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionClaseAdmin(ClasesAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Consultar Clase
        /// </summary>
        private ClaseAdminEntity DetalleClase(int ClaseID)
        {
            ClasesAdminBO bo = new ClasesAdminBO();
            List<string> messages = new List<string>();
            ClaseAdminEntity response = new ClaseAdminEntity();

            try
            {
                response = bo.consultarClase(ClaseID);
            }
            catch (ValidationAndMessageException ClaseAdminException)
            {
                messages.Add(ClaseAdminException.Message);
                ThrowHandledExceptionClaseAdmin(ClasesAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionClaseAdmin(ClasesAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// CRUD de Clases para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ClaseAdminDataResponse Post(CRUDClaseAdminDataRequest dataRequest)
        {
            ClaseAdminDataResponse response = new ClaseAdminDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de membresias
                if (dataRequest.flujoID == 0)
                {
                    List<ClaseAdminModel> model = new List<ClaseAdminModel>();
                    List<ClaseAdminEntity> items = ConsultarClases();

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.ClasesEntityToModel(items);
                        response.ResponseCode = ClasesAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = ClasesAdminResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarNuevaClase(dataRequest.disciplinaID, dataRequest.nombre, dataRequest.descripcion,dataRequest.estadoRegistro);

                    if (resp)
                    {
                        response.ResponseCode = ClasesAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = ClasesAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarClase(dataRequest.claseID, dataRequest.disciplinaID, dataRequest.nombre, dataRequest.descripcion);

                    if (resp)
                    {
                        response.ResponseCode = ClasesAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = ClasesAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }
                //Detalle de persona
                else if (dataRequest.flujoID == 3)
                {
                    ClaseAdminEntity resp = new ClaseAdminEntity();
                    ClaseAdminModel model = new ClaseAdminModel();

                    resp = DetalleClase(dataRequest.claseID);

                    if (resp.claseID > 0)
                    {
                        model = EntitesHelper.ClasesInfoEntityToModel(resp);
                        response.ResponseCode = ClasesAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = ClasesAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

                //Eliminar clase
                else if (dataRequest.flujoID == 4)
                {
                    bool resp = false;
                    ClaseAdminModel model = new ClaseAdminModel();

                    resp = EliminarClase(dataRequest.claseID);

                    if (resp == false)
                    {
                        
                        response.ResponseCode = ClasesAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = ClasesAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

                //Inactivar clase
                else if (dataRequest.flujoID == 5)
                {
                    bool resp = false;
                    ClaseAdminModel model = new ClaseAdminModel();

                    resp = InactivarClase(dataRequest.claseID);

                    if (resp == true)
                    {
                        
                        response.ResponseCode = ClasesAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = ClasesAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }
            }
            catch (ClasesAdminException ClaseAdminException)
            {
                SetResponseAsExceptionClaseAdmin(ClaseAdminException.Type, response, ClaseAdminException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar CRUDClaseAdmin.";
                SetResponseAsExceptionClaseAdmin(ClasesAdminResponseType.Error, response, message);
            }

            return response;
        }
    }
}