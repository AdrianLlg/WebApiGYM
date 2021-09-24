using System;
using System.Linq;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class RegistroBO
    {
        public bool insertUser(string nombre, string apellido, string identificacion, string email, string telefono, string edad, string sexo, string fechanacimiento, string password)
        {
            bool entity = false;

            entity = insertDBUser(nombre, apellido, identificacion, email, telefono, edad, sexo, fechanacimiento, password);
            
            return entity;
        }

        private bool insertDBUser(string nombre, string apellido, string identificacion, string email, string telefono, string edad, string sexo, string fechanacimiento, string password)
        {
            DateTime fecha = Convert.ToDateTime(fechanacimiento);
            DateTime hoy = DateTime.Now;

            persona item = new persona();
            persona recoverPerson = new persona();
            usuario newUser;

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new persona()
                    {
                        rolePID = 3,
                        nombres = nombre,
                        apellidos = apellido,
                        identificacion = identificacion,
                        email = email,
                        telefono = telefono,
                        edad = edad,
                        sexo = sexo,
                        fechaNacimiento = fecha,
                        fechaCreacion = hoy
                    };

                    dbContext.persona.Add(item);
                    dbContext.SaveChanges();

                    recoverPerson = dbContext.persona.Where(x => x.identificacion == identificacion).FirstOrDefault();

                    newUser = new usuario()
                    {
                       personaID = recoverPerson.personaID,
                       persona = recoverPerson,
                       email = recoverPerson.email,
                       password = password
                    };

                    dbContext.usuario.Add(newUser);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

 
    }
}
