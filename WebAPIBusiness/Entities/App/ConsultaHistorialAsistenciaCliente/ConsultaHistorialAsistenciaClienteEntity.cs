using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.App.ConsultaHistorialAsistenciaCliente
{
    public class ConsultaHistorialAsistenciaClienteEntity
    {
        public string Cliente { get; set; }
        public string Clase { get; set; } 
        public string Disciplina { get; set; }
        public string Profesor { get; set; }
        public string Horario { get; set; }
        public DateTime Fecha { get; set; } 
        public string Sala { get; set; }
        public string Asistencia { get; set; }

    }
}
