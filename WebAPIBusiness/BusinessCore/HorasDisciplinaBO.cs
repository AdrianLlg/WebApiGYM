using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebAPIBusiness.Entities.HorasDisciplina;
using WebAPIBusiness.Resources;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class HorasDisciplinaBO
    {
        public List<HorasDisciplinaEntity> horasDisciplina(string disciplinaID)
        {
            List<HorasDisciplinaEntity> horasDisciplinaDB = gethorasDisciplinaDB(disciplinaID);

            return horasDisciplinaDB;
        }

        private List<HorasDisciplinaEntity> gethorasDisciplinaDB(string disciplinaID)
        {
            List<HorasDisciplinaEntity> horasDisciplinaDB = new List<HorasDisciplinaEntity>();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    string query = string.Format(ScriptsGYMDB.getHorasDisciplina, disciplinaID);
                    horasDisciplinaDB = dbContext.Database.SqlQuery<HorasDisciplinaEntity>(query).ToList();
                }

                return horasDisciplinaDB;
            }
            catch (Exception ex)
            {
                return horasDisciplinaDB;
            }
        }

        
    }
}
