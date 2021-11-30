using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.ConsultaPerfil;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore
{
    public class ConsultaPerfilBO
    {
        public List<ConsultaPerfilEntity> getPerfil(int personaID)
        {
            List<ConsultaPerfilEntity> entities = new List<ConsultaPerfilEntity>();

            entities = getPerfilDB(personaID);


            return entities;
        }

        private List<ConsultaPerfilEntity> getPerfilDB(int personaID)
        {

            List<ConsultaPerfilEntity> consulta = new List<ConsultaPerfilEntity>();
            ConsultaPerfilEntity item = new ConsultaPerfilEntity();


            using (var dbContext = new GYMDBEntities())
            {
                string query = string.Format(ScriptsGYMDB.getPerfil, personaID);
                consulta = dbContext.Database.SqlQuery<ConsultaPerfilEntity>(query).ToList();
            }




            return consulta;
        }


    }
}


