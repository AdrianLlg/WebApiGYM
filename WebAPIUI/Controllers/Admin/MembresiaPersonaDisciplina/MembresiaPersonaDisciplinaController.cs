using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIUI.Controllers.MembresiaPersonaDisciplina.Models;
using WebAPIUI.Helpers;
using WebAPIUI.Models.MembresiaPersonaDisciplina;
using WebAPIBusiness.Entities.MembresiaAdmin;
using WebAPIUI.CustomExceptions.MembresiaPersonaDisciplina;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Clases.
    /// </summary>
    public class MembresiaPersonaDisciplinaController : BaseAPIController
    {
        private void ValidatePostRequest(MembresiaPersonaDisciplinaDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionMembresiaPersonaDisciplina(MembresiaPersonaDisciplinaResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.nombres))
            //{
            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }

        /// <summary>
        /// Insertar un nuevo Clase en la BD
        /// </summary>
        private bool insertMembresiaPersonaDisciplina(int membresia_persona_pagoID, int personaID, int membresia_disciplinaID, DateTime fechaInicio, DateTime fechaFin, int numClasesDisponibles, int numClasesTomadas)
        {
            MembresiaPersonaDisciplinaBO bo = new MembresiaPersonaDisciplinaBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertMembresiPersonaDisciplina(membresia_persona_pagoID, personaID, membresia_disciplinaID, fechaInicio, fechaFin, numClasesDisponibles, numClasesTomadas);
            }
            catch (ValidationAndMessageException MembresiaPersonaDisciplinaException)
            {
                messages.Add(MembresiaPersonaDisciplinaException.Message);
                ThrowHandledExceptionMembresiaPersonaDisciplina(MembresiaPersonaDisciplinaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionMembresiaPersonaDisciplina(MembresiaPersonaDisciplinaResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta los Clases de la base 
        /// </summary>
        private List<MembresiaPersonaDisciplinaEntity> ConsultarMembresiaPersonaDisciplina()
        {
            MembresiaPersonaDisciplinaBO bo = new MembresiaPersonaDisciplinaBO();
            List<string> messages = new List<string>();
            List<MembresiaPersonaDisciplinaEntity> response = new List<MembresiaPersonaDisciplinaEntity>();

            try
            {
                response = bo.getMembresiaPersonaDisciplinas();
            }
            catch (ValidationAndMessageException MembresiaPersonaDisciplinaException)
            {
                messages.Add(MembresiaPersonaDisciplinaException.Message);
                ThrowHandledExceptionMembresiaPersonaDisciplina(MembresiaPersonaDisciplinaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionMembresiaPersonaDisciplina(MembresiaPersonaDisciplinaResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar Clase
        /// </summary>
        private bool ModificarMembresiaPersonaDisciplina(int membresia_persona_disciplinaID, int membresiaPersonaPagoID, int personaID, int membresia_disciplinaID, DateTime fechaInicio, DateTime fechaFin, int numClasesDisponibles, int numClasesTomadas, string estado)
        {
            MembresiaPersonaDisciplinaBO bo = new MembresiaPersonaDisciplinaBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifyMembresiPersonaDisciplina( membresia_persona_disciplinaID, membresiaPersonaPagoID, personaID, membresia_disciplinaID, fechaInicio, fechaFin, numClasesDisponibles, numClasesTomadas, estado);
            }
            catch (ValidationAndMessageException MembresiaPersonaDisciplinaException)
            {
                messages.Add(MembresiaPersonaDisciplinaException.Message);
                ThrowHandledExceptionMembresiaPersonaDisciplina(MembresiaPersonaDisciplinaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionMembresiaPersonaDisciplina(MembresiaPersonaDisciplinaResponseType.Error, ex);
            }

            return response;
        }


     
        

        /// <summary>
        /// Consultar Clase
        /// </summary>
        private MembresiaPersonaDisciplinaEntity DetalleClase(int membresia_persona_disciplinaID)
        {
            MembresiaPersonaDisciplinaBO bo = new MembresiaPersonaDisciplinaBO();
            List<string> messages = new List<string>();
            MembresiaPersonaDisciplinaEntity response = new MembresiaPersonaDisciplinaEntity();

            try
            {
                response = bo.ConsultarMemebresiPersonaDisciplina(membresia_persona_disciplinaID); 
            }
            catch (ValidationAndMessageException MembresiaPersonaDisciplinaException)
            {
                messages.Add(MembresiaPersonaDisciplinaException.Message);
                ThrowHandledExceptionMembresiaPersonaDisciplina(MembresiaPersonaDisciplinaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionMembresiaPersonaDisciplina(MembresiaPersonaDisciplinaResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// CRUD de Clases para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public MembresiaPersonaDisciplinaDataResponse Post(MembresiaPersonaDisciplinaDataRequest dataRequest)
        {
            MembresiaPersonaDisciplinaDataResponse response = new MembresiaPersonaDisciplinaDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de membresias
                if (dataRequest.flujoID == 0)
                {
                    List<MembresiaPersonaDisciplinaEntity> model = new List<MembresiaPersonaDisciplinaEntity>();
                    List<MembresiaPersonaDisciplinaEntity> items = ConsultarMembresiaPersonaDisciplina();

                    if (items.Count > 0)
                    {
                        model = items;
                        response.ResponseCode = MembresiaPersonaDisciplinaResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model; 
                    }
                    else
                    {
                        response.ResponseCode = MembresiaPersonaDisciplinaResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = insertMembresiaPersonaDisciplina(dataRequest.membresia_persona_pagoID, dataRequest.personaID, dataRequest.membresia_disciplinaID, dataRequest.fechaInicio, dataRequest.fechaFin, dataRequest.numClasesDisponibles, dataRequest.numClasesTomadas);

                    if (resp)
                    {
                        response.ResponseCode = MembresiaPersonaDisciplinaResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = MembresiaPersonaDisciplinaResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarMembresiaPersonaDisciplina(dataRequest.membresia_persona_disciplinaID, dataRequest.membresia_persona_pagoID, dataRequest.personaID, dataRequest.membresia_disciplinaID, dataRequest.fechaInicio, dataRequest.fechaFin, dataRequest.numClasesDisponibles, dataRequest.numClasesTomadas, dataRequest.estado);

                    if (resp)
                    {
                        response.ResponseCode = MembresiaPersonaDisciplinaResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = MembresiaPersonaDisciplinaResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }
                //Detalle de persona
                else if (dataRequest.flujoID == 3)
                {
                    MembresiaPersonaDisciplinaEntity resp = new MembresiaPersonaDisciplinaEntity();
                    MembresiaPersonaDisciplinaEntity model = new MembresiaPersonaDisciplinaEntity();

                    resp = DetalleClase(dataRequest.membresia_persona_disciplinaID);

                    if (resp.membresia_persona_disciplinaID > 0)
                    {
                        model = resp;
                        response.ResponseCode = MembresiaPersonaDisciplinaResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = MembresiaPersonaDisciplinaResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

            }
            catch (MembresiaPersonaDisciplinaException MembresiaPersonaDisciplinaException)
            {
                SetResponseAsExceptionMembresiaPersonaDisciplina(MembresiaPersonaDisciplinaException.Type, response, MembresiaPersonaDisciplinaException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar MembresiaPersonaDisciplina.";
                SetResponseAsExceptionMembresiaPersonaDisciplina(MembresiaPersonaDisciplinaResponseType.Error, response, message);
            }

            return response;
        }
    }
}