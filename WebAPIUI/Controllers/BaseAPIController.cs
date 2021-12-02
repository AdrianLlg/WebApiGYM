using System;
using System.Collections.Generic;
using System.Web.Http;
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
using WebAPIUI.Controllers.RegistroMembresiaUsuario.Models;
using WebAPIUI.CustomExceptions.ConfiguracionesSistema;
using WebAPIUI.Controllers.ConfiguracionesSistema.Models;
using WebAPIUI.CustomExceptions.RecursoEspecialAdmin;
using WebAPIUI.Controllers.CRUDRecursoEspecialAdmin.Models;
using WebAPIUI.CustomExceptions.ClasesAdmin;
using WebAPIUI.Controllers.CRUDRClaseAdmin.Models;
using WebAPIUI.CustomExceptions.EventoAdmin;
using WebAPIUI.Controllers.CRUDREventoAdmin.Models;
using WebAPIUI.Controllers.CRUDRDisciplinaAdmin.Models;
using WebAPIUI.CustomExceptions.NoticiaAdmin;
using WebAPIUI.Controllers.CRUDNoticiaAdmin.Models;
using WebAPIUI.CustomExceptions.ConsultaHorarios;
using WebAPIUI.Controllers.CRUDRConsultaHorarios.Models;
using WebAPIUI.CustomExceptions.EventosSerializados;
using WebAPIUI.Controllers.EventosSerializados.Models;
using WebAPIUI.CustomExceptions.SolicitudesMembresias;
using WebAPIUI.Controllers.SolicitudesMembresias.Models;
using WebAPIUI.Controllers.RenovacionMembresiaUsuario.Models;
using WebAPIUI.CustomExceptions.ConsultaRepEventoDisciplina;
using WebAPIUI.Controllers.ConsultaRepEventoDisciplina.Models;
using WebAPIUI.CustomExceptions.ConsultaPersonaEstado;
using WebAPIUI.Controllers.ConsultaPersonaEstado.Models;
using WebAPIUI.CustomExceptions.ConsultaRepEventoSala;
using WebAPIUI.Controllers.ConsultaRepEventoSala.Models;
using WebAPIUI.CustomExceptions.TransaccionesAnuales;
using WebAPIUI.Controllers.TransaccionesAnuales.Models;
using WebAPIUI.CustomExceptions.ConsultaVentasMembresias;
using WebAPIUI.Controllers.ConsultaVentasMembresias.Models;
using WebAPIUI.Controllers.ModificarMembresiaUsuario.Models;
using WebAPIUI.CustomExceptions.ReporteGeneralAsistencia;
using WebAPIUI.Controllers.ReporteGeneralAsistencia.Models;
using WebAPIUI.CustomExceptions.FichaPersona;
using WebAPIUI.Controllers.CRUDFichaPersona.Models;
using WebAPIUI.CustomExceptions.FichaEntrenamiento;
using WebAPIUI.Controllers.CRUDFichaEntrenamiento.Models;
using WebAPIUI.CustomExceptions.ConsultaPerfil;
using WebAPIUI.Controllers.ConsultaPerfil.Models;
using WebAPIUI.CustomExceptions.EventoPersona;
using WebAPIUI.Controllers.CRUDREventoPersona.Models;

namespace WebAPIUI.Controllers
{
    public class BaseAPIController : ApiController
    {

        #region Persona Exceptions
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

        #endregion

        #region Login Exceptions
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

        #endregion

        #region Usuario Exceptions
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

        #endregion

        #region Horas_Disciplina Exceptions
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
        #endregion

        #region Evento_Clase_Persona Exceptions
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

        #endregion

        #region Evento_RecursoEspecial Exceptions
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
        #endregion

        #region Registro Admin Exceptions
        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
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
        #endregion

        #region Membresia Admin Exceptions

        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
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
        #endregion

        #region Rol Admin Exceptions
        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
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
        #endregion

        #region SalaAdmin Exceptions
        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
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

        #endregion

        #region DisciplinaAdmin Exceptions
        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
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

        #endregion

