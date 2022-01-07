using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.App.ConsultaDisciplinasDeportista;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore
{
    public class ConsultaDisciplinasDeportistaBO
    {
        public List<ConsultaDisciplinasDeportistaEntity> getListaDisciplinas()
        {
            List<ConsultaDisciplinasDeportistaEntity> entities = new List<ConsultaDisciplinasDeportistaEntity>();

            entities = getListaDisciplinasDB();

            return entities;
        }

        private List<ConsultaDisciplinasDeportistaEntity> getListaDisciplinasDB()
        {
            List<ConsultaDisciplinasDeportistaEntity> listaDisciplinas = new List<ConsultaDisciplinasDeportistaEntity>();

            try
            {

                using (var dbContext = new GYMDBEntities())
                {
                    //string query = string.Format(ScriptsGYMDB.getConsultaDisciplinasDeportistaApp );
                    //listaDisciplinas = dbContext.Database.SqlQuery<ConsultaDisciplinasDeportistaEntity>(query).ToList();

                    var resp = dbContext.disciplina.ToList();

                    if (resp.Count > 0)
                    {
                        foreach (var item in resp)
                        {
                            var classes = dbContext.clase.Where(x => x.disciplinaID == item.disciplinaID).ToList();

                            if (classes.Count > 0)
                            {
                                List<ClaseDisciplinaEntity> listClasses = new List<ClaseDisciplinaEntity>();

                                foreach (var Class in classes)
                                {
                                    listClasses.Add(new ClaseDisciplinaEntity()
                                    {
                                        claseID = Class.claseID,
                                        NombreClase = Class.nombre,
                                        DescripcionClase = Class.descripcion
                                    });
                                }
                                
                                ConsultaDisciplinasDeportistaEntity obj = new ConsultaDisciplinasDeportistaEntity()
                                {
                                    DisciplinaID = item.disciplinaID,
                                    DescripcionDisciplina = item.descripcion,
                                    NombreDisciplina = item.nombre,
                                    clases = listClasses
                                };

                                listaDisciplinas.Add(obj);
                            }
                            else
                            {
                                ConsultaDisciplinasDeportistaEntity obj = new ConsultaDisciplinasDeportistaEntity()
                                {
                                    DisciplinaID = item.disciplinaID,
                                    DescripcionDisciplina = item.descripcion,
                                    NombreDisciplina = item.nombre,
                                    clases = null
                                };

                                listaDisciplinas.Add(obj);
                            }
                        }

                        return listaDisciplinas;
                    }
                    else
                    {
                        throw new Exception("NoDisciplinas");
                    }
                }
            }
            catch (Exception ex)
            {
                return listaDisciplinas;
            }
        }
    }
}
