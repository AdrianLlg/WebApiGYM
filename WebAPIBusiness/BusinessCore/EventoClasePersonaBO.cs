using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.EventoClasePersona;
using WebAPIBusiness.Resources;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class EventoClasePersonaBO { 

        public List<EventoClasePersonaEntity> ConsultarHorario(int personaID)
        {
            List<EventoClasePersonaEntity> eventosClasePersona = getConsultarHorarios(personaID);

            return eventosClasePersona;
        }

        private List<EventoClasePersonaEntity> getConsultarHorarios(int personaID)
        {
            
            try
            {
                DateTime hoy = DateTime.Now;
                var recEspecial = string.Empty;

                List<EventoClasePersonaEntity> eventosClasePersona = new List<EventoClasePersonaEntity>();

                using (var dbContext = new GYMDBEntities())
                {
                    dbContext.Database.Log = log => System.Diagnostics.Debug.WriteLine(log);

                    var query = dbContext.evento_persona.Where(x => x.personaID == personaID && x.estadoRegistro == "A" && x.evento.fecha > hoy).ToList();

                    if (query.Count > 0)
                    {
                        foreach (var item in query)
                        {
                            var asistentes = dbContext.evento_persona.Where(x => x.eventoID == item.eventoID && x.asistencia == 1 && x.estadoRegistro == "A").ToList().Count;

                            var recursoEspecial = dbContext.evento_recursoEspecial.Where(x => x.personaID == personaID && x.eventoID == item.eventoID).FirstOrDefault();

                            if (recursoEspecial != null)
                            {
                                recEspecial = recursoEspecial.recursoEspecial.nombre + "-" + recursoEspecial.recursoEspecial.descripcion;
                            }

                            eventosClasePersona.Add(new EventoClasePersonaEntity { 
                            
                                EventoID = item.eventoID,
                                NombreInstructor = item.evento.persona.nombres + " "+ item.evento.persona.apellidos,
                                Sala = item.evento.sala.nombre,
                                AforoMaximoClase = item.evento.aforoMax,
                                fecha = item.evento.fecha.ToString("yyyy-MM-dd"),
                                Asistentes = asistentes,
                                recursoEspecial = recEspecial,
                                horaInicio = item.evento.horarioM.horaInicio,
                                horaFin = item.evento.horarioM.horaFin,
                                Disciplina = item.evento.clase.disciplina.nombre,
                                AforoMinimoClase = item.evento.aforoMin                                
                            });
                        }
                    }
                    else
                    {
                       return eventosClasePersona = new List<EventoClasePersonaEntity>();
                    }

                }

                return eventosClasePersona;
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }
        }

        
    }
}
