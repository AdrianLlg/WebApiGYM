﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.Models.ConfiguracionesSistema
{
    public class ConfiguracionesSistemaModel
    {
        public int ConfiguracionSistemaID { get; set; }
        public string TipoConfiguracion { get; set; }
        public string NombreConfiguracion { get; set; }
        public string DescripcionConfiguracion { get; set; }
        public string Estado { get; set; }
        public string Valor { get; set; }
        public string Fecha { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }


    }
}