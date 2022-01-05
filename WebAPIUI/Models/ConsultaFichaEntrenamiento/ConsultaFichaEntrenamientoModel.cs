using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.ConsultaFichaEntrenamiento
{
    public class ConsultaFichaEntrenamientoModel
    {
        public int fichaEntrenamientoID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int fichaPersonaID { get; set; }
        public int ProfesorID { get; set; }
        public int DisciplinaID { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public decimal IndiceMasaMuscular { get; set; }
        public decimal IndiceGrasaCorporal { get; set; }
        public decimal MedicionBrazos { get; set; }
        public decimal MedicionPecho { get; set; }
        public decimal MedicionEspalda { get; set; }
        public decimal MedicionPiernas { get; set; }
        public decimal MedicionCintura { get; set; }
        public decimal MedicionCuello { get; set; }
        public string Observaciones { get; set; }

        public string Profesor { get; set; }
        public string Disciplina { get; set; }
    }
}