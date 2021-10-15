using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIUI.Controllers.CRUDDisciplinaAdmin.Models;
using WebAPIUI.Controllers.CRUDMembresiaAdmin.Models;
using WebAPIUI.Controllers.CRUDRecursoAdmin.Models;
using WebAPIUI.Controllers.CRUDRegistroAdmin.Models;
using WebAPIUI.Controllers.CRUDRolAdmin.Models;
using WebAPIUI.Controllers.CRUDRSalaAdmin.Models;
using WebAPIUI.Controllers.EventoClasePersona.Models;
using WebAPIUI.Controllers.EventosRecursoEspecial.Models;
using WebAPIUI.Controllers.HorasDisciplina.Models;
using WebAPIUI.Controllers.Login.Models;
using WebAPIUI.Controllers.MembresiasUsuario.Models;
using WebAPIUI.Controllers.Registro.Models;
using WebAPIUI.Controllers.CRUDRHorarioAdmin.Models;
using WebAPIUI.CustomExceptions.DisciplinaAdmin;
using WebAPIUI.CustomExceptions.EventoClasePersona;
using WebAPIUI.CustomExceptions.EventoRecursoEspecial;
using WebAPIUI.CustomExceptions.HorasDisciplina;
using WebAPIUI.CustomExceptions.Login;
using WebAPIUI.CustomExceptions.MembresiasAdmin;
using WebAPIUI.CustomExceptions.MembresiasUsuario;
using WebAPIUI.CustomExceptions.RecursoAdmin;
using WebAPIUI.CustomExceptions.RegisterPerson;
using WebAPIUI.CustomExceptions.RegistroAdmin;
using WebAPIUI.CustomExceptions.RolAdmin;
using WebAPIUI.CustomExceptions.SalaAdmin;
using WebAPIUI.CustomExceptions.HorarioAdmin;
using WebAPIUI.CustomExceptions.HorarioMAdmin;
using WebAPIUI.Controllers.CRUDRHorarioMAdmin.Models;

