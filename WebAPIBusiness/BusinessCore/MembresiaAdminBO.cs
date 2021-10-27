using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.DisciplinaAdmin;
using WebAPIBusiness.Entities.Membresia;
using WebAPIBusiness.Entities.MembresiaAdmin;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class MembresiaAdminBO
    {
        public List<MembresiaAdminEntity> getMembershipsInfo()
        {
            List<MembresiaAdminEntity> entities = new List<MembresiaAdminEntity>();

            entities = getMemberships();

            return entities;
        }

        private List<MembresiaAdminEntity> getMemberships()
        {
            List<MembresiaAdminEntity> entities = new List<MembresiaAdminEntity>();
            List<membresia> membresias = new List<membresia>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    membresias = dbContext.membresia.ToList();
                }

                if (membresias.Count > 0)
                {
                    foreach (var m in membresias)
                    {
                        MembresiaAdminEntity MembresiasEntity = new MembresiaAdminEntity()
                        {
                            membresiaID = m.membresiaID,
                            descripcion = m.descripcion,
                            nombre = m.nombre,
                            precio = m.precio,
                            periodicidad = m.periodicidad

                        };

                        entities.Add(MembresiasEntity);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public bool insertMembership(string nombre, string descripcion, string precio, string periodicidad, List<DisciplinasMembresiaRequestEntity> disciplinas)
        {
            bool resp = false;
            decimal valPrecio;

            try
            {
                if (string.IsNullOrEmpty(precio))
                {
                    throw new Exception("El precio ingresado no es un valor válido.");
                }
                else
                {
                    valPrecio = decimal.Parse(precio);
                }

                resp = insertDBMembership(nombre, descripcion, valPrecio, periodicidad, out int id);

                if (resp)
                {
                    resp = insertDBMembershipAndDisciplines(disciplinas, id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el usuario/calcular la edad del usuario.");
            }

            return resp;
        }

        private bool insertDBMembership(string nombre, string descripcion, decimal precio, string periodicidad, out int id)
        {

            membresia item = new membresia();
            id = 0;

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new membresia()
                    {
                        nombre = nombre,
                        precio = precio,
                        descripcion = descripcion,
                        periodicidad = periodicidad
                    };

                    dbContext.membresia.Add(item);
                    dbContext.SaveChanges();

                    id = dbContext.membresia.OrderByDescending(x => x.membresiaID).Select(x => x.membresiaID).FirstOrDefault();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool insertDBMembershipAndDisciplines(List<DisciplinasMembresiaRequestEntity> disciplinas, int membresiaid)
        {
            if (membresiaid == 0)
            {
                throw new Exception("El ID de la membresia no es válido.");
            }

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    foreach (var disc in disciplinas)
                    {
                        membresia_disciplina item = new membresia_disciplina()
                        {
                            membresiaID = membresiaid,
                            disciplinaID = int.Parse(disc.Value),
                            numClasesDisponibles = disc.Quantity
                        };

                        dbContext.membresia_disciplina.Add(item);
                        dbContext.SaveChanges();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifyMembership(int membresiaID, string nombre, string descripcion, string precio)
        {
            bool entity = false;

            try
            {
                if (membresiaID == 0)
                {
                    throw new Exception("El ID de la membresia no es válido.");
                }

                entity = UpdateRecord(membresiaID, nombre, descripcion, precio);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el usuario.");
            }

            return entity;
        }

        private bool UpdateRecord(int membresiaID, string nombre, string descripcion, string precio)
        {
            membresia memb = new membresia();

            try
            {
                int precioC = int.Parse(precio);

                using (var dbContext = new GYMDBEntities())
                {
                    memb = dbContext.membresia.Where(x => x.membresiaID == membresiaID).FirstOrDefault();

                    if (memb != null)
                    {
                        if (!string.IsNullOrEmpty(nombre))
                        {
                            memb.nombre = nombre;
                        }
                        if (!string.IsNullOrEmpty(descripcion))
                        {
                            memb.descripcion = descripcion;
                        }
                        if (!string.IsNullOrEmpty(precio))
                        {
                            memb.precio = precioC;
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

        public MembresiaAdminEntity consultarMembresia(int membresiaID)
        {
            MembresiaAdminEntity resp = new MembresiaAdminEntity();

            resp = getMembershipInfo(membresiaID);

            return resp;
        }


        private MembresiaAdminEntity getMembershipInfo(int membresiaID)
        {
            membresia memb = new membresia();
            MembresiaAdminEntity resp = new MembresiaAdminEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    memb = dbContext.membresia.Where(x => x.membresiaID == membresiaID).FirstOrDefault();
                }

                if (memb != null)
                {
                    resp = new MembresiaAdminEntity()
                    {
                        membresiaID = memb.membresiaID,
                        nombre = memb.nombre,
                        descripcion = memb.descripcion,
                        precio = memb.precio,
                        periodicidad = memb.periodicidad
                    };
                }

                return resp;
            }
            catch (Exception ex)
            {
                return resp;
            }
        }


        public bool insertNewMembership(int personaID, int membresiaID)
        {
            List<MembresiaDisciplinaEntity> entities = new List<MembresiaDisciplinaEntity>();
            bool resp = false;
            try
            {
                if (personaID > 0 && membresiaID > 0)
                {
                    entities = consultarDisciplinasdeMembresia(personaID, membresiaID);

                    if (entities.Count > 0)
                    {
                        resp = insertNewPersonMembershipDB(personaID, membresiaID, entities);
                    }
                    else
                    {
                        throw new ValidationAndMessageException("La membresía ingresada no contiene disciplinas o no existe la membresía.");
                    }

                    return resp;
                }
                else
                {
                    throw new ValidationAndMessageException("PersonaID o MembresiaID tienen valores inválidos.");
                }
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }

        }

        private List<MembresiaDisciplinaEntity> consultarDisciplinasdeMembresia(int personaID, int membresiaID)
        {
            List<MembresiaDisciplinaEntity> entities = new List<MembresiaDisciplinaEntity>();
            List<membresia_disciplina> query = new List<membresia_disciplina>();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    query = dbContext.membresia_disciplina.Where(x => x.membresiaID == membresiaID).ToList();
                }

                if (query.Count > 0)
                {

                    foreach (var item in query)
                    {
                        MembresiaDisciplinaEntity entity = new MembresiaDisciplinaEntity()
                        {
                            membresia_disciplinaID = item.membresia_disciplinaID,
                            membresiaID = item.membresiaID,
                            disciplinaID = item.disciplinaID,
                            numClasesDisponibles = item.numClasesDisponibles
                        };

                        entities.Add(entity);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException("Ocurrió un error en el manejo de datos en la BD.");
            }
        }

        private bool insertNewPersonMembershipDB(int personaID, int membresiaID, List<MembresiaDisciplinaEntity> entities)
        {
            membresia_persona_disciplina query = new membresia_persona_disciplina();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    foreach (var entity in entities)
                    {
                        query = new membresia_persona_disciplina()
                        {
                            membresia_disciplinaID = entity.membresia_disciplinaID,
                            personaID = personaID,
                            numClasesDisponibles = entity.numClasesDisponibles,
                            estado = "I"
                        };

                        dbContext.membresia_persona_disciplina.Add(query);
                        dbContext.SaveChanges();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException("Ocurrió un error en el manejo de datos en la BD.");
            }
        }

        public List<Membresia_Disciplina_NumClasesEntity> consultarDisciplinasDeMembresia(int membresiaID)
        {
            List<Membresia_Disciplina_NumClasesEntity> resp = new List<Membresia_Disciplina_NumClasesEntity>();

            resp = getMembershipDisciplinesInfo(membresiaID);

            return resp;
        }


        private List<Membresia_Disciplina_NumClasesEntity> getMembershipDisciplinesInfo(int membresiaID)
        {
            List<membresia_disciplina> memb = new List<membresia_disciplina>();
            List<Membresia_Disciplina_NumClasesEntity> resp = new List<Membresia_Disciplina_NumClasesEntity>();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    memb = dbContext.membresia_disciplina.Where(x => x.membresiaID == membresiaID).ToList();

                    if (memb.Count > 0)
                    {
                        foreach (var m in memb)
                        {
                            Membresia_Disciplina_NumClasesEntity item = new Membresia_Disciplina_NumClasesEntity()
                            {
                                disciplinaID = m.disciplinaID,
                                nombre = m.disciplina.nombre,
                                descripcion = m.disciplina.descripcion,
                                numClasesDisponibles = m.numClasesDisponibles
                            };

                            resp.Add(item);
                        }
                    }
                    else
                    {
                        throw new ValidationAndMessageException("No se encontró las disciplinas de la membresía buscada.");
                    }
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
