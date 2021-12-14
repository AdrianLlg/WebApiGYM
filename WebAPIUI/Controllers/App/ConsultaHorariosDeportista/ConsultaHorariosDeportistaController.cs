using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.BusinessCore.App;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.App.ConsultaEventosDeportista;
using WebAPIBusiness.Entities.EventoAdmin;
using WebAPIUI.Controllers.App.ConsultaHorariosDeportista.Models;
using WebAPIUI.CustomExceptions.App.ConsultaHorariosDeportista;

namespace WebAPIUI.Controllers.App.ConsultaHorariosDeportista
{
    public class ConsultaHorariosDeportistaController : BaseAPIController
    {
        private void ValidatePostRequest(ConsultaHorariosDeportistaDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionConsultaHorariosDeportista(ConsultaHorariosDeportistaResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Obtiene los horarios disponibles en el dia especificado
        /// </summary>
        private List<EventosDeportistaEntity> ObtenerHorarios(int personaID, string fecha) 
        { 
            EventoAdminBO bo = new EventoAdminBO();
            List<string> messages = new List<string>();
            List<EventosDeportistaEntity> resp = new List<EventosDeportistaEntity>();

            try
            {
                resp = bo.getSchedules(personaID, fecha);
            }
            catch (ValidationAndMessageException ConsultaHorariosDeportistaException)
            {
                messages.Add(ConsultaHorariosDeportistaException.Message);
                ThrowHandledExceptionConsultaHorariosDeportista(ConsultaHorariosDeportistaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionConsultaHorariosDeportista(ConsultaHorariosDeportistaResponseType.Error, ex);
            }

            return resp;
        }



        /// <summary>
        /// Consulta los horarios disponibles para la fecha especificada
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ConsultaHorariosDeportistaDataResponse Post(ConsultaHorariosDeportistaDataRequest dataRequest)
        {
            ConsultaHorariosDeportistaDataResponse response = new ConsultaHorariosDeportistaDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                List<EventosDeportistaEntity> resp = ObtenerHorarios(dataRequest.personaID, dataRequest.fecha);

                if (resp.Count > 0)
                {
                    response.ResponseCode = ConsultaHorariosDeportistaResponseType.Ok;
                    response.ResponseMessage = "Método ejecutado con éxito.";
                    response.Content = resp;
                }
                else
                {
                    response.ResponseCode = ConsultaHorariosDeportistaResponseType.Error;
                    response.ResponseMessage = "Error en la ejecución";
                    response.Content = null;
                }

            }
            catch (ConsultaHorariosDeportistaException ConsultaHorariosDeportistaException)
            {
                SetResponseAsExceptionConsultaHorariosDeportista(ConsultaHorariosDeportistaException.Type, response, ConsultaHorariosDeportistaException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar ConsultaHorariosDeportista.";
                SetResponseAsExceptionConsultaHorariosDeportista(ConsultaHorariosDeportistaResponseType.Error, response, message);
            }

            return response;
        }
    }
}