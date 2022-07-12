using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIBusiness.BusinessCore;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.Fichas;
using WebAPIUI.Controllers.CRUDFichaEntrenamiento.Models;
using WebAPIUI.CustomExceptions.FichaEntrenamiento;
using WebAPIUI.Helpers;
using WebAPIUI.Models.Fichas;

namespace WebAPIUI.Controllers
{
    /// <summary>
    /// API que permite el manejo de Crear, Modificar y Consultar información de FichaEntrenamiento.
    /// </summary>
    public class FichaEntrenamientoController : BaseAPIController
    {
        private void ValidatePostRequest(FichaEntrenamientoDataRequest dataRequest)
        {
            List<string> messages = new List<string>();
            string message = string.Empty;

            if (dataRequest == null)
            {
                messages.Add("No se han especificado datos de ingreso.");
                ThrowHandledExceptionFichaEntrenamiento(FichaEntrenamientoResponseType.InvalidParameters, messages);
            }

            //if (string.IsNullOrEmpty(dataRequest.nombres))
            //{
            //    messages.Add("No se ha especificado el(los) nombre(s) del catalogo a consultar");
            //    ThrowHandledException(RegisterPersonResponseType.InvalidParameters, messages);
            //}
        }

        /// <summary>
        /// Insertar un nuevo FichaEntrenamiento en la BD
        /// </summary>
        private bool InsertarFichaEntrenamiento(string FechaCreacion, int fichaPersonaID, int ProfesorID, int DisciplinaID, decimal Altura, decimal Peso, decimal IndiceMasaMuscular, decimal IndiceGrasaCorporal, decimal MedicionBrazos, decimal MedicionPecho, decimal MedicionEspalda, decimal MedicionPiernas, decimal MedicionCintura, decimal MedicionCuello, string Observaciones)
        {
            FichaEntrenamientoBO bo = new FichaEntrenamientoBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.insertFichaEntrenamiento(FechaCreacion, fichaPersonaID, ProfesorID, DisciplinaID, Altura, Peso, IndiceMasaMuscular, IndiceGrasaCorporal, MedicionBrazos, MedicionPecho, MedicionEspalda, MedicionPiernas, MedicionCintura, MedicionCuello, Observaciones);
            }
            catch (ValidationAndMessageException FichaEntrenamientoException)
            {
                messages.Add(FichaEntrenamientoException.Message);
                ThrowHandledExceptionFichaEntrenamiento(FichaEntrenamientoResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionFichaEntrenamiento(FichaEntrenamientoResponseType.Error, ex);
            }

            return response;
        }


