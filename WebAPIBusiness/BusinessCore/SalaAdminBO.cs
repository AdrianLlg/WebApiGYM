using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.SalasAdmin;

using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class SalaAdminBO
    {
        public List<SalasAdminEntity> getSalas()
        {
            List<SalasAdminEntity> entities = new List<SalasAdminEntity>();

            entities = getSalasDB();

            return entities;
        }

        private List<SalasAdminEntity> getSalasDB()
        {
            List<SalasAdminEntity> entities = new List<SalasAdminEntity>();
            List<sala> salas = new List<sala>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    salas = dbContext.sala.ToList();
                }

                if (salas.Count > 0)
                {
                    foreach (var sala in salas)
                    {
                        SalasAdminEntity SalasAdminEntity = new SalasAdminEntity()
                        {
                            salaID = sala.salaID,
                            nombre = sala.nombre,
                            descripcion = sala.descripcion

                        };

                        entities.Add(SalasAdminEntity);
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

            }

            return entity;
        }

        private bool insertDBSala(string nombre, string descripcion)
        {

            sala item = new sala();
            sala recoverSala = new sala();
            sala newSala;

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



        public bool modifySala(int salaID, string nombre, string descripcion)
        {
            bool entity = false;

            try
            {
                string validation = salaID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la sala no se ha especificado.");
                }

                entity = UpdateRecord(salaID, nombre, descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el sala.");
            }

            return entity;
        }

        private bool UpdateRecord(int salaID, string nombre, string descripcion)
        {
            bool resp = false;
            sala sls = new sala();


            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    sls = dbContext.sala.Where(x => x.salaID == salaID).FirstOrDefault();

                    if (sls != null)
                    {

                        if (!string.IsNullOrEmpty(nombre))
                        {
                            sls.nombre = nombre;
                        }
                        if (!string.IsNullOrEmpty(descripcion))
                        {
                            sls.descripcion = descripcion;
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

        public SalasAdminEntity consultarSala(int salaID)
        {
            SalasAdminEntity resp = new SalasAdminEntity();

            resp = getsalaInfo(salaID);

            return resp;
        }


        private SalasAdminEntity getsalaInfo(int salaID)
        {
            sala sls = new sala();
            SalasAdminEntity resp = new SalasAdminEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    sls = dbContext.sala.Where(x => x.salaID == salaID).FirstOrDefault();
                }

                if (sls != null)
                {
                    resp = new SalasAdminEntity()
                    {
                        salaID = sls.salaID,
                        nombre = sls.nombre,
                        descripcion = sls.descripcion

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
