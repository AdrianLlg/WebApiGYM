using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.App.ConsultaDisciplinasDeportista;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore
{
    public class ConsultaDisciplinasDeportistaBO
    {
        public List<ConsultaDisciplinasDeportistaEntity> getListaDisciplinas()
        {
            List<ConsultaDisciplinasDeportistaEntity> entities = new List<ConsultaDisciplinasDeportistaEntity>();

            entities = getListaDisciplinasDB();

            return entities;
        }
         
        private List<ConsultaDisciplinasDeportistaEntity> getListaDisciplinasDB()
        {
            List<ConsultaDisciplinasDeportistaEntity> listaDisciplinas = new List<ConsultaDisciplinasDeportistaEntity>();

            try
            { 
                
                using (var dbContext = new GYMDBEntities())
                { 
                    string query = string.Format(ScriptsGYMDB.getConsultaDisciplinasDeportistaApp );
                    listaDisciplinas = dbContext.Database.SqlQuery<ConsultaDisciplinasDeportistaEntity>(query).ToList();
                    
                }
                return listaDisciplinas;
            }
            catch (Exception ex)
            {
                return listaDisciplinas ;
            } 
        }
    }
}
