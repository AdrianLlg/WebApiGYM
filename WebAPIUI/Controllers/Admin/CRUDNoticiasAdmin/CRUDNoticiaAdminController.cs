using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.Noticia;
using WebAPIUI.Controllers.CRUDNoticiaAdmin.Models;
using WebAPIUI.CustomExceptions.NoticiaAdmin;
using WebAPIUI.Helpers;
using WebAPIUI.Models.NoticiaAdmin;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Noticias.
    /// </summary>
    public class CRUDNoticiaAdminController : BaseAPIController
    {
        private void ValidatePostRequest(CRUDNoticiaAdminDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionNoticiaAdmin(NoticiaAdminResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.nombres))
            //{
            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }

        /// <summary>
        /// Insertar un nuevo Noticia en la BD
        /// </summary>
        private bool InsertarNuevaNoticia(string titulo, string contenido, string imagen,string fechaInicio,string fechaFin)
        {
            NoticiaAdminBO bo = new NoticiaAdminBO();
            List<string> messages = new List<string>();
            bool response = false;
             
            try
            {
                response = bo.insertNoticia(titulo, contenido, imagen,fechaInicio,fechaFin);
            }
            catch (ValidationAndMessageException NoticiaAdminException)
            {
                messages.Add(NoticiaAdminException.Message);
                ThrowHandledExceptionNoticiaAdmin(NoticiaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionNoticiaAdmin(NoticiaAdminResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta los Noticias de la base 
        /// </summary>
        private List<NoticiaEntity> ConsultarNoticias()
        {
            NoticiaAdminBO bo = new NoticiaAdminBO();
            List<string> messages = new List<string>();
            List<NoticiaEntity> response = new List<NoticiaEntity>();

            try
            {
                response = bo.getNoticias();
            }
            catch (ValidationAndMessageException NoticiaAdminException)
            {
                messages.Add(NoticiaAdminException.Message);
                ThrowHandledExceptionNoticiaAdmin(NoticiaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionNoticiaAdmin(NoticiaAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar Noticia
        /// </summary>
        private bool ModificarNoticia(int noticiaID, string titulo, string contenido, string imagen,string fechaInicio,string fechaFin)
        {
            NoticiaAdminBO bo = new NoticiaAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifyNoticia(noticiaID, titulo, contenido, imagen,fechaInicio,fechaFin);
            }
            catch (ValidationAndMessageException NoticiaAdminException)
            {
                messages.Add(NoticiaAdminException.Message);
                ThrowHandledExceptionNoticiaAdmin(NoticiaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionNoticiaAdmin(NoticiaAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Consultar Noticia
        /// </summary>
        private NoticiaEntity DetalleNoticia(int noticiaID)
        {
            NoticiaAdminBO bo = new NoticiaAdminBO();
            List<string> messages = new List<string>();
            NoticiaEntity response = new NoticiaEntity();

            try
            {
                response = bo.consultarNoticia(noticiaID);
            }
            catch (ValidationAndMessageException NoticiaAdminException)
            {
                messages.Add(NoticiaAdminException.Message);
                ThrowHandledExceptionNoticiaAdmin(NoticiaAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionNoticiaAdmin(NoticiaAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// CRUD de Noticias para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public CRUDNoticiaAdminDataResponse Post(CRUDNoticiaAdminDataRequest dataRequest)
        {
            CRUDNoticiaAdminDataResponse response = new CRUDNoticiaAdminDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;               

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de membresias
                if (dataRequest.flujoID == 0)
                {
                    List<NoticiaAdminModel> model = new List<NoticiaAdminModel>();
                    List<NoticiaEntity> items = ConsultarNoticias();

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.NoticiaEntityToModel(items);
                        response.ResponseCode = NoticiaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = NoticiaAdminResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarNuevaNoticia(dataRequest.titulo, dataRequest.contenido,dataRequest.imagen, dataRequest.fechaInicio, dataRequest.fechaFin);

                    if (resp)
                    {
                        response.ResponseCode = NoticiaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = NoticiaAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarNoticia(dataRequest.noticiaID, dataRequest.titulo, dataRequest.contenido,dataRequest.imagen, dataRequest.fechaInicio, dataRequest.fechaFin);

                    if (resp)
                    {
                        response.ResponseCode = NoticiaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = NoticiaAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }  
                //Detalle de persona
                else if (dataRequest.flujoID == 3)
                {
                    NoticiaEntity resp = new NoticiaEntity();
                    NoticiaAdminModel model = new NoticiaAdminModel();

                    resp = DetalleNoticia(dataRequest.noticiaID);

                    if (resp.noticiaID > 0)
                    {
                        model = EntitesHelper.NoticiaInfoEntityToModel(resp);
                        response.ResponseCode = NoticiaAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = NoticiaAdminResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

            }
            catch (NoticiaAdminException NoticiaAdminException)
            {
                SetResponseAsExceptionNoticiaAdmin(NoticiaAdminException.Type, response, NoticiaAdminException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar CRUDNoticiaAdmin.";
                SetResponseAsExceptionNoticiaAdmin(NoticiaAdminResponseType.Error, response, message);
            }

            return response;
        }
    }
}