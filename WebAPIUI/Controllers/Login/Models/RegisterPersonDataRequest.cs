﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Controllers.Login.Models
{
    public class RegisterPersonDataRequest
    {
        public string rolePID { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string identificacion { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string edad { get; set; }
        public string sexo { get; set; }
        public string fechaNacimiento { get; set; }
    }
}