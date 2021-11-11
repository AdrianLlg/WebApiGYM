using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers.RenovacionMembresiaUsuario.Models;
using WebAPIUI.CustomExceptions.MembresiasAdmin;

namespace WebAPIUI.Controllers
{
    public class RenovacionMembresiaUsuarioController : BaseAPIController
    {
        private void ValidatePostRequest(RenovacionMembresiaUsuarioDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                //ThrowHandledExceptionRenovacionMembresiaUsuario(RenovacionMembresiaUsuarioResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Registra la solicitud para aprobación de membresía
        /// </summary>
        private bool membresiaUser(int personaID, int membresiaID, string imagen)
        {
            MembresiaAdminBO bo = new MembresiaAdminBO();
            List<string> messages = new List<string>();
            bool membresias = false;

            try
            {
                membresias = bo.insertPendingMembership(personaID, membresiaID, imagen);
            }
            catch (ValidationAndMessageException RenovacionMembresiaUsuarioException)
            {
                messages.Add(RenovacionMembresiaUsuarioException.Message);
                //ThrowHandledExceptionRenovacionMembresiaUsuario(RenovacionMembresiaUsuarioResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                //ThrowUnHandledExceptionRenovacionMembresiaUsuario(RenovacionMembresiaUsuarioResponseType.Error, ex);
            }

            return membresias;
        }

        /// <summary>
        /// Inserta una nueva solicitud de aceptación membresía
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public RenovacionMembresiaUsuarioDataResponse Post(RenovacionMembresiaUsuarioDataRequest dataRequest)
        {
            RenovacionMembresiaUsuarioDataResponse response = new RenovacionMembresiaUsuarioDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                bool membresia = membresiaUser(dataRequest.personaID, dataRequest.membresiaID, dataRequest.imagen);

                if (membresia)
                {
                    response.ResponseCode = RenovacionMembresiaUsuarioResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.Content = true;
                }
                else
                {
                    response.ResponseCode = RenovacionMembresiaUsuarioResponseType.Ok;
                    response.ResponseMessage = "No existen registros.";
                    response.Content = false;
                }

            }
            catch (RenovacionMembresiaUsuarioException RenovacionMembresiaUsuarioException)
            {
                //SetResponseAsExceptionRenovacionMembresiaUsuario(RenovacionMembresiaUsuarioException.Type, response, RenovacionMembresiaUsuarioException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar RenovacionMembresiaUsuario.";
                //SetResponseAsExceptionRenovacionMembresiaUsuario(RenovacionMembresiaUsuarioResponseType.Error, response, message);
            }

            return response;
        }
    }
}