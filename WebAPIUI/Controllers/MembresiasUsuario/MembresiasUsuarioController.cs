using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers.MembresiasUsuario.Models;
using WebAPIUI.CustomExceptions.MembresiasUsuario;
using WebAPIBusiness.Entities.Membresia;

namespace WebAPIUI.Controllers
{
    public class MembresiasUsuarioController : BaseAPIController
    {
        private void ValidatePostRequest(MembresiasUsuarioDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionMembresiasUsuario(MembresiasUsuarioResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Busca las membresias de esa persona
        /// </summary>
        private List<MembresiaEntity> membresiaUser(string personaID)
        {
            MembresiaBO bo = new MembresiaBO();
            List<string> messages = new List<string>();
            List<MembresiaEntity> membresias = new List<MembresiaEntity>();

            try
            {
                membresias = bo.membresiasUser(personaID);
            }
            catch (ValidationAndMessageException ConsultaRepositorioImagenesException)
            {
                messages.Add(ConsultaRepositorioImagenesException.Message);
                ThrowHandledExceptionMembresiasUsuario(MembresiasUsuarioResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionMembresiasUsuario(MembresiasUsuarioResponseType.Error, ex);
            }

            return membresias;
        }

        /// <summary>
        /// Insertar un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public MembresiasUsuarioDataResponse Post(MembresiasUsuarioDataRequest dataRequest)
        {
            MembresiasUsuarioDataResponse response = new MembresiasUsuarioDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                List<MembresiaEntity> membresias = membresiaUser(dataRequest.personaID);



                response.ResponseCode = MembresiasUsuarioResponseType.Ok;
                response.ResponseMessage = "Método ejecutado con éxito.";
                response.Content = membresias;


            }
            catch (MembresiasUsuarioException MembresiasUsuarioException)
            {
                SetResponseAsExceptionMembresiasUsuario(MembresiasUsuarioException.Type, response, MembresiasUsuarioException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar RegistrarPersona.";
                SetResponseAsExceptionMembresiasUsuario(MembresiasUsuarioResponseType.Error, response, message);
            }

            return response;
        }
    }
}