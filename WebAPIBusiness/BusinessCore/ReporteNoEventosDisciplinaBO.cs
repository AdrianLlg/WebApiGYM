using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.ConsultaRepEventoDisciplina;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore
{
    public class ReporteNoEventosDisciplinaBO
    {
        public List<ConsultaRepEventoDisciplinaEntity> getEventos(string fechaInicio, string fechaFin)
        {
            List<ConsultaRepEventoDisciplinaEntity> entities = new List<ConsultaRepEventoDisciplinaEntity>();

            entities = getEventosDisciplinasDB(fechaInicio,fechaFin);
            

            return entities;
        }

        private List<ConsultaRepEventoDisciplinaEntity> getEventosDisciplinasDB(string fechaInicio,string fechaFin)
        {

            List<ConsultaRepEventoDisciplinaEntity> consulta = new List<ConsultaRepEventoDisciplinaEntity>();
            DateTime FI= Convert.ToDateTime(fechaInicio);
            DateTime FF=Convert.ToDateTime(fechaFin);
            ConsultaRepEventoDisciplinaEntity item = new ConsultaRepEventoDisciplinaEntity();
            
            
            using (var dbContext = new GYMDBEntities())
            {
                string query = string.Format(ScriptsGYMDB.getEventosPorDisciplina, fechaInicio, fechaFin);
                consulta = dbContext.Database.SqlQuery<ConsultaRepEventoDisciplinaEntity>(query).ToList();
            }
            


           
            return consulta;
        }


    }
}


