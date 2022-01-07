﻿using System;
using System.Collections.Generic;
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
            int horaInicio = 0;
            int horaFin = 0;
            int horaActual = int.Parse(string.Concat(Hoy.Hour.ToString(), Hoy.Minute.ToString()));

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    eventoDB = dbContext.evento.Where(x => x.eventoID == eventoID).FirstOrDefault();

                    if (eventoDB == null)
                    {
                        valido = false;
                        return valido;
                    }
                    else
                    {
                        horarioM = dbContext.horarioM.Where(x => x.horarioMID == eventoDB.horarioMID).FirstOrDefault();
                        horaInicio = int.Parse(horarioM.horaInicio);
                        horaFin = int.Parse(horarioM.horaFin);

                        if (horaActual >= horaInicio && horaActual <= horaFin && eventoDB.fecha.Date == Hoy.Date)
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
