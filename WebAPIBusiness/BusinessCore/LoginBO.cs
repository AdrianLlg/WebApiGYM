using System;
using System.Linq;
using WebAPIBusiness.Entities.Login;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class LoginBO
    {
        public bool insertUser(string rol, string nombre, string apellido, string identificacion, string email, string telefono, string edad, string sexo, string fechanacimiento)
        {
            bool entity = false;
            LoginEntity p = new LoginEntity();

            //p = consultarItem("Bachata");
            entity = insertDBUser(rol, nombre, apellido, identificacion, email, telefono, edad, sexo, fechanacimiento);

            return entity;
        }

        private bool insertDBUser(string rol, string nombre, string apellido, string identificacion, string email, string telefono, string edad, string sexo, string fechanacimiento)
        {
            DateTime fecha = Convert.ToDateTime(fechanacimiento);
            DateTime hoy = DateTime.Now;

            persona item = new persona();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new persona()
                    {
                        rolePID = int.Parse(rol),
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

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private LoginEntity consultarItem(string tipo)
        {
            LoginEntity item = new LoginEntity();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    var entity = dbContext.disciplina.Where(x => x.nombre == tipo).FirstOrDefault();

                    if (entity != null )
                    {
                        item = new LoginEntity()
                        {
                            DisciplinaID = entity.disciplinaID,
                            Nombre = entity.nombre,
                            Descripcion = entity.descripcion
                        };
                    }

                    return item;
                }
            }
            catch (Exception ex)
            {
                return item;
            }
        }
    }
}
