//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIData
{
    using System;
    using System.Collections.Generic;
    
    public partial class membresia_disciplina
    {
        public int membresia_discplinaID { get; set; }
        public int membresiaID { get; set; }
        public int disciplinaID { get; set; }
    
        public virtual disciplina disciplina { get; set; }
        public virtual membresia membresia { get; set; }
    }
}
