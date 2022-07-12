using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.BusinessCore.App;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers.App.ModificacionDatosPersonales.Models;
using WebAPIUI.CustomExceptions.App.ModificacionDatosPersonales;

namespace WebAPIUI.Controllers.App.ModificacionDatosPersonales
{
    public class ModificacionDatosPersonalesController : BaseAPIController
    {
        private void ValidatePostRequest(ModificacionDatosPersonalesDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionModificacionDatosPersonales(ModificacionDatosPersonalesResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Modificar password del usuario.
        /// </summary>
        private bool ModificarPassword(int personaID, string newPassword)
        {
            PersonaUsuarioBO bo = new PersonaUsuarioBO();
            List<string> messages = new List<string>();
            bool resp = false;

            try
            {
                resp = bo.modifyUser(personaID, newPassword);
            }
            catch (ValidationAndMessageException ModificacionDatosPersonalesException)
            {
                messages.Add(ModificacionDatosPersonalesException.Message);
                ThrowHandledExceptionModificacionDatosPersonales(ModificacionDatosPersonalesResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionModificacionDatosPersonales(ModificacionDatosPersonalesResponseType.Error, ex);
            }

            return resp;
        }


        /// <summary>
        /// Modificar informacion del usuario
        /// </summary>
        private bool ModificarInfo(int personaID, string nombres, string apellidos, string telefono, string email, string fechaNacimiento)
        {
            PersonaUsuarioBO bo = new PersonaUsuarioBO();
            List<string> messages = new List<string>();
            bool resp = false;

            try
            {
                resp = bo.UpdateUserInfo(personaID, nombres, apellidos, telefono, email, fechaNacimiento);
            }
            catch (ValidationAndMessageException ModificacionDatosPersonalesException)
            {
                messages.Add(ModificacionDatosPersonalesException.Message);
                ThrowHandledExceptionModificacionDatosPersonales(ModificacionDatosPersonalesResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionModificacionDatosPersonales(ModificacionDatosPersonalesResponseType.Error, ex);
            }

            return resp;
        }


        /// <summary>
        /// Modificar informacion personal del usuario
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ModificacionDatosPersonalesDataResponse Post(ModificacionDatosPersonalesDataRequest dataRequest)
        {
            ModificacionDatosPersonalesDataResponse response = new ModificacionDatosPersonalesDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                //Flujo para modificar la contraseña
                if (dataRequest.flujoID == 0)
                {
                    bool resp = ModificarPassword(dataRequest.personaID, dataRequest.newPassword);

                    if (resp)
                    {
                        response.ResponseCode = ModificacionDatosPersonalesResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentPassword = true;
                    }
                    else
                    {
                        response.ResponseCode = ModificacionDatosPersonalesResponseType.Error;
                        response.ResponseMessage = "Error en la ejecución";
                        response.ContentPassword = false;
                    }
                }
                //Flujo para modificar la información personal
                else
                {
                    bool resp = ModificarInfo(dataRequest.personaID, dataRequest.nombres, dataRequest.apellidos, dataRequest.telefono, dataRequest.email, dataRequest.fechaNacimiento);

                    if (resp)
                    {
                        response.ResponseCode = ModificacionDatosPersonalesResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentPersonalInfo = true;
                    }
                    else
                    {
                        response.ResponseCode = ModificacionDatosPersonalesResponseType.Error;
                        response.ResponseMessage = "Error en la ejecución";
                        response.ContentPersonalInfo = false;
                    }
                }               

            }
            catch (ModificacionDatosPersonalesException ModificacionDatosPersonalesException)
            {
                SetResponseAsExceptionModificacionDatosPersonales(ModificacionDatosPersonalesException.Type, response, ModificacionDatosPersonalesException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ModificacionDatosPersonales.";
                SetResponseAsExceptionModificacionDatosPersonales(ModificacionDatosPersonalesResponseType.Error, response, message);
            }

            return response;
        }
    }
}