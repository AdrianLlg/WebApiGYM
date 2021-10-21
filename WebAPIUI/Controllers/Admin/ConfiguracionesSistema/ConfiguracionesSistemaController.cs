using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.ConfiguracionesSistemaAdmin;
using WebAPIUI.Controllers.ConfiguracionesSistema.Models;
using WebAPIUI.CustomExceptions.ConfiguracionesSistema;
using WebAPIUI.CustomExceptions.MembresiasAdmin;
using WebAPIUI.Helpers;
using WebAPIUI.Models.ConfiguracionesSistema;

namespace WebAPIUI.Controllers
{
    public class ConfiguracionesSistemaController : BaseAPIController
    {
        private void ValidatePostRequest(ConfiguracionesSistemaDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionConfiguracionesSistema(ConfiguracionesSistemaResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Consulta las configuraciones
        /// </summary>
        private List<ConfiguracionesAdminEntity> ConsultaConfiguracion(string tipoConfiguracion)
        {
            ConfiguracionesAdminBO bo = new ConfiguracionesAdminBO();
            List<string> messages = new List<string>();
            List<ConfiguracionesAdminEntity> entities = new List<ConfiguracionesAdminEntity>();

            try
            {
                entities = bo.getConfigurations(tipoConfiguracion);
            }
            catch (ValidationAndMessageException ConfiguracionesSistemaException)
            {
                messages.Add(ConfiguracionesSistemaException.Message);
                ThrowHandledExceptionConfiguracionesSistema(ConfiguracionesSistemaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionConfiguracionesSistema(ConfiguracionesSistemaResponseType.Error, ex);
            }

            return entities;
        }

        /// <summary>
        /// Consulta la configuración pasada por parámetro
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ConfiguracionesSistemaDataResponse Post(ConfiguracionesSistemaDataRequest dataRequest)
        {
            ConfiguracionesSistemaDataResponse response = new ConfiguracionesSistemaDataResponse();

            try
            {
                List<ConfiguracionesSistemaModel> model = new List<ConfiguracionesSistemaModel>();
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                List<ConfiguracionesAdminEntity> entities = ConsultaConfiguracion(dataRequest.tipoConfiguracion);

                if (entities.Count > 0)
                {
                    model = EntitesHelper.EntityToModelConfiguracionesSistema(entities);
                    response.ResponseCode = ConfiguracionesSistemaResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.Content = model;
                }
                else
                {
                    response.ResponseCode = ConfiguracionesSistemaResponseType.Ok;
                    response.ResponseMessage = "No existen registros.";
                    response.Content = null;
                }

            }
            catch (ConfiguracionesSistemaException ConfiguracionesSistemaException)
            {
                SetResponseAsExceptionConfiguracionesSistema(ConfiguracionesSistemaException.Type, response, ConfiguracionesSistemaException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ConfiguracionesSistema.";
                SetResponseAsExceptionConfiguracionesSistema(ConfiguracionesSistemaResponseType.Error, response, message);
            }

            return response;
        }
    }
}