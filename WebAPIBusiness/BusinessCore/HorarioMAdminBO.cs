using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIData;
using WebAPIBusiness.Entities.HorarioMAdmin;

namespace WebAPIBusiness.BusinessCore
{
    public class HorarioMAdminBO
    {
        public List<HorarioMAdminEntity> getHorarioM()
        {
            List<HorarioMAdminEntity> entities = new List<HorarioMAdminEntity>();

            entities = getHorarioMDB();

            return entities;
        }

        private List<HorarioMAdminEntity> getHorarioMDB()
        {
            List<HorarioMAdminEntity> entities = new List<HorarioMAdminEntity>();
            List<horarioM> HorarioM = new List<horarioM>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    HorarioM = dbContext.horarioM.ToList();
                }

                if (HorarioM.Count > 0)
                {
                    foreach (var HM in HorarioM)
                    {
                        HorarioMAdminEntity HorarioMEntity = new HorarioMAdminEntity()
                        {
                            horarioMID = HM.horarioMID,
                            horaInicio = HM.horaInicio,
                            horaFin = HM.horaFin                           
                        };

                        entities.Add(HorarioMEntity);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public bool insertHorarioM(string horaInicio, string horaFin)
        {
            bool entity = false;

            try
            {
                entity = insertDBHorarioM(horaInicio, horaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el usuario/calcular la edad del usuario.");
            }

            return entity;
        }

        private bool insertDBHorarioM(string horaInicio, string horaFin)
        {
            horarioM item = new horarioM();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new horarioM()
                    {
                       horaInicio = horaInicio,
                       horaFin = horaFin
                    };

                    dbContext.horarioM.Add(item);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifyHorarioM(int HorarioMID, string horaInicio, string horaFin)
        {
            bool entity = false;

            try
            {
                string validation = HorarioMID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la persona no se ha especificado.");
                }

                entity = UpdateRecord(HorarioMID, horaInicio, horaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el usuario.");
            }

            return entity;
        }

        private bool UpdateRecord(int HorarioMID, string horaInicio, string horaFin)
        {
            bool resp = false;
            horarioM HorarioM = new horarioM();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    HorarioM = dbContext.horarioM.Where(x => x.horarioMID == HorarioMID).FirstOrDefault();

                    if (HorarioM != null)
                    {
                        if (!string.IsNullOrEmpty(horaInicio))
                        {
                            HorarioM.horaInicio = horaInicio;
                        }
                        if (!string.IsNullOrEmpty(horaFin))
                        {
                            HorarioM.horaFin = horaFin;
                        }                       
                    }
                    else
                    {
                        return false;
                    }
                    dbContext.SaveChanges();
                    return true; 
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public HorarioMAdminEntity consultarHorarioM(int HorarioMID)
        {
            HorarioMAdminEntity resp = new HorarioMAdminEntity();

            resp = getHorarioMInfo(HorarioMID);

            return resp;
        }


        private HorarioMAdminEntity getHorarioMInfo(int HorarioMID)
        {
            horarioM HorarioM = new horarioM();
            HorarioMAdminEntity resp = new HorarioMAdminEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    HorarioM = dbContext.horarioM.Where(x => x.horarioMID == HorarioMID).FirstOrDefault();
                }

                if (HorarioM != null)
                {
                    resp = new HorarioMAdminEntity()
                    {
                       horarioMID = HorarioM.horarioMID,
                       horaInicio = HorarioM.horaInicio,
                       horaFin = HorarioM.horaFin
                    };
                }

                return resp;
            }
            catch (Exception ex)
            {
                return resp;
            }
        }
    }
}
