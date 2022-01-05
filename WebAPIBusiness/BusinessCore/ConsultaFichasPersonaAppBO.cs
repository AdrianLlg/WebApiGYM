using System;
using System.Linq;
using WebAPIBusiness.Entities.App.ConsultaFichaPersona;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore 
{
    public class ConsultaFichaPersonaAppBO
    {

        public ConsultaFichaPersonaEntity consultarFichaPersona(int personaID)
        {

            ConsultaFichaPersonaEntity entity = new ConsultaFichaPersonaEntity();
            entity = getFichaPersonaDB(personaID);


            return entity;
        }

        private ConsultaFichaPersonaEntity getFichaPersonaDB(int personaID)
        {

            ConsultaFichaPersonaEntity item = new ConsultaFichaPersonaEntity();
            persona personaDB = new persona();

            using (var dbContext = new GYMDBEntities())
            {
                string query = String.Empty;
                query = string.Format(ScriptsGYMDB.getFichaPersonaApp, personaID);
                item = dbContext.Database.SqlQuery<ConsultaFichaPersonaEntity>(query).FirstOrDefault();

            }


            return item;
        }


    }
}


