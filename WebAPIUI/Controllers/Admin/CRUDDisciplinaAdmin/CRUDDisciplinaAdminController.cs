using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.DisciplinaAdmin;
using WebAPIBusiness.Entities.RolAdmin;
using WebAPIUI.Controllers.CRUDDisciplinaAdmin.Models;
using WebAPIUI.CustomExceptions.DisciplinaAdmin;
using WebAPIUI.CustomExceptions.RolAdmin;
using WebAPIUI.Helpers;
using WebAPIUI.Models.DisciplinaAdmin;
using WebAPIUI.Models.RolAdmin;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de disciplinas.
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
        /// Insertar un nueva disciplina en la BD
        /// </summary>
        private bool InsertarNuevaDisciplina(string nombre, string descripcion, string numClases)
        {
            DisciplinaAdminBO bo = new DisciplinaAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertDisciplina(nombre, descripcion, numClases);
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
        /// Consulta las disciplinas de la base 
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
        /// Modificar disciplina
        /// </summary>
        private bool ModificarDisciplina(int disciplinaID, string nombre, string descripcion, string numClases)
        {
            DisciplinaAdminBO bo = new DisciplinaAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifyDisciplina(disciplinaID, nombre, descripcion, numClases);
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
        /// Consultar disciplina
        /// </summary>
        private DisciplinaAdminEntity DetalleDisciplina(int disciplinaID)
        {
            DisciplinaAdminBO bo = new DisciplinaAdminBO();
            List<string> messages = new List<string>();
            DisciplinaAdminEntity response = new DisciplinaAdminEntity();

            try
            {
                response = bo.consultarDisciplina(disciplinaID);
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

                //Mostrar Listado de membresias
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
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarNuevaDisciplina(dataRequest.nombre, dataRequest.descripcion, dataRequest.numClases);

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
                //Modificar
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarDisciplina(dataRequest.disciplinaID, dataRequest.nombre, dataRequest.descripcion, dataRequest.numClases);

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
                //Detalle de persona
                else if (dataRequest.flujoID == 3)
                {
                    DisciplinaAdminEntity resp = new DisciplinaAdminEntity();
                    DisciplinaAdminModel model = new DisciplinaAdminModel();

                    resp = DetalleDisciplina(dataRequest.disciplinaID);

                    if (resp.disciplinaID > 0)
                    {
                        model = EntitesHelper.DisciplinaInfoEntityToModel(resp);
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