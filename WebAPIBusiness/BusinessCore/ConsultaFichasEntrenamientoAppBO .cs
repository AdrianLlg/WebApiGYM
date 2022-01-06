using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.App.ConsultaFichaEntrenamiento;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore
{
    public class ConsultaFichasEntrenamientoAppBO
    {

        public List<ConsultaFichaEntrenamientoEntity> consultarFichaEntrenamiento(int personaID,int disciplinaID)
        {

            List<ConsultaFichaEntrenamientoEntity> entities = new List<ConsultaFichaEntrenamientoEntity>();
            entities = getFichasEntrenamientoDB(personaID,disciplinaID);
            return entities;
        }

        private List<ConsultaFichaEntrenamientoEntity> getFichasEntrenamientoDB(int personaID,int disciplinaID)
        {

            List<ConsultaFichaEntrenamientoEntity> items = new List<ConsultaFichaEntrenamientoEntity>();
            

            using (var dbContext = new GYMDBEntities())
            {
                string query = String.Empty;
                query = string.Format(ScriptsGYMDB.getFichasEntrenamientoPersona, personaID,disciplinaID);
                items = dbContext.Database.SqlQuery<ConsultaFichaEntrenamientoEntity>(query).ToList();

            }

            if (items.Count == 0)
            {
                return null;
            }

            return items;
        }


    }
}


