using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBusiness.Entities.App.ListaAsitenciaManual;
using WebAPIBusiness.Entities.ConsultaHorarios;

namespace WebAPIUI.Controllers.App.RegistrarAsistenciaManual.Models
{
    public class RegistrarAsistenciaManualDataRequest
    {
        public List<ListaAsitenciaManualEntity> listaAsistencia { get; set; } 
        
         
    }
} 