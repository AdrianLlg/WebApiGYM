using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.Entities.RolAdmin;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class RolAdminBO
    {
        public List<RolAdminEntity> getRoles()
        {
            List<RolAdminEntity> entities = new List<RolAdminEntity>();

            entities = getRoleDB();

            return entities;
        }

        private List<RolAdminEntity> getRoleDB()
        {
            List<RolAdminEntity> entities = new List<RolAdminEntity>();
            List<roleP> roles = new List<roleP>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    roles = dbContext.roleP.ToList();
                }

                if (roles.Count > 0)
                {
                    foreach (var rol in roles)
                    {
                        RolAdminEntity RolesEntity = new RolAdminEntity()
                        {
                            rolePID = rol.rolePID,
                            nombre = rol.nombre,
                            descripcion = rol.descripcion                           
                        };

                        entities.Add(RolesEntity);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public bool insertRol(string nombre, string descripcion)
        {
            bool entity = false;

            try
            {
                entity = insertDBRol(nombre, descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el usuario/calcular la edad del usuario.");
            }

            return entity;
        }

        private bool insertDBRol(string nombre, string descripcion)
        {           
            roleP item = new roleP();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new roleP()
                    {
                       nombre = nombre,
                       descripcion = descripcion
                    };

                    dbContext.roleP.Add(item);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifyRol(int rolID, string nombre, string descripcion)
        {
            bool entity = false;

            try
            {
                string validation = rolID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la persona no se ha especificado.");
                }

                entity = UpdateRecord(rolID, nombre, descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el usuario.");
            }

            return entity;
        }

        private bool UpdateRecord(int rolID, string nombre, string descripcion)
        {
            bool resp = false;
            roleP rol = new roleP();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    rol = dbContext.roleP.Where(x => x.rolePID == rolID).FirstOrDefault();

                    if (rol != null)
                    {
                        if (!string.IsNullOrEmpty(nombre))
                        {
                            rol.nombre = nombre;
                        }
                        if (!string.IsNullOrEmpty(descripcion))
                        {
                            rol.descripcion = descripcion;
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

        public RolAdminEntity consultarRol(int rolID)
        {
            RolAdminEntity resp = new RolAdminEntity();

            resp = getRolInfo(rolID);

            return resp;
        }


        private RolAdminEntity getRolInfo(int rolID)
        {
            roleP rol = new roleP();
            RolAdminEntity resp = new RolAdminEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    rol = dbContext.roleP.Where(x => x.rolePID == rolID).FirstOrDefault();
                }

                if (rol != null)
                {
                    resp = new RolAdminEntity()
                    {
                       rolePID = rol.rolePID,
                       nombre = rol.nombre,
                       descripcion = rol.descripcion
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
