using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.ConsultaRepEventoSala;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore
{
    public class ReporteNoEventosSalaBO
    {
        public List<ConsultaRepEventoSalaEntity> getEventos(string fechaInicio, string fechaFin)
        {
            List<ConsultaRepEventoSalaEntity> entities = new List<ConsultaRepEventoSalaEntity>();

            entities = getEventosSalasDB(fechaInicio,fechaFin);
            

            return entities;
        }

        private List<ConsultaRepEventoSalaEntity> getEventosSalasDB(string fechaInicio,string fechaFin)
        {

            List<ConsultaRepEventoSalaEntity> consulta = new List<ConsultaRepEventoSalaEntity>();
            DateTime FI= Convert.ToDateTime(fechaInicio);
            DateTime FF=Convert.ToDateTime(fechaFin);
            ConsultaRepEventoSalaEntity item = new ConsultaRepEventoSalaEntity();
            
            
            using (var dbContext = new GYMDBEntities())
            {
                string query = string.Format(ScriptsGYMDB.getEventoSala, fechaInicio, fechaFin);
                consulta = dbContext.Database.SqlQuery<ConsultaRepEventoSalaEntity>(query).ToList();
            }
            


           
            return consulta;
        }


    }
}


