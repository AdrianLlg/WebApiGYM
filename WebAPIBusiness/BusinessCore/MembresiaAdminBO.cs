using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebAPIBusiness.CustomExceptions;
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
                            precio = m.precio
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

        public bool insertMembership(string nombre, string descripcion, string precio)
        {
            bool entity = false;
            int valPrecio = 0;

            try
            {
                if (string.IsNullOrEmpty(precio))
                {
                    throw new Exception("El precio ingresado no es un entero válido.");
                }
                else
                {
                    valPrecio = int.Parse(precio);
                }

                entity = insertDBMembership(nombre, descripcion, valPrecio);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el usuario/calcular la edad del usuario.");
            }

            return entity;
        }

        private bool insertDBMembership(string nombre, string descripcion, int precio)
        {

            membresia item = new membresia();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new membresia()
                    {
                        nombre = nombre,
                        precio = precio,
                        descripcion = descripcion
                    };

                    dbContext.membresia.Add(item);
                    dbContext.SaveChanges();
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
                        precio = memb.precio
                    };
                }

                return resp;
            }
            catch (Exception ex)
            {
                return resp;
            }
        }


        public bool insertNewMembership(int personaID, int membresiaID, string fechapago)
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
                        DateTime fechPago = DateTime.Parse(fechapago);

                        resp = insertNewMembershipDB(personaID, membresiaID, fechPago, entities);
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

        private bool insertNewMembershipDB(int personaID, int membresiaID, DateTime fechapag, List<MembresiaDisciplinaEntity> entities)
        {
            membresia_persona_disciplina query = new membresia_persona_disciplina();
            var fechLimite = fechapag.AddDays(30).Date;

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
                            fechaPago = fechapag,
                            fechaLimite = fechLimite,
                            numClasesDisponibles = entity.numClasesDisponibles,
                            status = "I"
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

    }
}
