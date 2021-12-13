using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.DisciplinaAdmin;
using WebAPIUI.Controllers.CRUDDisciplinaAdmin.Models;
using WebAPIUI.Controllers.CRUDRDisciplinaAdmin.Models;
using WebAPIUI.CustomExceptions.DisciplinaAdmin;
using WebAPIUI.Helpers;
using WebAPIUI.Models.DisciplinaAdmin;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Disciplinas.
    /// </summary>
    public class CRUDDisciplinaAdminController : BaseAPIController
    {
        private void ValidatePostRequest(CRUDDisciplinaAdminDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionDisciplinaAdmin(DisciplinaAdminResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.nombres))
            //{
            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }

        /// <summary>
        /// Insertar un nuevo Disciplina en la BD
        /// </summary>
        private bool InsertarNuevaDisciplina(string nombre, string descripcion,string estadoRegistro)
        {
            DisciplinaAdminBO bo = new DisciplinaAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertDisciplina(nombre, descripcion, estadoRegistro);
            }
            catch (ValidationAndMessageException DisciplinaAdminException)
            {
                messages.Add(DisciplinaAdminException.Message);
                ThrowHandledExceptionDisciplinaAdmin(DisciplinaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionDisciplinaAdmin(DisciplinaAdminResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta los Disciplinas de la base 
        /// </summary>
        private List<DisciplinaAdminEntity> ConsultarDisciplinas()
        {
            DisciplinaAdminBO bo = new DisciplinaAdminBO();
            List<string> messages = new List<string>();
            List<DisciplinaAdminEntity> response = new List<DisciplinaAdminEntity>();

            try
            {
                response = bo.getDisciplinas();
            }
            catch (ValidationAndMessageException DisciplinaAdminException)
            {
                messages.Add(DisciplinaAdminException.Message);
                ThrowHandledExceptionDisciplinaAdmin(DisciplinaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionDisciplinaAdmin(DisciplinaAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar Disciplina
        /// </summary>
        private bool ModificarDisciplina(int DisciplinaID, string nombre, string descripcion,string estado)
        {
            DisciplinaAdminBO bo = new DisciplinaAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifyDisciplina(DisciplinaID, nombre, descripcion);
            }
            catch (ValidationAndMessageException DisciplinaAdminException)
            {
                messages.Add(DisciplinaAdminException.Message);
                ThrowHandledExceptionDisciplinaAdmin(DisciplinaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionDisciplinaAdmin(DisciplinaAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Eliminar Disciplina si no hay foreign keys
        /// </summary>
        private bool EliminarDisciplina(int DisciplinaID)
        {
            DisciplinaAdminBO bo = new DisciplinaAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.eliminarDisciplina(DisciplinaID);
            }
            catch (ValidationAndMessageException DisciplinaAdminException)
            {
                messages.Add(DisciplinaAdminException.Message);
                ThrowHandledExceptionDisciplinaAdmin(DisciplinaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionDisciplinaAdmin(DisciplinaAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Eliminar Disciplina si no hay foreign keys
        /// </summary>
        private bool InactivarDisciplina(int DisciplinaID)
        {
            DisciplinaAdminBO bo = new DisciplinaAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.inactivarDisciplina(DisciplinaID);
            }
            catch (ValidationAndMessageException DisciplinaAdminException)
            {
                messages.Add(DisciplinaAdminException.Message);
                ThrowHandledExceptionDisciplinaAdmin(DisciplinaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionDisciplinaAdmin(DisciplinaAdminResponseType.Error, ex);
            }

            return response;
        }
        /// <summary>
        /// Consultar Disciplina
        /// </summary>
        private DisciplinaAdminEntity DetalleDisciplina(int DisciplinaID)
        {
            DisciplinaAdminBO bo = new DisciplinaAdminBO();
            List<string> messages = new List<string>();
            DisciplinaAdminEntity response = new DisciplinaAdminEntity();

            try
            {
                response = bo.consultarDisciplina(DisciplinaID);
            }
            catch (ValidationAndMessageException DisciplinaAdminException)
            {
                messages.Add(DisciplinaAdminException.Message);
                ThrowHandledExceptionDisciplinaAdmin(DisciplinaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionDisciplinaAdmin(DisciplinaAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// CRUD de Disciplinas para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public DisciplinaAdminDataResponse Post(CRUDDisciplinaAdminDataRequest dataRequest)
        {
            DisciplinaAdminDataResponse response = new DisciplinaAdminDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;               

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de disicplinas
                if (dataRequest.flujoID == 0)
                {
                    List<DisciplinaAdminModel> model = new List<DisciplinaAdminModel>();
                    List<DisciplinaAdminEntity> items = ConsultarDisciplinas();

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.DisciplinasEntityToModel(items);
                        response.ResponseCode = DisciplinaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = DisciplinaAdminResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear Disciplina
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarNuevaDisciplina(dataRequest.nombre, dataRequest.descripcion,dataRequest.estadoRegistro);

                    if (resp)
                    {
                        response.ResponseCode = DisciplinaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = DisciplinaAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar Disiciplina
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarDisciplina(dataRequest.disciplinaID, dataRequest.nombre, dataRequest.descripcion,dataRequest.estadoRegistro);

                    if (resp)
                    {
                        response.ResponseCode = DisciplinaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = DisciplinaAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }  
                //Detalle disciplina
                else if (dataRequest.flujoID == 3)
                {
                    DisciplinaAdminEntity resp = new DisciplinaAdminEntity();
                    DisciplinaAdminModel model = new DisciplinaAdminModel();

                    resp = DetalleDisciplina(dataRequest.disciplinaID);

                    if (resp.disciplinaID > 0)
                    {
                        model = EntitesHelper.DisciplinasInfoEntityToModel(resp);
                        response.ResponseCode = DisciplinaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = DisciplinaAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

                //Eliminar de disciplina
                else if (dataRequest.flujoID == 4)
                {
                    bool resp = false;
                    DisciplinaAdminModel model = new DisciplinaAdminModel();

                    resp = EliminarDisciplina(dataRequest.disciplinaID);

                    if (resp==true) 
                    {
                        response.ResponseCode = DisciplinaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = DisciplinaAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }
                //Eliminar de disciplina
                else if (dataRequest.flujoID == 5)
                {
                    bool resp = false;
                    DisciplinaAdminModel model = new DisciplinaAdminModel();

                    resp = InactivarDisciplina(dataRequest.disciplinaID);

                    if (resp == true)
                    {
                        response.ResponseCode = DisciplinaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = DisciplinaAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }


            }
            catch (DisciplinaAdminException DisciplinaAdminException)
            {
                SetResponseAsExceptionDisciplinaAdmin(DisciplinaAdminException.Type, response, DisciplinaAdminException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar CRUDDisciplinaAdmin.";
                SetResponseAsExceptionDisciplinaAdmin(DisciplinaAdminResponseType.Error, response, message);
            }

            return response;
        }
    }
}