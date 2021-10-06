using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPIUI.Controllers.Registro.Models;
using WebAPIUI.Controllers.Login.Models;
using WebAPIUI.Controllers.MembresiasUsuario.Models;
using WebAPIUI.Controllers.HorasDisciplina.Models;
using WebAPIUI.Controllers.EventoClasePersona.Models;
using WebAPIUI.CustomExceptions.RegisterPerson;
using WebAPIUI.CustomExceptions.Login;
using WebAPIUI.CustomExceptions.MembresiasUsuario;
using WebAPIUI.CustomExceptions.HorasDisciplina;
using WebAPIUI.CustomExceptions.EventoClasePersona;
using WebAPIUI.CustomExceptions.EventoRecursoEspecial;
using WebAPIUI.Controllers.EventosRecursoEspecial.Models;

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



    }




}