using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.Entities.RecursoAdmin;
using WebAPIBusiness.Entities.RecursoEspecialAdmin;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class RecursoEspecialAdminBO
    {
        public List<RecursoEspecialAdminEntity> getRecursoEspeciales()
        {
            List<RecursoEspecialAdminEntity> entities = new List<RecursoEspecialAdminEntity>();

            entities = getRecursoEspecialesDB();

            return entities;
        }

        private List<RecursoEspecialAdminEntity> getRecursoEspecialesDB()
        {
            List<RecursoEspecialAdminEntity> entities = new List<RecursoEspecialAdminEntity>();
            List<recursoEspecial> recursos = new List<recursoEspecial>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    recursos = dbContext.recursoEspecial.ToList();
                }

                if (recursos.Count > 0)
                {
                    foreach (var recurso in recursos)
                    {
                        RecursoEspecialAdminEntity recursoEspecialAdminEntity = new RecursoEspecialAdminEntity()
                        {
                            recursoEspecialID = recurso.recursoEspecialID,
                            nombre = recurso.nombre,
                            descripcion = recurso.descripcion,
                        };

                        entities.Add(recursoEspecialAdminEntity);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            { 
                return entities;
            }
        }

        public bool insertRecursoEspecial(string nombre, string descripcion)
        {
            bool entity = false;

            try
            {
                entity = insertDBRecursoEspecial(nombre, descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el recurso");
            }

            return entity;
        }

        private bool insertDBRecursoEspecial(string nombre, string descripcion)
        {

            recursoEspecial item = new recursoEspecial();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new recursoEspecial()
                    {
                       nombre = nombre,
                       descripcion = descripcion,
                       
                    };

                    dbContext.recursoEspecial.Add(item);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifyRecursoEspecial(int recursoEspecialID, string nombre, string descripcion )
        {
            bool entity = false;

            try
            {
                string validation = recursoEspecialID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID del recurso no se ha especificado.");
                }

                entity = UpdateRecord(recursoEspecialID, nombre, descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el recurso.");
            }

            return entity;
        }

        private bool UpdateRecord(int recursoEspecialID, string nombre, string descripcion)
        {
            recursoEspecial rec = new recursoEspecial();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    rec = dbContext.recursoEspecial.Where(x => x.recursoEspecialID == recursoEspecialID).FirstOrDefault();

                    if (rec != null)
                    {
                        if (!string.IsNullOrEmpty(nombre))
                        {
                            rec.nombre = nombre;
                        }
                        if (!string.IsNullOrEmpty(descripcion))
                        {
                            rec.descripcion = descripcion;
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

        public RecursoEspecialAdminEntity consultarRecursoEspecial(int recursoEspecialID)
        {
            RecursoEspecialAdminEntity resp = new RecursoEspecialAdminEntity();

            resp = getRecursoInfo(recursoEspecialID);

            return resp;
        }


        private RecursoEspecialAdminEntity getRecursoInfo(int recursoEspecialID)
        {
            recursoEspecial rec = new recursoEspecial();
            RecursoEspecialAdminEntity resp = new RecursoEspecialAdminEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    rec = dbContext.recursoEspecial.Where(x => x.recursoEspecialID == recursoEspecialID).FirstOrDefault();
                }

                if (rec != null)
                {
                    resp = new RecursoEspecialAdminEntity()
                    {
                        recursoEspecialID = rec.recursoEspecialID,
                        nombre = rec.nombre,
                        descripcion = rec.descripcion,
                        
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
