using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.ConsultaPerfil
{
    public class ConsultaPerfilEntity
    {
        public int usuarioID { get; set; }
        public int personaID { get; set; }
        public int rolePID { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string identificacion { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string telefono { get; set; }
        public string edad { get; set; }
        public string sexo { get; set; }
        public DateTime fechaNacimiento { get; set; } 
        public DateTime fechaCreacion { get; set; }
        public string estado { get; set; }
    }
}
