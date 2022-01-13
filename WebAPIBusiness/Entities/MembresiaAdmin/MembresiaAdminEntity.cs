using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.Entities.DisciplinaAdmin;

namespace WebAPIBusiness.Entities.MembresiaAdmin
{
    public class MembresiaAdminEntity
    {
        public int membresiaID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public string periodicidad { get; set; }

        public List<Membresia_Disciplina_NumClasesEntity> disciplinas { get; set; }
    }
}
