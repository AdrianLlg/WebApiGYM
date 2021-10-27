using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.CustomExceptions.MembresiasUsuario;
using WebAPIBusiness.Entities.Membresia;
using WebAPIUI.Helpers;
using WebAPIUI.Models.Membresias;
using WebAPIUI.Controllers.RegistroMembresiaUsuario.Models;
using WebAPIBusiness.Entities.MembresiaAdmin;
using WebAPIUI.Models.MembresiasAdmin;
using WebAPIUI.CustomExceptions.MembresiasAdmin;

namespace WebAPIUI.Controllers
{
    public class RegistroMembresiaUsuarioController : BaseAPIController
    {
        private void ValidatePostRequest(RegistroMembresiaUsuarioDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionRegistroMembresiaUsuario(RegistroMembresiaUsuarioResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Inserta la membresias ligada a la persona
        /// </summary>
        private bool membresiaUser(int personaID, int membresiaID)
        {
            MembresiaAdminBO bo = new MembresiaAdminBO();
            List<string> messages = new List<string>();
            bool membresias = false;

            try
            {
                membresias = bo.insertNewMembership(personaID, membresiaID);
            }
            catch (ValidationAndMessageException RegistroMembresiaUsuarioException)
            {
                messages.Add(RegistroMembresiaUsuarioException.Message);
                ThrowHandledExceptionRegistroMembresiaUsuario(RegistroMembresiaUsuarioResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionRegistroMembresiaUsuario(RegistroMembresiaUsuarioResponseType.Error, ex);
            }

            return membresias;
        }

        /// <summary>
        /// Insertar un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public RegistroMembresiaUsuarioDataResponse Post(RegistroMembresiaUsuarioDataRequest dataRequest)
        {
            RegistroMembresiaUsuarioDataResponse response = new RegistroMembresiaUsuarioDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                bool membresia = membresiaUser(dataRequest.personaID, dataRequest.membresiaID);

                if (membresia)
                {
                    response.ResponseCode = RegistroMembresiaUsuarioResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.Content = true;
                }
                else
                {
                    response.ResponseCode = RegistroMembresiaUsuarioResponseType.Ok;
                    response.ResponseMessage = "No existen registros.";
                    response.Content = false;
                }

            }
            catch (RegistroMembresiaUsuarioException RegistroMembresiaUsuarioException)
            {
                SetResponseAsExceptionRegistroMembresiaUsuario(RegistroMembresiaUsuarioException.Type, response, RegistroMembresiaUsuarioException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar RegistrarPersona.";
                SetResponseAsExceptionRegistroMembresiaUsuario(RegistroMembresiaUsuarioResponseType.Error, response, message);
            }

            return response;
        }
    }
}