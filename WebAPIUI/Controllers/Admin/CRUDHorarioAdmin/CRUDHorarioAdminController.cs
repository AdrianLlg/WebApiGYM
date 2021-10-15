using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.HorarioAdmin;
using WebAPIUI.Controllers;
using WebAPIUI.Controllers.CRUDRHorarioAdmin.Models;
using WebAPIUI.Controllers.CRUDHorarioAdmin.Models;
using WebAPIUI.CustomExceptions.HorarioAdmin;
using WebAPIUI.Helpers;
using WebAPIUI.Models.HorarioAdmin;

namespace WebAPIUI.ContHorariolers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Horarios.
    /// </summary>
    public class CRUDRHorarioAdminController : BaseAPIController
    {
        private void ValidatePostRequest(CRUDHorarioAdminDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionHorarioAdmin(HorarioAdminResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.nombres))
            //{
            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }

        /// <summary>
        /// Insertar un nuevo Horario en la BD
        /// </summary>
        private bool InsertarNuevaHorario(string nombre, string descripcion)
        {
            HorarioAdminBO bo = new HorarioAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertHorario(nombre, descripcion);
            }
            catch (ValidationAndMessageException HorarioAdminException)
            {
                messages.Add(HorarioAdminException.Message);
                ThrowHandledExceptionHorarioAdmin(HorarioAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionHorarioAdmin(HorarioAdminResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta los Horarios de la base 
        /// </summary>
        private List<HorarioAdminEntity> ConsultarHorarios()
        {
            HorarioAdminBO bo = new HorarioAdminBO();
            List<string> messages = new List<string>();
            List<HorarioAdminEntity> response = new List<HorarioAdminEntity>();

            try
            {
                response = bo.getHorarios();
            }
            catch (ValidationAndMessageException HorarioAdminException)
            {
                messages.Add(HorarioAdminException.Message);
                ThrowHandledExceptionHorarioAdmin(HorarioAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionHorarioAdmin(HorarioAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar Horario
        /// </summary>
        private bool ModificarHorario(int HorarioID, string nombre, string descripcion)
        {
            HorarioAdminBO bo = new HorarioAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifyHorario(HorarioID, nombre, descripcion);
            }
            catch (ValidationAndMessageException HorarioAdminException)
            {
                messages.Add(HorarioAdminException.Message);
                ThrowHandledExceptionHorarioAdmin(HorarioAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionHorarioAdmin(HorarioAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Consultar Horario
        /// </summary>
        private HorarioAdminEntity DetalleHorario(int HorarioID)
        {
            HorarioAdminBO bo = new HorarioAdminBO();
            List<string> messages = new List<string>();
            HorarioAdminEntity response = new HorarioAdminEntity();

            try
            {
                response = bo.consultarHorario(HorarioID);
            }
            catch (ValidationAndMessageException HorarioAdminException)
            {
                messages.Add(HorarioAdminException.Message);
                ThrowHandledExceptionHorarioAdmin(HorarioAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionHorarioAdmin(HorarioAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// CRUD de Horarios para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public HorarioAdminDataResponse Post(CRUDHorarioAdminDataRequest dataRequest)
        {
            HorarioAdminDataResponse response = new HorarioAdminDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;               

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de membresias
                if (dataRequest.flujoID == 0)
                {
                    List<HorarioAdminModel> model = new List<HorarioAdminModel>();
                    List<HorarioAdminEntity> items = ConsultarHorarios();

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.HorariosEntityToModel(items);
                        response.ResponseCode = HorarioAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = HorarioAdminResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarNuevaHorario(dataRequest.nombre, dataRequest.descripcion);

                    if (resp)
                    {
                        response.ResponseCode = HorarioAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = HorarioAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarHorario(dataRequest.HorarioID, dataRequest.nombre, dataRequest.descripcion);

                    if (resp)
                    {
                        response.ResponseCode = HorarioAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = HorarioAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }  
                //Detalle de persona
                else if (dataRequest.flujoID == 3)
                {
                    HorarioAdminEntity resp = new HorarioAdminEntity();
                    HorarioAdminModel model = new HorarioAdminModel();

                    resp = DetalleHorario(dataRequest.HorarioID);

                    if (resp.horarioMID > 0)
                    {
                        model = EntitesHelper.HorarioInfoEntityToModel(resp);
                        response.ResponseCode = HorarioAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = HorarioAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

            }
            catch (HorarioAdminException HorarioAdminException)
            {
                SetResponseAsExceptionHorarioAdmin(HorarioAdminException.Type, response, HorarioAdminException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar CRUDHorarioAdmin.";
                SetResponseAsExceptionHorarioAdmin(HorarioAdminResponseType.Error, response, message);
            }

            return response;
        }
    }
}