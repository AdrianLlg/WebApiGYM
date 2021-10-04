using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.EventoRecurso;
using WebAPIBusiness.Resources;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class EventoRescursoBO
    {
        public List<EventoRecursoEntity> EventoRescurso(string personaID)
        {
            List<EventoRecursoEntity> eventosRecursos = getEventoRecursos(personaID);

            return eventosRecursos;
        }

        private List<EventoRecursoEntity> getEventoRecursos(string personaID)
        {
            int ID = Convert.ToInt16(personaID);
            List<EventoRecursoEntity> eventosRecursos = new List<EventoRecursoEntity>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    string query = string.Format(ScriptsGYMDB.getEventoRecurso, personaID);
                    eventosRecursos = dbContext.Database.SqlQuery<EventoRecursoEntity>(query).ToList();
                }

                return eventosRecursos;
            }
            catch (Exception ex)
            {
                return eventosRecursos;
            }
        }

        
    }
}
