#region Usings
using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPIUI.Controllers.App.ConsultaClasesPendientesInstructor.Models;
using WebAPIUI.Controllers.App.ConsultaDisciplinasDeportista.Models;
using WebAPIUI.Controllers.App.ConsultaHistorialAsistenciaCliente.Models;
using WebAPIUI.Controllers.App.ConsultaHorariosDeportista.Models;
using WebAPIUI.Controllers.App.ConsultaListaAsistencia.Models;
using WebAPIUI.Controllers.App.ConsultaNoticias.Models;
using WebAPIUI.Controllers.App.EnviarMailValidacion.Models;
using WebAPIUI.Controllers.App.GenerarQRInstructor.Models;
using WebAPIUI.Controllers.App.InscripcionUsuarioSesion.Models;
using WebAPIUI.Controllers.App.ModificacionDatosPersonales.Models;
using WebAPIUI.Controllers.App.RegistrarAsistenciaEventoPersona.Models;
using WebAPIUI.Controllers.App.RegistrarAsistenciaEventoProfesor.Models;
using WebAPIUI.Controllers.App.RegistrarAsistenciaManual.Models;
using WebAPIUI.Controllers.ConfiguracionesSistema.Models;
using WebAPIUI.Controllers.ConsultaFichaEntrenamiento.Models;
using WebAPIUI.Controllers.ConsultaFichaPersona.Models;
using WebAPIUI.Controllers.ConsultaPerfil.Models;
using WebAPIUI.Controllers.ConsultaPersonaEstado.Models;
using WebAPIUI.Controllers.ConsultaRepEventoDisciplina.Models;
using WebAPIUI.Controllers.ConsultaRepEventoSala.Models;
using WebAPIUI.Controllers.ConsultaVentasMembresias.Models;
using WebAPIUI.Controllers.CRUDFichaEntrenamiento.Models;
using WebAPIUI.Controllers.CRUDFichaPersona.Models;
using WebAPIUI.Controllers.CRUDMembresiaAdmin.Models;
using WebAPIUI.Controllers.CRUDNoticiaAdmin.Models;
using WebAPIUI.Controllers.CRUDRClaseAdmin.Models;
using WebAPIUI.Controllers.CRUDRConsultaHorarios.Models;
using WebAPIUI.Controllers.CRUDRDisciplinaAdmin.Models;
using WebAPIUI.Controllers.CRUDRecursoAdmin.Models;
using WebAPIUI.Controllers.CRUDRecursoEspecialAdmin.Models;
using WebAPIUI.Controllers.CRUDRegistroAdmin.Models;
using WebAPIUI.Controllers.CRUDREventoAdmin.Models;
using WebAPIUI.Controllers.CRUDREventoPersona.Models;
using WebAPIUI.Controllers.CRUDRHorarioAdmin.Models;
using WebAPIUI.Controllers.CRUDRHorarioMAdmin.Models;
using WebAPIUI.Controllers.CRUDRolAdmin.Models;
using WebAPIUI.Controllers.CRUDSalaAdmin.Models;
using WebAPIUI.Controllers.CRUDSalaRecurso.Models;
using WebAPIUI.Controllers.CRUDSalaRecursoEspecialEspecial.Models;
using WebAPIUI.Controllers.EventoClasePersona.Models;
using WebAPIUI.Controllers.EventosRecursoEspecial.Models;
using WebAPIUI.Controllers.EventosSerializados.Models;
using WebAPIUI.Controllers.HorasDisciplina.Models;
using WebAPIUI.Controllers.Login.Models;
using WebAPIUI.Controllers.MembresiasUsuario.Models;
using WebAPIUI.Controllers.ModificarMembresiaUsuario.Models;
using WebAPIUI.Controllers.Registro.Models;
using WebAPIUI.Controllers.RegistroMembresiaUsuario.Models;
using WebAPIUI.Controllers.RenovacionMembresiaUsuario.Models;
using WebAPIUI.Controllers.ReporteGeneralAsistencia.Models;
using WebAPIUI.Controllers.SolicitudesMembresias.Models;
using WebAPIUI.Controllers.TransaccionesAnuales.Models;
using WebAPIUI.CustomExceptions.App.ConsultaHorariosDeportista;
using WebAPIUI.CustomExceptions.App.EnviarMailValidacion;
using WebAPIUI.CustomExceptions.App.InscripcionUsuarioSesion;
using WebAPIUI.CustomExceptions.App.ModificacionDatosPersonales;
using WebAPIUI.CustomExceptions.ClasesAdmin;
using WebAPIUI.CustomExceptions.ConfiguracionesSistema;
using WebAPIUI.CustomExceptions.ConsultaClasesPendientesInstructor;
using WebAPIUI.CustomExceptions.ConsultaDisciplinasDeportista;
using WebAPIUI.CustomExceptions.ConsultaFichaEntrenamiento;
using WebAPIUI.CustomExceptions.ConsultaFichaPersona;
using WebAPIUI.CustomExceptions.ConsultaHistorialAsistenciaCliente;
using WebAPIUI.CustomExceptions.ConsultaHorarios;
using WebAPIUI.CustomExceptions.ConsultaListaAsistencia;
using WebAPIUI.CustomExceptions.ConsultaNoticias;
using WebAPIUI.CustomExceptions.ConsultaPerfil;
using WebAPIUI.CustomExceptions.ConsultaPersonaEstado;
using WebAPIUI.CustomExceptions.ConsultaRepEventoDisciplina;
using WebAPIUI.CustomExceptions.ConsultaRepEventoSala;
using WebAPIUI.CustomExceptions.ConsultaVentasMembresias;
using WebAPIUI.CustomExceptions.DisciplinaAdmin;
using WebAPIUI.CustomExceptions.EventoAdmin;
using WebAPIUI.CustomExceptions.EventoClasePersona;
using WebAPIUI.CustomExceptions.EventoPersona;
using WebAPIUI.CustomExceptions.EventoRecursoEspecial;
using WebAPIUI.CustomExceptions.EventosSerializados;
using WebAPIUI.CustomExceptions.FichaEntrenamiento;
using WebAPIUI.CustomExceptions.FichaPersona;
using WebAPIUI.CustomExceptions.GenerarQRInstructor;
using WebAPIUI.CustomExceptions.HorarioAdmin;
using WebAPIUI.CustomExceptions.HorarioMAdmin;
using WebAPIUI.CustomExceptions.HorasDisciplina;
using WebAPIUI.CustomExceptions.Login;
using WebAPIUI.CustomExceptions.MembresiasAdmin;
using WebAPIUI.CustomExceptions.MembresiasUsuario;
using WebAPIUI.CustomExceptions.NoticiaAdmin;
using WebAPIUI.CustomExceptions.RecursoAdmin;
using WebAPIUI.CustomExceptions.RecursoEspecialAdmin;
using WebAPIUI.CustomExceptions.RegisterPerson;
using WebAPIUI.CustomExceptions.RegistrarAsistenciaEventoPersona;
using WebAPIUI.CustomExceptions.RegistrarAsistenciaEventoProfesor;
using WebAPIUI.CustomExceptions.RegistrarAsistenciaManual;
using WebAPIUI.CustomExceptions.RegistroAdmin;
using WebAPIUI.CustomExceptions.ReporteGeneralAsistencia;
using WebAPIUI.CustomExceptions.RolAdmin;
using WebAPIUI.CustomExceptions.SalaAdmin;
using WebAPIUI.CustomExceptions.SalaRecurso;
using WebAPIUI.CustomExceptions.SalaRecursoEspecial;
using WebAPIUI.CustomExceptions.SolicitudesMembresias;
using WebAPIUI.CustomExceptions.TransaccionesAnuales;
#endregion

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

        #region SalaRecurso Exceptions
        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
        internal static void ThrowHandledExceptionSalaRecurso(SalaRecursoResponseType type, IList<string> messages)
        {
            var newException = new SalaRecursoException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionSalaRecurso(SalaRecursoResponseType type, Exception ex)
        {
            throw new SalaRecursoException(type, ex.Message);
        }

        internal void SetResponseAsExceptionSalaRecurso(SalaRecursoResponseType code, SalaRecursoDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
            response.ContentCreate = false;
            response.ContentModify = false;
            response.ContentDetail = null;
        }

        #endregion

        #region SalaRecursoEspecial Exceptions
        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
        internal static void ThrowHandledExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType type, IList<string> messages)
        {
            var newException = new SalaRecursoEspecialException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType type, Exception ex)
        {
            throw new SalaRecursoEspecialException(type, ex.Message);
        }

        internal void SetResponseAsExceptionSalaRecursoEspecial(SalaRecursoEspecialResponseType code, SalaRecursoEspecialDataResponse response, string message)
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

        #region ModificacionDatosPersonales Expections
        internal static void ThrowHandledExceptionModificacionDatosPersonales(ModificacionDatosPersonalesResponseType type, IList<string> messages)
        {
            var newException = new ModificacionDatosPersonalesException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionModificacionDatosPersonales(ModificacionDatosPersonalesResponseType type, Exception ex)
        {
            throw new ModificacionDatosPersonalesException(type, ex.Message);
        }

        internal void SetResponseAsExceptionModificacionDatosPersonales(ModificacionDatosPersonalesResponseType code, ModificacionDatosPersonalesDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentPassword = false;
            response.ContentPersonalInfo = false;
        }
        #endregion


        #region EnviarMailValidacion Exceptions
        internal static void ThrowHandledExceptionEnviarMailValidacion(EnviarMailValidacionResponseType type, IList<string> messages)
        {
            var newException = new EnviarMailValidacionException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionEnviarMailValidacion(EnviarMailValidacionResponseType type, Exception ex)
        {
            throw new EnviarMailValidacionException(type, ex.Message);
        }

        internal void SetResponseAsExceptionEnviarMailValidacion(EnviarMailValidacionResponseType code, EnviarMailValidacionDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = null;
        }
        #endregion

        #region ConsultaHorariosDeportista Exceptions
        internal static void ThrowHandledExceptionConsultaHorariosDeportista(ConsultaHorariosDeportistaResponseType type, IList<string> messages)
        {
            var newException = new ConsultaHorariosDeportistaException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionConsultaHorariosDeportista(ConsultaHorariosDeportistaResponseType type, Exception ex)
        {
            throw new ConsultaHorariosDeportistaException(type, ex.Message);
        }

        internal void SetResponseAsExceptionConsultaHorariosDeportista(ConsultaHorariosDeportistaResponseType code, ConsultaHorariosDeportistaDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = null;
        }
        #endregion

        #region InscripcionUsuarioSesion Exceptions
        internal static void ThrowHandledExceptionInscripcionUsuarioSesion(InscripcionUsuarioSesionResponseType type, IList<string> messages)
        {
            var newException = new InscripcionUsuarioSesionException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionInscripcionUsuarioSesion(InscripcionUsuarioSesionResponseType type, Exception ex)
        {
            throw new InscripcionUsuarioSesionException(type, ex.Message);
        }

        internal void SetResponseAsExceptionInscripcionUsuarioSesion(InscripcionUsuarioSesionResponseType code, InscripcionUsuarioSesionDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = false;
        }
        #endregion

        #region ConsultaFichaPersonaException Exceptions
        internal static void ThrowHandledExceptionConsultaFichaPersonaException(ConsultaFichaPersonaResponseType type, IList<string> messages)
        {
            var newException = new ConsultaFichaPersonaException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionConsultaFichaPersonaException(ConsultaFichaPersonaResponseType type, Exception ex)
        {
            throw new ConsultaFichaPersonaException(type, ex.Message);
        }

        internal void SetResponseAsExceptionConsultaFichaPersonaException(ConsultaFichaPersonaResponseType code, ConsultaFichaPersonaDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
        }
        #endregion

        #region ConsultaFichaEntrenamientoException Exceptions
        internal static void ThrowHandledExceptionConsultaFichaEntrenamientoException(ConsultaFichaEntrenamientoResponseType type, IList<string> messages)
        {
            var newException = new ConsultaFichaEntrenamientoException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionConsultaFichaEntrenamientoException(ConsultaFichaEntrenamientoResponseType type, Exception ex)
        {
            throw new ConsultaFichaEntrenamientoException(type, ex.Message);
        }

        internal void SetResponseAsExceptionConsultaFichaEntrenamientoException(ConsultaFichaEntrenamientoResponseType code, ConsultaFichaEntrenamientoDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
        }
        #endregion

        #region ConsultaNoticiasException Exceptions
        internal static void ThrowHandledExceptionConsultaNoticiasException(ConsultaNoticiasResponseType type, IList<string> messages)
        {
            var newException = new ConsultaNoticiasException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionConsultaNoticiasException(ConsultaNoticiasResponseType type, Exception ex)
        {
            throw new ConsultaNoticiasException(type, ex.Message);
        }

        internal void SetResponseAsExceptionConsultaNoticiasException(ConsultaNoticiasResponseType code, ConsultaNoticiasDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
        }
        #endregion

        #region ConsultaListaAsistenciaException Exceptions
        internal static void ThrowHandledExceptionConsultaListaAsistenciaException(ConsultaListaAsistenciaResponseType type, IList<string> messages)
        {
            var newException = new ConsultaListaAsistenciaException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionConsultaListaAsistenciaException(ConsultaListaAsistenciaResponseType type, Exception ex)
        {
            throw new ConsultaListaAsistenciaException(type, ex.Message);
        }

        internal void SetResponseAsExceptionConsultaListaAsistenciaException(ConsultaListaAsistenciaResponseType code, ConsultaListaAsistenciaDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
        }
        #endregion

        #region ConsultaHistorialAsitenciaClienteException Exceptions
        internal static void ThrowHandledExceptionConsultaHistorialAsitenciaClienteException(ConsultaHistorialAsistenciaClienteResponseType type, IList<string> messages)
        {
            var newException = new ConsultaHistorialAsistenciaClienteException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionConsultaHistorialAsitenciaClienteException(ConsultaHistorialAsistenciaClienteResponseType type, Exception ex)
        {
            throw new ConsultaHistorialAsistenciaClienteException(type, ex.Message);
        }

        internal void SetResponseAsExceptionConsultaHistorialAsitenciaClienteException(ConsultaHistorialAsistenciaClienteResponseType code, ConsultaHistorialAsistenciaClienteDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = null;
        }
        #endregion

        #region ConsultaDisciplinasDeportistaException Exceptions
        internal static void ThrowHandledExceptionConsultaDisciplinasDeportistaException(ConsultaDisciplinasDeportistaResponseType type, IList<string> messages)
        {
            var newException = new ConsultaDisciplinasDeportistaException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionConsultaDisciplinasDeportistaException(ConsultaDisciplinasDeportistaResponseType type, Exception ex)
        {
            throw new ConsultaDisciplinasDeportistaException(type, ex.Message);
        }

        internal void SetResponseAsExceptionConsultaDisciplinasDeportistaException(ConsultaDisciplinasDeportistaResponseType code, ConsultaDisciplinasDeportistaDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = null;
        }
        #endregion


        #region RegistrarAsistenciaEventoPersonaException Exceptions
        internal static void ThrowHandledExceptionRegistrarAsistenciaEventoPersonaException(RegistrarAsistenciaEventoPersonaResponseType type, IList<string> messages)
        {
            var newException = new RegistrarAsistenciaEventoPersonaException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionRegistrarAsistenciaEventoPersonaException(RegistrarAsistenciaEventoPersonaResponseType type, Exception ex)
        {
            throw new RegistrarAsistenciaEventoPersonaException(type, ex.Message);
        }

        internal void SetResponseAsExceptionRegistrarAsistenciaEventoPersonaException(RegistrarAsistenciaEventoPersonaResponseType code, RegistrarAsistenciaEventoPersonaDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            
        }
        #endregion

        #region GenerarQRInstructorException Exceptions
        internal static void ThrowHandledExceptionGenerarQRInstructorException(GenerarQRInstructorResponseType type, IList<string> messages)
        {
            var newException = new GenerarQRInstructorException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionGenerarQRInstructorException(GenerarQRInstructorResponseType type, Exception ex)
        {
            throw new GenerarQRInstructorException(type, ex.Message);
        }

        internal void SetResponseAsExceptionGenerarQRInstructorException(GenerarQRInstructorResponseType code, GenerarQRInstructorDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.content = false;
        }
        #endregion


        #region RegistrarAsistenciaEventoProfesorException Exceptions
        internal static void ThrowHandledExceptionRegistrarAsistenciaEventoProfesorException(RegistrarAsistenciaEventoProfesorResponseType type, IList<string> messages)
        {
            var newException = new RegistrarAsistenciaEventoProfesorException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionRegistrarAsistenciaEventoProfesorException(RegistrarAsistenciaEventoProfesorResponseType type, Exception ex)
        {
            throw new RegistrarAsistenciaEventoProfesorException(type, ex.Message);
        }

        internal void SetResponseAsExceptionRegistrarAsistenciaEventoProfesorException(RegistrarAsistenciaEventoProfesorResponseType code, RegistrarAsistenciaEventoProfesorDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;

        }
        #endregion


        #region ConsultaClasesPendientesInstructorException Exceptions
        internal static void ThrowHandledExceptionConsultaClasesPendientesInstructorException(ConsultaClasesPendientesInstructorResponseType type, IList<string> messages)
        {
            var newException = new ConsultaClasesPendientesInstructorException(type, messages);
            throw newException;
        }  

        internal static void ThrowUnHandledExceptionConsultaClasesPendientesInstructorException(ConsultaClasesPendientesInstructorResponseType type, Exception ex)
        {
            throw new ConsultaClasesPendientesInstructorException(type, ex.Message);
        }

        internal void SetResponseAsExceptionConsultaClasesPendientesInstructorException(ConsultaClasesPendientesInstructorResponseType code, ConsultaClasesPendientesInstructorDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.ContentIndex = null;
        }
        #endregion

        #region RegistrarAsistenciaManualException Exceptions
        internal static void ThrowHandledExceptionRegistrarAsistenciaManualException(RegistrarAsistenciaManualResponseType type, IList<string> messages)
        {
            var newException = new RegistrarAsistenciaManualException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledExceptionRegistrarAsistenciaManualException(RegistrarAsistenciaManualResponseType type, Exception ex)
        {
            throw new RegistrarAsistenciaManualException(type, ex.Message);
        }

        internal void SetResponseAsExceptionRegistrarAsistenciaManualException(RegistrarAsistenciaManualResponseType code, RegistrarAsistenciaManualDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;

        }
        #endregion
 

    }
}