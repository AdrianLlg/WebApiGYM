//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Http;
//using WebAPIBusiness.BusinessCore;
//using WebAPIBusiness.CustomExceptions;
//using WebAPIBusiness.Entities.RecursoAdmin;
//using WebAPIUI.Controllers.CRUDRecursoAdmin.Models;
//using WebAPIUI.CustomExceptions.RecursoAdmin;
//using WebAPIUI.Helpers;
//using WebAPIUI.Models.RecursoAdmin;

//namespace WebAPIUI.Controllers
//{
//    /// <summary>
//    /// API que permite el manejo de Crear, Modificar y Consultar información de recursos.
//    /// </summary>
//    public class CRUDRecursoAdminController : BaseAPIController
//    {
//        private void ValidatePostRequest(CRUDRecursoAdminDataRequest dataRequest)
//        {
//            List<string> messages = new List<string>();
//            string message = string.Empty;

//            if (dataRequest == null)
//            {
//                messages.Add("No se han especificado datos de ingreso.");
//                ThrowHandledExceptionRecursoAdmin(RecursoAdminResponseType.InvalidParameters, messages);
//            }

//            //if (string.IsNullOrEmpty(dataRequest.nombres))
//            //{
//            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
//            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
//            //}
//        }

//        /// <summary>
//        /// Insertar un nuevo recurso en la BD
//        /// </summary>
//        private bool InsertarNuevoRecurso(string nombre, string descripcion, string cantidadRecurso)
//        {
//            RecursoAdminBO bo = new RecursoAdminBO();
//            List<string> messages = new List<string>();
//            bool response = false;

//            try
//            {
//                response = bo.insertRecurso(nombre, descripcion, cantidadRecurso);
//            }
//            catch (ValidationAndMessageException RecursoAdminException)
//            {
//                messages.Add(RecursoAdminException.Message);
//                ThrowHandledExceptionRecursoAdmin(RecursoAdminResponseType.Error, messages);
//            }
//            catch (Exception ex)
//            {
//                messages.Add("Ocurrió un error al ejecutar el proceso.");
//                ThrowUnHandledExceptionRecursoAdmin(RecursoAdminResponseType.Error, ex);
//            }

//            return response;
//        }


//        /// <summary>
//        /// Consulta los recursos de la base 
//        /// </summary>
//        private List<RecursoAdminEntity> ConsultarRecursos()
//        {
//            RecursoAdminBO bo = new RecursoAdminBO();
//            List<string> messages = new List<string>();
//            List<RecursoAdminEntity> response = new List<RecursoAdminEntity>();

//            try
//            {
//                response = bo.getRecursos();
//            }
//            catch (ValidationAndMessageException RecursoAdminException)
//            {
//                messages.Add(RecursoAdminException.Message);
//                ThrowHandledExceptionRecursoAdmin(RecursoAdminResponseType.Error, messages);
//            }
//            catch (Exception ex)
//            {
//                messages.Add("Ocurrió un error al ejecutar el proceso.");
//                ThrowUnHandledExceptionRecursoAdmin(RecursoAdminResponseType.Error, ex);
//            }

//            return response;
//        }

//        /// <summary>
//        /// Modificar recurso
//        /// </summary>
//        private bool ModificarRecurso(int recursoID, string nombre, string descripcion, string cantidadRecurso)
//        {
//            RecursoAdminBO bo = new RecursoAdminBO();
//            List<string> messages = new List<string>();
//            bool response = false;

//            try
//            {
//                response = bo.modifyRecurso(recursoID, nombre, descripcion, cantidadRecurso);
//            }
//            catch (ValidationAndMessageException RecursoAdminException)
//            {
//                messages.Add(RecursoAdminException.Message);
//                ThrowHandledExceptionRecursoAdmin(RecursoAdminResponseType.Error, messages);
//            }
//            catch (Exception ex)
//            {
//                messages.Add("Ocurrió un error al ejecutar el proceso.");
//                ThrowUnHandledExceptionRecursoAdmin(RecursoAdminResponseType.Error, ex);
//            }

//            return response;
//        }

//        /// <summary>
//        /// Eliminar recurso
//        /// </summary>
//        private bool EliminarRecurso(int recursoID)
//        {
//            RecursoAdminBO bo = new RecursoAdminBO();
//            List<string> messages = new List<string>();
//            bool response = false;

//            try
//            {
                
//                response = bo.eliminarRecurso(recursoID);
//            }
//            catch (ValidationAndMessageException RecursoAdminException)
//            {
//                messages.Add(RecursoAdminException.Message);
//                ThrowHandledExceptionRecursoAdmin(RecursoAdminResponseType.Error, messages);
//            }
//            catch (Exception ex)
//            {
//                messages.Add("Ocurrió un error al ejecutar el proceso.");
//                ThrowUnHandledExceptionRecursoAdmin(RecursoAdminResponseType.Error, ex);
//            }

//            return response;
//        }

//        /// <summary>
//        /// Consultar recurso
//        /// </summary>
//        private RecursoAdminEntity DetalleRecurso(int recursoID)
//        {
//            RecursoAdminBO bo = new RecursoAdminBO();
//            List<string> messages = new List<string>();
//            RecursoAdminEntity response = new RecursoAdminEntity();

