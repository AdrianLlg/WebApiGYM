using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.Fichas;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class FichaPersonaBO
    {
        public List<FichaPersonaEntity> getFichas()
        {
            List<FichaPersonaEntity> entities = new List<FichaPersonaEntity>();

            entities = getFichasDB();

            return entities;
        }

        private List<FichaPersonaEntity> getFichasDB()
        {
            List<FichaPersonaEntity> entities = new List<FichaPersonaEntity>();
            List<fichaPersona> fichaPersonas = new List<fichaPersona>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    fichaPersonas = dbContext.fichaPersona.ToList();
                }

                if (fichaPersonas.Count > 0)
                {
                    foreach (var fichaPersona in fichaPersonas)
                    {
                        FichaPersonaEntity fichaPersonaEntity = new FichaPersonaEntity()
                        {
                            fichaPersonaID = fichaPersona.fichaPersonaID,
                            PersonaID = fichaPersona.PersonaID,
                            Peso = fichaPersona.Peso,
                            Altura = fichaPersona.Altura,
                            MesoTipo = fichaPersona.MesoTipo,
                            NivelActualActividadFisica = fichaPersona.NivelActualActividadFisica,
                            IndiceMasaMuscular = fichaPersona.IndiceMasaMuscular,
                            IndiceGrasaCorporal = fichaPersona.IndiceGrasaCorporal,
                            MedicionBrazos = fichaPersona.MedicionBrazos,
                            MedicionPecho = fichaPersona.MedicionPecho,
                            MedicionEspalda = fichaPersona.MedicionEspalda,
                            MedicionPiernas = fichaPersona.MedicionPiernas,
                            MedicionCintura = fichaPersona.MedicionCintura,
                            MedicionCuello = fichaPersona.MedicionCuello,
                            AntecendesMedicos = fichaPersona.AntecendesMedicos,
                            Alergias = fichaPersona.Alergias,
                            Enfermedades = fichaPersona.Enfermedades,


                        };

                        entities.Add(fichaPersonaEntity);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public bool insertfichaPersona(int PersonaID, decimal Peso, decimal Altura, string MesoTipo,
        string NivelActualActividadFisica, string IndiceMasaMuscular, string IndiceGrasaCorporal, string MedicionBrazos, string MedicionPecho,
        string MedicionEspalda, string MedicionPiernas, string MedicionCintura, string MedicionCuello, string AntecendesMedicos, string Alergias, string Enfermedades)
        {
            bool entity = false;

            try
            {
                entity = insertDBfichaPersona(PersonaID, Peso, Altura, MesoTipo,
                NivelActualActividadFisica, IndiceMasaMuscular, IndiceGrasaCorporal, MedicionBrazos, MedicionPecho,
                 MedicionEspalda, MedicionPiernas, MedicionCintura, MedicionCuello, AntecendesMedicos, Alergias, Enfermedades);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el fichaPersona");
            }

            return entity;
        }

        private bool insertDBfichaPersona(int PersonaID, decimal Peso, decimal Altura, string MesoTipo,
        string NivelActualActividadFisica, string IndiceMasaMuscular, string IndiceGrasaCorporal, string MedicionBrazos, string MedicionPecho,
        string MedicionEspalda, string MedicionPiernas, string MedicionCintura, string MedicionCuello, string AntecendesMedicos, string Alergias, string Enfermedades)
        {

            fichaPersona item = new fichaPersona();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new fichaPersona()
                    {
                        PersonaID = PersonaID,
                        Peso = Peso,
                        Altura = Altura,
                        MesoTipo = MesoTipo,
                        NivelActualActividadFisica = NivelActualActividadFisica,
                        IndiceMasaMuscular = IndiceMasaMuscular,
                        IndiceGrasaCorporal = IndiceGrasaCorporal,
                        MedicionBrazos = MedicionBrazos,
                        MedicionPecho = MedicionPecho,
                        MedicionEspalda = MedicionEspalda,
                        MedicionPiernas = MedicionPiernas,
                        MedicionCintura = MedicionCintura,
                        MedicionCuello = MedicionCuello,
                        AntecendesMedicos = AntecendesMedicos,
                        Alergias = Alergias,
                        Enfermedades =Enfermedades
                    };

                    dbContext.fichaPersona.Add(item);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifyfichaPersona(int fichaPersonaID, int PersonaID, decimal Peso, decimal Altura, string MesoTipo,
        string NivelActualActividadFisica, string IndiceMasaMuscular, string IndiceGrasaCorporal, string MedicionBrazos, string MedicionPecho,
        string MedicionEspalda, string MedicionPiernas, string MedicionCintura, string MedicionCuello, string AntecendesMedicos, string Alergias, string Enfermedades)

        {
            bool entity = false;

            try
            {
                string validation = fichaPersonaID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID del fichaPersona no se ha especificado.");
                }

                entity = UpdateRecord(fichaPersonaID, PersonaID, Peso, Altura, MesoTipo,
         NivelActualActividadFisica, IndiceMasaMuscular, IndiceGrasaCorporal, MedicionBrazos, MedicionPecho,
         MedicionEspalda, MedicionPiernas, MedicionCintura, MedicionCuello, AntecendesMedicos, Alergias, Enfermedades);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el fichaPersona.");
            }

            return entity;
        }

        private bool UpdateRecord(int fichaPersonaID, int PersonaID, decimal Peso, decimal Altura, string MesoTipo,
        string NivelActualActividadFisica, string IndiceMasaMuscular, string IndiceGrasaCorporal, string MedicionBrazos, string MedicionPecho,
        string MedicionEspalda, string MedicionPiernas, string MedicionCintura, string MedicionCuello, string AntecendesMedicos, string Alergias, string Enfermedades)
        {
            fichaPersona rec = new fichaPersona();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    rec = dbContext.fichaPersona.Where(x => x.fichaPersonaID == fichaPersonaID).FirstOrDefault();

                    if (rec != null)
                    {
                        #region Validate
                        if (!string.IsNullOrEmpty(Peso.ToString()))
                        {
                            rec.Peso = Peso;
                        }
                        if (!string.IsNullOrEmpty(Altura.ToString()))
                        {
                            rec.Altura = Altura;
                        }
                        if (!string.IsNullOrEmpty(MesoTipo))
                        {
                            rec.MesoTipo = MesoTipo;
                        }
                        if (!string.IsNullOrEmpty(NivelActualActividadFisica))
                        {
                            rec.NivelActualActividadFisica = NivelActualActividadFisica;
                        }
                        if (!string.IsNullOrEmpty(IndiceMasaMuscular))
                        {
                            rec.IndiceMasaMuscular = IndiceMasaMuscular;
                        }
                        if (!string.IsNullOrEmpty(IndiceGrasaCorporal))
                        {
                            rec.IndiceGrasaCorporal = IndiceGrasaCorporal;
                        }
                        if (!string.IsNullOrEmpty(MedicionBrazos))
                        {
                            rec.MedicionBrazos = MedicionBrazos;
                        }
                        if (!string.IsNullOrEmpty(MedicionPecho))
                        {
                            rec.MedicionPecho = MedicionPecho;
                        }
                        if (!string.IsNullOrEmpty(MedicionEspalda))
                        {
                            rec.MedicionEspalda = MedicionEspalda;
                        }
                        if (!string.IsNullOrEmpty(MedicionPiernas))
                        {
                            rec.MedicionPiernas = MedicionPiernas;
                        }
                        if (!string.IsNullOrEmpty(MedicionCintura))
                        {
                            rec.MedicionCintura = MedicionCintura;
                        }
                        if (!string.IsNullOrEmpty(MedicionCuello))
                        {
                            rec.MedicionCuello = MedicionCuello;
                        }
                        if (!string.IsNullOrEmpty(AntecendesMedicos))
                        {
                            rec.AntecendesMedicos = AntecendesMedicos;
                        }
                        if (!string.IsNullOrEmpty(Alergias))
                        {
                            rec.Alergias = Alergias;
                        }
                        if (!string.IsNullOrEmpty(Enfermedades))
                        {
                            rec.Enfermedades = Enfermedades;
                        }
                        #endregion
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

        public FichaPersonaEntity consultarfichaPersona(int fichaPersonaID)
        {
            FichaPersonaEntity resp = new FichaPersonaEntity();

            resp = getfichaPersonaInfo(fichaPersonaID);

            return resp;
        }


        private FichaPersonaEntity getfichaPersonaInfo(int fichaPersonaID)
        {
            fichaPersona rec = new fichaPersona();
            FichaPersonaEntity resp = new FichaPersonaEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    rec = dbContext.fichaPersona.Where(x => x.fichaPersonaID == fichaPersonaID).FirstOrDefault();
                }

                if (rec != null)
                {
                    resp = new FichaPersonaEntity()
                    {
                        fichaPersonaID = rec.fichaPersonaID,
                        PersonaID = rec.PersonaID,
                        Peso = rec.Peso,
                        Altura = rec.Altura,
                        MesoTipo = rec.MesoTipo,
                        NivelActualActividadFisica = rec.NivelActualActividadFisica,
                        IndiceMasaMuscular = rec.IndiceMasaMuscular,
                        IndiceGrasaCorporal = rec.IndiceGrasaCorporal,
                        MedicionBrazos = rec.MedicionBrazos,
                        MedicionPecho = rec.MedicionPecho,
                        MedicionEspalda = rec.MedicionEspalda,
                        MedicionPiernas = rec.MedicionPiernas,
                        MedicionCintura = rec.MedicionCintura,
                        MedicionCuello = rec.MedicionCuello,
                        AntecendesMedicos = rec.AntecendesMedicos,
                        Alergias = rec.Alergias,
                        Enfermedades = rec.Enfermedades
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
