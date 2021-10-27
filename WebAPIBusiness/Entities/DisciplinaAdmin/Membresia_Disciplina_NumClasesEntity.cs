using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.DisciplinaAdmin
{
    public class Membresia_Disciplina_NumClasesEntity
    {
        public int disciplinaID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int numClasesDisponibles { get; set; }

    }
}
