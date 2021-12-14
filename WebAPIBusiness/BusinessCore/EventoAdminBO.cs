using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.App.ConsultaEventosDeportista;
using WebAPIBusiness.Entities.EventoAdmin;
using WebAPIBusiness.Entities.SalaAdmin;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class EventoAdminBO
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

        public bool insertEvento(string claseID, string horarioMID, string fecha, string salaID, string aforoMax, string aforoMin)
        {
            bool entity = false;

            try
            {
                entity = insertDBEvento(claseID, horarioMID, fecha, salaID, aforoMax, aforoMin);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el usuario/calcular la edad del usuario.");
            }

            return entity;
        }

        private bool insertDBEvento(string claseID, string horarioMID, string fecha, string salaID, string aforoMax, string aforoMin)
        {
            evento item = new evento();

            DateTime fechaF = Convert.ToDateTime(fecha);
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new evento()
                    {
                        claseID = int.Parse(claseID),
                        horarioMID = int.Parse(horarioMID),
                        fecha = fechaF,
                        salaID = int.Parse(salaID),
                        aforoMax = int.Parse(aforoMax),
                        aforoMin = int.Parse(aforoMin),
                    };

                    dbContext.evento.Add(item);
                    dbContext.SaveChanges();
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


        #region ConsultaHorariosDeportista (App)
        public List<EventosDeportistaEntity> getSchedules(int personaID, string fecha)
        {
            List<EventosDeportistaEntity> resp = new List<EventosDeportistaEntity>();
            DateTime date = new DateTime();

            try
            {
                date = Convert.ToDateTime(fecha);
            }
            catch
            {
                throw new ValidationAndMessageException("Ocurrió un error al transformar la fecha.");
            }

            List<int> MembershipSchedules = MembershipValidation(personaID);

            if (MembershipSchedules.Count > 0)
            {
                List<int> classes = getClassesOfDisciplines(MembershipSchedules);

                if (classes.Count > 0)
                {
                    resp = ObtainSchedulesDB(classes, date, personaID);
                }
                else
                {
                    throw new ValidationAndMessageException("No se encontraron clases para la membresia del usuario.");
                }
            }
            else
            {
                throw new ValidationAndMessageException("No se encontraron disciplinas para las membresias del usuario.");
            }

            return resp;
        }

        private List<int> MembershipValidation(int personaID)
        {
            List<int> resp = new List<int>();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    var memberships = dbContext.membresia_persona_pago.Where(x => x.personaID == personaID && x.estado == "A").Select(x => x.membresiaID).ToList();
                    
                    if (memberships.Count > 0)
                    {
                        resp = dbContext.membresia_disciplina.Where(x => memberships.Contains(x.membresiaID)).Select(x => x.disciplinaID).Distinct().ToList();
                    }
                    else
                    {
                        throw new ValidationAndMessageException("La persona no tiene membresias activas.");
                    }

                    return resp;
                }
            }
            catch (Exception ex)
            {
                return resp;
            }
        }

        private List<int> getClassesOfDisciplines(List<int> MembershipSchedules)
        {
            List<int> resp = new List<int>();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    dbContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                    resp = dbContext.clase.Where(x => MembershipSchedules.Contains(x.disciplinaID)).Select(x => x.claseID).ToList();
                }

                return resp;
            }
            catch (Exception ex)
            {
                return resp;
            }
        }
        private List<EventosDeportistaEntity> ObtainSchedulesDB(List<int> classes, DateTime fecha, int personaID)
        {
            List<EventosDeportistaEntity> resp = new List<EventosDeportistaEntity>();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    dbContext.Database.Log = log => System.Diagnostics.Debug.WriteLine(log);

                    var query = dbContext.evento.Where(x => x.fecha == fecha && classes.Contains(x.claseID)).ToList();

                    if (query.Count > 0)
                    {
                        foreach (var item in query)
                        {
                            var asistencia = dbContext.evento_persona.Where(x => x.eventoID == item.eventoID && x.asistencia == 1 && x.estadoRegistro == "A").Count();

                            var estadoInscripcion = dbContext.evento_persona.Where(x => x.eventoID == item.eventoID && x.personaID == personaID).Select(x => x.estadoRegistro).FirstOrDefault();

                            if (string.IsNullOrEmpty(estadoInscripcion))
                            {
                                estadoInscripcion = string.Empty;
                            }

                            resp.Add(new EventosDeportistaEntity() {
                            
                            eventoID = item.eventoID,
                            disciplina = item.clase.disciplina.nombre,
                            horaInicioEvento = item.horarioM.horaInicio,
                            horaFinEvento = item.horarioM.horaFin,
                            sala = item.sala.nombre,
                            fecha = item.fecha.ToString("yyyy-MM-dd"),
                            aforoMax = item.aforoMax,
                            aforoMin = item.aforoMin,
                            asistencia = asistencia,
                            estadoInscripcion = estadoInscripcion
                            });
                        }

                        return resp;
                    }
                    else
                    {
                        throw new ValidationAndMessageException("Al momento no se encontraron sesiones para el usuario consultado.");
                    }

                }
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }
        }

        #endregion

        #region InscripcionUsuarioSesion
        public bool RegisterEventUser(int personaID, int eventoID, string estado)
        {
            bool resp = false;

            bool verifyPreviousRecord = VerifyPreviousEventPerson(personaID, eventoID);

            if (verifyPreviousRecord == false)
            {
                resp = InsertNewEvent_Persona(personaID, eventoID);
            }
            else
            {
                resp = ChangeStateEvent_Persona(personaID, eventoID, estado);
            }

            return resp;
        }

        
        private bool InsertNewEvent_Persona(int personaID, int eventoID)
        {
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    dbContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    evento_persona obj = new evento_persona
                    {
                        eventoID = eventoID,
                        personaID = personaID,
                        asistencia = 1,
                        estadoRegistro = "A"
                    };

                    dbContext.evento_persona.Add(obj);
                    dbContext.SaveChanges();

                    return true;

                }
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }
        }
        private bool VerifyPreviousEventPerson(int personaID, int eventoID)
        {
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    dbContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    var record = dbContext.evento_persona
                                    .Where(x => x.personaID == personaID && x.eventoID == eventoID) 
                                    .Count();

                    if (record == 1)
                    {
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
                throw new ValidationAndMessageException(ex.Message);
            }
        }

        private bool ChangeStateEvent_Persona(int personaID, int eventoID, string estado)
        {
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    dbContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    var obj = dbContext.evento_persona.Where(x => x.eventoID == eventoID && x.personaID == personaID).FirstOrDefault();

                    if (obj != null)
                    {
                        if (estado == "A")
                        {
                            obj.estadoRegistro = "I";
                        }
                        else
                        {
                            obj.estadoRegistro = "A";
                        }

                        dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new ValidationAndMessageException("Ocurrio un error en el manejo de la BDD.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }
        }
        #endregion
    }
}
