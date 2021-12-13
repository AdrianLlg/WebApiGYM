using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.SalaRecurso;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class salaRecursoBO
    {
        public List<SalaRecursoEntity> getsalaRecursos()
        {
            List<SalaRecursoEntity> entities = new List<SalaRecursoEntity>();

            entities = getsalaRecursoDB();

            return entities;
        }

        private List<SalaRecursoEntity> getsalaRecursoDB()
        {
            List<SalaRecursoEntity> entities = new List<SalaRecursoEntity>();
            List<salaRecurso> salaRecursos = new List<salaRecurso>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    salaRecursos = dbContext.salaRecurso.ToList();
                }

                if (salaRecursos.Count > 0)
                {
                    foreach (var salaRecurso in salaRecursos)
                    {
                        SalaRecursoEntity salaRecursosEntity = new SalaRecursoEntity()
                        {
                            salaRecursoID = salaRecurso.salaRecursoID,
                            salaID = salaRecurso.salaID,
                            nombreRecurso = salaRecurso.nombreRecurso,
                            cantidad = salaRecurso.cantidad,
                            estadoRegistro=salaRecurso.estadoRegistro  
                        };

                        entities.Add(salaRecursosEntity);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public bool insertSalaRecurso(int salaID, string nombreRecurso, int cantidad,string estadoRegistro)
        {
            bool entity = false;

            try
            {
                entity = insertDBsalaRecurso(salaID, nombreRecurso, cantidad, estadoRegistro);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar salaRecurso");
            }

            return entity;
        }

        private bool insertDBsalaRecurso(int salaID, string nombreRecurso, int cantidad, string estadoRegistro)
        {
            salaRecurso item = new salaRecurso();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new salaRecurso()
                    {
                        salaID = salaID,
                        nombreRecurso = nombreRecurso,
                        cantidad = cantidad,
                        estadoRegistro="A"
                    };

                    dbContext.salaRecurso.Add(item);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifysalaRecurso(int salaRecursoID, int salaID, string nombreRecurso, int cantidad,string estadoRegistro)
        {
            bool entity = false;

            try
            {
                string validation = salaRecursoID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la persona no se ha especificado.");
                }

                entity = UpdateRecord(salaRecursoID, salaID, nombreRecurso, cantidad, estadoRegistro);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el usuario.");
            }

            return entity;
        }

        private bool UpdateRecord(int salaRecursoID, int salaID, string nombreRecurso, int cantidad, string estadoRegistro)
        {
            bool resp = false;
            salaRecurso salaRecurso = new salaRecurso();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    salaRecurso = dbContext.salaRecurso.Where(x => x.salaRecursoID == salaRecursoID).FirstOrDefault();

                    if (salaRecurso != null)
                    {
                        salaRecurso.salaRecursoID = salaRecursoID;
                        salaRecurso.salaID = salaID;
                        salaRecurso.cantidad = cantidad;
                        salaRecurso.estadoRegistro = estadoRegistro;

                        if (!string.IsNullOrEmpty(nombreRecurso))
                        {
                            salaRecurso.nombreRecurso = nombreRecurso;
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

        public SalaRecursoEntity consultarSalaRecurso(int salaRecursoID)
        {
            SalaRecursoEntity resp = new SalaRecursoEntity();

            resp = getSalaRecursoInfo(salaRecursoID);

            return resp;
        }


        private SalaRecursoEntity getSalaRecursoInfo(int salaRecursoID)
        {
            salaRecurso salaRecurso = new salaRecurso();
            SalaRecursoEntity resp = new SalaRecursoEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    salaRecurso = dbContext.salaRecurso.Where(x => x.salaRecursoID == salaRecursoID).FirstOrDefault();
                }

                if (salaRecurso != null)
                {
                    resp = new SalaRecursoEntity()
                    {
                        salaRecursoID = salaRecurso.salaRecursoID,
                        salaID = salaRecurso.salaID,
                        nombreRecurso = salaRecurso.nombreRecurso,
                        cantidad = salaRecurso.cantidad,
                        estadoRegistro=salaRecurso.estadoRegistro
                    };
                }

                return resp;
            }
            catch (Exception ex)
            {
                return resp;
            }
        }

        public bool eliminarSalaRecurso(int salaRecursoID)
        {
            bool resp = false;

            resp = EliminarInfo(salaRecursoID);

            return resp;
        }




        private bool EliminarInfo(int salaRecursoID)
        {

            SalaRecursoEntity resp = new SalaRecursoEntity();
            //FKS:
            //evento
            //salaRecursoRecurso
            //salaRecursoRecursoEspecial
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    var salaRecurso = dbContext.salaRecurso.Where(x => x.salaRecursoID == salaRecursoID).FirstOrDefault();


                    if (salaRecurso != null)
                    {
                        dbContext.salaRecurso.Remove(salaRecurso);
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

        public bool inactivarSalaRecurso(int salaRecursoID)
        {
            bool resp = false;

            resp = InactivarInfo(salaRecursoID);

            return resp;
        }

        private bool InactivarInfo(int salaRecursoID)
        {

            salaRecurso salaRecurso = new salaRecurso();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    salaRecurso = dbContext.salaRecurso.Where(x => x.salaRecursoID == salaRecursoID).FirstOrDefault();

                    if (salaRecurso != null)
                    {
                        if (salaRecurso.estadoRegistro == "A")
                        {
                            salaRecurso.estadoRegistro = "I";
                        }
                        else if (salaRecurso.estadoRegistro == "I")
                        {
                            salaRecurso.estadoRegistro = "A";
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
