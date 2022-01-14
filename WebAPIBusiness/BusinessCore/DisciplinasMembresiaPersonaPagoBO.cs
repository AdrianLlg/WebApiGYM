using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.DisciplinasMembresiaPersonaPago;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class DisciplinasMembresiaPersonaPagoBO
    {
        public List<DisciplinasMembresiaPersonaPagoEntity> getDisciplinesInfo(int membresia_persona_pagoID)
        {
            List<DisciplinasMembresiaPersonaPagoEntity> response = new List<DisciplinasMembresiaPersonaPagoEntity>();

            response = getDisciplinesDB(membresia_persona_pagoID);

            return response;

        }



        private List<DisciplinasMembresiaPersonaPagoEntity> getDisciplinesDB(int membresia_persona_pagoID)
        {
            List<DisciplinasMembresiaPersonaPagoEntity> resp = new List<DisciplinasMembresiaPersonaPagoEntity>();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    var query = dbContext.membresia_persona_disciplina.Where(x => x.membresia_persona_pagoID == membresia_persona_pagoID).ToList();

                    if (query.Count > 0)
                    {
                        foreach (var item in query)
                        {
                            resp.Add(new DisciplinasMembresiaPersonaPagoEntity()
                            {
                                membresia_persona_disciplinaID = item.membresia_persona_disciplinaID,
                                disciplinaID = item.membresia_disciplina.disciplinaID,
                                nombreDisciplina = item.membresia_disciplina.disciplina.nombre,
                                numClasesDisponibles = item.numClasesDisponibles,
                                numClasesTomadas = item.numClasesTomadas
                            });
                        }

                        return resp;
                    }
                    else
                    {
                        return resp;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException(ex.InnerException.Message);
            }
        }

    }
}
