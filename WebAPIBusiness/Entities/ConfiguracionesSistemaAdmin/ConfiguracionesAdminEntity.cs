using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.ConfiguracionesSistemaAdmin
{
    public class ConfiguracionesAdminEntity
    {
        public int ConfiguracionSistemaID { get; set; }
        public string TipoConfiguracion { get; set; }
        public string NombreConfiguracion { get; set; }
        public string DescripcionConfiguracion { get; set; }
        public string Estado { get; set; }
        public string Valor { get; set; }
        public Nullable<DateTime> Fecha { get; set; }
        public Nullable<DateTime> FechaInicio { get; set; }
        public Nullable<DateTime> FechaFin { get; set; }

    }
}
