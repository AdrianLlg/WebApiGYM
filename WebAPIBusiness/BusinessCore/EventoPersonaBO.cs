using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.EventoPersona;
using WebAPIBusiness.Resources;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class EventoPersonaBO { 

        public List<EventoPersonaEntity> EventoPersona(string personaID)
        {
            List<EventoPersonaEntity> eventosPersona = getEventoPersona(personaID);

            return eventosPersona;
        }

        private List<EventoPersonaEntity> getEventoPersona(string personaID)
        {
            int ID = Convert.ToInt16(personaID);
            List<EventoPersonaEntity> eventosPersona = new List<EventoPersonaEntity>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    string query = string.Format(ScriptsGYMDB.getEventoRecurso, personaID);
                    eventosPersona = dbContext.Database.SqlQuery<EventoPersonaEntity>(query).ToList();
                }

                return eventosPersona;
            }
            catch (Exception ex)
            {
                return eventosPersona;
            }
        }

        
    }
}
