﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.App.ConsultaDisciplinasDeportista
{
    public class ConsultaDisciplinasDeportistaEntity 
    {
        public int disciplinaID { get; set; }
        public int claseID { get; set; }
        public string Clase { get; set; }
        public string DescripcionClase { get; set; }
        public string Disciplina { get; set; }
        public string DescripcionDisciplina { get; set; } 

    }
}
