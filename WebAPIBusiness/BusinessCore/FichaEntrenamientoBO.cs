using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.Fichas;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class FichaEntrenamientoBO
    {
        public List<FichaEntrenamientoEntity> getFichas()
        {
            List<FichaEntrenamientoEntity> entities = new List<FichaEntrenamientoEntity>();

            entities = getFichasDB();

            return entities;
        }

        private List<FichaEntrenamientoEntity> getFichasDB()
        {
            List<FichaEntrenamientoEntity> entities = new List<FichaEntrenamientoEntity>();
            List<fichaEntrenamiento> FichaEntrenamientos = new List<fichaEntrenamiento>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    FichaEntrenamientos = dbContext.fichaEntrenamiento.ToList();
                }

                if (FichaEntrenamientos.Count > 0)
                {
                    foreach (var FichaEntrenamiento in FichaEntrenamientos)
                    {
                        FichaEntrenamientoEntity FichaEntrenamientoEntity = new FichaEntrenamientoEntity()
                        {

                            fichaEntrenamientoID = FichaEntrenamiento.fichaEntrenamientoID,
                            FechaCreacion = FichaEntrenamiento.FechaCreacion,
                            fichaPersonaID = FichaEntrenamiento.fichaPersonaID,
                            DiciplinaID = FichaEntrenamiento.DiciplinaID,
                            Observaciones = FichaEntrenamiento.Observaciones,
                            ProfesorID = FichaEntrenamiento.ProfesorID

                        };

                        entities.Add(FichaEntrenamientoEntity);
                    }
                }
                return entities;
            }
            catch (Exception ex)
            {
                return null;
            }
        }






        public bool insertFichaEntrenamiento(string FechaCreacion, int fichaPersonaID, int ProfesorID, int DiciplinaID, string Observaciones)
        {
            bool entity = false;

            try
            {
                entity = insertDBFichaEntrenamiento(FechaCreacion, fichaPersonaID, ProfesorID, DiciplinaID, Observaciones);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el FichaEntrenamiento");
            }

            return entity;
        }

        private bool insertDBFichaEntrenamiento(string FechaCreacion, int fichaPersonaID, int ProfesorID, int DiciplinaID, string Observaciones)
        {

            fichaEntrenamiento item = new fichaEntrenamiento();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new fichaEntrenamiento()
                    {
                        FechaCreacion = Convert.ToDateTime(FechaCreacion),
                        fichaPersonaID = fichaPersonaID,
                        ProfesorID = ProfesorID,
                        DiciplinaID = DiciplinaID,
                        Observaciones = Observaciones
                    };
                    dbContext.fichaEntrenamiento.Add(item);
                    dbContext.SaveChanges();
                };



                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifyFichaEntrenamiento(int FichaEntrenamientoID, string FechaCreacion, int fichaPersonaID, int ProfesorID, int DiciplinaID, string Observaciones)

        {
            bool entity = false;

            try
            {
                string validation = FichaEntrenamientoID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID del FichaEntrenamiento no se ha especificado.");
                }

                entity = UpdateRecord(FichaEntrenamientoID, FechaCreacion, fichaPersonaID, ProfesorID, DiciplinaID, Observaciones);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el FichaEntrenamiento.");
            }

            return entity;
        }

        private bool UpdateRecord(int FichaEntrenamientoID, string FechaCreacion, int fichaPersonaID, int ProfesorID, int DiciplinaID, string Observaciones)
        {
            fichaEntrenamiento rec = new fichaEntrenamiento();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    rec = dbContext.fichaEntrenamiento.Where(x => x.fichaEntrenamientoID == FichaEntrenamientoID).FirstOrDefault();

                    if (rec != null)
                    {


                        if (!string.IsNullOrEmpty(Observaciones))
                        {
                            rec.Observaciones = Observaciones;
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

        public FichaEntrenamientoEntity consultarFichaEntrenamiento(int fichaEntrenamientoID)
        {
            FichaEntrenamientoEntity resp = new FichaEntrenamientoEntity();

            resp = getFichaEntrenamientoInfo(fichaEntrenamientoID);

            return resp;
        }


        private FichaEntrenamientoEntity getFichaEntrenamientoInfo(int fichaEntrenamientoID)
        {
            fichaEntrenamiento rec = new fichaEntrenamiento();
            FichaEntrenamientoEntity resp = new FichaEntrenamientoEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    rec = dbContext.fichaEntrenamiento.Where(x => x.fichaEntrenamientoID == fichaEntrenamientoID).FirstOrDefault();
                }

                if (rec != null)
                {
                    resp = new FichaEntrenamientoEntity()
                    {
                        fichaEntrenamientoID = rec.fichaEntrenamientoID,
                        FechaCreacion = rec.FechaCreacion,
                        fichaPersonaID = rec.fichaPersonaID,
                        ProfesorID = rec.ProfesorID,
                        DiciplinaID = rec.DiciplinaID,
                        Observaciones = rec.Observaciones
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