        #region Recurso Admin Expections
        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
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
        #endregion

        #region RecursoEspecial Admin Expections
        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
        internal static void ThrowHandledExceptionRecursoEspecialAdmin(RecursoEspecialAdminResponseType type, IList<string> messages)
        {
            var newException = new RecursoEspecialAdminException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionRecursoEspecialAdmin(RecursoEspecialAdminResponseType type, Exception ex)
        {
            throw new RecursoEspecialAdminException(type, ex.Message);
        }

        internal void SetResponseAsExceptionRecursoEspecialAdmin(RecursoEspecialAdminResponseType code, RecursoEspecialAdminDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }
        #endregion

        #region HorarioAdmin Exceptions
        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
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

        #endregion

        #region HorarioMAdmin Expections
        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
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
        #endregion

        #region NoticiaAdmin Expections
        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
        internal static void ThrowHandledExceptionNoticiaAdmin(NoticiaAdminResponseType type, IList<string> messages)
        {
            var newException = new NoticiaAdminException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionNoticiaAdmin(NoticiaAdminResponseType type, Exception ex)
        {
            throw new NoticiaAdminException(type, ex.Message);
        }


        internal void SetResponseAsExceptionNoticiaAdmin(NoticiaAdminResponseType code, CRUDNoticiaAdminDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }
        #endregion

        #region Clases Expections
        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
        internal static void ThrowHandledExceptionClaseAdmin(ClasesAdminResponseType type, IList<string> messages)
        {
            var newException = new ClasesAdminException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionClaseAdmin(ClasesAdminResponseType type, Exception ex)
        {
            throw new ClasesAdminException(type, ex.Message);
        }


        internal void SetResponseAsExceptionClaseAdmin(ClasesAdminResponseType code, ClaseAdminDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }
        #endregion

        #region RegistroMembresiasUsuario Expections
        internal static void ThrowHandledExceptionRegistroMembresiaUsuario(RegistroMembresiaUsuarioResponseType type, IList<string> messages)
        {
            var newException = new RegistroMembresiaUsuarioException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionRegistroMembresiaUsuario(RegistroMembresiaUsuarioResponseType type, Exception ex)
        {
            throw new RegistroMembresiaUsuarioException(type, ex.Message);
        }
        internal void SetResponseAsExceptionRegistroMembresiaUsuario(RegistroMembresiaUsuarioResponseType code, RegistroMembresiaUsuarioDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = false;
        }
        #endregion

        #region ConfiguracionesSistema Expections
        internal static void ThrowHandledExceptionConfiguracionesSistema(ConfiguracionesSistemaResponseType type, IList<string> messages)
        {
            var newException = new ConfiguracionesSistemaException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionConfiguracionesSistema(ConfiguracionesSistemaResponseType type, Exception ex)
        {
            throw new ConfiguracionesSistemaException(type, ex.Message);
        }

        internal void SetResponseAsExceptionConfiguracionesSistema(ConfiguracionesSistemaResponseType code, ConfiguracionesSistemaDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = null;
        }
        #endregion

        #region Evento Expections
        internal static void ThrowHandledExceptionEventoAdmin(EventoAdminResponseType type, IList<string> messages)
        {
            var newException = new EventoAdminException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionEventoAdmin(EventoAdminResponseType type, Exception ex)
        {
            throw new EventoAdminException(type, ex.Message);
        }

        internal void SetResponseAsExceptionEventoAdmin(EventoAdminResponseType code, EventoAdminDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }
        #endregion

        #region EventoPersona Expections
        internal static void ThrowHandledExceptionEventoPersona(EventoPersonaResponseType type, IList<string> messages)
        {
            var newException = new EventoPersonaException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionEventoPersona(EventoPersonaResponseType type, Exception ex)
        {
            throw new EventoPersonaException(type, ex.Message);
        }

        internal void SetResponseAsExceptionEventoPersona(EventoPersonaResponseType code, EventoPersonaDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }
        #endregion

        #region SolicitudesMembresias
        internal static void ThrowHandledExceptionSolicitudesMembresias(SolicitudesMembresiasResponseType type, IList<string> messages)
        {
            var newException = new SolicitudesMembresiasException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionSolicitudesMembresias(SolicitudesMembresiasResponseType type, Exception ex)
        {
            throw new SolicitudesMembresiasException(type, ex.Message);
        }

        internal void SetResponseAsExceptionSolicitudesMembresias(SolicitudesMembresiasResponseType code, SolicitudesMembresiasDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = null;
        }
        #endregion

        #region ConsultaHorarios Expections
        internal static void ThrowHandledExceptionConsultaHorarios(ConsultaHorariosResponseType type, IList<string> messages)
        {
            var newException = new ConsultaHorariosException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionConsultaHorarios(ConsultaHorariosResponseType type, Exception ex)
        {
            throw new ConsultaHorariosException(type, ex.Message);
        }

        internal void SetResponseAsExceptionConsultaHorarios(ConsultaHorariosResponseType code, ConsultaHorariosDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
        }
        #endregion

        #region EventosSerializados Expections
        internal static void ThrowHandledExceptionEventosSerializados(EventosSerializadosResponseType type, IList<string> messages)
        {
            var newException = new EventosSerializadosException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionEventosSerializados(EventosSerializadosResponseType type, Exception ex)
        {
            throw new EventosSerializadosException(type, ex.Message);
        }

        internal void SetResponseAsExceptionEventosSerializados(EventosSerializadosResponseType code, EventosSerializadosDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentCreate = false;
            
        }
        #endregion

        #region Renovacion Membresia Usuario
        internal static void ThrowHandledExceptionRenovacionMembresiaUsuario(RenovacionMembresiaUsuarioResponseType type, IList<string> messages)
        {
            var newException = new RenovacionMembresiaUsuarioException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionRenovacionMembresiaUsuario(RenovacionMembresiaUsuarioResponseType type, Exception ex)
        {
            throw new RenovacionMembresiaUsuarioException(type, ex.Message);
        }

        internal void SetResponseAsExceptionRenovacionMembresiaUsuario(RenovacionMembresiaUsuarioResponseType code, RenovacionMembresiaUsuarioDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = false;
        }
        #endregion

        #region ConsultaRepEventoDisciplina Expections
        internal static void ThrowHandledExceptionConsultaRepEventoDisciplina(ConsultaRepEventoDisciplinaResponseType type, IList<string> messages)
        {
            var newException = new ConsultaRepEventoDisciplinaException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionConsultaRepEventoDisciplina(ConsultaRepEventoDisciplinaResponseType type, Exception ex)
        {
            throw new ConsultaRepEventoDisciplinaException(type, ex.Message);
        }

        internal void SetResponseAsExceptionConsultaRepEventoDisciplina(ConsultaRepEventoDisciplinaResponseType code, ConsultaRepEventoDisciplinaDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
        }
        #endregion

        #region ConsultaRepEventoSala Expections
        internal static void ThrowHandledExceptionConsultaRepEventoSala(ConsultaRepEventoSalaResponseType type, IList<string> messages)
        {
            var newException = new ConsultaRepEventoSalaException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionConsultaRepEventoSala(ConsultaRepEventoSalaResponseType type, Exception ex)
        {
            throw new ConsultaRepEventoSalaException(type, ex.Message);
        }

        internal void SetResponseAsExceptionConsultaRepEventoSala(ConsultaRepEventoSalaResponseType code, ConsultaRepEventoSalaDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
        }
        #endregion 

        #region ConsultaPersonaEstado Expections
        internal static void ThrowHandledExceptionConsultaPersonaEstado(ConsultaPersonaEstadoResponseType type, IList<string> messages)
        {
            var newException = new ConsultaPersonaEstadoException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionConsultaPersonaEstado(ConsultaPersonaEstadoResponseType type, Exception ex)
        {
            throw new ConsultaPersonaEstadoException(type, ex.Message);
        }

        internal void SetResponseAsExceptionConsultaPersonaEstado(ConsultaPersonaEstadoResponseType code, ConsultaPersonaEstadoDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
        }
        #endregion

        #region TransaccionesAnuales Expections
        internal static void ThrowHandledExceptionTransaccionesAnuales(TransaccionesAnualesResponseType type, IList<string> messages)
        {
            var newException = new TransaccionesAnualesException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionTransaccionesAnuales(TransaccionesAnualesResponseType type, Exception ex)
        {
            throw new TransaccionesAnualesException(type, ex.Message);
        }

        internal void SetResponseAsExceptionTransaccionesAnuales(TransaccionesAnualesResponseType code, TransaccionesAnualesDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
        }
        #endregion

        #region ConsultaVentasMembresias Expections
        internal static void ThrowHandledExceptionConsultaVentasMembresias(ConsultaVentasMembresiasResponseType type, IList<string> messages)
        {
            var newException = new ConsultaVentasMembresiasException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionConsultaVentasMembresias(ConsultaVentasMembresiasResponseType type, Exception ex)
        {
            throw new ConsultaVentasMembresiasException(type, ex.Message);
        }

        internal void SetResponseAsExceptionConsultaVentasMembresias(ConsultaVentasMembresiasResponseType code, ConsultaVentasMembresiasDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
        }
        #endregion

        #region ModificarMembresiaUsuario
        internal static void ThrowHandledExceptionModificarMembresiaUsuario(ModificarMembresiaUsuarioResponseType type, IList<string> messages)
        {
            var newException = new ModificarMembresiaUsuarioException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionModificarMembresiaUsuario(ModificarMembresiaUsuarioResponseType type, Exception ex)
        {
            throw new ModificarMembresiaUsuarioException(type, ex.Message);
        }

        internal void SetResponseAsExceptionModificarMembresiaUsuario(ModificarMembresiaUsuarioResponseType code, ModificarMembresiaUsuarioDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = false;
        }
        #endregion

        #region ReporteGeneralAsistencia Expections
        internal static void ThrowHandledExceptionReporteGeneralAsistencia(ReporteGeneralAsistenciaResponseType type, IList<string> messages)
        {
            var newException = new ReporteGeneralAsistenciaException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionReporteGeneralAsistencia(ReporteGeneralAsistenciaResponseType type, Exception ex)
        {
            throw new ReporteGeneralAsistenciaException(type, ex.Message);
        }

        internal void SetResponseAsExceptionReporteGeneralAsistencia(ReporteGeneralAsistenciaResponseType code, ReporteGeneralAsistenciaDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
        }
        #endregion

        #region FichaPersona Expections
        internal static void ThrowHandledExceptionFichaPersona(FichaPersonaResponseType type, IList<string> messages)
        {
            var newException = new FichaPersonaException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionFichaPersona(FichaPersonaResponseType type, Exception ex)
        {
            throw new FichaPersonaException(type, ex.Message);
        }

        internal void SetResponseAsExceptionFichaPersona(FichaPersonaResponseType code, FichaPersonaDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }
        #endregion

        #region FichaEntrenamiento Expections
        internal static void ThrowHandledExceptionFichaEntrenamiento(FichaEntrenamientoResponseType type, IList<string> messages)
        {
            var newException = new FichaEntrenamientoException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionFichaEntrenamiento(FichaEntrenamientoResponseType type, Exception ex)
        {
            throw new FichaEntrenamientoException(type, ex.Message);
        }

        internal void SetResponseAsExceptionFichaEntrenamiento(FichaEntrenamientoResponseType code, FichaEntrenamientoDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }
        #endregion

        #region ConsultaPerfil Expections
        internal static void ThrowHandledExceptionConsultaPerfil(ConsultaPerfilResponseType type, IList<string> messages)
        {
            var newException = new ConsultaPerfilException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionConsultaPerfil(ConsultaPerfilResponseType type, Exception ex)
        {
            throw new ConsultaPerfilException(type, ex.Message);
        }

        internal void SetResponseAsExceptionConsultaPerfil(ConsultaPerfilResponseType code, ConsultaPerfilDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
        }
        #endregion

    }
}