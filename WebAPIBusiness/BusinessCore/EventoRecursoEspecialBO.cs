using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.EvetoRecursoEspecial;
using WebAPIBusiness.Resources;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class EventoRecursoEspecialBO
    {

        public List<EventoRecursoEspecialEntity> ConsultarRecursoEspecial(string personaID,string eventoID)
        {
            List<EventoRecursoEspecialEntity> eventosRecursosEspeciales = getConsultarRecursoEspecial(personaID,eventoID);

            return eventosRecursosEspeciales;
        }

        private List<EventoRecursoEspecialEntity> getConsultarRecursoEspecial(string personaID,string eventoID)
        {
            
            List<EventoRecursoEspecialEntity> eventosRecursosEspeciales = new List<EventoRecursoEspecialEntity>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    string query = string.Format(ScriptsGYMDB.getEventoRecursoEspecial, personaID,eventoID);
                    eventosRecursosEspeciales = dbContext.Database.SqlQuery<EventoRecursoEspecialEntity>(query).ToList();
                }

                return eventosRecursosEspeciales;
            }
            catch (Exception ex)
            {
                return eventosRecursosEspeciales;
            }
        }

        
    }
}
