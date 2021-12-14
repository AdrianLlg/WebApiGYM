using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.SalaRecurso
{
    public class SalaRecursoEntity
    {
        public int salaRecursoID { get; set; }
        public int salaID { get; set; }
        public string nombreRecurso { get; set; }
        public int cantidad { get; set; }
        public string estadoRegistro { get; set; }
    }
}
