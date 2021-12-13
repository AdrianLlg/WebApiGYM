//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WebAPIBusiness.Entities.FKRelationships;
//using WebAPIBusiness.Entities.RecursoAdmin;
//using WebAPIBusiness.Resources;
//using WebAPIData;

//namespace WebAPIBusiness.BusinessCore
//{
//    public class RecursoAdminBO
//    {
//        public List<RecursoAdminEntity> getRecursos()
//        {
//            List<RecursoAdminEntity> entities = new List<RecursoAdminEntity>();

//            entities = getRecursosDB();

//            return entities;
//        }

//        private List<RecursoAdminEntity> getRecursosDB()
//        {
//            List<RecursoAdminEntity> entities = new List<RecursoAdminEntity>();
//            List<recurso> recursos = new List<recurso>();
//            try
//            {
//                using (var dbContext = new GYMDBEntities())
//                {
//                    recursos = dbContext.recurso.ToList();
//                }

//                if (recursos.Count > 0)
//                {
//                    foreach (var recurso in recursos)
//                    {
//                        RecursoAdminEntity RecursoEntity = new RecursoAdminEntity()
//                        {
//                            recursoID = recurso.recursoID,
//                            nombre = recurso.nombre,
//                            descripcion = recurso.descripcion,
//                            cantidadRecurso = recurso.cantidadRecurso

//                        };

//                        entities.Add(RecursoEntity);
//                    }
//                }

//                return entities;
//            }
//            catch (Exception ex)
//            {
//                return entities;
//            }
//        }

//        public bool insertRecurso(string nombre, string descripcion, string cantidadRecurso)
//        {
//            bool entity = false;

//            try
//            {
//                entity = insertDBRecurso(nombre, descripcion, cantidadRecurso);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Ocurrió un error al insertar el recurso");
//            }

//            return entity;
//        }

//        private bool insertDBRecurso(string nombre, string descripcion, string cantidadRecurso)
//        {

//            recurso item = new recurso();

//            try
//            {
//                using (var dbContext = new GYMDBEntities())
//                {
//                    item = new recurso()
//                    {
//                        nombre = nombre,
//                        descripcion = descripcion,
//                        cantidadRecurso = int.Parse(cantidadRecurso)
//                    };

//                    dbContext.recurso.Add(item);
//                    dbContext.SaveChanges();
//                }

//                return true;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        public bool modifyRecurso(int recursoID, string nombre, string descripcion, string cantidadRecurso)
//        {
//            bool entity = false;

//            try
//            {
//                string validation = recursoID.ToString();

//                if (string.IsNullOrEmpty(validation))
//                {
//                    throw new Exception("El ID del recurso no se ha especificado.");
//                }

//                entity = UpdateRecord(recursoID, nombre, descripcion, cantidadRecurso);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Ocurrió un error al modificar el recurso.");
//            }

//            return entity;
//        }

//        private bool UpdateRecord(int recursoID, string nombre, string descripcion, string cantidadRecurso)
//        {
//            recurso rec = new recurso();

//            try
//            {
//                using (var dbContext = new GYMDBEntities())
//                {
//                    rec = dbContext.recurso.Where(x => x.recursoID == recursoID).FirstOrDefault();

//                    if (rec != null)
//                    {
//                        if (!string.IsNullOrEmpty(nombre))
//                        {
//                            rec.nombre = nombre;
//                        }
//                        if (!string.IsNullOrEmpty(descripcion))
//                        {
//                            rec.descripcion = descripcion;
//                        }
//                        if (!string.IsNullOrEmpty(cantidadRecurso))
//                        {
//                            rec.cantidadRecurso = int.Parse(cantidadRecurso);
//                        }
//                    }
//                    else
//                    {
//                        return false;
//                    }
//                    dbContext.SaveChanges();
//                    return true;
//                }
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        public RecursoAdminEntity consultarRecurso(int recursoID)
//        {
//            RecursoAdminEntity resp = new RecursoAdminEntity();

//            resp = getRecursoInfo(recursoID);

//            return resp;
//        }


//        private RecursoAdminEntity getRecursoInfo(int recursoID)
//        {
//            recurso rec = new recurso();
//            RecursoAdminEntity resp = new RecursoAdminEntity();

//            try
//            {
//                using (var dbContext = new GYMDBEntities())
//                {
//                    rec = dbContext.recurso.Where(x => x.recursoID == recursoID).FirstOrDefault();
//                }

//                if (rec != null)
//                {
//                    resp = new RecursoAdminEntity()
//                    {
//                        recursoID = rec.recursoID,
//                        nombre = rec.nombre,
//                        descripcion = rec.descripcion,
//                        cantidadRecurso = rec.cantidadRecurso
//                    };
//                }

//                return resp;
//            }
//            catch (Exception ex)
//            {
//                return resp;
//            }
//        }

//        public bool eliminarRecurso(int recursoID)
//        {
//            bool resp = false;

//            resp = eliminarRecursoDB(recursoID);

//            return resp;
//        }


//        private bool eliminarRecursoDB(int recursoID)
//        {

//            RecursoAdminEntity resp = new RecursoAdminEntity();

//            try
//            {
//                //List<string> tablasFK = checkForeignKeys();


//                bool canDelete = false; 
//                using (var dbContext = new GYMDBEntities())
//                {
//                    var check = false;
//                    var evR=dbContext.evento_recurso.Where(s => s.recursoID == recursoID).FirstOrDefault<evento_recurso>(); ;
//                    if (evR == null)
//                    {
//                        check = true;
//                        canDelete = check;
//                    }
//                    else {
//                        canDelete = false;
//                    }
//                }
                 

//                if (canDelete == true)
//                {

//                    using (var dbContext = new GYMDBEntities())
//                    {
//                        var nt = dbContext.recurso.Where(x => x.recursoID == recursoID).FirstOrDefault();
//                        if (nt != null)
//                        {
//                            dbContext.recurso.Remove(nt);
//                            dbContext.SaveChanges();
//                        }
                       
//                    }

//                    return true;

//                }
//                else {
//                    return false;
//                }
                
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        private List<string> checkForeignKeys()
//        {

//            List<FKListEntity> consulta = new List<FKListEntity>();
//            List<string> resp = new List<string>();

           

//            using (var dbContext = new GYMDBEntities())
//            {
//                string query = string.Format(ScriptsGYMDB.get_FKRelationships, "recurso");
//                consulta = dbContext.Database.SqlQuery<FKListEntity>(query).ToList();
//            }

//            foreach (var i in consulta)
//            {
//                resp.Add(i.FKTABLE_NAME);
//            }

//            return resp;
//        }







//    }
//}

