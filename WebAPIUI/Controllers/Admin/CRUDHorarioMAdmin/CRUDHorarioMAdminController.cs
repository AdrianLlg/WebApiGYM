using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers;
using WebAPIUI.Helpers;
using WebAPIBusiness.Entities.HorarioMAdmin;
using WebAPIUI.Models.HorarioMAdmin;
using WebAPIUI.CustomExceptions.HorarioMAdmin;
using WebAPIUI.Controllers.CRUDRHorarioMAdmin.Models;
using WebAPIUI.Controllers.CRUDSHorarioMAdmin.Models;

namespace WebAPIUI.ContHorarioMlers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de HorarioM.
    /// </summary>
    public class CRUDHorarioMAdminController : BaseAPIController
    {
        private void ValidatePostRequest(CRUDHorarioMAdminDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionHorarioMAdmin(HorarioMAdminResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.horaInicios))
            //{
            //    messages.Add("No se ha especificado el(los) horaInicio(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }

        /// <summary>
        /// Insertar un nuevo HorarioM en la BD
        /// </summary>
        private bool InsertarNuevoHorarioM(string horaInicio, string horaFin)
        {
            HorarioMAdminBO bo = new HorarioMAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertHorarioM(horaInicio, horaFin);
            }
            catch (ValidationAndMessageException HorarioMException)
            {
                messages.Add(HorarioMException.Message);
                ThrowHandledExceptionHorarioMAdmin(HorarioMAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionHorarioMAdmin(HorarioMAdminResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta los HorarioM de la base 
        /// </summary>
        private List<HorarioMAdminEntity> ConsultarHorarioM()
        {
            HorarioMAdminBO bo = new HorarioMAdminBO();
            List<string> messages = new List<string>();
            List<HorarioMAdminEntity> response = new List<HorarioMAdminEntity>();

            try
            {
                response = bo.getHorarioM();
            }
            catch (ValidationAndMessageException HorarioMException)
            {
                messages.Add(HorarioMException.Message);
                ThrowHandledExceptionHorarioMAdmin(HorarioMAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionHorarioM(HorarioMAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar HorarioM
        /// </summary>
        private bool ModificarHorarioM(int a, string horaInicio, string horaFin)
        {
            HorarioMAdminBO bo = new HorarioMAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifyHorarioM(a, horaInicio, horaFin);
            }
            catch (ValidationAndMessageException HorarioMException)
            {
                messages.Add(HorarioMException.Message);
                ThrowHandledExceptionHorarioMAdmin(HorarioMAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionHorarioMAdmin(HorarioMAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Consultar HorarioM
        /// </summary>
        private HorarioMAdminEntity DetalleHoraioM(int a)
        {
            HorarioMAdminBO bo = new HorarioMAdminBO();
            List<string> messages = new List<string>();
            HorarioMAdminEntity response = new HorarioMAdminEntity();

            try
            {
                response = bo.consultarHorarioM(a);
            }
            catch (ValidationAndMessageException HorarioMAdminException)
            {
                messages.Add(HorarioMAdminException.Message);
                ThrowHandledExceptionHorarioMAdmin(HorarioMAdminResponseType.InvalidParameters, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionHorarioM(HorarioMAdminResponseType.Error, ex);
            }

            return response;
        }

        private void ThrowUnHandledExceptionHorarioM(HorarioMAdminResponseType error, Exception ex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// CRUD de HorarioM para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public HorarioMAdminDataResponse Post(CRUDHorarioMAdminDataRequest dataRequest)
        {
            HorarioMAdminDataResponse response = new HorarioMAdminDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;               

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de membresias
                if (dataRequest.flujoID == 0)
                {
                    List<HorarioMAdminModel> model = new List<HorarioMAdminModel>();
                    List<HorarioMAdminEntity> items = ConsultarHorarioM();

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.horarioMEntityToModel(items);
                        response.ResponseCode = HorarioMAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = HorarioMAdminResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarNuevoHorarioM(dataRequest.horaInicio, dataRequest.horaFin);

                    if (resp)
                    {
                        response.ResponseCode = HorarioMAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = HorarioMAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarHorarioM(dataRequest.horarioMID, dataRequest.horaInicio, dataRequest.horaFin);

                    if (resp)
                    {
                        response.ResponseCode = HorarioMAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = HorarioMAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }  
                //Detalle de persona
                else if (dataRequest.flujoID == 3)
                {
                    HorarioMAdminEntity resp = new HorarioMAdminEntity();
                    HorarioMAdminModel model = new HorarioMAdminModel();

                    resp = DetalleHoraioM(dataRequest.horarioMID);

                    if (resp.horarioMID > 0)
                    {
                        model = EntitesHelper.HorarioMInfoEntityToModel(resp);
                        response.ResponseCode = HorarioMAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = HorarioMAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

            }
            catch (HorarioMAdminException HorarioMException)
            {
                SetResponseAsExceptionHorarioMAdmin(HorarioMException.Type, response, HorarioMException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar CRUDHorarioMAdmin.";
                SetResponseAsExceptionHorarioMAdmin(HorarioMAdminResponseType.Error, response, message);
            }

            return response;
        }
    }
}