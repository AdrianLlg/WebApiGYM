using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIBusiness.Entities.ConsultaPerfil;
using WebAPIBusiness.Resources;
using WebAPIData;


namespace WebAPIBusiness.BusinessCore
{
    public class ConsultaPerfilBO
    {
        public ConsultaPerfilEntity getPerfil(int personaID)
        {
            ConsultaPerfilEntity entity = new ConsultaPerfilEntity();

            entity = getPerfilDB(personaID);


            return entity;
        }

        private ConsultaPerfilEntity getPerfilDB(int personaID)
        {

            ConsultaPerfilEntity resp;
            persona item = new persona();


            using (var dbContext = new GYMDBEntities())
            {
                item = dbContext.persona.Where(x => x.personaID == personaID).FirstOrDefault();
            }

            if (item != null)
            {
                resp = new ConsultaPerfilEntity()
                {
                    personaID = item.personaID,
                    apellidos = item.apellidos,
                    nombres = item.nombres,
                    edad = item.edad,
                    email = item.email,
                    estado = item.estado,
                    fechaNacimiento = item.fechaNacimiento,
                    identificacion = item.identificacion,
                    rolePID = item.rolePID,
                    sexo = item.sexo,
                    telefono = item.telefono
                };

                return resp;
            }else
            {
                return null;
            }
        }


    }
}


