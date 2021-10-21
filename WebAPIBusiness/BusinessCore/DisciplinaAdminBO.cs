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
                    foreach (var dsp in disciplinas)
                    {
                        DisciplinaAdminEntity disciplinasEntity = new DisciplinaAdminEntity()
                        {
                            disciplinaID = dsp.disciplinaID,
                            nombre = dsp.nombre,
                            descripcion = dsp.descripcion                           
                        };

                        entities.Add(disciplinasEntity);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public bool insertDisciplina(string nombre, string descripcion)
        {
            bool entity = false;

            try
            {
                entity = insertDBDisciplina(nombre, descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el usuario/calcular la edad del usuario.");
            }

            return entity;
        }

        private bool insertDBDisciplina(string nombre, string descripcion)
        {           
            disciplina item = new disciplina();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new disciplina()
                    {
                       nombre = nombre,
                       descripcion = descripcion
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

        public bool modifyDisciplina(int disciplinaID, string nombre, string descripcion)
        {
            bool entity = false;

            try
            {
                string validation = disciplinaID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la persona no se ha especificado.");
                }

                entity = UpdateRecord(disciplinaID, nombre, descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el usuario.");
            }

            return entity;
        }

        private bool UpdateRecord(int discplinaID, string nombre, string descripcion)
        {
            bool resp = false;
            disciplina disciplina= new disciplina();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    disciplina = dbContext.disciplina.Where(x => x.disciplinaID == discplinaID).FirstOrDefault();

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
                       descripcion = disciplina.descripcion
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
