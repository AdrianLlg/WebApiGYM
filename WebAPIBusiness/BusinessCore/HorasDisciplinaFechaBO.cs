using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebAPIBusiness.Entities.HorasDisciplinaFechaEntity;
using WebAPIBusiness.Entities.Membresia;
using WebAPIBusiness.Resources;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class HorasDisciplinaFechaBO
    {
        public List<HorasDisciplinaFechaEntity> horasdisciplinaFecha(string personaID)
        {
            List<HorasDisciplinaFechaEntity> horasDisciplinaFecha = getHorasdisciplinaFecha(personaID);

            return horasDisciplinaFecha;
        }

        private List<HorasDisciplinaFechaEntity> getHorasdisciplinaFecha(string personaID)
        {
            int ID = Convert.ToInt16(personaID);
            List<HorasDisciplinaFechaEntity> horasDisciplinaFecha = new List<HorasDisciplinaFechaEntity>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    string query = string.Format(ScriptsGYMDB.getHorasFechaDisciplina, personaID);
                    horasDisciplinaFecha = dbContext.Database.SqlQuery<HorasDisciplinaFechaEntity>(query).ToList();
                }

                return horasDisciplinaFecha;
            }
            catch (Exception ex)
            {
                return horasDisciplinaFecha;
            }
        }

        
    }
}
