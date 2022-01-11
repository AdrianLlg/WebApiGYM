using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WebAPIBusiness.Entities.EventoPersona;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class RegistrarAsistenciaEventoPersonaBO
    {
        //Método  para verificar si el instructor puede gnerar el codigo QR
        public bool GenerarQRInstructor(int eventoID)
        {
            bool check = false;

            try
            {
                check = validarEvento(eventoID);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un erro al ejecutar el proceso");
            }
            return check;

        }
        public string registrarAsistenciaPersona(int eventoID, int personaID)
        {
            string mensaje = string.Empty;

            try
            {
                mensaje = registrarAsistenciaPersonaDB(eventoID, personaID);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al registrar asistencia");
            }

            return mensaje;
        }

        private string registrarAsistenciaPersonaDB(int eventoID, int personaID)
        {
            string mensaje = string.Empty;
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    var resultado = dbContext.evento_persona.Where(x => x.eventoID == eventoID && x.personaID == personaID).FirstOrDefault();
                    if (resultado == null)
                    {
                        mensaje = "Usted no está registrado en este evento";
                        return mensaje;
                    }
                    else
                    {
                        if (validarEvento(eventoID))
                        {
                            resultado.asistencia = 1;
                            dbContext.SaveChanges();
                            mensaje = "Usted ha sido registrado en este evento !!!";
                            return mensaje;
                        }
                        else
                        {
                            mensaje = "El horario para registrar su asistencia no es valido";
                            return mensaje;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                return mensaje;
                throw new Exception("Ocurrió un error al registrar asistencia");
            }
        }

        private bool validarEvento(int eventoID)
        {
            bool valido = false;
            evento eventoDB = new evento();
            horarioM horarioM = new horarioM();
            DateTime Hoy = DateTime.Now;
            DateTime fechaInicio;
            DateTime fechaFin;
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    eventoDB = dbContext.evento.Where(x => x.eventoID == eventoID).FirstOrDefault();
                    fechaInicio = DateTime.ParseExact(eventoDB.fecha.ToString("yyyy-MM-dd") + " " + eventoDB.horarioM.horaInicio, "yyyy-MM-dd HHmm", CultureInfo.InvariantCulture);
                    fechaFin = DateTime.ParseExact(eventoDB.fecha.ToString("yyyy-MM-dd") + " " + eventoDB.horarioM.horaFin, "yyyy-MM-dd HHmm", CultureInfo.InvariantCulture);

                    if (eventoDB == null)
                    {
                        valido = false;
                        return valido;
                    }
                    else
                    {
                        

                        if (Hoy >= fechaInicio && Hoy<= fechaFin && eventoDB.fecha.Date == Hoy.Date)
                        {
                            valido = true;
                            return valido;
                        }
                        else
                        {
                            valido = false;
                            return valido;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                valido = false;
                return valido;
                throw new Exception("Ocurrió un error al registrar asistencia");
            }
        }




    }
}
