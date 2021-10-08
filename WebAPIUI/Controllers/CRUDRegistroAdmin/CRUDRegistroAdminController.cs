using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.RegistroAdmin;
using WebAPIUI.Controllers.CRUDRegistroAdmin.Models;
using WebAPIUI.CustomExceptions.RegisterPerson;
using WebAPIUI.CustomExceptions.RegistroAdmin;
using WebAPIUI.Models.Login;

namespace WebAPIUI.Controllers
{
    public class CRUDRegistroAdminController : BaseAPIController
    {
        private void ValidatePostRequest(CRUDRegistroAdminDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionRegistro(RegistroAdminResponseType.InvalidParameters, messages);
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
        private bool InsertarNuevaPersona(string rolePID, string nombres, string apellidos, string identificacion, string email,  string telefono, string sexo, string fechaNacimiento)
        {
            RegistroAdminBO bo = new RegistroAdminBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertUser(rolePID, nombres, apellidos, identificacion, email, telefono, sexo, fechaNacimiento);
            }
            catch (ValidationAndMessageException RegistroAdminException)
            {
                messages.Add(RegistroAdminException.Message);
                ThrowHandledExceptionRegistro(RegistroAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionRegistro(RegistroAdminResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta las personas de la base 
        /// </summary>
        private List<UsuariosRegistradosEntity> ConsultarPersonas()
        {
            RegistroAdminBO bo = new RegistroAdminBO();
            List<string> messages = new List<string>();
            List<UsuariosRegistradosEntity> response = new List<UsuariosRegistradosEntity>();

            try
            {
                response = bo.getUserPersons();
            }
            catch (ValidationAndMessageException RegistroAdminException)
            {
                messages.Add(RegistroAdminException.Message);
                ThrowHandledExceptionRegistro(RegistroAdminResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionRegistro(RegistroAdminResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// CRUD para el Admin para Registro Personas
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public RegistroAdminDataResponse Post(CRUDRegistroAdminDataRequest dataRequest)
        {
            RegistroAdminDataResponse response = new RegistroAdminDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                if (dataRequest.flujoID == 1)
                {
                    List<UsuariosRegistradosEntity> items = ConsultarPersonas();

                    if (items.Count > 0)
                    {
                        response.ResponseCode = RegistroAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = items;
                    }
                    else
                    {
                        response.ResponseCode = RegistroAdminResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = InsertarNuevaPersona(dataRequest.rolePID, dataRequest.nombres, dataRequest.apellidos, dataRequest.identificacion, dataRequest.email, dataRequest.telefono, dataRequest.sexo, dataRequest.fechaNacimiento);

                    if (resp)
                    {
                        response.ResponseCode = RegistroAdminResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = RegistroAdminResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }

               

            }
            catch (RegistroAdminException RegistroAdminException)
            {
                SetResponseAsExceptionRegistro(RegistroAdminException.Type, response, RegistroAdminException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar RegistrarPersona.";
                SetResponseAsExceptionRegistro(RegistroAdminResponseType.Error, response, message);
            }

            return response;
        }
    }
}