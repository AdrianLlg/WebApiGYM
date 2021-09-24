using System;
using System.Linq;
using WebAPIBusiness.Entities.Login;
using WebAPIData;

namespace WebAPIBusiness.BusinessCore
{
    public class LoginBO
    {
        public UsuarioEntity searchUser(string email, string password)
        {
            var usuario = new UsuarioEntity();

            usuario = searchDBUser(email, password);

            return usuario;
        }

        private UsuarioEntity searchDBUser(string email, string password)
        {
            UsuarioEntity usuarioDB = new UsuarioEntity();
            persona recoverPerson = new persona();
            usuario user;

            try
            {
                using (var dbContext = new GYMDBEntities())
                {
                    user = dbContext.usuario.Where(x => x.email == email && x.password == password).FirstOrDefault();
                    recoverPerson = dbContext.persona.Where(x => x.personaID == user.personaID).FirstOrDefault();
                }

                if(user == null)
                {
                    return null;
                }else
                {
                    usuarioDB = new UsuarioEntity()
                    {
                        personaID = user.personaID,
                        role = recoverPerson.rolePID
                    };
                }

                return usuarioDB;
            }
            catch (Exception ex)
            {
                return usuarioDB;
            }
        }

        
    }
}
