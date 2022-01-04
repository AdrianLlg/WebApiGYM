using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.BusinessCore.App;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers.App.EnviarMailValidacion.Models;
using WebAPIUI.CustomExceptions.App.EnviarMailValidacion;

namespace WebAPIUI.Controllers.App.EnviarMailValidacion
{
    public class EnviarMailValidacionController : BaseAPIController
    {
        private void ValidatePostRequest(EnviarMailValidacionDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionEnviarMailValidacion(EnviarMailValidacionResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Modificar password del usuario.
        /// </summary>
        private string SendMail(string mail)
        {
            PersonaUsuarioBO bo = new PersonaUsuarioBO();
            List<string> messages = new List<string>();
            string resp = string.Empty;

            try
            {
                resp = bo.sendMail(mail);
            }
            catch (ValidationAndMessageException EnviarMailValidacionException)
            {
                messages.Add(EnviarMailValidacionException.Message);
                ThrowHandledExceptionEnviarMailValidacion(EnviarMailValidacionResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionEnviarMailValidacion(EnviarMailValidacionResponseType.Error, ex);
            }

            return resp;
        }


        /// <summary>
        /// Modificar informacion personal del usuario
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public EnviarMailValidacionDataResponse Post(EnviarMailValidacionDataRequest dataRequest)
        {
            EnviarMailValidacionDataResponse response = new EnviarMailValidacionDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                string resp = SendMail(dataRequest.mail);

                if (!string.IsNullOrEmpty(resp))
                {
                    response.ResponseCode = EnviarMailValidacionResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.Content = resp;
                }
                else
                {
                    response.ResponseCode = EnviarMailValidacionResponseType.Error;
                    response.ResponseMessage = "Error en la ejecución";
                    response.Content = null;
                }

            }
            catch (EnviarMailValidacionException EnviarMailValidacionException)
            {
                SetResponseAsExceptionEnviarMailValidacion(EnviarMailValidacionException.Type, response, EnviarMailValidacionException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar EnviarMailValidacion.";
                SetResponseAsExceptionEnviarMailValidacion(EnviarMailValidacionResponseType.Error, response, message);
            }

            return response;
        }
    }
}