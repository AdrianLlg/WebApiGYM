//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIData
{
    using System;
    using System.Collections.Generic;
    
    public partial class cronograma
    {
        public int cronogramaID { get; set; }
        public int claseID { get; set; }
        public int horarioMID { get; set; }
        public System.DateTime fecha { get; set; }
        public int salaID { get; set; }
    
        public virtual clase clase { get; set; }
        public virtual horarioM horarioM { get; set; }
        public virtual sala sala { get; set; }
    }
}