using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBusiness.Entities.DisciplinaAdmin;

namespace WebAPIUI.Models.MembresiasAdmin
{
    public class MembresiaAdminModel
    {
        public int MembresiaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Periodicidad { get; set; }
        public string estadoRegistro { get; set; }
        
        public List<Membresia_Disciplina_NumClasesEntity> membresiaDisciplinas { get; set; }

    }

}