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

        public List<EventoClasePersonaEntity> ConsultarHorario(string personaID,string fecha)
        {
            List<EventoClasePersonaEntity> eventosClasePersona = getConsultarHorarios(personaID,fecha);

            return eventosClasePersona;
        }

        private List<EventoClasePersonaEntity> getConsultarHorarios(string personaID,string fecha)
        {
            
            try
            {
                DateTime hoy = DateTime.Now;
                List<EventoClasePersonaEntity> eventosClasePersona = new List<EventoClasePersonaEntity>();

                int personID = int.Parse(personaID);


                using (var dbContext = new GYMDBEntities())
                {
                    var query = dbContext.evento_persona.Where(x => x.personaID == personID && x.estadoRegistro == "A").ToList();


                    if (query.Count > 0)
                    {
                        foreach (var item in query)
                        {

                            var asistentes = dbContext.evento_persona.Where(x => x.eventoID == item.eventoID && x.asistencia == 1 && x.estadoRegistro == "A").ToList().Count;

                            eventosClasePersona.Add(new EventoClasePersonaEntity { 
                            
                                EventoID = item.eventoID,
                                NombreInstructor = item.evento.persona.nombres + " "+ item.evento.persona.apellidos,
                                Sala = item.evento.sala.nombre,
                                AforoMaximoClase = item.evento.aforoMax,
                                fecha = item.evento.fecha,
                                Asistentes = asistentes,
                                
                            
                            });
                        }
                    }
                    else
                    {
                        throw new ValidationAndMessageException("NoAgendamientos");
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
