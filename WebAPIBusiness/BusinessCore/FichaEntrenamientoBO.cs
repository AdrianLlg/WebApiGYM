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
                            ProfesorID = FichaEntrenamiento.ProfesorID,
                            DiciplinaID = FichaEntrenamiento.DiciplinaID,
                            Altura = FichaEntrenamiento.Altura,
                            Peso = FichaEntrenamiento.Peso,
                            IndiceMasaMuscular = FichaEntrenamiento.IndiceMasaMuscular,
                            IndiceGrasaCorporal = FichaEntrenamiento.IndiceGrasaCorporal,
                            MedicionBrazos = FichaEntrenamiento.MedicionBrazos,
                            MedicionPecho = FichaEntrenamiento.MedicionPecho,
                            MedicionEspalda = FichaEntrenamiento.MedicionEspalda,
                            MedicionPiernas = FichaEntrenamiento.MedicionPiernas,
                            MedicionCintura = FichaEntrenamiento.MedicionCintura,
                            MedicionCuello = FichaEntrenamiento.MedicionCuello,
                            Observaciones = FichaEntrenamiento.Observaciones,







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






        public bool insertFichaEntrenamiento(string FechaCreacion, int fichaPersonaID, int ProfesorID, int DiciplinaID, decimal Altura, decimal Peso, decimal IndiceMasaMuscular, decimal IndiceGrasaCorporal, decimal MedicionBrazos, decimal MedicionPecho, decimal MedicionEspalda, decimal MedicionPiernas, decimal MedicionCintura, decimal MedicionCuello, string Observaciones)
        {
            bool entity = false;

            try
            {
                entity = insertDBFichaEntrenamiento(FechaCreacion, fichaPersonaID, ProfesorID, DiciplinaID, Altura, Peso, IndiceMasaMuscular, IndiceGrasaCorporal, MedicionBrazos, MedicionPecho, MedicionEspalda, MedicionPiernas, MedicionCintura, MedicionCuello, Observaciones);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el FichaEntrenamiento");
            }

            return entity;
        }

        private bool insertDBFichaEntrenamiento(string FechaCreacion, int fichaPersonaID, int ProfesorID, int DiciplinaID, decimal Altura, decimal Peso, decimal IndiceMasaMuscular, decimal IndiceGrasaCorporal, decimal MedicionBrazos, decimal MedicionPecho, decimal MedicionEspalda, decimal MedicionPiernas, decimal MedicionCintura, decimal MedicionCuello, string Observaciones)
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
                        Altura = Altura,
                        Peso = Peso,
                        IndiceMasaMuscular = IndiceMasaMuscular,
                        IndiceGrasaCorporal = IndiceGrasaCorporal,
                        MedicionBrazos = MedicionBrazos,
                        MedicionPecho = MedicionPecho,
                        MedicionEspalda = MedicionEspalda,
                        MedicionPiernas = MedicionPiernas,
                        MedicionCintura = MedicionCintura,
                        MedicionCuello = MedicionCuello,
                        Observaciones = Observaciones,
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

        public bool modifyFichaEntrenamiento(int FichaEntrenamientoID, string FechaCreacion, int fichaPersonaID, int ProfesorID, int DiciplinaID, decimal Altura, decimal Peso, decimal IndiceMasaMuscular, decimal IndiceGrasaCorporal, decimal MedicionBrazos, decimal MedicionPecho, decimal MedicionEspalda, decimal MedicionPiernas, decimal MedicionCintura, decimal MedicionCuello, string Observaciones)

        {
            bool entity = false;

            try
            {
                string validation = FichaEntrenamientoID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID del FichaEntrenamiento no se ha especificado.");
                }

                entity = UpdateRecord(FichaEntrenamientoID, FechaCreacion, fichaPersonaID, ProfesorID, DiciplinaID, Altura, Peso, IndiceMasaMuscular, IndiceGrasaCorporal, MedicionBrazos, MedicionPecho, MedicionEspalda, MedicionPiernas, MedicionCintura, MedicionCuello, Observaciones);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el FichaEntrenamiento.");
            }

            return entity;
        }

        private bool UpdateRecord(int FichaEntrenamientoID, string FechaCreacion, int fichaPersonaID, int ProfesorID, int DiciplinaID, decimal Altura, decimal Peso, decimal IndiceMasaMuscular, decimal IndiceGrasaCorporal, decimal MedicionBrazos, decimal MedicionPecho, decimal MedicionEspalda, decimal MedicionPiernas, decimal MedicionCintura, decimal MedicionCuello, string Observaciones)
        {
            fichaEntrenamiento rec = new fichaEntrenamiento();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    rec = dbContext.fichaEntrenamiento.Where(x => x.fichaEntrenamientoID == FichaEntrenamientoID).FirstOrDefault();

                    if (rec != null)
                    {

                        if (!string.IsNullOrEmpty(FechaCreacion))
                        {
                            rec.FechaCreacion= Convert.ToDateTime(FechaCreacion);
                        }
                        if (!string.IsNullOrEmpty(Observaciones))
                        {
                            rec.Observaciones = Observaciones;
                        }

                        rec.fichaPersonaID = fichaPersonaID;
                        rec.ProfesorID = ProfesorID;
                        rec.DiciplinaID = DiciplinaID;
                        rec.Altura = Altura;
                        rec.Peso = Peso;
                        rec.IndiceMasaMuscular = IndiceMasaMuscular;
                        rec.IndiceGrasaCorporal = IndiceGrasaCorporal;
                        rec.MedicionBrazos = MedicionBrazos;
                        rec.MedicionPecho = MedicionPecho;
                        rec.MedicionEspalda = MedicionEspalda;
                        rec.MedicionPiernas = MedicionPiernas;
                        rec.MedicionCintura = MedicionCintura;
                        rec.MedicionCuello = MedicionCuello;

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
                        Altura = rec.Altura,
                        Peso = rec.Peso,
                        IndiceMasaMuscular = rec.IndiceMasaMuscular,
                        IndiceGrasaCorporal = rec.IndiceGrasaCorporal,
                        MedicionBrazos = rec.MedicionBrazos,
                        MedicionPecho = rec.MedicionPecho,
                        MedicionEspalda = rec.MedicionEspalda,
                        MedicionPiernas = rec.MedicionPiernas,
                        MedicionCintura = rec.MedicionCintura,
                        MedicionCuello = rec.MedicionCuello,
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
