using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers.Login.Models;
using WebAPIUI.CustomExceptions.RegisterPerson;
using WebAPIUI.Models.Login;

namespace WebAPIUI.Controllers
{
    public class LoginController : BaseAPIController
    {
        private void ValidatePostRequest(RegisterPersonDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.nombres))
            //{
            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }

        /// <summary>
        /// Insertar una nueva persona en la tabla
        /// </summary>
        private bool InsertarNuevaPersona(string rol, string nombre, string apellido, string identificacion, string email, string telefono, string edad, string sexo, string fechanacimiento)
        {
            LoginBO bo = new LoginBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertUser(rol, nombre, apellido, identificacion, email, telefono, edad, sexo, fechanacimiento);
            }
            catch (ValidationAndMessageException ConsultaRepositorioImagenesException)
            {
                messages.Add(ConsultaRepositorioImagenesException.Message);
                ThrowHandledException(RegisterPersonResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledException(RegisterPersonResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Insertar un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public RegisterPersonDataResponse Post(RegisterPersonDataRequest dataRequest)
        {
            RegisterPersonDataResponse response = new RegisterPersonDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                bool resp = InsertarNuevaPersona(dataRequest.rolePID, dataRequest.nombres, dataRequest.apellidos, dataRequest.identificacion, dataRequest.email, dataRequest.telefono, dataRequest.edad, dataRequest.sexo, dataRequest.fechaNacimiento);

                if (resp)
                {
                    response.ResponseCode = RegisterPersonResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.Content = true;
                }
                else
                {
                    response.ResponseCode = RegisterPersonResponseType.InvalidParameters;
                    response.ResponseMessage = "Fallo en la ejecución.";
                    response.Content = false;
                }

            }
            catch (RegisterPersonException RegisterPersonException)
            {
                SetResponseAsException(RegisterPersonException.Type, response, RegisterPersonException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar RegistrarPersona.";
                SetResponseAsException(RegisterPersonResponseType.Error, response, message);
            }

            return response;
        }
    }
}