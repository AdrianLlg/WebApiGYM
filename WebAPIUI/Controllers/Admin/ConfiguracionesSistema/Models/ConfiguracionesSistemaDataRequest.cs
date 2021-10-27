using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.ConfiguracionesSistema.Models
{
    public class ConfiguracionesSistemaDataRequest
    {
        public int flujoID { get; set; }
        public int ConfiguracionSistemaID { get; set; }
        public string Valor { get; set; }
        public string Fecha { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
    }
}