﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.CRUDRDisciplinaAdmin.Models
{
    public class CRUDDisciplinaAdminDataRequest
    {
        public int flujoID { get; set; }
        public int disciplinaID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
} 