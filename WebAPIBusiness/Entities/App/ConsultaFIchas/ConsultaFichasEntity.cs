using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.Entities.App.ConsultaFichaEntrenamiento;
using WebAPIBusiness.Entities.App.ConsultaFichaPersona;

namespace WebAPIBusiness.Entities.App.ConsultaFIchas
{
    public class ConsultaFichasEntity
    {
        public ConsultaFichaPersonaEntity consultaFichaPersona { get; set; }
        public List<ConsultaFichaEntrenamientoEntity> ConsultaFichaEntrenamientos { get; set; }
    }
}
