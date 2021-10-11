using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers.CRUDSalaAdmin.Models;
using WebAPIUI.CustomExceptions.SalasAdmin;
using WebAPIUI.Helpers;
using WebAPIUI.Models.SalasAdmin;

namespace WebAPIUI.Controllers
{
    public class CRUDSalaAdminController : BaseAPIController
    {
        private void ValidatePostRequest(CRUDSalaAdminDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionSalaAdmin(SalaAdminResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.nombres))
            //{
            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }

        /// <summary>
        /// Insertar una nueva persona en la tabla
        /// </summary>
        private bool InsertarNuevaSala( string nombre, string descripcion)
        {
            SalaAdminBO bo = new SalaAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertSala(nombre, descripcion);
            }
            catch (ValidationAndMessageException SalaAdminException)
            {
                messages.Add(SalaAdminException.Message);
                ThrowHandledExceptionSalaAdmin(SalaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaAdmin(SalaAdminResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta las personas de la base 
        /// </summary>
        private List<SalaAdminModel> ConsultarPersonas()
        {
            SalaAdminBO bo = new SalaAdminBO();
            List<string> messages = new List<string>();
            List<SalaAdminModel> response = new List<SalaAdminModel>();

            try
            {
                response = bo.getSalas();
            }
            catch (ValidationAndMessageException SalaAdminException)
            {
                messages.Add(SalaAdminException.Message);
                ThrowHandledExceptionSalaAdmin(SalaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaAdmin(SalaAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar persona
        /// </summary>
        private bool ModificarSala(int salaID, string nombre, string descripcion)
        {
            SalaAdminBO bo = new SalaAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifySala(salaID, nombre, descripcion);
            }
            catch (ValidationAndMessageException SalaAdminException)
            {
                messages.Add(SalaAdminException.Message);
                ThrowHandledExceptionSalaAdmin(SalaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaAdmin(SalaAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Consultar persona
        /// </summary>
        private SalaAdminModel DetalleSala(int salaID)
        {
            SalaAdminBO bo = new SalaAdminBO();
            List<string> messages = new List<string>();
            SalaAdminModel response = new SalaAdminModel();

            try
            {
                response = bo.consultarSala(salaID);
            }
            catch (ValidationAndMessageException SalaAdminException)
            {
                messages.Add(SalaAdminException.Message);
                ThrowHandledExceptionSalaAdmin(SalaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSalaAdmin(SalaAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// CRUD para el Admin para Sala Personas
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public CRUDSalaAdminDataResponse Post(CRUDSalaAdminDataRequest dataRequest)
        {
            CRUDSalaAdminDataResponse response = new CRUDSalaAdminDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;               

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de usuarios
                if (dataRequest.flujoID == 0)
                {
                    List<SalaAdminModel> model = new List<SalaAdminModel>();
                    List<SalaAdminModel> items = ConsultarPersonas();

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.SalasEntityToModel(items);
                        response.ResponseCode = SalaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = SalaAdminResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarNuevaSala(dataRequest.nombre, dataRequest.descripcion);

                    if (resp)
                    {
                        response.ResponseCode = SalaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = SalaAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar (se incluye modificacion para inhabilitar a la persona)
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarSala(dataRequest.salaID, dataRequest.nombre, dataRequest.descripcion);

                    if (resp)
                    {
                        response.ResponseCode = SalaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = SalaAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }  
                //Detalle de persona
                else if (dataRequest.flujoID == 3)
                {
                    SalaAdminModel resp = new SalaAdminModel();
                    SalaAdminModel model = new SalaAdminModel();

                    resp = DetalleSala(dataRequest.salaID);

                    if (resp.salaID > 0)
                    {
                        model = EntitesHelper.SalasEntityToModel(resp);
                        response.ResponseCode = SalaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = SalaAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

            }
            catch (SalaAdminException SalaAdminException)
            {
                SetResponseAsExceptionSalaAdmin(SalaAdminException.Type, response, SalaAdminException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar RegistrarPersona.";
                SetResponseAsExceptionSalaAdmin(SalaAdminResponseType.Error, response, message);
            }

            return response;
        }
    }
}