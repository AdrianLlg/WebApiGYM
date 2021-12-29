﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.ConsultaHorarios;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore
{
    public class ConsultaHorariosBO
    {
        public List<ConsultaHorariosModel> getHorarios(string fechaInicio,string fechaFin, List<SalaEntity> salas)
        {
            List<ConsultaHorariosModel> entities = new List<ConsultaHorariosModel>();

            entities = getHorariosDB(fechaInicio,fechaFin,salas);

            return entities;
        }

        private List<ConsultaHorariosModel> getHorariosDB(string fechaInicio, string fechaFin, List<SalaEntity> salas)
        {
           
            List<ConsultaHorariosModel> horariosConsultados= new List<ConsultaHorariosModel>();
            List<ConsultaHorariosModel> horariosDisponibles = new List<ConsultaHorariosModel>();
            ConsultaHorariosModel horarioaux = new ConsultaHorariosModel();
            List<horarioM> HorariosM = new List<horarioM>();


            try
            {
                DateTime fechaDB = Convert.ToDateTime(fechaInicio);
                DateTime fechaFinDB = Convert.ToDateTime(fechaFin);
                using (var dbContext = new GYMDBEntities())
                { 
                    string query = string.Format(ScriptsGYMDB.getHorariosFecha, fechaInicio,fechaFin );
                    horariosConsultados = dbContext.Database.SqlQuery<ConsultaHorariosModel>(query).ToList();
                    HorariosM = dbContext.horarioM.ToList();
                }

                while (fechaDB <= fechaFinDB)
                {
                    foreach(SalaEntity saladb in salas)
                    {
                        foreach (horarioM horariodb in HorariosM)
                        {
                            horarioaux = horariosConsultados.Where(x => x.fecha == fechaDB && x.horarioMID == horariodb.horarioMID && x.salaID == saladb.salaID).FirstOrDefault();
                            if(horarioaux == null)
                            {
                                horarioaux = new ConsultaHorariosModel()
                                {
                                    fecha = fechaDB,
                                    horarioMID = horariodb.horarioMID,
                                    salaID = saladb.salaID
                                };
                                horariosDisponibles.Add(horarioaux);
                            }

                        }
                    }
                    fechaDB = fechaDB.AddDays(1);
                }


                return horariosDisponibles;
            }
            catch (Exception ex)
            {
                return horariosDisponibles;
            }
        }
    }
}