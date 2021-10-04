using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.EventoRecurso;
using WebAPIBusiness.Entities.Eventos;
using WebAPIBusiness.Resources;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class EventosBO
    {
        public List<EventosEntity> Eventos(string personaID)
        {
            List<EventosEntity> eventos = getEventos(personaID);

            return eventos;
        }

        private List<EventosEntity> getEventos(string personaID)
        {
            int ID = Convert.ToInt16(personaID);
            List<EventosEntity> eventos = new List<EventosEntity>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    string query = string.Format(ScriptsGYMDB.getEventoRecurso, personaID);
                    eventos = dbContext.Database.SqlQuery<EventosEntity>(query).ToList();
                }

                return eventos;
            }
            catch (Exception ex)
            {
                return eventos;
            }
        }

        
    }
}
