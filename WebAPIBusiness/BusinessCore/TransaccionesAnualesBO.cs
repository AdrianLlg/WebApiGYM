using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.TransaccionesAnuales;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore
{ 
    public class TransaccionesAnualesBO
    {
        public List<TransaccionesAnualesEntity> getPagos(int anio)
        {
            List<TransaccionesAnualesEntity> entities = new List<TransaccionesAnualesEntity>();

            entities = getPagosDB(anio);
            

            return entities;
        }

        private List<TransaccionesAnualesEntity> getPagosDB(int anio)
        {

            List<TransaccionesAnualesEntity> consulta = new List<TransaccionesAnualesEntity>();
            
            TransaccionesAnualesEntity item = new TransaccionesAnualesEntity();

            
            using (var dbContext = new GYMDBEntities())
            {
                string query = string.Format(ScriptsGYMDB.getTransaccionesAnuales, anio);
                consulta = dbContext.Database.SqlQuery<TransaccionesAnualesEntity>(query).ToList();
            }
            


           
            return consulta;
        }


    }
}


