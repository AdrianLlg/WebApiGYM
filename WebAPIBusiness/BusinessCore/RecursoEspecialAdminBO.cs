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
                            estadoRegistro=recurso.estadoRegistro
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

        public bool insertRecursoEspecial(string nombre, string descripcion, string estadoRegistro)
        {
            bool entity = false;

            try
            {
                entity = insertDBRecursoEspecial(nombre, descripcion,estadoRegistro);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el recurso");
            }

            return entity;
        }

        private bool insertDBRecursoEspecial(string nombre, string descripcion,string estadoRegistro)
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
                       estadoRegistro="A"
                       
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

        public bool modifyRecursoEspecial(int recursoEspecialID, string nombre, string descripcion,string estadoRegistro)
        {
            bool entity = false;

            try
            {
                string validation = recursoEspecialID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID del recurso no se ha especificado.");
                }

                entity = UpdateRecord(recursoEspecialID, nombre, descripcion, estadoRegistro);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el recurso.");
            }

            return entity;
        }

        private bool UpdateRecord(int recursoEspecialID, string nombre, string descripcion,string estadoRegistro)
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
                        rec.estadoRegistro = estadoRegistro;
                        
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
                        estadoRegistro=rec.estadoRegistro
                    };
                }

                return resp;
            }
            catch (Exception ex)
            {
                return resp;
            }
        }


        public bool eliminarRecursoEspecial(int recursoEspecialID)
        {
            bool resp = false;

            resp = EliminarInfo(recursoEspecialID);

            return resp;
        }




        private bool EliminarInfo(int recursoEspecialID)
        {

            RecursoEspecialAdminEntity resp = new RecursoEspecialAdminEntity();
            //FKS:
            //evento
            //recursoEspecialRecurso
            //recursoEspecialRecursoEspecial
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    var recursoEspecial = dbContext.recursoEspecial.Where(x => x.recursoEspecialID == recursoEspecialID).FirstOrDefault();
                    var salaRecursoEspeciallLS = dbContext.salaRecursoEspecial.ToList();
                    
                    bool hasSalaRecursoEspecial = salaRecursoEspeciallLS.Any(x => x.recursoEspecialID == recursoEspecialID);
                    
                    if (recursoEspecial != null)
                    {
                        if (hasSalaRecursoEspecial == false)
                        {
                            dbContext.recursoEspecial.Remove(recursoEspecial);
                            dbContext.SaveChanges();
                            return true;
                        }
                        

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool inactivarRecursoEspecial(int recursoEspecialID)
        {
            bool resp = false;

            resp = InactivarInfo(recursoEspecialID);

            return resp;
        }

        private bool InactivarInfo(int recursoEspecialID)
        {

            recursoEspecial recursoEspecial = new recursoEspecial();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    recursoEspecial = dbContext.recursoEspecial.Where(x => x.recursoEspecialID == recursoEspecialID).FirstOrDefault();

                    if (recursoEspecial.estadoRegistro == "A")
                    {
                        recursoEspecial.estadoRegistro = "I";
                    }
                    else if (recursoEspecial.estadoRegistro == "I")
                    {
                        recursoEspecial.estadoRegistro = "A";
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

    }
}
