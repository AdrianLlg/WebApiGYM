using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.App.CancelarEventoApp;
using WebAPIBusiness.Entities.ConsultaMailCancelacionApp;
using WebAPIBusiness.Resources;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore.App
{
    public class CancelarEventoAppBO
    {
        public bool inactivarEvento(int eventoID, int personaID, string motivo, string posibleHorarioRecuperacion)
        {
            try
            {
                bool resp = false;

                if (eventoID > 0 && personaID > 0)
                {
                    resp = CancelValidation(eventoID);

                    if (resp)
                    {
                        resp = InactivarInfo(eventoID, personaID, motivo, posibleHorarioRecuperacion);
                    }
                    else
                    {
                        throw new ValidationAndMessageException("FueraDeHorarioCancelar");
                    }


                    return resp;
                }
                else
                {
                    throw new ValidationAndMessageException("Los IDs proporcionados no son válidos.");
                }

            }
            catch
            {
                return false;
            }

        }
        private bool InactivarInfo(int eventoID, int personaID, string motivo, string posibleHorarioRecuperacion)
        {

            evento evento = new evento();
            evento_profesor eventoProfesor = new evento_profesor();
            List<evento_persona> asistentes = new List<evento_persona>();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    evento = dbContext.evento.Where(x => x.eventoID == eventoID).FirstOrDefault();

                    if (evento != null)
                    {
                        eventoProfesor = dbContext.evento_profesor.Where(x => x.personaID == personaID && x.eventoID == eventoID).FirstOrDefault();
                        asistentes = dbContext.evento_persona.Where(x => x.eventoID == eventoID).ToList();

                        if (evento.estadoRegistro == "A")
                        {
                            eventoProfesor.estadoRegistro = "C";
                            eventoProfesor.motivo = motivo;
                            eventoProfesor.posibleHorarioRecuperacion = posibleHorarioRecuperacion;
                            evento.estadoRegistro = "C";

                            foreach (var a in asistentes)
                            {
                                a.estadoRegistro = "C";
                                a.membresia_persona_disciplina.numClasesDisponibles = a.membresia_persona_disciplina.numClasesDisponibles + 1;
                                a.membresia_persona_disciplina.numClasesTomadas = a.membresia_persona_disciplina.numClasesTomadas - 1;
                                a.asistencia = 0;
                                dbContext.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("El evento no existe.");
                    }

                }

                enviarCorreoCancelacion(eventoID, motivo, posibleHorarioRecuperacion);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void enviarCorreoCancelacion(int eventoID, string motivo, string posibleHorarioRecuperacion)
        {
            List<ConsultaMailCancelacionAppEntity> consulta;
            ConsultaMailCancelacionAppEntity profesor;
            List<persona> administradores;
            bool evtCheck = false;

            using (var dbContext = new GYMDBEntities())
            {
                string query = string.Format(ScriptsGYMDB.getConsultaMailCancelacionProfesor, eventoID);
                string query2 = string.Format(ScriptsGYMDB.getConsultaMailCancelacionAlumnos, eventoID);
                profesor = dbContext.Database.SqlQuery<ConsultaMailCancelacionAppEntity>(query).FirstOrDefault();
                consulta = dbContext.Database.SqlQuery<ConsultaMailCancelacionAppEntity>(query2).ToList();
                administradores = dbContext.persona.Where(x => x.rolePID == 1).ToList();
                evtCheck = dbContext.evento.Where(x => x.eventoID == eventoID && x.estadoRegistro == "I").Any();
            }

            //Enviar correo a alumnos
            foreach (var c in consulta)
            {
                using (MailMessage mail = new MailMessage())
                {

                    mail.From = new MailAddress("rootacc.2022@gmail.com"); mail.To.Add(c.email);
                    mail.Subject = "Evento Cancelado: " + c.clase + "  " + c.horario;
                    mail.Body =
                    " <div style=\"border: 1px solid #c3c3c3;border-radius: 10px;padding: 20px;\">" +
                    "     <h1 style=\"color: dodgerblue\">Evento Cancelado</h1>" +
                    "     <hr>" +
                    "     <p><span style=\"font-weight: bold; color: dodgerblue; \">Estimado " + c.nombres + ",</span></p>" +
                    "     <p>La clase de <span style=\"font-weight: bold; color: dodgerblue; \">" + c.clase + "</span> programada para el día   " +
                    "     <span style=\"font-weight: bold; color: dodgerblue; \">" + c.fecha.ToShortDateString() + "</span> en el horario de" +
                    "     <span style=\"font-weight: bold; color: dodgerblue;\"> " + c.horario + "</span> ha sido cancelada por el siguiente motivo:</p>" +
                    "     <p>" + motivo + "</p>" +
                    "     <hr>" +
                    "     <p><span style=\"font-weight: bold; color: dodgerblue; \">La clase se le ha sido retornada.</span></p>" +
                    "     <hr>" +
                    "     <p>Gracias por su comprensión.</p>" +
                    "     <p style=\"color: dodgerblue; font-weight:bold\">© GymAdmin</p>" +
                    " </div>";
                    ;



                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("rootacc.2022@gmail.com", "masteruser");
                        smtp.EnableSsl = true; smtp.Send(mail);

                    }
                }


            }

            //Enviar correo confirmacion al profesor
            using (MailMessage mail = new MailMessage())
            {

                mail.From = new MailAddress("rootacc.2022@gmail.com"); mail.To.Add(profesor.email);
                mail.Subject = "Evento Cancelado: " + profesor.clase + "  " + profesor.horario;
                mail.Body =
                    "<div style=\"border: 1px solid #c3c3c3;border-radius: 10px; padding: 20px; \">" +
                    "<h1 style=\"color: dodgerblue; font - weight: bold\">Evento Cancelado</h1>" +
                    "<hr>" +
                    "<p style=\"font-weight: bold;color:dodgerblue\">Estimado Instructor " + profesor.nombres + ",</p>" +
                    "<p>Su clase de " + "<span style=\"color: dodgerblue; font-weight: bold; \">" +
                    profesor.clase + "</span>" +
                    " programada para el día   <span style=\"color: dodgerblue; font-weight: bold\">"
                    + profesor.fecha.ToShortDateString() + "</span> en el horario de " +
                    "<span style=\"color: dodgerblue; font-weight: bold\">" + profesor.horario + "</span> ha sido cancelada por el siguiente motivo: </p>  " +
                    "<p>" + motivo + "</p>" +
                    "<hr>" +
                    "<p>Se ha enviado el posible horario de recuperación al administrador: " +
                    "<span style=\"color: dodgerblue; font-weight: bold; \">" + posibleHorarioRecuperacion + "</span>" +
                    "</p>" +
                    "<hr>" +
                    "<p>Si tiene dudas por favor contacte al adminsitrador.</p>" +
                    "<p>Gracias por su comprensión</p>" +
                    "<p style=\"color:dodgerblue;;font-weight:bold\">© GymAdmin</p>"
                    + "</div>";

                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new System.Net.NetworkCredential("rootacc.2022@gmail.com", "masteruser");
                    smtp.EnableSsl = true; smtp.Send(mail);

                }
            }


            //Enviar correo a los administradores
            foreach (var c in administradores)
            {
                using (MailMessage mail = new MailMessage())
                {

                    mail.From = new MailAddress("rootacc.2022@gmail.com"); mail.To.Add(c.email);
                    mail.Subject = "Evento Cancelado: " + profesor.clase + "  " + profesor.horario;
                    mail.Body =
                        "<div style=\"border: 1px solid #c3c3c3;border-radius:10px ; padding: 20px;\">" +
                        "<h1 style=\"color: dodgerblue\">Evento Cancelado</h1>" +
                        "<hr>" +
                        "<p><span style=\"color: dodgerblue; font-weight: bold; \">Estimado Administrador " + c.nombres + ",</span></p>" +
                        "<p>La clase de <span style=\"color: dodgerblue; font-weight: bold; \">" + profesor.clase + "</span> programada para el día   " +
                        "<span style=\"color: dodgerblue; font-weight: bold; \">" + profesor.fecha.ToShortDateString() + "</span> en el horario de " +
                        "<span style=\"color: dodgerblue; font-weight: bold; \">" + profesor.horario + "</span> ha sido cancelada por el siguiente motivo: </p>" +
                        "<p>" + motivo + "</p>" +
                        "<hr>" +
                        "<p>Se ha solicitado agendar una clase de recuperación en el siguiente horario: " +
                        "<span style=\"color: dodgerblue; font-weight: bold; \">" + posibleHorarioRecuperacion + "</span> </p>" +
                        "<hr>" +
                        "<p>Gracias por su atención.</p>" +
                        "<p style=\"color: dodgerblue; font-weight:bold\">© GymAdmin</p>" +
                        "</div>";

                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("rootacc.2022@gmail.com", "masteruser");
                        smtp.EnableSsl = true; smtp.Send(mail);

                    }
                }


            }
        }

        public bool CancelValidation(int eventoID)
        {
            try
            {
                bool resp = false;
                DateTime hoy = DateTime.Now;
                string query = string.Empty;
                CancelarEventoEntity fechaEvento = new CancelarEventoEntity();

                using (var dbContext = new GYMDBEntities())
                {
                    query = dbContext.configuraciones_Sistema.Where(x => x.NombreConfiguracion.Equals("cancelacionEventoInstructor")).Select(x => x.Valor).FirstOrDefault();

                    var evento = dbContext.evento.Where(x => x.eventoID == eventoID && x.estadoRegistro == "A").FirstOrDefault();

                    if (evento != null)
                    {
                        fechaEvento = new CancelarEventoEntity()
                        {
                            eventoID = evento.eventoID,
                            fechaInicioEvento = evento.fecha,
                            horaInicio = evento.horarioM.horaInicio
                        };
                    }
                }

                if (!string.IsNullOrWhiteSpace(query) && fechaEvento != null)
                {
                    int value = int.Parse(query);

                    DateTime fechaInicioConHora = DateTime.ParseExact(fechaEvento.fechaInicioEvento.ToString("yyyy-MM-dd") + " " + fechaEvento.horaInicio, "yyyy-MM-dd HHmm", CultureInfo.InvariantCulture);

                    fechaInicioConHora = fechaInicioConHora.AddHours(-value);

                    if (hoy < fechaInicioConHora)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new ValidationAndMessageException("No existe el evento consultado.");
                }
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }

        }
    }

}

