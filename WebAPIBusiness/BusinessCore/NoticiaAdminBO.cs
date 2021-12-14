using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.Noticia;
using WebAPIBusiness.Resources;
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
            List<NoticiaEntityHelper> helperLS = new List<NoticiaEntityHelper>();
            List<noticia> Noticias = new List<noticia>();
            NoticiaEntity ntcEntity = new NoticiaEntity();
            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    Noticias = dbContext.noticia.ToList();
                }

                if (Noticias.Count > 0)
                {
                    foreach (var n in Noticias) {
                        NoticiaEntity noticia = new NoticiaEntity()
                        {
                            noticiaID=n.noticiaID,
                            contenido=n.contenido,
                            titulo=n.titulo,
                            imagen =Convert.ToBase64String(n.imagen),
                            fechaInicio=n.fechaInicio,
                            fechaFin=n.fechaFin,
                            estadoRegistro=n.estadoRegistro

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


        public bool insertNoticia(string titulo, string contenido, string imagen, string fechaInicio, string fechaFin, string estadoRegistro)
        {
            bool entity = false;

            try
            {
                entity = insertDBNoticia(titulo, contenido, imagen, fechaInicio, fechaFin, estadoRegistro);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar .");
            }

            return entity;
        }

        private bool insertDBNoticia(string titulo, string contenido, string imagen, string fechaInicio, string fechaFin, string estadoRegistro)
        {
            noticia item = new noticia();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    item = new noticia()
                    {
                        titulo = titulo,
                        contenido = contenido,
                        imagen = Convert.FromBase64String(imagen),
                        fechaInicio = Convert.ToDateTime(fechaInicio),
                        fechaFin = Convert.ToDateTime(fechaFin),
                        estadoRegistro = "A"
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

        public bool modifyNoticia(int noticiaID, string titulo, string contenido, string imagen, string fechaInicio, string fechaFin, string estadoRegistro)
        {
            bool entity = false;

            try
            {
                string validation = noticiaID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la persona no se ha especificado.");
                }

                entity = UpdateRecord(noticiaID, titulo, contenido, imagen, fechaInicio, fechaFin, estadoRegistro);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el usuario.");
            }

            return entity;
        }

        private bool UpdateRecord(int noticiaID, string titulo, string contenido, string imagen, string fechaInicio, string fechaFin, string estadoRegistro)
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

                        noticia.fechaInicio = Convert.ToDateTime(fechaInicio);
                        noticia.fechaFin = Convert.ToDateTime(fechaFin);


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
                        fechaInicio = nt.fechaInicio,
                        fechaFin = nt.fechaFin,
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

        public bool inactivarNoticias(int noticiaID)
        {
            bool entity = false;

            try
            {
                string validation = noticiaID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la persona no se ha especificado.");
                }

                entity = inactivarNoticia(noticiaID);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar el usuario.");
            }

            return entity;
        }

        private bool inactivarNoticia(int noticiaID)
        {
            
            noticia noticia = new noticia();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    noticia = dbContext.noticia.Where(x => x.noticiaID == noticiaID).FirstOrDefault();

                    if (noticia != null)
                    {
                        if (noticia.estadoRegistro == "A")
                        {
                            noticia.imagen = new byte[0];
                            noticia.estadoRegistro = "I";
                        }
                        else if (noticia.estadoRegistro == "I")
                        {
                            noticia.estadoRegistro = "A";
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
        public bool eliminarNoticia(int noticiaID)
        {
            bool resp = false;

            resp = eliminarInfo(noticiaID);

            return resp;
        }



        private bool eliminarInfo(int noticiaID)
        {

            NoticiaEntity resp = new NoticiaEntity();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    var nt = dbContext.noticia.Where(x => x.noticiaID == noticiaID).FirstOrDefault();
                    if (nt != null)
                    {
                        dbContext.noticia.Remove(nt);
                        dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
