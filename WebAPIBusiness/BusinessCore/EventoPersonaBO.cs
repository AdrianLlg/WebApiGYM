using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.EventoPersona;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class EventoPersonaBO
    {
        public List<EventoPersonaEntity> getEventoPersona()
        {
            List<EventoPersonaEntity> entities = new List<EventoPersonaEntity>();

            entities = getEventoPersonaDB();

            return entities;
        }

        private List<EventoPersonaEntity> getEventoPersonaDB()
        {
            List<EventoPersonaEntity> entities = new List<EventoPersonaEntity>();
            List<evento_persona> EventoPersonas = new List<evento_persona>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    EventoPersonas = dbContext.evento_persona.ToList();
                }

                if (EventoPersonas.Count > 0)
                {
                    foreach (var evtp in EventoPersonas)
                    {
                        EventoPersonaEntity EventosEntity = new EventoPersonaEntity()
                        {

                            evento_personaID = evtp.evento_personaID,
                            eventoID = evtp.eventoID,
                            personaID = evtp.personaID,
                            asistencia = evtp.asistencia,
                            estadoRegistro=evtp.estadoRegistro

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

        public bool insertEventoPersona(int eventoID, int personaID, int asistencia)
        {
            bool entity = false;

            try
            {
                entity = insertDBEventoPersona(eventoID, personaID, asistencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el usuario/calcular la edad del usuario.");
            }

            return entity;
        }

        private bool insertDBEventoPersona(int eventoID, int personaID, int asistencia)
        {
            evento_persona item = new evento_persona();


            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new evento_persona()
                    {
                        eventoID = eventoID,
                        personaID = personaID,
                        asistencia = asistencia,
                        estadoRegistro="A"
                    };

                    dbContext.evento_persona.Add(item);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifyEventoPersona(int evento_personaID, int eventoID, int personaID, int asistencia)
        {
            bool entity = false;

            try
            {
                string validation = eventoID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la persona no se ha especificado.");
                }

                entity = UpdateRecord(evento_personaID, eventoID, personaID, asistencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el usuario.");
            }

            return entity;
        }

        private bool UpdateRecord(int evento_personaID, int eventoID, int personaID, int asistencia)
        {
            bool resp = false;
            evento_persona EventoPersona = new evento_persona();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    EventoPersona = dbContext.evento_persona.Where(x => x.eventoID == eventoID && x.personaID==personaID).FirstOrDefault();

                    if (EventoPersona != null)
                    {
                         
                        EventoPersona.asistencia = asistencia;
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }
                  
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public EventoPersonaEntity consultarEventoPersona(int eventoID)
        {
            EventoPersonaEntity resp = new EventoPersonaEntity();

            resp = getEventoPersonaInfo(eventoID);

            return resp;
        }


        private EventoPersonaEntity getEventoPersonaInfo(int evento_personaID)
        {
            evento_persona ep = new evento_persona();
            EventoPersonaEntity resp = new EventoPersonaEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    ep = dbContext.evento_persona.Where(x => x.evento_personaID == evento_personaID).FirstOrDefault();
                }

                if (ep != null)
                {
                    resp = new EventoPersonaEntity()
                    {
                        eventoID = ep.eventoID,
                        personaID = ep.personaID,
                        asistencia = ep.eventoID,
                        estadoRegistro=ep.estadoRegistro
                    };
                }

                return resp;
            }
            catch (Exception ex)
            {
                return resp;
            }
        }

        public bool eliminarEventoPersona(int eventoPersonaID)
        {
            bool resp = false;

            resp = EliminarInfo(eventoPersonaID);

            return resp;
        }




        private bool EliminarInfo(int eventoPersonaID)
        {

            EventoPersonaEntity resp = new EventoPersonaEntity();
            //FKS:
            //evento
            //eventoPersonaRecurso
            //eventoPersonaRecursoEspecial
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    var eventoPersona = dbContext.evento_persona.Where(x => x.evento_personaID == eventoPersonaID).FirstOrDefault();


                    if (eventoPersona != null)
                    {
                        dbContext.evento_persona.Remove(eventoPersona);
                        dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
