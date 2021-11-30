using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.ReporteGeneralAsistencia;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore
{
    public class ReporteGeneralAsistenciaBO
    {

        List<ReporteGeneralAsistenciaCNAEntity> CNA = new List<ReporteGeneralAsistenciaCNAEntity>();
        List<ReporteGeneralAsistenciaCAEntity> CA = new List<ReporteGeneralAsistenciaCAEntity>();
        List<ReporteGeneralAsistenciaEntity> consulta = new List<ReporteGeneralAsistenciaEntity>();

        public List<ReporteGeneralAsistenciaEntity> getAsistencia(int personaID,string fechaInicio, string fechaFin)
        {
            List<ReporteGeneralAsistenciaEntity> entities = new List<ReporteGeneralAsistenciaEntity>();

            entities = getAsistenciaDB(personaID,fechaInicio, fechaFin);


            return entities;
        }

        private List<ReporteGeneralAsistenciaEntity> getAsistenciaDB(int personaID,string fechaInicio, string fechaFin)
        {



            DateTime FI = Convert.ToDateTime(fechaInicio);
            DateTime FF = Convert.ToDateTime(fechaFin);
            ReporteGeneralAsistenciaEntity item = new ReporteGeneralAsistenciaEntity();


            using (var dbContext = new GYMDBEntities())
            {
                string query = string.Format(ScriptsGYMDB.getReporteAsistenciaLog,personaID, fechaInicio, fechaFin);


                consulta = dbContext.Database.SqlQuery<ReporteGeneralAsistenciaEntity>(query).ToList();


            }


            for (int i = 0; i < consulta.Count; i++)
            {
                using (var dbContext = new GYMDBEntities())
                {
                    string query2 = string.Format(ScriptsGYMDB.getReporteGeneralAsistenciaCA, personaID, fechaInicio, fechaFin);
                    string query3 = string.Format(ScriptsGYMDB.getReporteGeneralAsistenciaCNA, personaID, fechaInicio, fechaFin);
                    CA = dbContext.Database.SqlQuery<ReporteGeneralAsistenciaCAEntity>(query2).ToList();
                    CNA = dbContext.Database.SqlQuery<ReporteGeneralAsistenciaCNAEntity>(query3).ToList();

                }
            }
             

            
                for (int i=0;i<consulta.Count;i++)
                {
                consulta[i].clasesAsistidas = CA;
                consulta[i].clasesNoAsistidas = CNA;
                
                    
                }




            return consulta;
        }


    }
}


