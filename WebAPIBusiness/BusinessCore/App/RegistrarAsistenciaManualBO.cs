using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.Entities.App.ListaAsitenciaManual;
using WebAPIBusiness.Entities.EventoAdmin;
using WebAPIBusiness.Entities.SalaAdmin;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class RegistrarAsistenciaManualBO
    {


        public bool insertAsistenciaManual(List<ListaAsitenciaManualEntity> listaAsistencia)
        {
            bool entity = false;

            try
            {

                entity = insertAsistenciaManualDB(listaAsistencia);

                entity = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar la lista de asistencia.");
            }

            return entity;
        }

        private bool insertAsistenciaManualDB(List<ListaAsitenciaManualEntity> listaAsistencia)
        {
            List<evento_persona> items = new List<evento_persona>();
            evento_persona item = new evento_persona();
            List<evento_persona> eventoPersonaAux = new List<evento_persona>();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    eventoPersonaAux = dbContext.evento_persona.ToList();
                    foreach (var itemLA in listaAsistencia)
                    {
                        item = dbContext.evento_persona.Where(x => x.evento_personaID == itemLA.evento_personaID).FirstOrDefault();
                        item.asistencia = itemLA.asistencia;
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

    }
}
