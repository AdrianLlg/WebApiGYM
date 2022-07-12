using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.Entities.HorarioAdmin;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class HorarioAdminBO
    {
        public List<HorarioAdminEntity> getHorarios()
        {
            List<HorarioAdminEntity> entities = new List<HorarioAdminEntity>();

            entities = getHorarioDB();

            return entities;
        }

        private List<HorarioAdminEntity> getHorarioDB()
        {
            List<HorarioAdminEntity> entities = new List<HorarioAdminEntity>();
            List<horarioM> Horarios = new List<horarioM>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    Horarios = dbContext.horarioM.ToList();
                }

                if (Horarios.Count > 0)
                {
                    foreach (var Horario in Horarios)
                    {
                        HorarioAdminEntity HorariosEntity = new HorarioAdminEntity()
                        {
                            horarioMID = Horario.horarioMID,
                            horaInicio = Horario.horaInicio,
                            horaFin = Horario.horaFin
                        };

                        entities.Add(HorariosEntity);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public bool insertHorario(string horaInicio, string horaFin)
        {
            bool entity = false;

            try
            {
                entity = insertDBHorario(horaInicio, horaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar");
            }

            return entity;
        }

        private bool insertDBHorario(string horaInicio, string horaFin)
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

        public bool modifyHorario(int HorarioID, string horaInicio, string horaFin)
        {
            bool entity = false;

            try
            {
                string validation = HorarioID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la persona no se ha especificado.");
                }

                entity = UpdateRecord(HorarioID, horaInicio, horaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar.");
            }

            return entity;
        }

        private bool UpdateRecord(int HorarioID, string horaInicio, string horaFin)
        {
            bool resp = false;
            horarioM Horario = new horarioM();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    Horario = dbContext.horarioM.Where(x => x.horarioMID == HorarioID).FirstOrDefault();

                    if (Horario != null)
                    {
                        if (!string.IsNullOrEmpty(horaInicio))
                        {
                            Horario.horaInicio = horaInicio;
                        }
                        if (!string.IsNullOrEmpty(horaFin))
                        {
                            Horario.horaFin = horaFin;
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

        public HorarioAdminEntity consultarHorario(int HorarioID)
        {
            HorarioAdminEntity resp = new HorarioAdminEntity();

            resp = getHorarioInfo(HorarioID);

            return resp;
        }


        private HorarioAdminEntity getHorarioInfo(int HorarioID)
        {
            horarioM Horario = new horarioM();
            HorarioAdminEntity resp = new HorarioAdminEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    Horario = dbContext.horarioM.Where(x => x.horarioMID == HorarioID).FirstOrDefault();
                }

                if (Horario != null)
                {
                    resp = new HorarioAdminEntity()
                    {
                        horarioMID = Horario.horarioMID,
                        horaInicio = Horario.horaInicio,
                        horaFin = Horario.horaFin
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
