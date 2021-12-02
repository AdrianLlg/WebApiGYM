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
                            MesoTipo = fichaPersona.MesoTipo,
                            NivelActualActividadFisica = fichaPersona.NivelActualActividadFisica,
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

        public bool insertfichaPersona(int PersonaID, string MesoTipo,string NivelActualActividadFisica, string AntecendesMedicos, string Alergias, string Enfermedades)
        {
            bool entity = false;

            try
            {
                entity = insertDBfichaPersona(PersonaID, MesoTipo,NivelActualActividadFisica, AntecendesMedicos, Alergias, Enfermedades);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el fichaPersona");
            }

            return entity;
        }

        private bool insertDBfichaPersona(int PersonaID, string MesoTipo,string NivelActualActividadFisica, string AntecendesMedicos, string Alergias, string Enfermedades)
        {

            fichaPersona item = new fichaPersona();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new fichaPersona()
                    {
                        PersonaID = PersonaID,
                        MesoTipo = MesoTipo,
                        NivelActualActividadFisica = NivelActualActividadFisica,
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

        public bool modifyfichaPersona(int fichaPersonaID, int PersonaID, string MesoTipo,string NivelActualActividadFisica, string AntecendesMedicos, string Alergias, string Enfermedades)

        {
            bool entity = false;

            try
            {
                string validation = fichaPersonaID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID del fichaPersona no se ha especificado.");
                }

                entity = UpdateRecord(fichaPersonaID, PersonaID,  MesoTipo,NivelActualActividadFisica, AntecendesMedicos, Alergias, Enfermedades);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el fichaPersona.");
            }

            return entity;
        }

        private bool UpdateRecord(int fichaPersonaID, int PersonaID, string MesoTipo,string NivelActualActividadFisica,string AntecendesMedicos, string Alergias, string Enfermedades)
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

                        rec.fichaPersonaID = fichaPersonaID;
                        
                        
                        
                        
                        
                        if (!string.IsNullOrEmpty(MesoTipo))
                        {
                            rec.MesoTipo = MesoTipo;
                        }
                        if (!string.IsNullOrEmpty(NivelActualActividadFisica))
                        {
                            rec.NivelActualActividadFisica = NivelActualActividadFisica;
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
                        MesoTipo = rec.MesoTipo,
                        NivelActualActividadFisica = rec.NivelActualActividadFisica,
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
