using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers.HorasDisciplina.Models;
using WebAPIUI.CustomExceptions.HorasDisciplina;
using WebAPIBusiness.Entities.HorasDisciplina;

namespace WebAPIUI.Controllers
{
    public class HorasDisciplinaController : BaseAPIController
    {
        private void ValidatePostRequest(HorasDisciplinaDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionHorasDisciplina(HorasDisciplinaResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Busca las HorasDisciplinas de esa persona
        /// </summary>
        private List<HorasDisciplinaEntity> HorasDisciplina(string personaID)
        {
            HorasDisciplinaBO bo = new HorasDisciplinaBO();
            List<string> messages = new List<string>();
            List<HorasDisciplinaEntity> HorasDisciplinas = new List<HorasDisciplinaEntity>();

            try
            {
                HorasDisciplinas = bo.horasDisciplina(personaID);
            }
            catch (ValidationAndMessageException ConsultaRepositorioImagenesException)
            {
                messages.Add(ConsultaRepositorioImagenesException.Message);
                ThrowHandledExceptionHorasDisciplina(HorasDisciplinaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionHorasDisciplina(HorasDisciplinaResponseType.Error, ex);
            }

            return HorasDisciplinas;
        }

        /// <summary>
        /// Insertar un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public HorasDisciplinaDataResponse Post(HorasDisciplinaDataRequest dataRequest)
        {
            HorasDisciplinaDataResponse response = new HorasDisciplinaDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                List<HorasDisciplinaEntity> HorasDisciplinas = HorasDisciplina(dataRequest.disciplinaID);



                response.ResponseCode = HorasDisciplinaResponseType.Ok;
                response.ResponseMessage = "Método ejecutado con éxito.";
                response.Content = HorasDisciplinas;


            }
            catch (HorasDisciplinaException HorasDisciplinaException)
            {
                SetResponseAsExceptionHorasDisciplina(HorasDisciplinaException.Type, response, HorasDisciplinaException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar RegistrarPersona.";
                SetResponseAsExceptionHorasDisciplina(HorasDisciplinaResponseType.Error, response, message);
            }

            return response;
        }
    }
}