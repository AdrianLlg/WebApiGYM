using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.SalaAdmin
{
    public class SalaAdminEntity
    {
        public int salaID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string estadoRegistro{ get; set; }
    }

}
