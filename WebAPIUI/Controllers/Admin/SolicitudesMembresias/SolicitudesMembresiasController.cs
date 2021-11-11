using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers.SolicitudesMembresias.Models;
using WebAPIUI.CustomExceptions.SolicitudesMembresias;
using WebAPIUI.CustomExceptions.MembresiasAdmin;
using WebAPIUI.Helpers;
using WebAPIUI.Models.SolicitudesMembresias;
using WebAPIBusiness.Entities.SolicitudesMembresias;

namespace WebAPIUI.Controllers
{
    public class SolicitudesMembresiasController : BaseAPIController
    {
        private void ValidatePostRequest(SolicitudesMembresiasDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionSolicitudesMembresias(SolicitudesMembresiasResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Consulta las Solicitudes de Membresias
        /// </summary>
        private List<SolicitudesMembresiasEntity> ConsultaSolicitudesMembresias()
        {
            SolicitudesMembresiasBO bo = new SolicitudesMembresiasBO();
            List<string> messages = new List<string>();
            List<SolicitudesMembresiasEntity> entities = new List<SolicitudesMembresiasEntity>();

            try
            {
                entities = bo.getMembershipRequests();
            }
            catch (ValidationAndMessageException SolicitudesMembresiasException)
            {
                messages.Add(SolicitudesMembresiasException.Message);
                ThrowHandledExceptionSolicitudesMembresias(SolicitudesMembresiasResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionSolicitudesMembresias(SolicitudesMembresiasResponseType.Error, ex);
            }

            return entities;
        }

        /// <summary>
        /// Consulta las Solicitudes de Membresias en el sistema
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public SolicitudesMembresiasDataResponse Post(SolicitudesMembresiasDataRequest dataRequest)
        {
            SolicitudesMembresiasDataResponse response = new SolicitudesMembresiasDataResponse();

            try
            {
                List<SolicitudesMembresiasModel> model = new List<SolicitudesMembresiasModel>();
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);


                if (dataRequest.flujoID == 0)
                {
                    List<SolicitudesMembresiasEntity> entities = ConsultaSolicitudesMembresias();

                    if (entities.Count > 0)
                    {
                        model = EntitesHelper.EntityToModelSolicitudesMembresias(entities);

                        response.ResponseCode = SolicitudesMembresiasResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.Content = model;
                    }
                    else
                    {
                        response.ResponseCode = SolicitudesMembresiasResponseType.Ok;
                        response.ResponseMessage = "No existen registros.";
                        response.Content = null;
                    }
                }
            }
            catch (SolicitudesMembresiasException SolicitudesMembresiasException)
            {
                SetResponseAsExceptionSolicitudesMembresias(SolicitudesMembresiasException.Type, response, SolicitudesMembresiasException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar SolicitudesMembresias.";
                SetResponseAsExceptionSolicitudesMembresias(SolicitudesMembresiasResponseType.Error, response, message);
            }

            return response;
        }
    }
}