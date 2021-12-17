using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBusiness.CustomExceptions;
using WebAPIBusiness.Entities.ConfiguracionesSistemaAdmin;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class ConfiguracionesAdminBO
    {
        public List<ConfiguracionesAdminEntity> getConfigurations()
        {
            List<ConfiguracionesAdminEntity> resp = new List<ConfiguracionesAdminEntity>();

            resp = getConfigDB();

            return resp;
        }

        public bool editarConfigurations(
            int ConfiguracionSistemaID,
            string Valor,
            string Fecha,
            string FechaInicio,
            string FechaFin

            )
        {
            bool entity = false;

            try
            {
                string validation = ConfiguracionSistemaID.ToString();

                if (string.IsNullOrEmpty(validation))
                {
                    throw new Exception("El ID de la configuracion no se ha especificado.");
                }

                entity = editarConfigDB(
                    ConfiguracionSistemaID,
                    Valor,
                    Fecha,
                    FechaInicio,
                    FechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al modificar la disciplina.");
            }

            return entity;
        }

        

        private bool editarConfigDB(
            int ConfiguracionSistemaID,
            string Valor,
            string Fecha,
            string FechaInicio,
            string FechaFin
            )
        {
            configuraciones_Sistema confSistema = new configuraciones_Sistema();
            DateTime FechaDB = new DateTime();
            DateTime FechaInicioDB = new DateTime();
            DateTime FechaFinDB = new DateTime();
            try
            {
                FechaDB = Convert.ToDateTime(Fecha);
                FechaInicioDB = Convert.ToDateTime(FechaInicio);
                FechaFinDB = Convert.ToDateTime(FechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al transformar una de las entidades en el formato requerido.");
            }

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    confSistema = dbContext.configuraciones_Sistema.Where(x => x.ConfiguracionSistemaID == ConfiguracionSistemaID).FirstOrDefault();

                    if (confSistema != null)
                    {
                        if (!string.IsNullOrEmpty(Valor))
                        {
                            confSistema.Valor = Valor;
                        }
                        if (!string.IsNullOrEmpty(Fecha))
                        {
                            confSistema.Fecha = FechaDB;
                        }
                        if (!string.IsNullOrEmpty(FechaInicio))
                        {
                            confSistema.FechaInicio = FechaInicioDB;
                        }
                        if (!string.IsNullOrEmpty(FechaFin))
                        {
                            confSistema.FechaFin = FechaFinDB;
                        }
                        confSistema.Valor = Valor; 
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
        

        private List<ConfiguracionesAdminEntity> getConfigDB()
        {
            List<ConfiguracionesAdminEntity> configEntities = new List<ConfiguracionesAdminEntity>();
            List<configuraciones_Sistema> configResp = new List<configuraciones_Sistema>();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    configResp = dbContext.configuraciones_Sistema.ToList();                                                                      
                }

                if (configResp.Count > 0)
                {
                    foreach (var entity in configResp)
                    {
                        ConfiguracionesAdminEntity item = new ConfiguracionesAdminEntity { 
                        
                            ConfiguracionSistemaID = entity.ConfiguracionSistemaID,
                            TipoConfiguracion = entity.TipoConfiguracion,
                            NombreConfiguracion = entity.NombreConfiguracion,
                            DescripcionConfiguracion = entity.DescripcionConfiguracion,
                            Valor = entity.Valor,
                            Estado = entity.Estado,
                            Fecha = entity.Fecha,
                            FechaFin = entity.FechaFin,
                            FechaInicio = entity.FechaInicio
                        
                        };

                        configEntities.Add(item);
                    }
                }

                return configEntities;
            }
            catch (Exception ex)
            {
                throw new ValidationAndMessageException("Ocurrió un error en el manejo de datos en la BD.");
            }
        }




    }
}
