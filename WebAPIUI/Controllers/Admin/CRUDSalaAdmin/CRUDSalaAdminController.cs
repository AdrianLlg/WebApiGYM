using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.SalaAdmin;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.CRUDRSalaAdmin.Models;
using WebAPIUI.Controllers.CRUDSalaAdmin.Models;
using WebAPIUI.CustomExceptions.SalaAdmin;
using WebAPIUI.Helpers;
using WebAPIUI.Models.SalaAdmin;

namespace WebAPIUI.ContSalalers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Salas.
    /// </summary>
    public class CRUDRSalaAdminController : BaseAPIController
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
        /// Insertar un nuevo Sala en la BD
        /// </summary>
        private bool InsertarNuevaSala(string nombre, string descripcion)
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
        /// Consulta los Salas de la base 
        /// </summary>
        private List<SalaAdminEntity> ConsultarSalas()
        {
            SalaAdminBO bo = new SalaAdminBO();
            List<string> messages = new List<string>();
            List<SalaAdminEntity> response = new List<SalaAdminEntity>();

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
        /// Modificar Sala
        /// </summary>
        private bool ModificarSala(int SalaID, string nombre, string descripcion)
        {
            SalaAdminBO bo = new SalaAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifySala(SalaID, nombre, descripcion);
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
        /// Consultar Sala
        /// </summary>
        private SalaAdminEntity DetalleSala(int SalaID)
        {
            SalaAdminBO bo = new SalaAdminBO();
            List<string> messages = new List<string>();
            SalaAdminEntity response = new SalaAdminEntity();

            try
            {
                response = bo.consultarSala(SalaID);
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
        /// CRUD de Salas para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public SalaAdminDataResponse Post(CRUDSalaAdminDataRequest dataRequest)
        {
            SalaAdminDataResponse response = new SalaAdminDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;               

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de membresias
                if (dataRequest.flujoID == 0)
                {
                    List<SalaAdminModel> model = new List<SalaAdminModel>();
                    List<SalaAdminEntity> items = ConsultarSalas();

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
                //Modificar
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
                    SalaAdminEntity resp = new SalaAdminEntity();
                    SalaAdminModel model = new SalaAdminModel();

                    resp = DetalleSala(dataRequest.salaID);

                    if (resp.salaID > 0)
                    {
                        model = EntitesHelper.SalaInfoEntityToModel(resp);
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
                string message = "Se ha produccido un error al invocar CRUDSalaAdmin.";
                SetResponseAsExceptionSalaAdmin(SalaAdminResponseType.Error, response, message);
            }

            return response;
        }
    }
}