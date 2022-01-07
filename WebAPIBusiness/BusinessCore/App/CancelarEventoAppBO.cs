using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.Entities.ConsultaMailCancelacionApp;
using WebAPIBusiness.Resources;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore.App
{
    public class CancelarEventoAppBO
    {
        private bool InactivarInfo(int eventoID, int personaID, string motivo, string posibleHorarioRecuperacion)
        {

            evento evento = new evento();
            evento_profesor eventoProfesor = new evento_profesor();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    evento = dbContext.evento.Where(x => x.eventoID == eventoID).FirstOrDefault();
                    eventoProfesor = dbContext.evento_profesor.Where(x => x.personaID == personaID && x.eventoID == eventoID).FirstOrDefault();
                    if (evento != null)
                    {
                        if (evento.estadoRegistro == "A")
                        {
                            eventoProfesor.estadoRegistro = "I";
                            eventoProfesor.motivo = motivo;
                            eventoProfesor.posibleHorarioRecuperacion = posibleHorarioRecuperacion;
                            evento.estadoRegistro = "I";
                            enviarCorreoCancelacion(eventoID, motivo, posibleHorarioRecuperacion);
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
                consulta = dbContext.Database.SqlQuery<ConsultaMailCancelacionAppEntity>(query).ToList();
                profesor = dbContext.Database.SqlQuery<ConsultaMailCancelacionAppEntity>(query).FirstOrDefault();
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
                        "<h1 style=\"color:#93E9BE\" > Evento Cancelado:</h1>" +
                        "</br>" +
                        "</br>" +
                        "<p>Estimado " + c.nombres + ",</p>" +
                        "</br>" +
                        "<p>La clase de " + c.clase + " programada para el  " + c.fecha.ToShortDateString() + " en el horario de " + c.horario +
                        " ha sido cancelada por el siguiente motivo: " +
                        "</br>" +
                        motivo +
                        "</br>" +
                        "La clase se  le ha sido retornada.</p>" +
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

            //Enviar correo confirmacion al profesor
            using (MailMessage mail = new MailMessage())
            {

                mail.From = new MailAddress("rootacc.2022@gmail.com"); mail.To.Add(profesor.email);
                mail.Subject = "Evento Cancelado: " + profesor.clase + "  " + profesor.horario;
                mail.Body =
                    "<h1 style=\"color:#93E9BE\" > Evento Cancelado:</h1>" +
                    "</br>" +
                    "</br>" +
                    "<p>Estimado Instructor" + profesor.nombres + ",</p>" +
                    "</br>" +
                    "<p>Su clase de " + profesor.clase + " programada para el  " + profesor.fecha.ToShortDateString() + " en el horario de " + profesor.horario +
                    " ha sido cancelada por el siguiente motivo: " +
                    "</br>" +
                    motivo +
                    "</br>" +
                    "Se ha enviado el posible horario de recuperación al administrador:</p>" +
                    "</br>" +
                    posibleHorarioRecuperacion +
                    "</br>" +
                    "<p> Si tiene dudas por favor contacte al adminsitrador,gracias por su comprensión</p>"
                    ;

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
                        "<h1 style=\"color:#93E9BE\" > Evento Cancelado:</h1>" +
                        "</br>" +
                        "</br>" +
                        "<p>Estimado administrador" + c.nombres + ",</p>" +
                        "</br>" +
                        "<p>La clase de " + profesor.clase + " programada para el  " + profesor.fecha.ToShortDateString() + " en el horario de " + profesor.horario +
                        " ha sido cancelada por el siguiente motivo: " +
                        "</br>" +
                        motivo +
                        "</br>" + 
                        "Se ha solicitado agendar una clase de recuperación en el siguiente hhorario </p>" +
                    "</br>" +
                    posibleHorarioRecuperacion +
                    "</br>" +
                        "<p>Gracias por su atención.</p>"
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
    }

}

