using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.CustomExceptions;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore.App
{
    public class PersonaUsuarioBO
    {
        private static Random random = new Random();
        public bool modifyUser(int personaID, string newPassword)
        {
            bool usuario = modifyUserPassword(personaID, newPassword);

            return usuario;
        }

        private bool modifyUserPassword(int personaID, string newPassword)
        {
            try
            {
                usuario user;

                using (var dbContext = new GYMDBEntities())
                {
                    user = dbContext.usuario.Where(x => x.personaID == personaID).FirstOrDefault();

                    if (user != null)
                    {
                        user.password = newPassword;
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        throw new ValidationAndMessageException("El ID de la persona proporcionado no existe.");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }
        }
        public bool UpdateUserInfo(int personaID, string nombres, string apellidos, string telefono, string email, string fechaNacimiento)
        {
            bool usuario = modifyUserInfo(personaID, nombres, apellidos, telefono, email, fechaNacimiento);

            return usuario;
        }

        private bool modifyUserInfo(int personaID, string nombres, string apellidos, string telefono, string email, string fechaNacimiento)
        {
            bool resp = false;
            persona pers = new persona();
            DateTime fechaNacimient = new DateTime();

            try
            {
               fechaNacimient = Convert.ToDateTime(fechaNacimiento);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al transformar una de las entidades en el formato requerido.");
            }

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    pers = dbContext.persona.Where(x => x.personaID == personaID).FirstOrDefault();

                    if (pers != null)
                    {                        
                        if (!string.IsNullOrEmpty(nombres))
                        {
                            pers.nombres = nombres;
                        }
                        if (!string.IsNullOrEmpty(apellidos))
                        {
                            pers.apellidos = apellidos;
                        }
                       
                        if (!string.IsNullOrEmpty(email))
                        {
                            var existsMailValidation = dbContext.persona.Where(x => x.email == email).FirstOrDefault();

                            if(existsMailValidation == null)
                            {
                                var userRecord = dbContext.usuario.Where(x => x.personaID == personaID).FirstOrDefault();

                                userRecord.email = email;
                                pers.email = email;
                            }
                        }
                        if (!string.IsNullOrEmpty(telefono))
                        {
                            pers.telefono = telefono;
                        }
                      
                        if (!string.IsNullOrEmpty(fechaNacimiento))
                        {
                            pers.fechaNacimiento = fechaNacimient;
                        }
                    }
                    else
                    {
                        throw new ValidationAndMessageException("La persona ingresada no existe.");
                    }
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }
        }

        public string sendMail(string mail)
        {
            string resp = sendSMTPEmail(mail);

            return resp;
        }


        private string sendSMTPEmail(string email)
        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var code = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            //MailMessage mail = new MailMessage();
            //mail.To.Add(email);
            //mail.From = new MailAddress("servicioenviocorreogym@gmail.com", "Código de Seguridad", Encoding.UTF8);
            //mail.Subject = "Cambio de contraseña";
            //mail.SubjectEncoding = Encoding.UTF8;
            //mail.Body = "Su código para verificar su identidad es el siguiente: " + " " + code + "<br>" + "Por favor, ingrese el código en la aplicación.";
            //mail.BodyEncoding = Encoding.UTF8;
            //mail.IsBodyHtml = true;
            ////mail.Priority = MailPriority.High;
            //SmtpClient client = new SmtpClient();
            //client.UseDefaultCredentials = false;
            //client.Credentials = new System.Net.NetworkCredential("servicioenviocorreogym@gmail.com", "servicioEnvioCorreoGYM123");
            //client.Port = 587;
            //client.Host = "smtp.gmail.com";
            //client.EnableSsl = true;


            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("servicioenviocorreogym@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Cambio de contraseña";
                mail.Body = "Su código para verificar su identidad es el siguiente: " + " " + code + "<br>" + "Por favor, ingrese el código en la aplicación.";
                mail.IsBodyHtml = true;

                //using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                //{
                //    smtp.Credentials = new NetworkCredential("servicioenviocorreogym@gmail.com", "servicioEnvioCorreoGYM123");
                //    smtp.EnableSsl = true;

                //    try
                //    {
                //        smtp.Send(mail);
                //    }
                //    catch (Exception ex)
                //    {
                //        throw new ValidationAndMessageException(ex.Message);
                //    }
                //}

                SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential("servicioenviocorreogym@gmail.com", "servicioEnvioCorreoGYM123")
                };

                client.Send(mail);
            }           

            return code;
        }
    }
}
