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
    
    public partial class fichaPersona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public fichaPersona()
        {
            this.fichaEntrenamiento = new HashSet<fichaEntrenamiento>();
        }
    
        public int fichaPersonaID { get; set; }
        public int PersonaID { get; set; }
        public string MesoTipo { get; set; }
        public string NivelActualActividadFisica { get; set; }
        public string AntecendesMedicos { get; set; }
        public string Alergias { get; set; }
        public string Enfermedades { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fichaEntrenamiento> fichaEntrenamiento { get; set; }
        public virtual persona persona { get; set; }
    }
}