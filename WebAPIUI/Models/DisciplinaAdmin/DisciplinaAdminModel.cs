﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.DisciplinaAdmin
{
    public class DisciplinaAdminModel
    {
        public int DisciplinaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string NumeroDeClases { get; set; }

    }
}