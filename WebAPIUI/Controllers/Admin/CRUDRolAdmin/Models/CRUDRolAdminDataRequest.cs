﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.CRUDRolAdmin.Models
{
    public class CRUDRolAdminDataRequest
    {
        public int flujoID { get; set; }
        public int rolID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}