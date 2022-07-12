using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.App.ConsultaNoticias;
using WebAPIBusiness.Entities.ConsultaPersonaEstado;
using WebAPIBusiness.Entities.Noticia;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore
{
    public class ConsultaNoticiasAppBO
    {
        public List<ConsultaNoticiaEntity> getNoticias()
        {
            List<ConsultaNoticiaEntity> entities = new List<ConsultaNoticiaEntity>();

            entities = getNoticiaDB();

            return entities;
        }

        private List<ConsultaNoticiaEntity> getNoticiaDB()
        {
            List<ConsultaNoticiaEntity> entities = new List<ConsultaNoticiaEntity>();
            List<ConsultaNoticiaEntityHelper> helperLS = new List<ConsultaNoticiaEntityHelper>();
            List<noticia> Noticias = new List<noticia>();
            ConsultaNoticiaEntity ntcEntity = new ConsultaNoticiaEntity();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    string query = String.Empty;
                    query = string.Format(ScriptsGYMDB.getNoticiasApp);
                    Noticias =dbContext.Database.SqlQuery<noticia>(query).ToList();
                    
                }

                if (Noticias.Count > 0)
                {
                    foreach (var n in Noticias)
                    {
                        ConsultaNoticiaEntity noticia = new ConsultaNoticiaEntity()
                        {
                            noticiaID = n.noticiaID,
                            contenido = n.contenido,
                            titulo = n.titulo,
                            imagen = Convert.ToBase64String(n.imagen),
                            fechaInicio = n.fechaInicio.ToString("yyyy-MM-dd"),
                            fechaFin = n.fechaFin.ToString("yyyy-MM-dd"),
                            estadoRegistro = n.estadoRegistro

                        };

                        entities.Add(noticia);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public ConsultaNoticiaEntity consultarNoticia(int noticiaID)
        {
            ConsultaNoticiaEntity resp = new ConsultaNoticiaEntity();

            resp = getNoticiaInfo(noticiaID);

            return resp;
        }


        private ConsultaNoticiaEntity getNoticiaInfo(int noticiaID)
        {
            noticia nt = new noticia();
            List<noticia> Noticias = new List<noticia>();
            ConsultaNoticiaEntity resp = new ConsultaNoticiaEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    string query = String.Empty;
                    query = string.Format(ScriptsGYMDB.getNoticiasApp);
                    Noticias = dbContext.Database.SqlQuery<noticia>(query).ToList();
                    nt = Noticias.Where(x => x.noticiaID == noticiaID).FirstOrDefault();
                }

                if (nt != null)
                {
                    resp = new ConsultaNoticiaEntity()
                    {
                        noticiaID = nt.noticiaID,
                        titulo = nt.titulo,
                        contenido = nt.contenido,
                        imagen = Convert.ToBase64String(nt.imagen),
                        fechaInicio = nt.fechaInicio.ToString("yyyy-MM-dd"),
                        fechaFin = nt.fechaFin.ToString("yyyy-MM-dd"),
                        estadoRegistro = nt.estadoRegistro
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



