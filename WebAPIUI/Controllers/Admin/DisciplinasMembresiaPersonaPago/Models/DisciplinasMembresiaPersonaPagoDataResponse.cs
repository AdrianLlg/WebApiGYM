using System;
using System.Collections.Generic;
using WebAPIUI.Models.ConfiguracionesSistema;
using WebAPIUI.CustomExceptions.DisciplinasMembresiaPersonaPago;
using WebAPIBusiness.Entities.DisciplinasMembresiaPersonaPago;

namespace WebAPIUI.Controllers.ConfiguracionesSistema.Models
{
    public class DisciplinasMembresiaPersonaPagoDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public DisciplinasMembresiaPersonaPagoResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<DisciplinasMembresiaPersonaPagoEntity> Content { get; set; }
    }
}