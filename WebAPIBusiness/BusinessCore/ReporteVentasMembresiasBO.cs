using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.ConsultaVentasMembresias;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore
{
    public class ReporteVentasMembresiasBO
    {
        public List<ConsultaVentasMembresiasEntity> getVentas(string fechaInicio, string fechaFin)
        {
            List<ConsultaVentasMembresiasEntity> entities = new List<ConsultaVentasMembresiasEntity>();

            entities = getVentasMembresias(fechaInicio,fechaFin);
            

            return entities;
        }

        private List<ConsultaVentasMembresiasEntity> getVentasMembresias(string fechaInicio,string fechaFin)
        {

            List<ConsultaVentasMembresiasEntity> consulta = new List<ConsultaVentasMembresiasEntity>();
            DateTime FI= Convert.ToDateTime(fechaInicio);
            DateTime FF=Convert.ToDateTime(fechaFin);
            ConsultaVentasMembresiasEntity item = new ConsultaVentasMembresiasEntity();
            
            
            using (var dbContext = new GYMDBEntities())
            {
                string query = string.Format(ScriptsGYMDB.getVentasMembresias, fechaInicio, fechaFin);
                consulta = dbContext.Database.SqlQuery<ConsultaVentasMembresiasEntity>(query).ToList(); 
            }
            


           
            return consulta;
        }


    }
}


