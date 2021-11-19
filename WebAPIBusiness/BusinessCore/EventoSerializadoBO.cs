using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.Entities.EventoAdmin;
using WebAPIBusiness.Entities.SalaAdmin;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class EventosSerializadosBO
    {
        public List<EventoAdminEntity> getEventos()
        {
            List<EventoAdminEntity> entities = new List<EventoAdminEntity>();

            entities = getEventoDB();

            return entities;
        }

        private List<EventoAdminEntity> getEventoDB()
        {
            List<EventoAdminEntity> entities = new List<EventoAdminEntity>();
            List<evento> Eventos = new List<evento>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    Eventos = dbContext.evento.ToList();
                }

                if (Eventos.Count > 0)
                {
                    foreach (var evt in Eventos)
                    {
                        EventoAdminEntity EventosEntity = new EventoAdminEntity()
                        {
                            eventoID = evt.eventoID,
                            claseID = evt.claseID.ToString(),
                            horarioMID = evt.horarioMID.ToString(),
                            fecha = evt.fecha.ToString(),
                            salaID = evt.salaID.ToString(),
                            aforoMax = evt.aforoMax.ToString(),
                            aforoMin = evt.aforoMin.ToString(),


                        };

                        entities.Add(EventosEntity);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public bool insertEvento(List<EventoAdminEntity> listaEventos)
        {
            bool entity = false;

            try
            {

                entity = insertDBEvento(listaEventos);

                entity = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el usuario/calcular la edad del usuario.");
            }

            return entity;
        }

        private bool insertDBEvento(List<EventoAdminEntity> listaEventos)
        {
            List<evento> items = new List<evento>();
            evento item = new evento();


            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    for (int i = 0; i < listaEventos.Count; i++)
                    {
                        DateTime fechaF = Convert.ToDateTime(listaEventos[i].fecha);
                        item = new evento()
                        {
                            claseID = int.Parse(listaEventos[i].claseID),
                            horarioMID = int.Parse(listaEventos[i].horarioMID),
                            fecha = fechaF,
                            salaID = int.Parse(listaEventos[i].salaID),
                            aforoMax = int.Parse(listaEventos[i].aforoMax),
                            aforoMin = int.Parse(listaEventos[i].aforoMin),
                        };

                        dbContext.evento.Add(item);
                        dbContext.SaveChanges();
                    }
                }




                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifyEvento(int eventoID, string claseID, string horarioMID, string fecha, string salaID, string aforoMax, string aforoMin)
        {
            bool entity = false;

            try
            {
                string validation = eventoID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la persona no se ha especificado.");
                }

                entity = UpdateRecord(eventoID, claseID, horarioMID, fecha, salaID, aforoMax, aforoMin);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el usuario.");
            }

            return entity;
        }

        private bool UpdateRecord(int eventoID, string claseID, string horarioMID, string fecha, string salaID, string aforoMax, string aforoMin)
        {
            bool resp = false;
            evento Evento = new evento();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    Evento = dbContext.evento.Where(x => x.eventoID == eventoID).FirstOrDefault();

                    if (Evento != null)
                    {
                        if (!string.IsNullOrEmpty(claseID))
                        {
                            Evento.claseID = int.Parse(claseID);
                        }

                        if (!string.IsNullOrEmpty(horarioMID))
                        {
                            Evento.horarioMID = int.Parse(horarioMID);
                        }

                        if (!string.IsNullOrEmpty(salaID))
                        {
                            Evento.salaID = int.Parse(salaID);
                        }
                        if (!string.IsNullOrEmpty(aforoMax))
                        {
                            Evento.aforoMax = int.Parse(aforoMax);
                        }
                        if (!string.IsNullOrEmpty(aforoMin))
                        {
                            Evento.aforoMin = int.Parse(aforoMin);
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

        public EventoAdminEntity consultarEvento(int eventoID)
        {
            EventoAdminEntity resp = new EventoAdminEntity();

            resp = getSalaInfo(eventoID);

            return resp;
        }


        private EventoAdminEntity getSalaInfo(int eventoID)
        {
            evento Evento = new evento();
            EventoAdminEntity resp = new EventoAdminEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    Evento = dbContext.evento.Where(x => x.eventoID == eventoID).FirstOrDefault();
                }

                if (Evento != null)
                {
                    resp = new EventoAdminEntity()
                    {
                        eventoID = Evento.eventoID,
                        claseID = Evento.claseID.ToString(),
                        horarioMID = Evento.horarioMID.ToString(),
                        fecha = Evento.fecha.ToString(),
                        salaID = Evento.salaID.ToString(),
                        aforoMax = Evento.aforoMax.ToString(),
                        aforoMin = Evento.aforoMin.ToString(),
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
