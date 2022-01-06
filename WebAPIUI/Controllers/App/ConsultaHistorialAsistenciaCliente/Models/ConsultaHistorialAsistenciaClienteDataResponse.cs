using System.Collections.Generic;
using WebAPIUI.CustomExceptions.ConsultaHistorialAsistenciaCliente;
using WebAPIUI.Models.ConsultaHistorialAsitenciaCliente;

namespace WebAPIUI.Controllers.App.ConsultaHistorialAsistenciaCliente.Models
{
    public class ConsultaHistorialAsistenciaClienteDataResponse
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public ConsultaHistorialAsistenciaClienteResponseType ResponseCode { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Conteo de resultados
        /// </summary>
        public int count { get; set; } 

        /// <summary>
        /// Contenido de respuesta
        /// </summary>
        public List<ConsultaHistorialAsistenciaClienteModel> ContentIndex { get; set; }
        

    }
}