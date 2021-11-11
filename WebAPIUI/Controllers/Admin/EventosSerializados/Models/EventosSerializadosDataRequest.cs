using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBusiness.Entities.EventoAdmin;

namespace WebAPIUI.Controllers.EventosSerializados.Models
{
    public class EventosSerializadosDataRequest
    {
        public int flujoID{ get; set; }
        public List<EventoAdminEntity> listaEventos { get; set; }

    }
}