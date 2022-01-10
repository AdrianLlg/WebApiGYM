using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.CustomExceptions;
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

                UsuariosRegistradosEntity person = validationPerson(identificacion, email);

                if (person.personaID >= 0)
                {
                    entity = insertDBUser(rolePID, nombres, apellidos, identificacion, email, telefono, sexo, fechaNacimient, edad);
                }
                else
                {
                    throw new ValidationAndMessageException("La persona ya existe en la BD.");
                }
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }           

            return entity;
        }

        private bool insertDBUser(string rolePID, string nombres, string apellidos, string identificacion, string email, string telefono, string sexo, DateTime fechaNacimiento, int edad)
        {
            
            DateTime hoy = DateTime.Now;
            int rol = int.Parse(rolePID);
            persona item = new persona();
            persona recoverPerson = new persona();
            usuario newUser;

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new persona()
                    {
                        rolePID = rol,
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

        public bool modifyUser(int personaID, string rolePID, string nombres, string apellidos, string identificacion, string email, string telefono, string sexo, string fechaNacimiento, string edad, string estado)
        {
            bool entity = false;

            try
            {
                string validation = personaID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la persona no se ha especificado.");
                }

                entity = UpdateRecord(personaID, rolePID, nombres, apellidos, identificacion, email, telefono, sexo, fechaNacimiento, edad, estado);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el usuario.");
            }

            return entity;
        }

        private bool UpdateRecord(int personaID, string rolePID, string nombres, string apellidos, string identificacion, string email, string telefono, string sexo, string fechaNacimiento, string edad, string estado)
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
                        if (!string.IsNullOrEmpty(rolePID))
                        {
                            pers.rolePID = int.Parse(rolePID);
                        }
                        if (!string.IsNullOrEmpty(nombres))
                        {
                            pers.nombres = nombres;
                        }
                        if (!string.IsNullOrEmpty(apellidos))
                        {
                            pers.apellidos = apellidos;
                        }
                        if (!string.IsNullOrEmpty(identificacion))
                        {
                            pers.identificacion = identificacion;
                        }
                        if (!string.IsNullOrEmpty(email))
                        {
                            pers.email = email;
                        }
                        if (!string.IsNullOrEmpty(telefono))
                        {
                            pers.telefono = telefono;
                        }
                        if (!string.IsNullOrEmpty(sexo))
                        {
                            pers.sexo = sexo;
                        }
                        if (!string.IsNullOrEmpty(fechaNacimiento))
                        {
                            pers.fechaNacimiento = fechaNacimient;
                        }
                        if (!string.IsNullOrEmpty(edad))
                        {
                            pers.edad = edad;
                        }
                        if (!string.IsNullOrEmpty(estado))
                        {
                            pers.estado = estado;
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

        public UsuariosRegistradosEntity consultarPersona(int personaID)
        {
            UsuariosRegistradosEntity resp = new UsuariosRegistradosEntity();

            resp = getPersonInfo(personaID);

            return resp;
        }


        private UsuariosRegistradosEntity getPersonInfo(int personaID)
        {
            persona pers = new persona();
            UsuariosRegistradosEntity resp = new UsuariosRegistradosEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    pers = dbContext.persona.Where(x => x.personaID == personaID).FirstOrDefault();
                }

                if (pers != null)
                {
                    resp = new UsuariosRegistradosEntity()
                    {
                        personaID = pers.personaID,
                        rolePID = pers.rolePID,
                        identificacion = pers.identificacion,
                        nombres = pers.nombres,
                        apellidos = pers.apellidos,
                        email = pers.email,
                        edad = pers.edad,
                        sexo = pers.sexo,
                        telefono = pers.telefono,
                        estado = pers.estado,
                        fechaNacimiento = pers.fechaNacimiento,
                        fechaCreacion = pers.fechaCreacion
                    };
                }

                return resp;
            }
            catch (Exception ex)
            {
                return resp;
            }
        }

        private UsuariosRegistradosEntity validationPerson(string cedula, string correo)
        {
            persona pers = new persona();
            UsuariosRegistradosEntity resp = new UsuariosRegistradosEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    pers = dbContext.persona.Where(x => x.identificacion == cedula || x.email == correo).FirstOrDefault();
                }

                if (pers != null)
                {
                    resp = new UsuariosRegistradosEntity()
                    {
                        personaID = pers.personaID,
                        rolePID = pers.rolePID,
                        identificacion = pers.identificacion,
                        nombres = pers.nombres,
                        apellidos = pers.apellidos,
                        email = pers.email,
                        edad = pers.edad,
                        sexo = pers.sexo,
                        telefono = pers.telefono,
                        estado = pers.estado,
                        fechaNacimiento = pers.fechaNacimiento,
                        fechaCreacion = pers.fechaCreacion
                    };
                }

                return resp;
            }
            catch (Exception ex)
            {
                return resp;
            }
        }
    }
}
