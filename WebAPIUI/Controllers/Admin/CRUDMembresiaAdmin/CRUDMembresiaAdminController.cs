using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.DisciplinaAdmin;
using WebAPIBusiness.Entities.Membresia;
using WebAPIBusiness.Entities.MembresiaAdmin;
using WebAPIUI.Controllers.Admin.CRUDMembresiaAdmin.Models;
using WebAPIUI.Controllers.CRUDMembresiaAdmin.Models;
using WebAPIUI.CustomExceptions.MembresiasAdmin;
using WebAPIUI.Helpers;
using WebAPIUI.Models.MembresiasAdmin;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de membresias.
    /// </summary>
    public class CRUDMembresiaAdminController : BaseAPIController
    {
        private void ValidatePostRequest(CRUDMembresiaAdminDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionMembresiaAdmin(MembresiaAdminResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.nombres))
            //{
            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }

        /// <summary>
        /// Insertar una nueva membresia en la tabla
        /// </summary>
        private bool InsertarNuevaMembresia(string nombre, string descripcion, string precio, string periodicidad, List<DisciplinasMembresiaModel> disciplinas)
        {
            MembresiaAdminBO bo = new MembresiaAdminBO();
            List<string> messages = new List<string>();
            bool response = false;
            List<DisciplinasMembresiaRequestEntity> disciplinas1 = new List<DisciplinasMembresiaRequestEntity>();
            try
            {
                if (disciplinas.Count > 0)
                {
                    foreach (var disciplina in disciplinas)
                    {
                        DisciplinasMembresiaRequestEntity disc = new DisciplinasMembresiaRequestEntity()
                        {
                            Quantity = disciplina.Quantity,
                            Selected = disciplina.Selected,
                            Text = disciplina.Text,
                            Value = disciplina.Value
                        };

                        disciplinas1.Add(disc);
                    }

                    response = bo.insertMembership(nombre, descripcion, precio, periodicidad, disciplinas1);
                }
                else
                {
                    throw new Exception("No se especificaron las disciplinas de la membresía.");
                }
            }
            catch (ValidationAndMessageException MembresiaAdminException)
            {
                messages.Add(MembresiaAdminException.Message);
                ThrowHandledExceptionMembresiaAdmin(MembresiaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionMembresiaAdmin(MembresiaAdminResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta las personas de la base 
        /// </summary>
        private List<MembresiaAdminEntity> ConsultarMembresias()
        {
            MembresiaAdminBO bo = new MembresiaAdminBO();
            List<string> messages = new List<string>();
            List<MembresiaAdminEntity> response = new List<MembresiaAdminEntity>();

            try
            {
                response = bo.getMembershipsInfo();
            }
            catch (ValidationAndMessageException RegistroAdminException)
            {
                messages.Add(RegistroAdminException.Message);
                ThrowHandledExceptionMembresiaAdmin(MembresiaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionMembresiaAdmin(MembresiaAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar persona
        /// </summary>
        private bool ModificarMembresia(int membresiaID, string nombre, string descripcion, string precio)
        {
            MembresiaAdminBO bo = new MembresiaAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifyMembership(membresiaID, nombre, descripcion, precio);
            }
            catch (ValidationAndMessageException MembresiaAdminException)
            {
                messages.Add(MembresiaAdminException.Message);
                ThrowHandledExceptionMembresiaAdmin(MembresiaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionMembresiaAdmin(MembresiaAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Consultar membresia
        /// </summary>
        private MembresiaAdminEntity DetalleMembresia(int membresiaID)
        {
            MembresiaAdminBO bo = new MembresiaAdminBO();
            List<string> messages = new List<string>();
            MembresiaAdminEntity response = new MembresiaAdminEntity();

            try
            {
                response = bo.consultarMembresia(membresiaID);
            }
            catch (ValidationAndMessageException MembresiaAdminException)
            {
                messages.Add(MembresiaAdminException.Message);
                ThrowHandledExceptionMembresiaAdmin(MembresiaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionMembresiaAdmin(MembresiaAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Consultar disciplinas de membresia
        /// </summary>
        private List<Membresia_Disciplina_NumClasesEntity> DetalleMembresiaDisciplinas(int membresiaID)
        {
            MembresiaAdminBO bo = new MembresiaAdminBO();
            List<string> messages = new List<string>();
            List<Membresia_Disciplina_NumClasesEntity> response = new List<Membresia_Disciplina_NumClasesEntity>();

            try
            {
                response = bo.consultarDisciplinasDeMembresia(membresiaID);
            }
            catch (ValidationAndMessageException MembresiaAdminException)
            {
                messages.Add(MembresiaAdminException.Message);
                ThrowHandledExceptionMembresiaAdmin(MembresiaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionMembresiaAdmin(MembresiaAdminResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// CRUD para el Admin para Registro Personas
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public MembresiaAdminDataResponse Post(CRUDMembresiaAdminDataRequest dataRequest)
        {
            MembresiaAdminDataResponse response = new MembresiaAdminDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de membresias
                if (dataRequest.flujoID == 0)
                {
                    List<MembresiaAdminModel> model = new List<MembresiaAdminModel>();
                    List<MembresiaAdminEntity> items = ConsultarMembresias();

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.MembresiasEntityToModel(items);
                        response.ResponseCode = MembresiaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = MembresiaAdminResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarNuevaMembresia(dataRequest.nombre, dataRequest.descripcion, dataRequest.precio, dataRequest.periodicidad, dataRequest.disciplinas);

                    if (resp)
                    {
                        response.ResponseCode = MembresiaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = MembresiaAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar (se incluye modificacion para inhabilitar a la persona)
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarMembresia(dataRequest.membresiaID, dataRequest.nombre, dataRequest.descripcion, dataRequest.precio);

                    if (resp)
                    {
                        response.ResponseCode = MembresiaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = MembresiaAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }
                //Detalle de membresia
                else if (dataRequest.flujoID == 3)
                {
                    MembresiaAdminEntity resp = new MembresiaAdminEntity();
                    MembresiaAdminModel model = new MembresiaAdminModel();

                    resp = DetalleMembresia(dataRequest.membresiaID);
                    List<Membresia_Disciplina_NumClasesEntity> entities = DetalleMembresiaDisciplinas(dataRequest.membresiaID);

                    if (resp.membresiaID > 0)
                    {
                        model = EntitesHelper.MembresiaInfoEntityToModel(resp, entities);
                        response.ResponseCode = MembresiaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = MembresiaAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

            }
            catch (MembresiaAdminException MembresiaAdminException)
            {
                SetResponseAsExceptionMembresiaAdmin(MembresiaAdminException.Type, response, MembresiaAdminException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar RegistrarPersona.";
                SetResponseAsExceptionMembresiaAdmin(MembresiaAdminResponseType.Error, response, message);
            }

            return response;
        }
    }
}