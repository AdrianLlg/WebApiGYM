using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.Entities.SalaAdmin;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class SalaAdminBO
    {
        public List<SalaAdminEntity> getSalas()
        {
            List<SalaAdminEntity> entities = new List<SalaAdminEntity>();

            entities = getSalaDB();

            return entities;
        }

        private List<SalaAdminEntity> getSalaDB()
        {
            List<SalaAdminEntity> entities = new List<SalaAdminEntity>();
            List<sala> Salas = new List<sala>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    Salas = dbContext.sala.ToList();
                }

                if (Salas.Count > 0)
                {
                    foreach (var Sala in Salas)
                    {
                        SalaAdminEntity SalasEntity = new SalaAdminEntity()
                        {
                            salaID = Sala.salaID,
                            nombre = Sala.nombre,
                            descripcion = Sala.descripcion                           
                        };

                        entities.Add(SalasEntity);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public bool insertSala(string nombre, string descripcion)
        {
            bool entity = false;

            try
            {
                entity = insertDBSala(nombre, descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el usuario/calcular la edad del usuario.");
            }

            return entity;
        }

        private bool insertDBSala(string nombre, string descripcion)
        {           
            sala item = new sala();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new sala()
                    {
                       nombre = nombre,
                       descripcion = descripcion
                    };

                    dbContext.sala.Add(item);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifySala(int SalaID, string nombre, string descripcion)
        {
            bool entity = false;

            try
            {
                string validation = SalaID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la persona no se ha especificado.");
                }

                entity = UpdateRecord(SalaID, nombre, descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el usuario.");
            }

            return entity;
        }

        private bool UpdateRecord(int SalaID, string nombre, string descripcion)
        {
            bool resp = false;
            sala Sala = new sala();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    Sala = dbContext.sala.Where(x => x.salaID == SalaID).FirstOrDefault();

                    if (Sala != null)
                    {
                        if (!string.IsNullOrEmpty(nombre))
                        {
                            Sala.nombre = nombre;
                        }
                        if (!string.IsNullOrEmpty(descripcion))
                        {
                            Sala.descripcion = descripcion;
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

        public SalaAdminEntity consultarSala(int SalaID)
        {
            SalaAdminEntity resp = new SalaAdminEntity();

            resp = getSalaInfo(SalaID);

            return resp;
        }


        private SalaAdminEntity getSalaInfo(int SalaID)
        {
            sala Sala = new sala();
            SalaAdminEntity resp = new SalaAdminEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    Sala = dbContext.sala.Where(x => x.salaID == SalaID).FirstOrDefault();
                }

                if (Sala != null)
                {
                    resp = new SalaAdminEntity()
                    {
                       salaID = Sala.salaID,
                       nombre = Sala.nombre,
                       descripcion = Sala.descripcion
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