//            try
//            {
//                response = bo.consultarRecurso(recursoID);
//            }
//            catch (ValidationAndMessageException RecursoAdminException)
//            {
//                messages.Add(RecursoAdminException.Message);
//                ThrowHandledExceptionRecursoAdmin(RecursoAdminResponseType.Error, messages);
//            }
//            catch (Exception ex)
//            {
//                messages.Add("Ocurrió un error al ejecutar el proceso.");
//                ThrowUnHandledExceptionRecursoAdmin(RecursoAdminResponseType.Error, ex);
//            }

//            return response;
//        }

//        /// <summary>
//        /// CRUD de recursos para Admin
//        /// </summary>
//        /// <param name="dataRequest"></param>
//        /// <returns></returns>
//        [HttpPost]
//        public RecursoAdminDataResponse Post(CRUDRecursoAdminDataRequest dataRequest)
//        {
//            RecursoAdminDataResponse response = new RecursoAdminDataResponse();

//            try
//            {
//                List<string> messages = new List<string>();
//                string message = string.Empty;               

//                ValidatePostRequest(dataRequest);

//                //Mostrar Listado de membresias
//                if (dataRequest.flujoID == 0)
//                {
//                    List<RecursoAdminModel> model = new List<RecursoAdminModel>();
//                    List<RecursoAdminEntity> items = ConsultarRecursos();

//                    if (items.Count > 0)
//                    {
//                        model = EntitesHelper.RecursosEntityToModel(items);
//                        response.ResponseCode = RecursoAdminResponseType.Ok;
//                        response.ResponseMessage = "Método ejecutado con éxito.";
//                        response.ContentIndex = model;
//                    }
//                    else
//                    {
//                        response.ResponseCode = RecursoAdminResponseType.InvalidParameters;
//                        response.ResponseMessage = "Fallo en la ejecución.";
//                        response.ContentIndex = null;
//                    }
//                }
//                //Crear
//                else if (dataRequest.flujoID == 1)
//                {
//                    bool resp = InsertarNuevoRecurso(dataRequest.nombre, dataRequest.descripcion, dataRequest.cantidadRecurso);

//                    if (resp)
//                    {
//                        response.ResponseCode = RecursoAdminResponseType.Ok;
//                        response.ResponseMessage = "Método ejecutado con éxito.";
//                        response.ContentCreate = true;
//                    }
//                    else
//                    {
//                        response.ResponseCode = RecursoAdminResponseType.Error;
//                        response.ResponseMessage = "Fallo en la ejecución.";
//                        response.ContentCreate = false;
//                    }
//                }
//                //Modificar
//                else if (dataRequest.flujoID == 2)
//                {
//                    bool resp = ModificarRecurso(dataRequest.recursoID, dataRequest.nombre, dataRequest.descripcion, dataRequest.cantidadRecurso);

//                    if (resp)
//                    {
//                        response.ResponseCode = RecursoAdminResponseType.Ok;
//                        response.ResponseMessage = "Método ejecutado con éxito.";
//                        response.ContentModify = true;
//                    }
//                    else
//                    {
//                        response.ResponseCode = RecursoAdminResponseType.Error;
//                        response.ResponseMessage = "Fallo en la ejecución.";
//                        response.ContentModify = false;
//                    }
//                }  
//                //Detalle de persona
//                else if (dataRequest.flujoID == 3)
//                {
//                    RecursoAdminEntity resp = new RecursoAdminEntity();
//                    RecursoAdminModel model = new RecursoAdminModel();

//                    resp = DetalleRecurso(dataRequest.recursoID);

//                    if (resp.recursoID > 0)
//                    {
//                        model = EntitesHelper.RecursoInfoEntityToModel(resp);
//                        response.ResponseCode = RecursoAdminResponseType.Ok;
//                        response.ResponseMessage = "Método ejecutado con éxito.";
//                        response.ContentDetail = model;
//                    }
//                    else
//                    {
//                        response.ResponseCode = RecursoAdminResponseType.Error;
//                        response.ResponseMessage = "Fallo en la ejecución.";
//                        response.ContentDetail = null;
//                    }

//                }
//                //Detalle de persona
//                else if (dataRequest.flujoID == 4)
//                {
//                    bool resp = false;
//                    RecursoAdminModel model = new RecursoAdminModel();

//                    resp = EliminarRecurso(dataRequest.recursoID);

//                    if (resp==true)
//                    {
                        
//                        response.ResponseCode = RecursoAdminResponseType.Ok;
//                        response.ResponseMessage = "Método ejecutado con éxito.";
//                        response.ContentDelete = true;
//                    }
//                    else
//                    {
//                        response.ResponseCode = RecursoAdminResponseType.Error;
//                        response.ResponseMessage = "Fallo en la ejecución.";
//                        response.ContentDelete = false;
//                    }

//                }

//            }
//            catch (RecursoAdminException RecursoAdminException)
//            {
//                SetResponseAsExceptionRecursoAdmin(RecursoAdminException.Type, response, RecursoAdminException.Message);
//            }
//            catch (Exception ex)
//            {
//                string message = "Se ha produccido un error al invocar CRUDRecursoAdmin.";
//                SetResponseAsExceptionRecursoAdmin(RecursoAdminResponseType.Error, response, message);
//            }

//            return response;
//        }
//    }
//}