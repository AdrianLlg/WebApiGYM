using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.Noticia;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class NoticiaAdminBO
    {
        public List<NoticiaEntity> getNoticias()
        {
            List<NoticiaEntity> entities = new List<NoticiaEntity>();

            entities = getNoticiaDB();

            return entities;
        }

        private List<NoticiaEntity> getNoticiaDB()
        {
            List<NoticiaEntity> entities = new List<NoticiaEntity>();
            List<noticia> Noticias = new List<noticia>();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    Noticias = dbContext.noticia.ToList();
                }

                if (Noticias.Count > 0)
                {
                    foreach (var nt in Noticias)
                    {
                        NoticiaEntity NoticiasEntity = new NoticiaEntity()
                        {
                            noticiaID = nt.noticiaID,
                            titulo=nt.titulo,
                            contenido=nt.contenido,
                            imagen= Convert.ToBase64String(nt.imagen),
                            fechaInicio=nt.fechaInicio,
                            fechaFin = nt.fechaFin,
                        };

                        entities.Add(NoticiasEntity);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                return entities;
            }
        }

        public bool insertNoticia(string titulo, string contenido,string imagen,string fechaInicio,string fechaFin)
        {
            bool entity = false;

            try
            {
                entity = insertDBNoticia(titulo, contenido, imagen, fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar .");
            }

            return entity;
        }

        private bool insertDBNoticia(string titulo, string contenido, string imagen, string fechaInicio, string fechaFin)
        {           
            noticia item = new noticia();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new noticia()
                    {
                      titulo=titulo,
                      contenido=contenido,
                      imagen= Convert.FromBase64String(imagen),
                      fechaInicio=Convert.ToDateTime(fechaInicio),
                      fechaFin= Convert.ToDateTime(fechaFin)
                    };

                    dbContext.noticia.Add(item);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifyNoticia(int noticiaID,string titulo, string contenido, string imagen, string fechaInicio,string fechaFin)
        {
            bool entity = false;

            try
            {
                string validation = noticiaID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la persona no se ha especificado.");
                }

                entity = UpdateRecord(noticiaID, titulo, contenido,imagen,fechaInicio,fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el usuario.");
            }

            return entity;
        }

        private bool UpdateRecord(int noticiaID, string titulo, string contenido, string imagen,string fechaInicio,string fechaFin)
        {
            bool resp = false;
            noticia noticia = new noticia();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    noticia = dbContext.noticia.Where(x => x.noticiaID == noticiaID).FirstOrDefault();

                    if (noticia != null)
                    {
                        if (!string.IsNullOrEmpty(titulo))
                        {
                            noticia.titulo = titulo;
                        }
                        if (!string.IsNullOrEmpty(contenido))
                        {
                            noticia.contenido = contenido;
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

        public NoticiaEntity consultarNoticia(int noticiaID)
        {
            NoticiaEntity resp = new NoticiaEntity();

            resp = getNoticiaInfo(noticiaID);
             
            return resp;
        }


        private NoticiaEntity getNoticiaInfo(int noticiaID)
        {
            noticia nt = new noticia();
            NoticiaEntity resp = new NoticiaEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    nt = dbContext.noticia.Where(x => x.noticiaID == noticiaID).FirstOrDefault();
                }

                if (nt != null)
                {
                    resp = new NoticiaEntity()
                    {
                        noticiaID = nt.noticiaID,
                        titulo = nt.titulo,
                        contenido = nt.contenido,
                        imagen = Convert.ToBase64String(nt.imagen),
                        fechaInicio=nt.fechaInicio,
                        fechaFin=nt.fechaFin
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
