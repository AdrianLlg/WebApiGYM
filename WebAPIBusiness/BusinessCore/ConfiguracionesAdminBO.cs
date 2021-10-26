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
        public List<ConfiguracionesAdminEntity> getConfigurations(string tipoConfiguracion)
        {
            List<ConfiguracionesAdminEntity> resp = new List<ConfiguracionesAdminEntity>();

            resp = getConfigDB(tipoConfiguracion);

            return resp;
        }

        private List<ConfiguracionesAdminEntity> getConfigDB(string tipoConfiguracion)
        {
            List<ConfiguracionesAdminEntity> configEntities = new List<ConfiguracionesAdminEntity>();
            List<configuraciones_Sistema> configResp = new List<configuraciones_Sistema>();

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    configResp = dbContext.configuraciones_Sistema.Where(x => x.TipoConfiguracion == tipoConfiguracion
                                                                         && x.Estado == "A").ToList();                                                                      
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
