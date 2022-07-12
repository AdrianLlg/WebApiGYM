using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.SalaRecursoEspecial;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class salaRecursoEspecialBO
    {
        public List<SalaRecursoEspecialEntity> getsalaRecursoEspecials()
        {
            List<SalaRecursoEspecialEntity> entities = new List<SalaRecursoEspecialEntity>();

            entities = getsalaRecursoEspecialDB();

            return entities;
        }

        private List<SalaRecursoEspecialEntity> getsalaRecursoEspecialDB()
        {
            List<SalaRecursoEspecialEntity> entities = new List<SalaRecursoEspecialEntity>();
            List<salaRecursoEspecial> salaRecursoEspecials = new List<salaRecursoEspecial>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    salaRecursoEspecials = dbContext.salaRecursoEspecial.ToList();
                }

                if (salaRecursoEspecials.Count > 0)
                {
                    foreach (var salaRecursoEspecial in salaRecursoEspecials)
                    {
                        SalaRecursoEspecialEntity salaRecursoEspecialsEntity = new SalaRecursoEspecialEntity()
                        {
                            salaRecursoEspecialID = salaRecursoEspecial.salaRecursoEspecialID,
                            salaID = salaRecursoEspecial.salaID,
                            recursoEspecialID = salaRecursoEspecial.recursoEspecialID,
                            estadoRegistro=salaRecursoEspecial.estadoRegistro 

                        };

                        entities.Add(salaRecursoEspecialsEntity);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public bool insertsalaRecursoEspecial(int salaID, int recursoEspecialID,string estadoRegistro)
        {
            bool entity = false;

            try
            {
                entity = insertDBsalaRecursoEspecial(salaID, recursoEspecialID,estadoRegistro);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar salaRecurso");
            }

            return entity;
        }

        private bool insertDBsalaRecursoEspecial(int salaID, int recursoEspecialID,string estadoRegistro)
        {
            salaRecursoEspecial item = new salaRecursoEspecial();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new salaRecursoEspecial()
                    {
                        salaID = salaID,
                        recursoEspecialID = recursoEspecialID,
                        estadoRegistro="A"
                    };

                    dbContext.salaRecursoEspecial.Add(item);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifysalaRecursoEspecial(int salaRecursoEspecialID, int salaID, int recursoEspecialID,string estadoRegistro)
        {
            bool entity = false;

            try
            {
                string validation = salaRecursoEspecialID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la persona no se ha especificado.");
                }

                entity = UpdateRecord(salaRecursoEspecialID, salaID, recursoEspecialID,estadoRegistro);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el usuario.");
            }

            return entity;
        }

        private bool UpdateRecord(int salaRecursoEspecialID, int salaID, int recursoEspecialID,string estadoRegistro)
        {
            bool resp = false;
            salaRecursoEspecial salaRecursoEspecial = new salaRecursoEspecial();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    salaRecursoEspecial = dbContext.salaRecursoEspecial.Where(x => x.salaRecursoEspecialID == salaRecursoEspecialID).FirstOrDefault();

                    if (salaRecursoEspecial != null)
                    {
                        salaRecursoEspecial.salaRecursoEspecialID = salaRecursoEspecialID;
                        salaRecursoEspecial.salaID = salaID;
                        salaRecursoEspecial.recursoEspecialID = recursoEspecialID;
                        salaRecursoEspecial.estadoRegistro = estadoRegistro;

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

        public SalaRecursoEspecialEntity consultarsalaRecursoEspecial(int salaRecursoEspecialID)
        {
            SalaRecursoEspecialEntity resp = new SalaRecursoEspecialEntity();

            resp = getsalaRecursoEspecialInfo(salaRecursoEspecialID);

            return resp;
        }


        private SalaRecursoEspecialEntity getsalaRecursoEspecialInfo(int salaRecursoEspecialID)
        {
            salaRecursoEspecial salaRecursoEspecial = new salaRecursoEspecial();
            SalaRecursoEspecialEntity resp = new SalaRecursoEspecialEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    salaRecursoEspecial = dbContext.salaRecursoEspecial.Where(x => x.salaRecursoEspecialID == salaRecursoEspecialID).FirstOrDefault();
                }

                if (salaRecursoEspecial != null)
                {
                    resp = new SalaRecursoEspecialEntity()
                    {
                        salaRecursoEspecialID = salaRecursoEspecial.salaRecursoEspecialID,
                        salaID = salaRecursoEspecial.salaID,
                        recursoEspecialID = salaRecursoEspecial.recursoEspecialID,

                    };
                }

                return resp;
            }
            catch (Exception ex)
            {
                return resp;
            }
        }

        public bool eliminarSalaREcursoEspecial(int salaRecursoEspecialID)
        {
            bool resp = false;

            resp = InactivarInfo(salaRecursoEspecialID);

            return resp;
        }

        private bool EliminarInfo(int salaRecursoEspecialID)
        {
            SalaRecursoEspecialEntity resp = new SalaRecursoEspecialEntity();
            //FKS:
            //evento
            //salaRecursoEspecialRecurso
            //salaRecursoEspecialRecursoEspecial
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    var salaRecursoEspecial = dbContext.salaRecursoEspecial.Where(x => x.salaRecursoEspecialID == salaRecursoEspecialID).FirstOrDefault();




                    if (salaRecursoEspecial != null)
                    {
                        dbContext.salaRecursoEspecial.Remove(salaRecursoEspecial);
                        dbContext.SaveChanges();
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

        public bool inactivarSala(int salaRecursoEspecialID)
        {
            bool resp = false;

            resp = InactivarInfo(salaRecursoEspecialID);

            return resp;
        }

        private bool InactivarInfo(int salaRecursoEspecialID)
        {

            salaRecursoEspecial salaRecursoEspecial = new salaRecursoEspecial();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    salaRecursoEspecial = dbContext.salaRecursoEspecial.Where(x => x.salaRecursoEspecialID == salaRecursoEspecialID).FirstOrDefault();

                    if (salaRecursoEspecial != null)
                    {
                        if (salaRecursoEspecial.estadoRegistro == "A")
                        {
                            salaRecursoEspecial.estadoRegistro = "I";
                        }
                        else if (salaRecursoEspecial.estadoRegistro == "I")
                        {
                            salaRecursoEspecial.estadoRegistro = "A";
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
