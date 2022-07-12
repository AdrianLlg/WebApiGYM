using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.ClasesAdmin
{
    public class ClaseAdminEntity
    {
        public int claseID { get; set; }
        public int disciplinaID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string  estadoRegistro{ get; set; }
    }
}
