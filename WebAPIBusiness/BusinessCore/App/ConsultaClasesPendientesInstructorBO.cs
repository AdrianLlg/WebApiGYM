using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.App.ConsultaClasesPendientesInstructor;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore.App
{
    public class ConsultaClasesPendientesInstructorBO
    {
        public List<ConsultaClasesPendientesInstructorEntity> getClasesPendientes(int personaID)
        {
            List<ConsultaClasesPendientesInstructorEntity> entities = new List<ConsultaClasesPendientesInstructorEntity>();

            entities = getCLasesPendientesDB(personaID);

            return entities;
        }
         
        private List<ConsultaClasesPendientesInstructorEntity> getCLasesPendientesDB(int personaID)
        {
            List<ConsultaClasesPendientesInstructorEntity> listaClasesPendientes = new List<ConsultaClasesPendientesInstructorEntity>();

            try
            { 
                
                using (var dbContext = new GYMDBEntities())
                { 
                    string query = string.Format(ScriptsGYMDB.getClasesPendientesInstructor,personaID );
                    listaClasesPendientes = dbContext.Database.SqlQuery<ConsultaClasesPendientesInstructorEntity>(query).ToList();
                    
                }
                return listaClasesPendientes;
            }
            catch (Exception ex)
            { 
                return listaClasesPendientes ;
            } 
        }
    }
}
