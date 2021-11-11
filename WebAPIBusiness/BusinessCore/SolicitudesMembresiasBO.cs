using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            List<solicitud_membresiaPersona> membresiasSol = new List<solicitud_membresiaPersona>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    membresiasSol = dbContext.solicitud_membresiaPersona.Where(x => x.estado == "A").ToList();

                    if (membresiasSol.Count > 0)
                    {
                        foreach (var m in membresiasSol)
                        {
                            SolicitudesMembresiasEntity MembresiasEntity = new SolicitudesMembresiasEntity()
                            {
                                solicitud_membresiaPersonaID = m.solicitud_membresiaPersonaID,
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
                        throw new Exception("No existen solicitudes a buscar.");
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
