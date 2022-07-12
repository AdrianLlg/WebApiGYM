using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.ConsultaPersonaEstado;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore
{
    public class ReportePersonasEstadoBO
    {
        public List<ConsultaPersonaEstadoEntity> getPersonas()
        { 
            List<ConsultaPersonaEstadoEntity> entities = new List<ConsultaPersonaEstadoEntity>();

            entities = getPersonasEstadoDB();
            

            return entities;
        }

        private List<ConsultaPersonaEstadoEntity> getPersonasEstadoDB()
        {

            List<ConsultaPersonaEstadoEntity> consulta = new List<ConsultaPersonaEstadoEntity>();
          
            ConsultaPersonaEstadoEntity item = new ConsultaPersonaEstadoEntity();
            
            
            using (var dbContext = new GYMDBEntities())
            {
                string query = string.Format(ScriptsGYMDB.getPersonasEstado);
                consulta = dbContext.Database.SqlQuery<ConsultaPersonaEstadoEntity>(query).ToList();
            }
            
            return consulta;
        }


    }
}


