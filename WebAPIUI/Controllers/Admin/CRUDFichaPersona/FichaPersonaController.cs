using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.Fichas;
using WebAPIUI.Controllers.CRUDFichaPersona.Models;
using WebAPIUI.CustomExceptions.FichaPersona;
using WebAPIUI.Helpers;
using WebAPIUI.Models.Fichas;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de Fichas.
    /// </summary>
    public class FichaPersonaController : BaseAPIController
    {
        private void ValidatePostRequest(FichaPersonaDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionFichaPersona(FichaPersonaResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.nombres))
            //{
            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }

        /// <summary>
        /// Insertar un nuevo recurso en la BD
        /// </summary>
        private bool InsertarNuevoRecurso(int PersonaID, string MesoTipo,string NivelActualActividadFisica,string AntecendesMedicos, string Alergias, string Enfermedades)
        {
            FichaPersonaBO bo = new FichaPersonaBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertfichaPersona(PersonaID, MesoTipo,NivelActualActividadFisica, AntecendesMedicos, Alergias, Enfermedades);
            }
            catch (ValidationAndMessageException FichaPersonaException)
            {
                messages.Add(FichaPersonaException.Message);
                ThrowHandledExceptionFichaPersona(FichaPersonaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionFichaPersona(FichaPersonaResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta los Fichas de la base 
        /// </summary>
        private List<FichaPersonaEntity> ConsultarFichas()
        {
            FichaPersonaBO bo = new FichaPersonaBO();
            List<string> messages = new List<string>();
            List<FichaPersonaEntity> response = new List<FichaPersonaEntity>();

            try
            {
                response = bo.getFichas();
            }
            catch (ValidationAndMessageException FichaPersonaException)
            {
                messages.Add(FichaPersonaException.Message);
                ThrowHandledExceptionFichaPersona(FichaPersonaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionFichaPersona(FichaPersonaResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar recurso
        /// </summary>
        private bool ModificarFicha(int fichaPersonaID, int PersonaID, string MesoTipo,string NivelActualActividadFisica,string AntecendesMedicos, string Alergias, string Enfermedades)
        {
            FichaPersonaBO bo = new FichaPersonaBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifyfichaPersona(fichaPersonaID, PersonaID, MesoTipo,NivelActualActividadFisica, AntecendesMedicos, Alergias, Enfermedades);
            }
            catch (ValidationAndMessageException FichaPersonaException)
            {
                messages.Add(FichaPersonaException.Message);
                ThrowHandledExceptionFichaPersona(FichaPersonaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionFichaPersona(FichaPersonaResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Consultar recurso
        /// </summary>
        private FichaPersonaEntity DetalleRecurso(int fichaPersonaID)
        {
            FichaPersonaBO bo = new FichaPersonaBO();
            List<string> messages = new List<string>();
            FichaPersonaEntity response = new FichaPersonaEntity();

            try
            {
                response = bo.consultarfichaPersona(fichaPersonaID);
            }
            catch (ValidationAndMessageException FichaPersonaException)
            {
                messages.Add(FichaPersonaException.Message);
                ThrowHandledExceptionFichaPersona(FichaPersonaResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionFichaPersona(FichaPersonaResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// CRUD de Fichas para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public FichaPersonaDataResponse Post(FichaPersonaDataRequest dataRequest)
        {
            FichaPersonaDataResponse response = new FichaPersonaDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;               

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de membresias
                if (dataRequest.flujoID == 0)
                {
                    List<FichaPersonaModel> model = new List<FichaPersonaModel>();
                    List<FichaPersonaEntity> items = ConsultarFichas();

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.FichaPersonasEntityToModel(items);
                        response.ResponseCode = FichaPersonaResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = FichaPersonaResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarNuevoRecurso(dataRequest.PersonaID, dataRequest.MesoTipo, dataRequest.NivelActualActividadFisica, dataRequest.AntecendesMedicos, dataRequest.Alergias, dataRequest.Enfermedades);

                    if (resp)
                    {
                        response.ResponseCode = FichaPersonaResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = FichaPersonaResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarFicha(dataRequest.fichaPersonaID,dataRequest.PersonaID, dataRequest.MesoTipo, dataRequest.NivelActualActividadFisica,  dataRequest.AntecendesMedicos, dataRequest.Alergias, dataRequest.Enfermedades);

                    if (resp)
                    {
                        response.ResponseCode = FichaPersonaResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = FichaPersonaResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }  
                //Detalle de persona
                else if (dataRequest.flujoID == 3)
                {
                    FichaPersonaEntity resp = new FichaPersonaEntity();
                    FichaPersonaModel model = new FichaPersonaModel();

                    resp = DetalleRecurso(dataRequest.fichaPersonaID);

                    if (resp.fichaPersonaID > 0)
                    {
                        model = EntitesHelper.FichaPersonaInfoEntityToModel(resp); 
                        response.ResponseCode = FichaPersonaResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = FichaPersonaResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

            }
            catch (FichaPersonaException FichaPersonaException)
            {
                SetResponseAsExceptionFichaPersona(FichaPersonaException.Type, response, FichaPersonaException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar CRUDFichaPersona.";
                SetResponseAsExceptionFichaPersona(FichaPersonaResponseType.Error, response, message);
            }

            return response;
        }
    }
}