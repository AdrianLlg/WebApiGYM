﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebAPIBusiness.Entities.Membresia;
using WebAPIBusiness.Resources;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class MembresiaBO
    {
        public List<MembresiaEntity> membresiasUser(string personaID)
        {
            List<MembresiaEntity> membresias = getMembresiasUser(personaID);

            return membresias;
        }

        private List<MembresiaEntity> getMembresiasUser(string personaID)
        {
            List<MembresiaEntity> membresias = new List<MembresiaEntity>();
            try
            {
                int personID = int.Parse(personaID);

                using (var dbContext = new GYMDBEntities())
                {
                    var items1 = dbContext.membresia_persona_pago.Where(x => x.personaID == personID).OrderBy(x => x.fechaInicioMembresia).ToList();

                    if (items1.Count > 0)
                    {
                        foreach (var item in items1)
                        {
                            //var items2 = dbContext.membresia_persona_disciplina.Where(x => x.personaID == personID && x.fechaInicio == item.fechaInicioMembresia.Date).ToList();

                            MembresiaEntity entity = new MembresiaEntity()
                            {
                                membresia_persona_pagoID = item.membresia_persona_pagoID,
                                membresiaID = item.membresiaID,
                                nombreMembresia = item.membresia.nombre,
                                precioMembresia = item.membresia.precio,
                                periodicidadMembresia = item.membresia.periodicidad,
                                formaPago = item.formaPago,
                                nroDocumento = item.nroDocumento,
                                Banco = item.Banco,
                                fechaPago = Convert.ToDateTime(item.fechaTransaccion),
                                fechaLimite = item.fechaFinMembresia,
                                fechaInicioMembresia = item.fechaInicioMembresia,
                                fechaFinMembresia = item.fechaFinMembresia,
                                estado = item.estado                                
                                //disciplinasmembresia = items2
                            };

                            membresias.Add(entity);
                        }
                    }                    
                }

                return membresias;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool updateUserMembership(int membresia_persona_pagoID, string fechaInicioMembresia, string fechaFinMembresia, string Banco, string fechaPago, string formaPago, string nroDocumento)
        {
            bool resp = updateRecord(membresia_persona_pagoID, fechaInicioMembresia, fechaFinMembresia, Banco, fechaPago, formaPago, nroDocumento);

            return resp;
        }

        private bool updateRecord(int membresia_persona_pagoID, string fechaInicioMembresia, string fechaFinMembresia, string Banco, string fechaPago, string formaPago, string nroDocumento)
        {
            try
            {
                DateTime fechaInicio = Convert.ToDateTime(fechaInicioMembresia);
                DateTime fechaFin = Convert.ToDateTime(fechaFinMembresia);
                DateTime fechaTransaccion = Convert.ToDateTime(fechaPago);


                using (var dbContext = new GYMDBEntities())
                {
                    var record = dbContext.membresia_persona_pago.Where(x => x.membresia_persona_pagoID == membresia_persona_pagoID).FirstOrDefault();
                    
                    if (record != null)
                    {
                        record.fechaInicioMembresia = fechaInicio;
                        record.fechaFinMembresia = fechaFin;
                        record.Banco = Banco;
                        record.fechaTransaccion = fechaTransaccion;
                        record.formaPago = formaPago;
                        record.nroDocumento = nroDocumento;

                        dbContext.SaveChanges();

                        return true;
                    }
                    else
                    {
                        throw new Exception("El ID proporcionado no existe.");
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
