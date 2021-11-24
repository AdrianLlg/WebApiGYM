using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.TransaccionesAnuales
{
    public class TransaccionesAnualesModel
    {
        public string Mes { get; set; }
        public int Anio { get; set; } 
        public int Transacciones { get; set; }  
    }
}