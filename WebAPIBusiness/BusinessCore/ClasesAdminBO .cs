using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.Entities.ClasesAdmin;
using WebAPIBusiness.Entities.DisciplinaAdmin;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class ClasesAdminBO
    {
        public List<ClaseAdminEntity> getClases()
        {
            List<ClaseAdminEntity> entities = new List<ClaseAdminEntity>();

            entities = getClaseDB();

            return entities;
        }

        private List<ClaseAdminEntity> getClaseDB()
        {
            List<ClaseAdminEntity> entities = new List<ClaseAdminEntity>();
            List<clase> clases = new List<clase>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    clases = dbContext.clase.ToList();
                }

                if (clases.Count > 0)
                {
                    foreach (var clase in clases)
                    {
                        ClaseAdminEntity Clase = new ClaseAdminEntity()
                        {
                            claseID = clase.claseID,
                            disciplinaID = clase.disciplinaID,
                            nombre = clase.nombre,
                            descripcion = clase.descripcion,
                            estadoRegistro = clase.estadoRegistro
                        };

                        entities.Add(Clase);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public bool insertClase(int disciplinaID, string nombre, string descripcion, string estadoRegistro)
        {
            bool entity = false;

            try
            {
                entity = insertDBClase(disciplinaID, nombre, descripcion, estadoRegistro);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar la disciplina");
            }

            return entity;
        }

        private bool insertDBClase(int disciplinaID, string nombre, string descripcion, string estadoRegistro)
        {
            clase item = new clase();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new clase()
                    {
                        disciplinaID = disciplinaID,
                        nombre = nombre,
                        descripcion = descripcion,
                        estadoRegistro = "A"
                    };

                    dbContext.clase.Add(item);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifyClase(int claseID, int disciplinaID, string nombre, string descripcion)
        {
            bool entity = false;

            try
            {
                string validation = claseID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la clase no se ha especificado.");
                }

                entity = UpdateRecord(claseID, disciplinaID, nombre, descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar la disciplina.");
            }

            return entity;
        }

        private bool UpdateRecord(int claseID, int disciplinaID, string nombre, string descripcion)
        {
            clase clase = new clase();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    clase = dbContext.clase.Where(x => x.claseID == claseID).FirstOrDefault();

                    if (clase != null)
                    {
                       
                            clase.disciplinaID = disciplinaID;
                      
                        if (!string.IsNullOrEmpty(nombre))
                        {
                            clase.nombre = nombre;
                        }
                        if (!string.IsNullOrEmpty(descripcion))
                        {
                            clase.descripcion = descripcion;
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

        public ClaseAdminEntity consultarClase(int claseID)
        {
            ClaseAdminEntity resp = new ClaseAdminEntity();

            resp = getClaseInfo(claseID);

            return resp;
        }


        private ClaseAdminEntity getClaseInfo(int claseID)
        {
            clase clase = new clase();
            ClaseAdminEntity resp = new ClaseAdminEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    clase = dbContext.clase.Where(x => x.claseID == claseID).FirstOrDefault();
                }

                if (clase != null)
                {
                    resp = new ClaseAdminEntity()
                    {
                        claseID = clase.claseID,
                        disciplinaID = clase.disciplinaID,
                        nombre = clase.nombre,
                        descripcion = clase.descripcion,
                        estadoRegistro = clase.estadoRegistro
                    };
                }

                return resp;
            }
            catch (Exception ex)
            {
                return resp;
            }
        }

        public bool eliminarClase(int claseID)
        {
            bool resp = false;

            resp = EliminarInfo(claseID);

            return resp;
        }




        private bool EliminarInfo(int claseID)
        {

            ClaseAdminEntity resp = new ClaseAdminEntity();
            //FKS:
            //evento

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    var clase = dbContext.clase.Where(x => x.claseID == claseID).FirstOrDefault();

                    var eventoLS = dbContext.evento.ToList();

                    bool hasEvento = eventoLS.Any(x => x.claseID == claseID);

                    if (clase != null)
                    {
                        if (hasEvento == false)
                        {
                            dbContext.clase.Remove(clase);
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

        public bool inactivarClase(int claseID)
        {
            bool resp = false;

            resp = InactivarInfo(claseID);

            return resp;
        }

        private bool InactivarInfo(int claseID)
        {

            clase clase = new clase();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    clase = dbContext.clase.Where(x => x.claseID == claseID).FirstOrDefault();

                    if (clase != null)
                    {
                        if (clase.estadoRegistro == "A")
                        {
                            clase.estadoRegistro = "I";
                        }
                        else if (clase.estadoRegistro == "I")
                        {
                            clase.estadoRegistro = "A";
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

    }
}
