using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers.Login.Models;
using WebAPIUI.CustomExceptions.Login;
using WebAPIUI.Models.Login;
using WebAPIBusiness.Entities.Login;

namespace WebAPIUI.Controllers
{
    public class LoginController : BaseAPIController
    {
        private void ValidatePostRequest(LoginDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionLogin(LoginResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Buscar persona en la DB
        /// </summary>
        private UsuarioEntity searchUser(string email, string password)
        {
            LoginBO bo = new LoginBO();
            List<string> messages = new List<string>();
            UsuarioEntity user = new UsuarioEntity();

            try
            {
                user = bo.searchUser( email, password);
            }
            catch (ValidationAndMessageException ConsultaRepositorioImagenesException)
            {
                messages.Add(ConsultaRepositorioImagenesException.Message);
                ThrowHandledExceptionLogin(LoginResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionLogin(LoginResponseType.Error, ex);
            }

            return user;
        }

        /// <summary>
        /// Insertar un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public LoginDataResponse Post(LoginDataRequest dataRequest)
        {
            LoginDataResponse response = new LoginDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                UsuarioEntity user = searchUser(dataRequest.email,dataRequest.password);

                if (user != null)
                {
                    response.ResponseCode = LoginResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.Content = user;
                }
                else
                {
                    response.ResponseCode = LoginResponseType.Ok;
                    response.ResponseMessage = "Error en la ejecución";
                    response.Content = null;
                }

            }
            catch (LoginException LoginException)
            {
                SetResponseAsExceptionLogin(LoginException.Type, response, LoginException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar RegistrarPersona.";
                SetResponseAsExceptionLogin(LoginResponseType.Error, response, message);
            }

            return response;
        }
    }
}