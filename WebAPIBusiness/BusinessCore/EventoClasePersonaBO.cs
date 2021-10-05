using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.EventoClasePersona;
using WebAPIBusiness.Resources;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class EventoClasePersonaBO { 

        public List<EventoClasePersonaEntity> ConsultarHorario(string personaID,string fecha)
        {
            List<EventoClasePersonaEntity> eventosClasePersona = getConsultarHorario(personaID,fecha);

            return eventosClasePersona;
        }

        private List<EventoClasePersonaEntity> getConsultarHorario(string personaID,string fecha)
        {
            
            List<EventoClasePersonaEntity> eventosClasePersona = new List<EventoClasePersonaEntity>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    string query = string.Format(ScriptsGYMDB.getEventoClasePersona, personaID,fecha);
                    eventosClasePersona = dbContext.Database.SqlQuery<EventoClasePersonaEntity>(query).ToList();
                }

                return eventosClasePersona;
            }
            catch (Exception ex)
            {
                return eventosClasePersona;
            }
        }

        
    }
}
