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
                        ClaseAdminEntity Clase= new ClaseAdminEntity()
                        {
                            claseID=clase.claseID,
                            disciplinaID=clase.disciplinaID,
                            nombre=clase.nombre,
                            descripcion=clase.descripcion
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

        public bool insertClase(string disciplinaID, string nombre, string descripcion)
        {
            bool entity = false;

            try
            {
                entity = insertDBClase(disciplinaID, nombre, descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar la disciplina");
            }

            return entity;
        }

        private bool insertDBClase( string disciplinaID, string nombre, string descripcion)
        {
            clase item = new clase();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new clase()
                    {
                        disciplinaID = int.Parse(disciplinaID),
                        nombre = nombre,
                        descripcion = descripcion
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

        public bool modifyClase(int claseID, string discplinaID, string nombre,string descripcion )
        {
            bool entity = false;

            try
            {
                string validation = claseID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la clase no se ha especificado.");
                }

                entity = UpdateRecord(claseID,  discplinaID,  nombre,  descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar la disciplina.");
            }

            return entity;
        }

        private bool UpdateRecord(int claseID,string disciplinaID, string nombre, string descripcion)
        {
            clase clase = new clase();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    clase = dbContext.clase.Where(x => x.claseID == claseID).FirstOrDefault();

                    if (clase != null)
                    {
                        if (!string.IsNullOrEmpty(disciplinaID))
                        {
                            clase.disciplinaID = int.Parse(disciplinaID);
                        }
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
            clase clase= new clase();
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
                        descripcion = clase.descripcion
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
