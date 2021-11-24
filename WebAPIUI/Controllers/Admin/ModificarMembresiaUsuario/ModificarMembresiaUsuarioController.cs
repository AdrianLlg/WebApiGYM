using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers.ModificarMembresiaUsuario.Models;
using WebAPIUI.Models;
using WebAPIUI.Helpers;
using WebAPIUI.Models.Membresias;
using WebAPIUI.CustomExceptions.MembresiasUsuario;

namespace WebAPIUI.Controllers
{
    public class ModificarMembresiaUsuarioController : BaseAPIController
    {
        private void ValidatePostRequest(ModificarMembresiaUsuarioDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionModificarMembresiaUsuario(ModificarMembresiaUsuarioResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Actualiza la membresia de la persona
        /// </summary>
        private bool UpdateRow(int membresia_persona_pagoID, string fechaInicioMembresia, string fechaFinMembresia, string Banco, string fechaPago, string formaPago, string nroDocumento)
        {
            MembresiaBO bo = new MembresiaBO();
            List<string> messages = new List<string>();
            bool resp = false;

            try
            {
                resp = bo.updateUserMembership(membresia_persona_pagoID, fechaInicioMembresia, fechaFinMembresia, Banco, fechaPago, formaPago, nroDocumento);
            }
            catch (ValidationAndMessageException ConsultaRepositorioImagenesException)
            {
                messages.Add(ConsultaRepositorioImagenesException.Message);
                ThrowHandledExceptionModificarMembresiaUsuario(ModificarMembresiaUsuarioResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionModificarMembresiaUsuario(ModificarMembresiaUsuarioResponseType.Error, ex);
            }

            return resp;
        }

        /// <summary>
        /// Actualiza la información de la membresía(s) según el usuario.
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ModificarMembresiaUsuarioDataResponse Post(ModificarMembresiaUsuarioDataRequest dataRequest)
        {
            ModificarMembresiaUsuarioDataResponse response = new ModificarMembresiaUsuarioDataResponse();

            try
            {
                List<MembresiasModel> resp = new List<MembresiasModel>();
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                bool updateRowResp = UpdateRow(dataRequest.membresia_persona_pagoID, dataRequest.fechaInicioMembresia, dataRequest.fechaFinMembresia, dataRequest.Banco, dataRequest.fechaPago, dataRequest.formaPago, dataRequest.nroDocumento);

                if (updateRowResp)
                {
                    response.ResponseCode = ModificarMembresiaUsuarioResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.Content = updateRowResp;
                }
                else
                {
                    response.ResponseCode = ModificarMembresiaUsuarioResponseType.Error;
                    response.ResponseMessage = "Ocurrió un error al modificar el registro.";
                    response.Content = false;
                }

            }
            catch (ModificarMembresiaUsuarioException ModificarMembresiaUsuarioException)
            {
                SetResponseAsExceptionModificarMembresiaUsuario(ModificarMembresiaUsuarioException.Type, response, ModificarMembresiaUsuarioException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ModificarMembresiaUsuario.";
                SetResponseAsExceptionModificarMembresiaUsuario(ModificarMembresiaUsuarioResponseType.Error, response, message);
            }

            return response;
        }
    }
}