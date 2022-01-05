using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.SolicitudesMembresias;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class SolicitudesMembresiasBO
    {
        public List<SolicitudesMembresiasEntity> getMembershipRequests()
        {
            List<SolicitudesMembresiasEntity> entities = new List<SolicitudesMembresiasEntity>();

            entities = getMembershipsRequestsDB();

            return entities;
        }

        private List<SolicitudesMembresiasEntity> getMembershipsRequestsDB()
        {
            List<SolicitudesMembresiasEntity> entities = new List<SolicitudesMembresiasEntity>();
            List<sol_membresiaPago> membresiasSol = new List<sol_membresiaPago>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    membresiasSol = dbContext.sol_membresiaPago.Where(x => x.estado == "A").ToList();

                    if (membresiasSol.Count > 0)
                    {
                        foreach (var m in membresiasSol)
                        {
                            SolicitudesMembresiasEntity MembresiasEntity = new SolicitudesMembresiasEntity()
                            {
                                solicitud_membresiaPagoID = m.sol_membresiaPagoID,
                                personaID = m.personaID,
                                nombrePersona = m.persona.nombres + " " + m.persona.apellidos,
                                identificacionPersona = m.persona.identificacion,
                                membresiaID = m.membresiaID,
                                nombreMembresia = m.membresia.nombre,
                                perioridicidadMembresia = m.membresia.periodicidad,
                                membresia_persona_pagoID = m.membresia_persona_pagoID,
                                fechaRegistroSolicitud = m.fechaRegistroSolicitud,
                                comprobante = m.comprobante,
                                estado = m.estado
                            };

                            entities.Add(MembresiasEntity);
                        }
                    }
                    else
                    {
                        throw new ValidationAndMessageException("No existen solicitudes pendientes.");
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }
        }

        public bool declineOrAcceptRequest(int solicitud_membresiaPagoID, int membresia_persona_pagoID, int IdentificadorAceptarEliminar, string formaPago, string fechaTransaccion, string nroDocumento, string Banco)
        {
            bool resp = false;

            try
            { 
                resp = declineOrAcceptRequestDB(solicitud_membresiaPagoID, membresia_persona_pagoID, IdentificadorAceptarEliminar, formaPago, fechaTransaccion, nroDocumento, Banco);
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.Message);
            }

            return resp;
        }

        private bool declineOrAcceptRequestDB(int solicitud_membresiaPagoID, int membresia_persona_pagoID, int IdentificadorAceptarEliminar, string formaPago, string fechaTransaccion, string nroDocumento, string Banco)
        {
            MembresiaAdminBO bo = new MembresiaAdminBO();
            try
            {               
                using (var dbContext = new GYMDBEntities())
                {
                    var objectSol = dbContext.sol_membresiaPago.Where(x => x.sol_membresiaPagoID == solicitud_membresiaPagoID).FirstOrDefault();

                    if (objectSol != null)
                    {
                        var objmembresia_persona_pago = dbContext.membresia_persona_pago
                                                                     .Where(x => x.membresia_persona_pagoID == membresia_persona_pagoID)
                                                                     .FirstOrDefault();
                        if (objmembresia_persona_pago != null)
                        {
                            //Aceptar Solicitud
                            if (IdentificadorAceptarEliminar == 1)
                            {
                                var disciplinas = bo.consultarDisciplinasdeMembresia(objmembresia_persona_pago.membresiaID);

                                foreach (var entity in disciplinas)
                                {
                                    membresia_persona_disciplina query = new membresia_persona_disciplina()
                                    {
                                        personaID = objmembresia_persona_pago.personaID,
                                        membresia_persona_pagoID = objmembresia_persona_pago.membresia_persona_pagoID,
                                        membresia_disciplinaID = entity.membresia_disciplinaID,
                                        fechaInicio = objmembresia_persona_pago.fechaInicioMembresia,
                                        fechaFin = (DateTime)objmembresia_persona_pago.fechaFinMembresia,
                                        numClasesDisponibles = entity.numClasesDisponibles,
                                        estado = "A"
                                    };

                                    dbContext.membresia_persona_disciplina.Add(query);
                                    dbContext.SaveChanges();
                                }

                                objmembresia_persona_pago.estado = "A";
                                objmembresia_persona_pago.formaPago = formaPago;
                                objmembresia_persona_pago.fechaTransaccion = Convert.ToDateTime(fechaTransaccion);
                                objmembresia_persona_pago.nroDocumento = nroDocumento;
                                objmembresia_persona_pago.Banco = Banco;
                                dbContext.sol_membresiaPago.Remove(objectSol);
                                dbContext.SaveChanges();

                                return true;
                            }
                            //Eliminar Solicitud
                            else
                            {
                                dbContext.sol_membresiaPago.Remove(objectSol);
                                dbContext.membresia_persona_pago.Remove(objmembresia_persona_pago);
                                dbContext.SaveChanges();

                                return true;
                            }
                        }
                        else
                        {
                            throw new Exception("No se encontró el registro de pago ligado a la solicitud");
                        }                        
                    }
                    else
                    {
                        throw new Exception("La solicitud ingresada no existe o está inactiva");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
