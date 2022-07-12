using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.App.ConsultaDisciplinasDeportista
{
    public class ConsultaDisciplinasDeportistaEntity 
    {
        public int DisciplinaID { get; set; }
        public string NombreDisciplina { get; set; }
        public string DescripcionDisciplina { get; set; } 

        public List<ClaseDisciplinaEntity> clases { get; set; }
    }
}
