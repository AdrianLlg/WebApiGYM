using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.Entities.DisciplinaAdmin;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class DisciplinaAdminBO
    {
        public List<DisciplinaAdminEntity> getDisciplinas()
        {
            List<DisciplinaAdminEntity> entities = new List<DisciplinaAdminEntity>();

            entities = getDisciplinaDB();

            return entities;
        }

        private List<DisciplinaAdminEntity> getDisciplinaDB()
        {
            List<DisciplinaAdminEntity> entities = new List<DisciplinaAdminEntity>();
            List<disciplina> disciplinas = new List<disciplina>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    disciplinas = dbContext.disciplina.ToList();
                }

                if (disciplinas.Count > 0)
                {
                    foreach (var disciplina in disciplinas)
                    {
                        DisciplinaAdminEntity Disciplina = new DisciplinaAdminEntity()
                        {
                            disciplinaID = disciplina.disciplinaID,
                            nombre = disciplina.nombre,
                            numClases = disciplina.numClases,
                            descripcion = disciplina.descripcion
                        };

                        entities.Add(Disciplina);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public bool insertDisciplina(string nombre, string descripcion, string numClases)
        {
            bool entity = false;

            try
            {
                entity = insertDBDisciplina(nombre, descripcion, numClases);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar la disciplina");
            }

            return entity;
        }

        private bool insertDBDisciplina(string nombre, string descripcion, string numClases)
        {
            disciplina item = new disciplina();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new disciplina()
                    {
                       nombre = nombre,
                       descripcion = descripcion,
                       numClases = int.Parse(numClases)
                    };

                    dbContext.disciplina.Add(item);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifyDisciplina(int disciplinaID, string nombre, string descripcion, string numClases)
        {
            bool entity = false;

            try
            {
                string validation = disciplinaID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la disciplina no se ha especificado.");
                }

                entity = UpdateRecord(disciplinaID, nombre, descripcion, numClases);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar la disciplina.");
            }

            return entity;
        }

        private bool UpdateRecord(int disciplinaID, string nombre, string descripcion, string numClases)
        {
            disciplina disciplina = new disciplina();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    disciplina = dbContext.disciplina.Where(x => x.disciplinaID == disciplinaID).FirstOrDefault();

                    if (disciplina != null)
                    {
                        if (!string.IsNullOrEmpty(nombre))
                        {
                            disciplina.nombre = nombre;
                        }
                        if (!string.IsNullOrEmpty(descripcion))
                        {
                            disciplina.descripcion = descripcion;
                        }
                        if (!string.IsNullOrEmpty(numClases))
                        {
                            disciplina.numClases = int.Parse(numClases);
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

        public DisciplinaAdminEntity consultarDisciplina(int disciplinaID)
        {
            DisciplinaAdminEntity resp = new DisciplinaAdminEntity();

            resp = getDisciplinaInfo(disciplinaID);

            return resp;
        }


        private DisciplinaAdminEntity getDisciplinaInfo(int disciplinaID)
        {
            disciplina disciplina = new disciplina();
            DisciplinaAdminEntity resp = new DisciplinaAdminEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    disciplina = dbContext.disciplina.Where(x => x.disciplinaID == disciplinaID).FirstOrDefault();
                }

                if (disciplina != null)
                {
                    resp = new DisciplinaAdminEntity()
                    {
                        disciplinaID = disciplina.disciplinaID,
                        nombre = disciplina.nombre,
                        descripcion = disciplina.descripcion,
                        numClases = disciplina.numClases
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
