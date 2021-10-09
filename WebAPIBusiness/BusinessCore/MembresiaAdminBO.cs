using System;
using System.Collections.Generic;
using System.Linq;
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
                        nombre =  nombre,
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
    }
}
