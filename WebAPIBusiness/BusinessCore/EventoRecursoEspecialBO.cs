using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.EventoRecurso;
using WebAPIBusiness.Entities.EventoRecursoEspecial;
using WebAPIBusiness.Resources;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class EventoRescursoEspecialBO
    {
        public List<EventoRecursoEspecialEntity> EventoRecursoEspecial(string personaID)
        {
            List<EventoRecursoEspecialEntity> eventosRecursoEspecial = getEventoRecursoEspecial(personaID);

            return eventosRecursoEspecial;
        }

        private List<EventoRecursoEspecialEntity> getEventoRecursoEspecial(string personaID)
        {
            int ID = Convert.ToInt16(personaID);
            List<EventoRecursoEspecialEntity> eventosRecursoEspecial= new List<EventoRecursoEspecialEntity>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    string query = string.Format(ScriptsGYMDB.getEventoRecurso, personaID);
                    eventosRecursoEspecial= dbContext.Database.SqlQuery<EventoRecursoEspecialEntity>(query).ToList();
                }

                return eventosRecursoEspecial;
            }
            catch (Exception ex)
            {
                return eventosRecursoEspecial;
            }
        }

        
    }
}
