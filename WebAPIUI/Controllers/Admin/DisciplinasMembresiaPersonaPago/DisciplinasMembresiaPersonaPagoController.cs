using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.DisciplinasMembresiaPersonaPago;
using WebAPIUI.Controllers.ConfiguracionesSistema.Models;
using WebAPIUI.Controllers.DisciplinasMembresiaPersonaPago.Models;
using WebAPIUI.CustomExceptions.DisciplinasMembresiaPersonaPago;
using WebAPIUI.Helpers;
using WebAPIUI.Models.DisciplinasMembresiaPersonaPago;

namespace WebAPIUI.Controllers
{
    public class DisciplinasMembresiaPersonaPagoController : BaseAPIController
    {
        private void ValidatePostRequest(DisciplinasMembresiaPersonaPagoDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionDisciplinasMembresiaPersonaPago(DisciplinasMembresiaPersonaPagoResponseType.InvalidParameters, messages);
            }
        }

        /// <summary>
        /// Consulta las configuraciones
        /// </summary>
        private List<DisciplinasMembresiaPersonaPagoEntity> ConsultaDisciplinas(int membresia_persona_pagoID)
        {
            DisciplinasMembresiaPersonaPagoBO bo = new DisciplinasMembresiaPersonaPagoBO();
            List<string> messages = new List<string>();
            List<DisciplinasMembresiaPersonaPagoEntity> entities = new List<DisciplinasMembresiaPersonaPagoEntity>();

            try
            {
                entities = bo.getDisciplinesInfo(membresia_persona_pagoID);
            }
            catch (ValidationAndMessageException DisciplinasMembresiaPersonaPagoException)
            {
                messages.Add(DisciplinasMembresiaPersonaPagoException.Message);
                ThrowHandledExceptionDisciplinasMembresiaPersonaPago(DisciplinasMembresiaPersonaPagoResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionDisciplinasMembresiaPersonaPago(DisciplinasMembresiaPersonaPagoResponseType.Error, ex);
            }

            return entities;
        }

        private bool EditarClasesTomadas(int membresia_persona_disciplinaID, int numClasesDisponibles)
        {
            DisciplinasMembresiaPersonaPagoBO bo = new DisciplinasMembresiaPersonaPagoBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifyDisciplinesInfo(membresia_persona_disciplinaID, numClasesDisponibles);
            }
            catch (ValidationAndMessageException DisciplinasMembresiaPersonaPagoException)
            {
                messages.Add(DisciplinasMembresiaPersonaPagoException.Message);
                ThrowHandledExceptionDisciplinasMembresiaPersonaPago(DisciplinasMembresiaPersonaPagoResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionDisciplinasMembresiaPersonaPago(DisciplinasMembresiaPersonaPagoResponseType.Error, ex);
            }

            return response;
        }



        /// <summary>
        /// Flujo que muestra y permite modificar la información de membresiaPersonaDisciplina
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public DisciplinasMembresiaPersonaPagoDataResponse Post(DisciplinasMembresiaPersonaPagoDataRequest dataRequest)
        {
            DisciplinasMembresiaPersonaPagoDataResponse response = new DisciplinasMembresiaPersonaPagoDataResponse();

            try
            {
                List<DisciplinasMembresiaPersonaPagoModel> model = new List<DisciplinasMembresiaPersonaPagoModel>();
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);


                if (dataRequest.flujoID == 0)
                {
                    List<DisciplinasMembresiaPersonaPagoEntity> entities = ConsultaDisciplinas(dataRequest.membresia_persona_pagoID);

                    if (entities.Count > 0)
                    {
                        response.ResponseCode = DisciplinasMembresiaPersonaPagoResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.Content = entities;
                    }
                    else
                    {
                        response.ResponseCode = DisciplinasMembresiaPersonaPagoResponseType.NoInformation;
                        response.ResponseMessage = "No existen registros.";
                        response.Content = null;
                    }
                }
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = EditarClasesTomadas(dataRequest.membresia_persona_disciplinaID, dataRequest.numClasesDisponibles);

                    if (resp)
                    {
                        response.ResponseCode = DisciplinasMembresiaPersonaPagoResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = DisciplinasMembresiaPersonaPagoResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }
            }
            catch (DisciplinasMembresiaPersonaPagoException DisciplinasMembresiaPersonaPagoException)
            {
                SetResponseAsExceptionDisciplinasMembresiaPersonaPago(DisciplinasMembresiaPersonaPagoException.Type, response, DisciplinasMembresiaPersonaPagoException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar DisciplinasMembresiaPersonaPago.";
                SetResponseAsExceptionDisciplinasMembresiaPersonaPago(DisciplinasMembresiaPersonaPagoResponseType.Error, response, message);
            }

            return response;
        }
    }
}