using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.App.ConsultaListaAsistencia;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore
{
    public class ConsultaListaAsistenciaBO
    {
        public List<ConsultaListaAsistenciaEntity> getListaAsistencia(int eventoID)
        {
            List<ConsultaListaAsistenciaEntity> entities = new List<ConsultaListaAsistenciaEntity>();

            entities = getAsistenciaEventoDB(eventoID);

            return entities;
        }
         
        private List<ConsultaListaAsistenciaEntity> getAsistenciaEventoDB(int eventoID)
        {
            List<ConsultaListaAsistenciaEntity> listaAsistencia = new List<ConsultaListaAsistenciaEntity>();

            try
            { 
                
                using (var dbContext = new GYMDBEntities())
                { 
                    string query = string.Format(ScriptsGYMDB.getListaAsistenciaApp,eventoID );
                    listaAsistencia = dbContext.Database.SqlQuery<ConsultaListaAsistenciaEntity>(query).ToList();
                    
                }
                return listaAsistencia;
            }
            catch (Exception ex)
            {
                return listaAsistencia ;
            } 
        }
    }
}
