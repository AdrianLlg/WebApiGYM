using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.Entities.RegistroAdmin;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class RegistroAdminBO
    {
        public List<UsuariosRegistradosEntity> getUserPersons()
        {
            List<UsuariosRegistradosEntity> entities = new List<UsuariosRegistradosEntity>();

            entities = getPersons();

            return entities;
        }

        private List<UsuariosRegistradosEntity> getPersons()
        {
            List<UsuariosRegistradosEntity> entities = new List<UsuariosRegistradosEntity>();
            List<persona> personas = new List<persona>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    personas = dbContext.persona.ToList();          
                }

                if (personas.Count > 0)
                {
                    foreach (var persona in personas)
                    {
                        UsuariosRegistradosEntity UsuariosRegistradosEntity = new UsuariosRegistradosEntity() { 
                        
                         personaID = persona.personaID,
                         rolePID = persona.rolePID,
                         nombres = persona.nombres,
                         apellidos = persona.apellidos,
                         identificacion = persona.identificacion,
                         edad = persona.edad,
                         email = persona.email,
                         telefono = persona.telefono,
                         sexo = persona.sexo,
                         fechaNacimiento = persona.fechaNacimiento,
                         estado = persona.estado,
                         fechaCreacion = persona.fechaCreacion
                        };

                        entities.Add(UsuariosRegistradosEntity);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public bool insertUser(string rolePID, string nombres, string apellidos, string identificacion, string email, string telefono, string sexo, string fechaNacimiento)
        {
            bool entity = false;

            try
            {
                DateTime fechaNacimient = Convert.ToDateTime(fechaNacimiento);

                int edad = calculateAge(fechaNacimient);

                entity = insertDBUser(rolePID, nombres, apellidos, identificacion, email, telefono, sexo, fechaNacimient, edad);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el usuario/calcular la edad del usuario.");
            }           

            return entity;
        }

        private bool insertDBUser(string rolePID, string nombres, string apellidos, string identificacion, string email, string telefono, string sexo, DateTime fechaNacimiento, int edad)
        {
            
            DateTime hoy = DateTime.Now;
            int roleID = int.Parse(rolePID);

            persona item = new persona();
            persona recoverPerson = new persona();
            usuario newUser;

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new persona()
                    {
                        rolePID = roleID,
                        nombres = nombres,
                        apellidos = apellidos,
                        identificacion = identificacion,
                        email = email,
                        telefono = telefono,
                        edad = edad.ToString(),
                        sexo = sexo,
                        fechaNacimiento = fechaNacimiento,
                        fechaCreacion = hoy,
                        estado = "A"
                    };

                    dbContext.persona.Add(item);
                    dbContext.SaveChanges();

                    recoverPerson = dbContext.persona.Where(x => x.identificacion == identificacion).FirstOrDefault();

                    newUser = new usuario()
                    {
                        personaID = recoverPerson.personaID,
                        persona = recoverPerson,
                        email = recoverPerson.email,
                        password = "123456789A"
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

        public int calculateAge(DateTime fechaNacimiento)
        {
            DateTime now = DateTime.Today;
            int edad = DateTime.Today.Year - fechaNacimiento.Year;

            if (DateTime.Today < fechaNacimiento.AddYears(edad))
            {
                --edad;
            }

            return edad;
        }
    }
}
