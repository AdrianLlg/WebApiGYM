using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebAPIBusiness.Entities.Membresia;
using WebAPIBusiness.Resources;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class MembresiaBO
    {
        public List<MembresiaEntity> membresiasUser(string personaID)
        {
            List<MembresiaEntity> membresias = getMembresiasUser(personaID);

            return membresias;
        }

        private List<MembresiaEntity> getMembresiasUser(string personaID)
        {
            int ID = Convert.ToInt16(personaID);
            List<MembresiaEntity> membresias = new List<MembresiaEntity>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    string query = string.Format(ScriptsGYMDB.getMembresiasUsuario, personaID);
                    membresias = dbContext.Database.SqlQuery<MembresiaEntity>(query).ToList();
                }

                return membresias;
            }
            catch (Exception ex)
            {
                return membresias;
            }
        }

        
    }
}