namespace WebAPIUI.Controllers
{
    public class BaseAPIController : ApiController
    {
        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
        internal static void ThrowHandledExceptionRegistro(RegisterPersonResponseType type, IList<string> messages)
        {
            var newException = new RegisterPersonException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionRegistro(RegisterPersonResponseType type, Exception ex)
        {
            throw new RegisterPersonException(type, ex.Message);
        }

        internal void SetResponseAsExceptionRegistro(RegisterPersonResponseType code, RegisterPersonDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = false;
        }



        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
        internal static void ThrowHandledExceptionLogin(LoginResponseType type, IList<string> messages)
        {
            var newException = new LoginException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionLogin(LoginResponseType type, Exception ex)
        {
            throw new LoginException(type, ex.Message);
        }

        internal void SetResponseAsExceptionLogin(LoginResponseType code, LoginDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = null;
        }



        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
        internal static void ThrowHandledExceptionMembresiasUsuario(MembresiasUsuarioResponseType type, IList<string> messages)
        {
            var newException = new MembresiasUsuarioException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionMembresiasUsuario(MembresiasUsuarioResponseType type, Exception ex)
        {
            throw new MembresiasUsuarioException(type, ex.Message);
        }

        internal void SetResponseAsExceptionMembresiasUsuario(MembresiasUsuarioResponseType code, MembresiasUsuarioDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = null;
        }


        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
        internal static void ThrowHandledExceptionHorasDisciplina(HorasDisciplinaResponseType type, IList<string> messages)
        {
            var newException = new HorasDisciplinaException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionHorasDisciplina(HorasDisciplinaResponseType type, Exception ex)
        {
            throw new HorasDisciplinaException(type, ex.Message);
        }

        internal void SetResponseAsExceptionHorasDisciplina(HorasDisciplinaResponseType code, HorasDisciplinaDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = null;
        }

        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
        internal static void ThrowHandledExceptionEventoClasePersona(EventoClasePersonaResponseType type, IList<string> messages)
        {
            var newException = new EventoClasePersonaException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionEventoClasePersona(EventoClasePersonaResponseType type, Exception ex)
        {
            throw new EventoClasePersonaException(type, ex.Message);
        }

        internal void SetResponseAsExceptionEventoClasePersona(EventoClasePersonaResponseType code, EventoClasePersonaResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = null; 
        }


        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
        internal static void ThrowHandledExceptionEventoRecursoEspecial(EventoRecursoEspecialResponseType type, IList<string> messages)
        {
            var newException = new EventoRecursoEspecialException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionEventoRecursoEspecial(EventoRecursoEspecialResponseType type, Exception ex)
        {
            throw new EventoRecursoEspecialException(type, ex.Message);
        }

        internal void SetResponseAsExceptionEventoRecursoEspecial(EventoRecursoEspecialResponseType code, EventoRecursoEspecialResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = null;
        }


        internal static void ThrowHandledExceptionRegistroAdmin(RegistroAdminResponseType type, IList<string> messages)
        {
            var newException = new RegistroAdminException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionRegistroAdmin(RegistroAdminResponseType type, Exception ex)
        {
            throw new RegistroAdminException(type, ex.Message);
        }

        internal void SetResponseAsExceptionRegistroAdmin(RegistroAdminResponseType code, RegistroAdminDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }

        internal static void ThrowHandledExceptionMembresiaAdmin(MembresiaAdminResponseType type, IList<string> messages)
        {
            var newException = new MembresiaAdminException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionMembresiaAdmin(MembresiaAdminResponseType type, Exception ex)
        {
            throw new MembresiaAdminException(type, ex.Message);
        }

        internal void SetResponseAsExceptionMembresiaAdmin(MembresiaAdminResponseType code, MembresiaAdminDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }

        internal static void ThrowHandledExceptionRolAdmin(RolAdminResponseType type, IList<string> messages)
        {
            var newException = new RolAdminException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionRolAdmin(RolAdminResponseType type, Exception ex)
        {
            throw new RolAdminException(type, ex.Message);
        }

        internal void SetResponseAsExceptionRolAdmin(RolAdminResponseType code, RolAdminDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }

        internal static void ThrowHandledExceptionSalaAdmin(SalaAdminResponseType type, IList<string> messages)
        {
            var newException = new SalaAdminException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionSalaAdmin(SalaAdminResponseType type, Exception ex)
        {
            throw new SalaAdminException(type, ex.Message); 
        }

        internal void SetResponseAsExceptionSalaAdmin(SalaAdminResponseType code, SalaAdminDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }


        internal static void ThrowHandledExceptionDisciplinaAdmin(DisciplinaAdminResponseType type, IList<string> messages)
        {
            var newException = new DisciplinaAdminException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionDisciplinaAdmin(DisciplinaAdminResponseType type, Exception ex)
        {
            throw new DisciplinaAdminException(type, ex.Message);
        }

        internal void SetResponseAsExceptionDisciplinaAdmin(DisciplinaAdminResponseType code, DisciplinaAdminDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }

        internal static void ThrowHandledExceptionRecursoAdmin(RecursoAdminResponseType type, IList<string> messages)
        {
            var newException = new RecursoAdminException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionRecursoAdmin(RecursoAdminResponseType type, Exception ex)
        {
            throw new RecursoAdminException(type, ex.Message);
        }

        internal void SetResponseAsExceptionRecursoAdmin(RecursoAdminResponseType code, RecursoAdminDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }


        internal static void ThrowHandledExceptionHorarioAdmin(HorarioAdminResponseType type, IList<string> messages)
        {
            var newException = new HorarioAdminException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionHorarioAdmin(HorarioAdminResponseType type, Exception ex)
        {
            throw new HorarioAdminException(type, ex.Message);
        }

        internal void SetResponseAsExceptionHorarioAdmin(HorarioAdminResponseType code,  HorarioAdminDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }


        internal static void ThrowHandledExceptionHorarioMAdmin(HorarioMAdminResponseType type, IList<string> messages)
        {
            var newException = new HorarioMAdminException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionHorarioMAdmin(HorarioMAdminResponseType type, Exception ex)
        {
            throw new HorarioMAdminException(type, ex.Message);
        }

        internal void SetResponseAsExceptionHorarioMAdmin(HorarioMAdminResponseType code, HorarioMAdminDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }

    }
}