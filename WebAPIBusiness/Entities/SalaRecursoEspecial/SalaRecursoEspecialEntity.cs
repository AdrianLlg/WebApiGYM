using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.SalaRecursoEspecial
{
    public class SalaRecursoEspecialEntity
    {
        public int salaRecursoEspecialID { get; set; }
        public int salaID { get; set; }
        public int recursoEspecialID { get; set; }
        public string estadoRegistro { get; set; }
    }
}
