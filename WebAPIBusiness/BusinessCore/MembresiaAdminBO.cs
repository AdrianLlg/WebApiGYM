using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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

                    if (membresias.Count > 0)
                    {
                        foreach (var m in membresias)
                        {
                            var disciplinas = dbContext.membresia_disciplina.Where(x => x.membresiaID == m.membresiaID).ToList();

                            List<Membresia_Disciplina_NumClasesEntity> listDisciplines = new List<Membresia_Disciplina_NumClasesEntity>();

                            if (disciplinas.Count > 0)
                            {
                                foreach (var discipl in disciplinas)
                                {
                                    Membresia_Disciplina_NumClasesEntity disciplina = new Membresia_Disciplina_NumClasesEntity()
                                    {

                                        disciplinaID = discipl.disciplinaID,
                                        descripcion = discipl.disciplina.descripcion,
                                        nombre = discipl.disciplina.nombre,
                                        numClasesDisponibles = discipl.numClasesDisponibles
                                    };

                                    listDisciplines.Add(disciplina);
                                }
                            }
                            else
                            {
                                listDisciplines = null;
                            }                           

                            MembresiaAdminEntity MembresiasEntity = new MembresiaAdminEntity()
                            {
                                membresiaID = m.membresiaID,
                                descripcion = m.descripcion,
                                nombre = m.nombre,
                                precio = m.precio,
                                periodicidad = m.periodicidad,
                                estadoRegistro = m.estadoRegistro,
                                disciplinas = listDisciplines
                            };

                            entities.Add(MembresiasEntity);
                        }
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
                        periodicidad = periodicidad,
                        estadoRegistro = "A"
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
                decimal precioC = decimal.Parse(precio);

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


        public bool insertNewMembership(int personaID, int membresiaID, string fechaInicioMembresia, string formaPago, string fechaTransaccion, string nroDocumento, string tipoBanco)
        {
            bool resp = false;
            try
            {
                DateTime fechaIMembresia = Convert.ToDateTime(fechaInicioMembresia);
                DateTime fechaTrans = Convert.ToDateTime(fechaTransaccion);
                int monthsToAdd = 0;
                bool verifyInsert = false;
                int membershipID = 0;

                if (personaID > 0 && membresiaID > 0)
                {
                    monthsToAdd = getMembershipPeriodicityDays(membresiaID, personaID, out verifyInsert);

                    if (verifyInsert)
                    {
                        List<MembresiaDisciplinaEntity> disciplinas = consultarDisciplinasdeMembresia(membresiaID);

                        if (disciplinas.Count > 0)
                        {
                            membershipID = insertNewMembershipDB_Pago(personaID, membresiaID, fechaIMembresia, formaPago, fechaTrans, nroDocumento, tipoBanco, monthsToAdd);

                            if (membresiaID > 0)
                            {
                                resp = insertNewPersonMembershipDB(personaID, disciplinas, fechaIMembresia, monthsToAdd, membershipID);
                            }
                        }
                        else
                        {
                            throw new ValidationAndMessageException("La membresía ingresada no contiene disciplinas o no existe la membresía.");
                        }
                    }
                    else
                    {
                        throw new ValidationAndMessageException("La persona ya tiene la misma membresía ingresada al sistema.");
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
        private int getMembershipPeriodicityDays(int membresiaID, int personaID, out bool verifyInsert)
        {
            int monthsToAdd = 0;
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    string membership_type = dbContext.membresia.Where(x => x.membresiaID == membresiaID).Select(x => x.periodicidad).FirstOrDefault();
                    var val = dbContext.membresia_persona_pago.Where(x => x.membresiaID == membresiaID && x.personaID == personaID && x.estado == "A").FirstOrDefault();

                    if (val == null)
                    {
                        verifyInsert = true;
                    }
                    else
                    {
                        verifyInsert = false;
                    }

                    if (membership_type != null)
                    {
                        monthsToAdd = calculateMonthsOfPeriodTime(membership_type);
                    }
                    else
                    {
                        throw new ValidationAndMessageException("La membresía ingresada no existe.");
                    }
                }

                return monthsToAdd;
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException("Ocurrió un error al obtener el número de días por periodicidad de membresía.");
            }
        }

        public List<MembresiaDisciplinaEntity> consultarDisciplinasdeMembresia(int membresiaID)
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

        private bool insertNewPersonMembershipDB(int personaID, List<MembresiaDisciplinaEntity> entities, DateTime fechaIMembresia, int monthsToAdd, int membershipID)
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
                            personaID = personaID,
                            membresia_persona_pagoID = membershipID,
                            membresia_disciplinaID = entity.membresia_disciplinaID,
                            fechaInicio = fechaIMembresia,
                            fechaFin = fechaIMembresia.AddMonths(monthsToAdd),
                            numClasesDisponibles = entity.numClasesDisponibles,
                            estado = "A"
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

        private int insertNewMembershipDB_Pago(int personaID, int membresiaID, DateTime fechaInicioMembresia, string formaPago, DateTime fechaTransaccion, string nroDocumento, string tipoBanco, int monthsToAdd)
        {
            try
            {
                using (var dbContext = new GYMDBEntities())
                {

                    membresia_persona_pago query = new membresia_persona_pago()
                    {
                        personaID = personaID,
                        membresiaID = membresiaID,
                        fechaInicioMembresia = fechaInicioMembresia,
                        fechaFinMembresia = fechaInicioMembresia.AddMonths(monthsToAdd),
                        formaPago = formaPago,
                        fechaTransaccion = fechaTransaccion.Date,
                        nroDocumento = nroDocumento,
                        Banco = tipoBanco,
                        estado = "A"
                    };

                    dbContext.membresia_persona_pago.Add(query);
                    dbContext.SaveChanges();


                    int resp = dbContext.membresia_persona_pago
                            .Where(x => x.formaPago == formaPago && x.fechaTransaccion == fechaTransaccion && x.nroDocumento == nroDocumento && x.Banco == tipoBanco)
                            .Select(x => x.membresia_persona_pagoID).FirstOrDefault();

                    return resp;
                }
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
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

        public bool insertPendingMembership(int personaID, int membresiaID, string imagen)
        {
            bool resp = false;
            int monthsToAddM = 0;
            int membresiaPersonaPagoID = 0;

            try
            {
                if (personaID > 0 && membresiaID > 0)
                {
                    bool validationPreviousSol = validatePreviousRequest(personaID, membresiaID);

                    if (validationPreviousSol)
                    {
                        throw new ValidationAndMessageException("SolicitudPrevia");
                    }

                    MembresiaPersonaPagoEntity item = hasPreviousMembership(personaID, membresiaID, out monthsToAddM);

                    if (item != null)
                    {
                        resp = insertPendingDBRegister(personaID, membresiaID, item.fechaInicioMembresia, monthsToAddM, out membresiaPersonaPagoID);

                        if (resp)
                        {
                            resp = insertPendingSol(personaID, membresiaID, membresiaPersonaPagoID, imagen);
                        }
                    }
                    else
                    {
                        resp = newSolMembership(personaID, membresiaID);

                        if (resp)
                        {
                            resp = newMembership(personaID, membresiaID, imagen);
                        }
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

        private bool validatePreviousRequest(int personaID, int membresiaID)
        {
            bool response = false;


            using (var dbContext = new GYMDBEntities())
            {
                var query = dbContext.sol_membresiaPago.Where(x => x.membresiaID == membresiaID && x.personaID == personaID && x.estado == "A").FirstOrDefault();

                if (query != null)
                {
                    response = true;
                }
            }

            return response;
        } 

        private MembresiaPersonaPagoEntity hasPreviousMembership(int personaID, int membresiaID, out int daysToAdd)
        {
            MembresiaPersonaPagoEntity entity;
            membresia_persona_pago query = new membresia_persona_pago();
            daysToAdd = 0;

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    query = dbContext.membresia_persona_pago
                                                .Where(x => x.membresiaID == membresiaID
                                                         && x.personaID == personaID
                                                         && x.estado == "A")
                                                .OrderByDescending(x => x.fechaInicioMembresia)
                                                .FirstOrDefault();
                    if (query != null)
                    {
                        daysToAdd = calculateMonthsOfPeriodTime(query.membresia.periodicidad);
                    }

                }

                if (query != null)
                {
                    entity = new MembresiaPersonaPagoEntity()

                    {
                        membresia_persona_pagoID = query.membresia_persona_pagoID,
                        membresiaID = query.membresiaID,
                        personaID = query.personaID,
                        estado = query.estado,
                        fechaInicioMembresia = (DateTime)query.fechaInicioMembresia,
                        fechaFinMembresia = (DateTime)query.fechaFinMembresia
                    };
                }
                else
                {
                    entity = null;
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }
        }

        private bool newSolMembership(int personaID, int membresiaID)
        {
            //Fecha default para identificar que es una membresia ingresada como solicitud.
            string dateDefault = "2000-12-12";
            DateTime dateDefault2 = DateTime.ParseExact(dateDefault, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    membresia_persona_pago query = new membresia_persona_pago()
                    {
                        personaID = personaID,
                        membresiaID = membresiaID,
                        fechaInicioMembresia = dateDefault2,
                        fechaFinMembresia = dateDefault2,                        
                        estado = "I"
                    };
                    dbContext.membresia_persona_pago.Add(query);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }
        }

        private bool newMembership(int personaID, int membresiaID, string imagen)
        {
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    int ID = dbContext.membresia_persona_pago
                            .OrderByDescending(x => x.membresia_persona_pagoID)
                            .Select(x => x.membresia_persona_pagoID)
                            .FirstOrDefault();

                    sol_membresiaPago query = new sol_membresiaPago()
                    {
                        personaID = personaID,
                        membresiaID = membresiaID,
                        membresia_persona_pagoID = ID,
                        fechaRegistroSolicitud = DateTime.Now,
                        comprobante = Convert.FromBase64String(imagen),
                        estado = "A"
                    };

                    dbContext.sol_membresiaPago.Add(query);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }
        }

        private bool insertPendingDBRegister(int personaID, int membresiaID, DateTime datePreviousMembreship, int monthsToAddM, out int membresiaPersonaPagoID)
        {
            DateTime newTimeMembership = datePreviousMembreship.AddMonths(monthsToAddM);
            newTimeMembership = newTimeMembership.AddDays(1);

            DateTime endTimeMembership = newTimeMembership.AddMonths(monthsToAddM);
            membresiaPersonaPagoID = 0;

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    dbContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    membresia_persona_pago query = new membresia_persona_pago()
                    {
                        personaID = personaID,
                        membresiaID = membresiaID,
                        fechaInicioMembresia = newTimeMembership,
                        fechaFinMembresia = endTimeMembership,
                        estado = "I"
                    };

                    dbContext.membresia_persona_pago.Add(query);
                    dbContext.SaveChanges();

                    membresiaPersonaPagoID = dbContext.membresia_persona_pago.Where(x => x.personaID == personaID
                                                                        && x.membresiaID == membresiaID
                                                                        && x.estado == "I")
                                                                        .OrderBy(x => x.membresia_persona_pagoID)
                                                                        .Select(x => x.membresia_persona_pagoID)
                                                                        .FirstOrDefault();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }
        }

        public int calculateMonthsOfPeriodTime(string Periodicidad)
        {
            int val = 0;

            switch (Periodicidad)
            {
                case "Mensual":
                    val = 1;
                    break;
                case "Bimestral":
                    val = 2;
                    break;
                case "Trimestral":
                    val = 3;
                    break;
                case "Semestral":
                    val = 6;
                    break;
                case "Anual":
                    val = 12;
                    break;
            }

            return val;
        }
        private bool insertPendingSol(int personaID, int membresiaID, int membresiaPersonaPagoID, string imagen)
        {
            DateTime hoy = DateTime.Now;

            try
            {
                using (var dbContext = new GYMDBEntities())
                {

                    sol_membresiaPago query = new sol_membresiaPago()
                    {
                        personaID = personaID,
                        membresiaID = membresiaID,
                        membresia_persona_pagoID = membresiaPersonaPagoID,
                        fechaRegistroSolicitud = hoy,
                        comprobante = Convert.FromBase64String(imagen),
                        estado = "A"
                    };

                    dbContext.sol_membresiaPago.Add(query);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }
        }

        public bool inactivarMembresia(int membresiaID)
        {
            bool resp = false;

            resp = InactivarMemb(membresiaID);

            return resp;
        }

        private bool InactivarMemb(int membresiaID)
        {
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    var memb = dbContext.membresia.Where(x => x.membresiaID == membresiaID).FirstOrDefault();

                    if (memb != null)
                    {
                        if (memb.estadoRegistro == "A")
                        {
                            memb.estadoRegistro = "I";
                        }
                        else
                        {
                            return false;
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
