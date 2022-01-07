using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.App.ConsultaEventosDeportista;
using WebAPIBusiness.Entities.App.MembresiasPersona;
using WebAPIBusiness.Entities.ConsultaMailCancelacion;
using WebAPIBusiness.Entities.EventoAdmin;
using WebAPIBusiness.Entities.EventoClasePersona;
using WebAPIBusiness.Entities.SalaAdmin;
using WebAPIBusiness.Resources;
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
                                estadoRegistro = evt.estadoRegistro,
                                personaID = evt.personaID,
                                nombreProfesor = evt.persona.nombres + " " + evt.persona.apellidos
                            };

                            entities.Add(EventosEntity);
                        }
                    }
                }




                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public bool insertEvento(string claseID, string horarioMID, string fecha, string salaID, string aforoMax, string aforoMin, string estadoRegistro, int personaID)
        {
            bool entity = false;

            try
            {
                entity = insertDBEvento(claseID, horarioMID, fecha, salaID, aforoMax, aforoMin, estadoRegistro, personaID);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el usuario/calcular la edad del usuario.");
            }

            return entity;
        }

        private bool insertDBEvento(string claseID, string horarioMID, string fecha, string salaID, string aforoMax, string aforoMin, string estadoRegistro, int personaID)
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
                        estadoRegistro = "A",
                        personaID = personaID,

                    };

                    dbContext.evento.Add(item);
                    dbContext.SaveChanges();
                    var eventoAux = dbContext.evento.Where(x =>
                           x.claseID == item.claseID
                           && x.horarioMID == item.horarioMID
                           && x.fecha == item.fecha
                           && x.salaID == item.salaID).FirstOrDefault();

                    var evento_profesor_Item = new evento_profesor()
                    {
                        eventoID = eventoAux.eventoID,
                        personaID = eventoAux.personaID,
                        asistencia = 0,
                        estadoRegistro = "A",
                        motivo = string.Empty,
                        posibleHorarioRecuperacion = string.Empty

                    };
                    dbContext.evento_profesor.Add(evento_profesor_Item);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifyEvento(int eventoID, string claseID, string horarioMID, string fecha, string salaID, string aforoMax, string aforoMin, int personaID)
        {
            bool entity = false;

            try
            {
                string validation = eventoID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la persona no se ha especificado.");
                }

                entity = UpdateRecord(eventoID, claseID, horarioMID, fecha, salaID, aforoMax, aforoMin, personaID);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el usuario.");
            }

            return entity;
        }

        private bool UpdateRecord(int eventoID, string claseID, string horarioMID, string fecha, string salaID, string aforoMax, string aforoMin, int personaID)
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

                        Evento.personaID = personaID;
                        Evento.fecha = Convert.ToDateTime(fecha);
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
            persona Persona = new persona();
            EventoAdminEntity resp = new EventoAdminEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    Evento = dbContext.evento.Where(x => x.eventoID == eventoID).FirstOrDefault();
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
                            estadoRegistro = Evento.estadoRegistro,
                            personaID = Evento.personaID,
                            nombreProfesor = Evento.persona.nombres + " " + Evento.persona.apellidos
                        };
                    }

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
            List<EventoClasePersonaRecursosEspecialesEntity> recursosEspecialesList = new List<EventoClasePersonaRecursosEspecialesEntity>();
            int recursoEspecialPersona = 0;
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
                            var asistenciaEvento = dbContext.evento_persona.Where(x => x.eventoID == item.eventoID && x.asistencia == 1 && x.estadoRegistro == "A").Count();

                            var estadoPersona = dbContext.evento_persona.Where(x => x.eventoID == item.eventoID && x.personaID == personaID).FirstOrDefault();

                            var recursosEspeciales = dbContext.evento_recursoEspecial.Where(x => x.eventoID == item.eventoID && x.personaID == 0).ToList();

                            if (estadoPersona == null)
                            {
                                estadoPersona = new evento_persona()
                                {
                                    asistencia = -1,
                                    estadoRegistro = "N",
                                    intentosCancelar = 0
                                };
                            }

                            if (recursosEspeciales.Count > 0)
                            {
                                recursosEspecialesList = new List<EventoClasePersonaRecursosEspecialesEntity>();

                                foreach (var i in recursosEspeciales)
                                {
                                    recursosEspecialesList.Add(new EventoClasePersonaRecursosEspecialesEntity
                                    {
                                        eventoRecursoID = i.evento_recursoEspecialID,
                                        eventoID = i.eventoID,
                                        personaID = i.personaID,
                                        recursoEspecialID = i.recursoEspecialID,
                                        nombreRecurso = i.recursoEspecial.nombre,
                                        descripcionRecurso = i.recursoEspecial.descripcion
                                    });
                                }

                                recursoEspecialPersona = dbContext.evento_recursoEspecial.Where(x => x.eventoID == item.eventoID && x.personaID == personaID).Select(x => x.evento_recursoEspecialID).FirstOrDefault();

                            }
                            else
                            {
                                recursosEspecialesList = null;
                            }

                            resp.Add(new EventosDeportistaEntity()
                            {
                                eventoID = item.eventoID,
                                instructorID = item.personaID,
                                nombreInstructor = item.persona.nombres + " " + item.persona.apellidos,
                                disciplina = item.clase.disciplina.nombre,
                                horaInicioEvento = item.horarioM.horaInicio,
                                horaFinEvento = item.horarioM.horaFin,
                                sala = item.sala.nombre,
                                fecha = item.fecha.ToString("yyyy-MM-dd"),
                                aforoMax = item.aforoMax,
                                aforoMin = item.aforoMin,
                                asistenciaEvento = asistenciaEvento,
                                asistenciaPersona = estadoPersona.asistencia,
                                estadoInscripcion = estadoPersona.estadoRegistro,
                                intentosCancelar = estadoPersona.intentosCancelar,
                                recursosEspeciales = recursosEspecialesList,
                                recursoEspecialPersona = recursoEspecialPersona
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
        public bool RegisterEventUser(int personaID, int eventoID, string estado, int recursoAsignado, bool recursosEvento)
        {
            bool insertData = false;
            int eventDiscipline = 0;
            try
            {
                if (personaID > 0 && eventoID > 0)
                {
                    eventDiscipline = getEventDiscipline(eventoID);

                    if (eventDiscipline > 0)
                    {
                        int membresiaPersonaDisciplina = PersonMemberships(personaID, eventDiscipline);

                        if (membresiaPersonaDisciplina > 0)
                        {
                            insertData = InsertEventUser(personaID, eventoID, estado, recursoAsignado, recursosEvento, membresiaPersonaDisciplina);
                        }
                        else
                        {
                            throw new ValidationAndMessageException("No se encontró una membresia ligada al usuario para vincularlo con el evento.");
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new ValidationAndMessageException("Los IDs proporcionados son incorrectos.");
                }
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }

            return insertData;
        }

        private bool InsertEventUser(int personaID, int eventoID, string estado, int recursoAsignadoID, bool recursosEvento, int membresiaPersonaDisciplinaID)
        {
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    dbContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    var record = dbContext.evento_persona
                                    .Where(x => x.personaID == personaID && x.eventoID == eventoID)
                                    .FirstOrDefault();

                    if (record == null)
                    {
                        if (recursosEvento)
                        {
                            var recurso = dbContext.evento_recursoEspecial.Where(x => x.evento_recursoEspecialID == recursoAsignadoID).FirstOrDefault();

                            recurso.personaID = personaID;
                            dbContext.SaveChanges();
                        }

                        evento_persona obj = new evento_persona
                        {
                            eventoID = eventoID,
                            personaID = personaID,
                            asistencia = 1,
                            estadoRegistro = "A",
                            membresia_persona_disciplinaID = membresiaPersonaDisciplinaID
                        };

                        dbContext.evento_persona.Add(obj);
                        dbContext.SaveChanges();

                        var membresiaPDObj = dbContext.membresia_persona_disciplina.Where(x => x.membresia_persona_disciplinaID == membresiaPersonaDisciplinaID).FirstOrDefault();

                        membresiaPDObj.numClasesDisponibles = membresiaPDObj.numClasesDisponibles - 1;
                        membresiaPDObj.numClasesTomadas = membresiaPDObj.numClasesTomadas + 1;
                        dbContext.SaveChanges();

                        return true;
                    }
                    else
                    {
                        //Cancelacion de una inscripcion
                        var canCancelDate = dbContext.configuraciones_Sistema.Where(x => x.NombreConfiguracion == "politicasCancelacion").Select(x => x.Valor).FirstOrDefault();
                        var canCancelClasses = dbContext.configuraciones_Sistema.Where(x => x.NombreConfiguracion == "LimiteClasesCanceladas").Select(x => x.Valor).FirstOrDefault();

                        int val = int.Parse(canCancelDate);
                        int canCancel = int.Parse(canCancelClasses);

                        if (estado == "C")
                        {
                            if (!string.IsNullOrEmpty(canCancelDate))
                            {
                                DateTime hoy = DateTime.Now;

                                var recordHoraI = dbContext.evento.Where(x => x.eventoID == eventoID).FirstOrDefault();

                                DateTime fechaInicio = DateTime.ParseExact(recordHoraI.fecha.ToString("yyyy-MM-dd") + " " + recordHoraI.horarioM.horaInicio, "yyyy-MM-dd HHmm", CultureInfo.InvariantCulture);

                                fechaInicio = fechaInicio.AddHours(-val);

                                if (hoy <= fechaInicio)
                                {                                  
                                    if (record.intentosCancelar < canCancel)
                                    {
                                        if (recursosEvento)
                                        {
                                            var recursoEspecial = dbContext.evento_recursoEspecial.Where(x => x.evento_recursoEspecialID == recursoAsignadoID).FirstOrDefault();

                                            recursoEspecial.personaID = 0;
                                            record.estadoRegistro = "C";
                                            record.intentosCancelar = record.intentosCancelar + 1;
                                            record.membresia_persona_disciplina.numClasesDisponibles = record.membresia_persona_disciplina.numClasesDisponibles + 1;
                                            record.membresia_persona_disciplina.numClasesTomadas = record.membresia_persona_disciplina.numClasesTomadas - 1; 
                                            record.asistencia = 0;
                                            dbContext.SaveChanges();

                                            return true;
                                        }
                                        else
                                        {
                                            record.estadoRegistro = "C";
                                            record.intentosCancelar = record.intentosCancelar + 1;
                                            record.membresia_persona_disciplina.numClasesDisponibles = record.membresia_persona_disciplina.numClasesDisponibles + 1;
                                            record.membresia_persona_disciplina.numClasesTomadas = record.membresia_persona_disciplina.numClasesTomadas - 1;
                                            record.asistencia = 0;
                                            dbContext.SaveChanges();

                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        throw new ValidationAndMessageException("IntentosCancelar");
                                    }
                                }
                                else
                                {
                                    throw new ValidationAndMessageException("HorarioCancelar");
                                }
                            }
                            else
                            {
                                throw new ValidationAndMessageException("Ha ocurrido un error al consultar las politicas de cancelacion.");
                            }
                        }
                        else if (estado == "A")
                        {
                            
                                if (recursosEvento)
                                {
                                    var recursoEspecial = dbContext.evento_recursoEspecial.Where(x => x.evento_recursoEspecialID == recursoAsignadoID).FirstOrDefault();

                                    recursoEspecial.personaID = personaID;
                                    dbContext.SaveChanges();
                            }

                                record.membresia_persona_disciplina.numClasesDisponibles = record.membresia_persona_disciplina.numClasesDisponibles - 1;
                                record.membresia_persona_disciplina.numClasesTomadas = record.membresia_persona_disciplina.numClasesTomadas + 1;
                                record.estadoRegistro = "A";
                                record.asistencia = 1;
                                dbContext.SaveChanges();

                                return true;                           
                        }
                        else
                        {
                            throw new ValidationAndMessageException("El estado proporcionado no es valido.");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }
        }
        #endregion

        public bool eliminarEvento(int eventoID)
        {
            bool resp = false;

            resp = EliminarInfo(eventoID);

            return resp;
        }




        private bool EliminarInfo(int eventoID)
        {

            EventoAdminEntity resp = new EventoAdminEntity();
            //FKS:
            //evento
            //eventoRecurso
            //eventoRecursoEspecial
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    var evento = dbContext.evento.Where(x => x.eventoID == eventoID).FirstOrDefault();

                    var eventoPersonaLS = dbContext.evento_persona.ToList();
                    bool hasEventoPersona = eventoPersonaLS.Any(x => x.eventoID == eventoID);

                    if (evento != null)
                    {
                        if (hasEventoPersona == false)
                        {
                            dbContext.evento.Remove(evento);
                            dbContext.SaveChanges();
                            return true;
                        }

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

        public bool inactivarEvento(int eventoID)
        {
            bool resp = false;


            resp = InactivarInfo(eventoID);
            

            return resp;
        }

        private bool InactivarInfo(int eventoID)
        {

            evento evento = new evento();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    evento = dbContext.evento.Where(x => x.eventoID == eventoID).FirstOrDefault();

                    if (evento != null)
                    {
                        if (evento.estadoRegistro == "A")
                        {
                            evento.estadoRegistro = "I";
                            enviarCorreoCancelacion(eventoID);
                        }
                        else if (evento.estadoRegistro == "I")
                        {
                            evento.estadoRegistro = "A";
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
         
        private void enviarCorreoCancelacion(int eventoID)
        {
            List<ConsultaMailCancelacionEntity> consulta;
            bool evtCheck= false;

            using (var dbContext = new GYMDBEntities())
            {
                string query = string.Format(ScriptsGYMDB.getEventMail, eventoID);
                consulta = dbContext.Database.SqlQuery<ConsultaMailCancelacionEntity>(query).ToList();
                 evtCheck = dbContext.evento.Where(x=>x.eventoID==eventoID && x.estadoRegistro=="I").Any();
            }
            
            foreach (var c in consulta) 
            {
                using (MailMessage mail = new MailMessage())
                {

                    mail.From = new MailAddress("rootacc.2022@gmail.com"); mail.To.Add(c.email);
                    mail.Subject = "Evento Cancelado: " + c.clase + "  " + c.horario;
                    mail.Body =
                        "<h1 style=\"color:#93E9BE\" > Evento Cancelado:</h1>" +
                        "</br>" +
                        "</br>"+
                        "<p>Estimado " + c.nombres + ",</p>" +
                        "</br>" +
                        "<p>La clase de " + c.clase + " programada para el  " + c.fecha.ToShortDateString() + " en el horario de " + c.horario +
                        " ha sido cancelada.Se le ha retornado esta clase.</p>" +
                        "</br>" +
                        "<p>Gracias por su comprensión</p>"
                        ;

                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("rootacc.2022@gmail.com", "masteruser");
                        smtp.EnableSsl = true; smtp.Send(mail);

                    }
                }


            }
        }

        public int PersonMemberships(int personaID, int eventDiscipline)
        {
            try
            {
                int response = 0;

                using (var dbContext = new GYMDBEntities())
                {
                    dbContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    var items = dbContext.membresia_persona_pago.Where(x => x.personaID == personaID && x.estado == "A").OrderBy(x => x.membresia_persona_pagoID).ToList();

                    if (items.Count > 0)
                    {
                        foreach (var item in items)
                        {
                            response = dbContext.membresia_persona_disciplina
                                .Where(x => x.membresia_persona_pagoID == item.membresia_persona_pagoID 
                                    && x.estado == "A" 
                                    && x.membresia_disciplina.disciplinaID == eventDiscipline)
                                .Select(x => x.membresia_persona_disciplinaID)
                                .FirstOrDefault();
                            
                            if (response > 0)
                            {
                                return response;
                            }
                        }

                        return response;
                    }
                    else
                    {
                        return response;
                    }
               }
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }

        }

        public int getEventDiscipline(int eventoID)
        {
            int response = 0;

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    response = dbContext.evento.Where(x => x.eventoID == eventoID).Select(x => x.clase.disciplinaID).FirstOrDefault();

                    return response;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