        /// <summary>
        /// Consulta los FichaEntrenamiento de la base 
        /// </summary>
        private List<FichaEntrenamientoEntity> ConsultarFichaEntrenamiento()
        {
            FichaEntrenamientoBO bo = new FichaEntrenamientoBO();
            List<string> messages = new List<string>();
            List<FichaEntrenamientoEntity> response = new List<FichaEntrenamientoEntity>();

            try
            {
                response = bo.getFichas();
            }
            catch (ValidationAndMessageException FichaEntrenamientoException)
            {
                messages.Add(FichaEntrenamientoException.Message);
                ThrowHandledExceptionFichaEntrenamiento(FichaEntrenamientoResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionFichaEntrenamiento(FichaEntrenamientoResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Modificar FichaEntrenamiento
        /// </summary>
        private bool ModificarFichaEntrenamiento(int fichaEntrenamientoID, string FechaCreacion, int fichaPersonaID, int ProfesorID, int DisciplinaID, decimal Altura, decimal Peso, decimal IndiceMasaMuscular, decimal IndiceGrasaCorporal, decimal MedicionBrazos, decimal MedicionPecho, decimal MedicionEspalda, decimal MedicionPiernas, decimal MedicionCintura, decimal MedicionCuello, string Observaciones)
        {
            FichaEntrenamientoBO bo = new FichaEntrenamientoBO();
            List<string> messages = new List<string>();
            bool response = false;

            try
            {
                response = bo.modifyFichaEntrenamiento(fichaEntrenamientoID,FechaCreacion, fichaPersonaID, ProfesorID, DisciplinaID, Altura, Peso, IndiceMasaMuscular, IndiceGrasaCorporal, MedicionBrazos, MedicionPecho, MedicionEspalda, MedicionPiernas, MedicionCintura, MedicionCuello, Observaciones);
            }
            catch (ValidationAndMessageException FichaEntrenamientoException)
            {
                messages.Add(FichaEntrenamientoException.Message);
                ThrowHandledExceptionFichaEntrenamiento(FichaEntrenamientoResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionFichaEntrenamiento(FichaEntrenamientoResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// Consultar FichaEntrenamiento
        /// </summary>
        private FichaEntrenamientoEntity DetalleFichaEntrenamiento(int fichaEntrenamientoID)
        {
            FichaEntrenamientoBO bo = new FichaEntrenamientoBO();
            List<string> messages = new List<string>();
            FichaEntrenamientoEntity response = new FichaEntrenamientoEntity();

            try
            {
                response = bo.consultarFichaEntrenamiento(fichaEntrenamientoID);
            }
            catch (ValidationAndMessageException FichaEntrenamientoException)
            {
                messages.Add(FichaEntrenamientoException.Message);
                ThrowHandledExceptionFichaEntrenamiento(FichaEntrenamientoResponseType.Error, messages);
            }
            catch (Exception ex)
            {
                messages.Add("Ocurrió un error al ejecutar el proceso.");
                ThrowUnHandledExceptionFichaEntrenamiento(FichaEntrenamientoResponseType.Error, ex);
            }

            return response;
        }

        /// <summary>
        /// CRUD de FichaEntrenamiento para Admin
        /// </summary>
        /// <param name="dataRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public FichaEntrenamientoDataResponse Post(FichaEntrenamientoDataRequest dataRequest)
        {
            FichaEntrenamientoDataResponse response = new FichaEntrenamientoDataResponse();

            try
            {
                List<string> messages = new List<string>();
                string message = string.Empty;

                ValidatePostRequest(dataRequest);

                //Mostrar Listado de membresias
                if (dataRequest.flujoID == 0)
                {
                    List<FichaEntrenamientoModel> model = new List<FichaEntrenamientoModel>();
                    List<FichaEntrenamientoEntity> items = ConsultarFichaEntrenamiento();

                    if (items.Count > 0)
                    {
                        model = EntitesHelper.FichaEntrenamientosEntityToModel(items);
                        response.ResponseCode = FichaEntrenamientoResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentIndex = model;
                    }
                    else
                    {
                        response.ResponseCode = FichaEntrenamientoResponseType.InvalidParameters;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentIndex = null;
                    }
                }
                //Crear
                else if (dataRequest.flujoID == 1)
                {
                    bool resp = InsertarFichaEntrenamiento(dataRequest.FechaCreacion, dataRequest.fichaPersonaID, dataRequest.ProfesorID, dataRequest.DisciplinaID, dataRequest.Altura, dataRequest.Peso, dataRequest.IndiceMasaMuscular, dataRequest.IndiceGrasaCorporal, dataRequest.MedicionBrazos, dataRequest.MedicionPecho, dataRequest.MedicionEspalda, dataRequest.MedicionPiernas, dataRequest.MedicionCintura, dataRequest.MedicionCuello, dataRequest.Observaciones);

                    if (resp)
                    {
                        response.ResponseCode = FichaEntrenamientoResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentCreate = true;
                    }
                    else
                    {
                        response.ResponseCode = FichaEntrenamientoResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentCreate = false;
                    }
                }
                //Modificar
                else if (dataRequest.flujoID == 2)
                {
                    bool resp = ModificarFichaEntrenamiento(dataRequest.fichaEntrenamientoID, dataRequest.FechaCreacion, dataRequest.fichaPersonaID, dataRequest.ProfesorID, dataRequest.DisciplinaID, dataRequest.Altura, dataRequest.Peso, dataRequest.IndiceMasaMuscular, dataRequest.IndiceGrasaCorporal, dataRequest.MedicionBrazos, dataRequest.MedicionPecho, dataRequest.MedicionEspalda, dataRequest.MedicionPiernas, dataRequest.MedicionCintura, dataRequest.MedicionCuello, dataRequest.Observaciones);

                    if (resp)
                    {
                        response.ResponseCode = FichaEntrenamientoResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentModify = true;
                    }
                    else
                    {
                        response.ResponseCode = FichaEntrenamientoResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentModify = false;
                    }
                }
                //Detalle de persona
                else if (dataRequest.flujoID == 3)
                {
                    FichaEntrenamientoEntity resp = new FichaEntrenamientoEntity();
                    FichaEntrenamientoModel model = new FichaEntrenamientoModel();

                    resp = DetalleFichaEntrenamiento(dataRequest.fichaEntrenamientoID);

                    if (resp.fichaEntrenamientoID > 0)
                    {
                        model = EntitesHelper.FichaEntrenamientoInfoEntityToModel(resp);
                        response.ResponseCode = FichaEntrenamientoResponseType.Ok;
                        response.ResponseMessage = "Método ejecutado con éxito.";
                        response.ContentDetail = model;
                    }
                    else
                    {
                        response.ResponseCode = FichaEntrenamientoResponseType.Error;
                        response.ResponseMessage = "Fallo en la ejecución.";
                        response.ContentDetail = null;
                    }

                }

            }
            catch (FichaEntrenamientoException FichaEntrenamientoException)
            {
                SetResponseAsExceptionFichaEntrenamiento(FichaEntrenamientoException.Type, response, FichaEntrenamientoException.Message);
            }
            catch (Exception ex)
            {
                string message = "Se ha produccido un error al invocar FichaEntrenamiento.";
                SetResponseAsExceptionFichaEntrenamiento(FichaEntrenamientoResponseType.Error, response, message);
            }

            return response;
        }
    }
}