using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.App.ConsultaHistorialAsistenciaCliente;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore
{
    public class ConsultaHistorialAsistenciaClienteBO
    {
        public List<ConsultaHistorialAsistenciaClienteEntity> getHistorialAsistencia(int personaID)
        {
            List<ConsultaHistorialAsistenciaClienteEntity> entities = new List<ConsultaHistorialAsistenciaClienteEntity>();

            entities = getHistorialAsitenciaDB(personaID);

            return entities;
        }
         
        private List<ConsultaHistorialAsistenciaClienteEntity> getHistorialAsitenciaDB(int personaID)
        {
            List<ConsultaHistorialAsistenciaClienteEntity> historialAsistencia = new List<ConsultaHistorialAsistenciaClienteEntity>();

            try
            { 
                
                using (var dbContext = new GYMDBEntities())
                { 
                    string query = string.Format(ScriptsGYMDB.getHistorialAsistenciaClienteApp,personaID );
                    historialAsistencia = dbContext.Database.SqlQuery<ConsultaHistorialAsistenciaClienteEntity>(query).ToList();
                    
                }
                return historialAsistencia;
            }
            catch (Exception ex)
            {
                return historialAsistencia ;
            } 
        }
    }
}
