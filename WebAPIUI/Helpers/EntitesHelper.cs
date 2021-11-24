using System.Collections.Generic;
using WebAPIBusiness.Entities.ClasesAdmin;
using WebAPIBusiness.Entities.DisciplinaAdmin;
using WebAPIBusiness.Entities.EventoAdmin;
using WebAPIBusiness.Entities.EventoClasePersona;
using WebAPIBusiness.Entities.EvetoRecursoEspecial;
using WebAPIBusiness.Entities.HorarioAdmin;
using WebAPIBusiness.Entities.HorarioMAdmin;
using WebAPIBusiness.Entities.Membresia;
using WebAPIBusiness.Entities.MembresiaAdmin;
using WebAPIBusiness.Entities.RecursoAdmin;
using WebAPIBusiness.Entities.RecursoEspecialAdmin;
using WebAPIBusiness.Entities.RegistroAdmin;
using WebAPIBusiness.Entities.RolAdmin;
using WebAPIBusiness.Entities.SalaAdmin;
using WebAPIUI.Models.ClaseAdmin;
using WebAPIUI.Models.DisciplinaAdmin;
using WebAPIUI.Models.EventoAdmin;
using WebAPIUI.Models.EventoClasePersona;
using WebAPIUI.Models.EventoRecursoEspecial;
using WebAPIUI.Models.HorarioAdmin;
using WebAPIUI.Models.HorarioMAdmin;
using WebAPIBusiness.Entities.ConfiguracionesSistemaAdmin;
using WebAPIUI.Models.ConfiguracionesSistema;
using WebAPIUI.Models.Membresias;
using WebAPIUI.Models.MembresiasAdmin;
using WebAPIUI.Models.RecursoAdmin;
using WebAPIUI.Models.RecursoEspecialAdmin;
using WebAPIUI.Models.RegistroAdmin;
using WebAPIUI.Models.RolAdmin;
using WebAPIUI.Models.SalaAdmin;
using WebAPIUI.Models.NoticiaAdmin;
using WebAPIBusiness.Entities.Noticia;
using WebAPIUI.Models.SolicitudesMembresias;
using WebAPIBusiness.Entities.SolicitudesMembresias;
using System;
using WebAPIUI.Models.ConsultaRepEventoDisciplina;
using WebAPIBusiness.Entities.ConsultaRepEventoDisciplina;
using WebAPIUI.Models.ConsultaPersonaEstado;
using WebAPIBusiness.Entities.ConsultaPersonaEstado;
using WebAPIUI.Models.ConsultaRepEventoSala;
using WebAPIBusiness.Entities.ConsultaRepEventoSala;
using WebAPIUI.Models.TransaccionesAnuales;
using WebAPIBusiness.Entities.TransaccionesAnuales;
using WebAPIUI.Models.ConsultaVentasMembresias;
using WebAPIBusiness.Entities.ConsultaVentasMembresias;

namespace WebAPIUI.Helpers
{
    public static class EntitesHelper
    {
        #region MembresiasHelper
        public static List<MembresiasModel> MembresiaEntityToModel(List<MembresiaEntity> entities)
        {

            List<MembresiasModel> response = new List<MembresiasModel>();

            foreach (var entity in entities)
            {
                var item = new MembresiasModel
                {
                    nombreMembresia = entity.nombreMembresia,
                    precioMembresia = entity.precioMembresia,
                    periodicidadMembresia = entity.periodicidadMembresia,
                    fechaPago = entity.fechaPago.ToString("yyyy-MM-dd"),
                    fechaLimite = entity.fechaLimite.ToString("yyyy-MM-dd"),
                };

                response.Add(item);
            }
            return response;
        }
        #endregion

        #region EventoClasePersonaHelper
        public static List<EventoClasePersonaModel> EventoClasePersonaEntityToModel(List<EventoClasePersonaEntity> entities)
        {

            List<EventoClasePersonaModel> response = new List<EventoClasePersonaModel>();

            foreach (var entity in entities)
            {
                var item = new EventoClasePersonaModel
                {
                    EventoID = entity.EventoID,
                    Clase = entity.Clase,
                    Sala = entity.Sala,
                    NombreInstructor = entity.NombreInstructor,
                    Descripcion = entity.Descripcion,
                    fecha = entity.fecha.ToString("yyyy-MM-dd"),
                    horaInicio = entity.horaInicio,
                    horaFin = entity.horaFin,
                    Asistentes = entity.Asistentes,
                    AforoMaximoClase = entity.AforoMaximoClase,
                    AforoMinimoClase = entity.AforoMinimoClase,
                    ClaseAgendada = entity.ClaseAgendada,
                    recursosEspeciales = entity.recursosEspeciales
                };


                response.Add(item);
            }
            return response;
        }
        #endregion

        #region EventoRecursoEspecialHelper
        public static List<EventoRecursoEspecialModel> EventoRecursoEspecialEntityToModel(List<EventoRecursoEspecialEntity> entities)
        {

            List<EventoRecursoEspecialModel> response = new List<EventoRecursoEspecialModel>();

            foreach (var entity in entities)
            {
                var item = new EventoRecursoEspecialModel
                {
                    Nombre = entity.Nombre,
                    Descripcion = entity.Descripcion,
                    Reservado = entity.Reservado
                };


                response.Add(item);
            }
            return response;
        }
        #endregion

        #region RegistroAdminHelper
        public static List<RegistroAdminModel> UsuariosRegistradosEntityToModel(List<UsuariosRegistradosEntity> entities)
        {

            List<RegistroAdminModel> response = new List<RegistroAdminModel>();

            foreach (var entity in entities)
            {
                var item = new RegistroAdminModel
                {
                    personaID = entity.personaID,
                    rolePID = entity.rolePID,
                    nombres = entity.nombres,
                    apellidos = entity.apellidos,
                    edad = entity.edad,
                    email = entity.email,
                    estado = entity.estado,
                    identificacion = entity.identificacion,
                    sexo = entity.sexo,
                    telefono = entity.telefono,
                    fechaNacimiento = entity.fechaNacimiento.ToString("dd/MM/yyyy"),
                    fechaCreacion = entity.fechaCreacion.ToString("dd/MM/yyyy"),

                };

                response.Add(item);
            }
            return response;
        }
        #endregion

        #region UsuarioRegistradoEntityHelper
        public static RegistroAdminModel UsuarioRegistradoEntityToModel(UsuariosRegistradosEntity entity)
        {

            RegistroAdminModel response = new RegistroAdminModel
            {
                personaID = entity.personaID,
                rolePID = entity.rolePID,
                nombres = entity.nombres,
                apellidos = entity.apellidos,
                edad = entity.edad,
                email = entity.email,
                estado = entity.estado,
                identificacion = entity.identificacion,
                sexo = entity.sexo,
                telefono = entity.telefono,
                fechaNacimiento = entity.fechaNacimiento.ToString("dd/MM/yyyy"),
                fechaCreacion = entity.fechaCreacion.ToString("dd/MM/yyyy"),

            };

            return response;
        }
        #endregion

        #region MembresiaAdminHelper
        public static List<MembresiaAdminModel> MembresiasEntityToModel(List<MembresiaAdminEntity> entities)
        {

            List<MembresiaAdminModel> response = new List<MembresiaAdminModel>();

            foreach (var entity in entities)
            {
                var item = new MembresiaAdminModel
                {
                    MembresiaID = entity.membresiaID,
                    Nombre = entity.nombre,
                    Descripcion = entity.descripcion,
                    Precio = entity.precio,
                    Periodicidad = entity.periodicidad
                };

                response.Add(item);
            }
            return response;
        }


        public static MembresiaAdminModel MembresiaInfoEntityToModel(MembresiaAdminEntity entity, List<Membresia_Disciplina_NumClasesEntity> entities)
        {

            MembresiaAdminModel response = new MembresiaAdminModel
            {
                MembresiaID = entity.membresiaID,
                Nombre = entity.nombre,
                Descripcion = entity.descripcion,
                Precio = entity.precio,
                Periodicidad = entity.periodicidad,
                membresiaDisciplinas = entities
            };

            return response;
        }
        #endregion

        #region RolAdminHelper
        public static List<RolAdminModel> RolesEntityToModel(List<RolAdminEntity> entities)
        {

            List<RolAdminModel> response = new List<RolAdminModel>();

            foreach (var entity in entities)
            {
                var item = new RolAdminModel
                {
                    rolePID = entity.rolePID,
                    nombre = entity.nombre,
                    descripcion = entity.descripcion
                };

                response.Add(item);
            }
            return response;
        }

        public static RolAdminModel RolInfoEntityToModel(RolAdminEntity entity)
        {

            RolAdminModel response = new RolAdminModel
            {
                rolePID = entity.rolePID,
                nombre = entity.nombre,
                descripcion = entity.descripcion
            };

            return response;
        }
        #endregion

        #region SalasAdminHelper
        public static List<SalaAdminModel> SalasEntityToModel(List<SalaAdminEntity> entities)
        {

            List<SalaAdminModel> response = new List<SalaAdminModel>();

            foreach (var entity in entities)
            {
                var item = new SalaAdminModel
                {
                    salaID = entity.salaID,
                    nombre = entity.nombre,
                    descripcion = entity.descripcion
                };

                response.Add(item);
            }
            return response;
        }


        public static SalaAdminModel SalaInfoEntityToModel(SalaAdminEntity entity)
        {

            SalaAdminModel response = new SalaAdminModel
            {
                salaID = entity.salaID,
                nombre = entity.nombre,
                descripcion = entity.descripcion
            };

            return response;
        }
        #endregion

        #region DisciplinasAdminHelper
        public static List<DisciplinaAdminModel> DisciplinasEntityToModel(List<DisciplinaAdminEntity> entities)
        {

            List<DisciplinaAdminModel> response = new List<DisciplinaAdminModel>();

            foreach (var entity in entities)
            {
                var item = new DisciplinaAdminModel
                {
                    disciplinaID = entity.disciplinaID,
                    nombre = entity.nombre,
                    descripcion = entity.descripcion
                };

                response.Add(item);
            }
            return response;
        }


        public static DisciplinaAdminModel DisciplinasInfoEntityToModel(DisciplinaAdminEntity entity)
        {

            DisciplinaAdminModel response = new DisciplinaAdminModel
            {
                disciplinaID = entity.disciplinaID,
                nombre = entity.nombre,
                descripcion = entity.descripcion
            };

            return response;
        }
        #endregion


        #region RecursoAdminHelper
        public static List<RecursoAdminModel> RecursosEntityToModel(List<RecursoAdminEntity> entities)
        {

            List<RecursoAdminModel> response = new List<RecursoAdminModel>();

            foreach (var entity in entities)
            {
                var item = new RecursoAdminModel
                {
                    RecursoID = entity.recursoID,
                    Nombre = entity.nombre,
                    Descripcion = entity.descripcion,
                    CantidadDeRecurso = entity.cantidadRecurso.ToString()
                };

                response.Add(item);
            }
            return response;
        }

        public static RecursoAdminModel RecursoInfoEntityToModel(RecursoAdminEntity entity)
        {

            RecursoAdminModel response = new RecursoAdminModel
            {
                RecursoID = entity.recursoID,
                Nombre = entity.nombre,
                Descripcion = entity.descripcion,
                CantidadDeRecurso = entity.cantidadRecurso.ToString()
            };

            return response;
        }

        #endregion

        #region RecursoEspecialAdminHelper
        public static List<RecursoEspecialAdminModel> RecursoEspecialsEntityToModel(List<RecursoEspecialAdminEntity> entities)
        {

            List<RecursoEspecialAdminModel> response = new List<RecursoEspecialAdminModel>();

            foreach (var entity in entities)
            {
                var item = new RecursoEspecialAdminModel
                {
                    recursoEspecialID = entity.recursoEspecialID,
                    nombre = entity.nombre,
                    descripcion = entity.descripcion,

                };

                response.Add(item);
            }
            return response;
        }

        public static RecursoEspecialAdminModel RecursoEspecialInfoEntityToModel(RecursoEspecialAdminEntity entity)
        {

            RecursoEspecialAdminModel response = new RecursoEspecialAdminModel
            {
                recursoEspecialID = entity.recursoEspecialID,
                nombre = entity.nombre,
                descripcion = entity.descripcion,

            };

            return response;
        }

        #endregion

        #region HorarioAdminHelper
        public static List<HorarioAdminModel> HorariosEntityToModel(List<HorarioAdminEntity> entities)
        {

            List<HorarioAdminModel> response = new List<HorarioAdminModel>();

            foreach (var entity in entities)
            {
                var item = new HorarioAdminModel
                {
                    horarioMID = entity.horarioMID,
                    horaInicio = entity.horaInicio,
                    horaFin = entity.horaFin
                };

                response.Add(item);
            }
            return response;
        }

        public static HorarioAdminModel HorarioInfoEntityToModel(HorarioAdminEntity entity)
        {

            HorarioAdminModel response = new HorarioAdminModel
            {
                horarioMID = entity.horarioMID,
                horaInicio = entity.horaInicio,
                horaFin = entity.horaFin
            };

            return response;
        }

        #endregion

        #region HorarioMAdminHelper
        public static List<HorarioMAdminModel> horarioMEntityToModel(List<HorarioMAdminEntity> entities)
        {

            List<HorarioMAdminModel> response = new List<HorarioMAdminModel>();

            foreach (var entity in entities)
            {
                var item = new HorarioMAdminModel
                {
                    horarioMID = entity.horarioMID,
                    horaInicio = entity.horaInicio,
                    horaFin = entity.horaFin
                };

                response.Add(item);
            }
            return response;
        }

        public static HorarioMAdminModel HorarioMInfoEntityToModel(HorarioMAdminEntity entity)
        {

            HorarioMAdminModel response = new HorarioMAdminModel
            {
                horarioMID = entity.horarioMID,
                horaInicio = entity.horaInicio,
                horaFin = entity.horaFin
            };

            return response;
        }
        #endregion


        #region ClasesAdminHelper
        public static List<ClaseAdminModel> ClasesEntityToModel(List<ClaseAdminEntity> entities)
        {

            List<ClaseAdminModel> response = new List<ClaseAdminModel>();

            foreach (var entity in entities)
            {
                var item = new ClaseAdminModel
                {
                    claseID = entity.claseID,
                    disciplinaID = entity.disciplinaID,
                    nombre = entity.nombre,
                    descripcion = entity.descripcion
                };

                response.Add(item);
            }
            return response;
        }

        public static ClaseAdminModel ClasesInfoEntityToModel(ClaseAdminEntity entity)
        {

            ClaseAdminModel response = new ClaseAdminModel
            {
                claseID = entity.claseID,
                disciplinaID = entity.disciplinaID,
                nombre = entity.nombre,
                descripcion = entity.descripcion
            };

            return response;
        }
        #endregion

        //public static NuevaMembresiaPersonaModel NuevaMembresiaEntityToModel(MembresiaPersonaDisciplinaEntity entity)
        //{

        //    NuevaMembresiaPersonaModel response = new NuevaMembresiaPersonaModel
        //    {
        //      membresia_persona_disciplinaID = entity.membresia_persona_disciplinaID,
        //      membresiaID = entity.membresiaID,
        //      personaID = entity.personaID,
        //      statusMembresia = entity.statusMembresia,
        //      fechaPago = entity.fechaPago.ToString(),
        //      fechaLimite = entity.fechaLimite.ToString()
        //    };

        //    return response;
        //}

        #region Configuraciones Helper
        public static List<ConfiguracionesSistemaModel> EntityToModelConfiguracionesSistema(List<ConfiguracionesAdminEntity> entities)
        {

            List<ConfiguracionesSistemaModel> response = new List<ConfiguracionesSistemaModel>();

            foreach (var entity in entities)
            {
                ConfiguracionesSistemaModel model = new ConfiguracionesSistemaModel()
                {
                    ConfiguracionSistemaID = entity.ConfiguracionSistemaID,
                    TipoConfiguracion = entity.TipoConfiguracion,
                    NombreConfiguracion = entity.NombreConfiguracion,
                    DescripcionConfiguracion = entity.DescripcionConfiguracion,
                    Valor = entity.Valor,
                    Estado = entity.Estado,
                    Fecha = entity.Fecha.ToString(),
                    FechaFin = entity.FechaFin.ToString(),
                    FechaInicio = entity.FechaInicio.ToString()
                };

                response.Add(model);
            };

            return response;
        }
        #endregion

        #region NoticiaAdmin
        public static List<NoticiaAdminModel> NoticiaEntityToModel(List<NoticiaEntity> entities)
        {

            List<NoticiaAdminModel> response = new List<NoticiaAdminModel>();

            foreach (var entity in entities)
            {
                var item = new NoticiaAdminModel
                {
                    noticiaID = entity.noticiaID,
                    titulo = entity.titulo,
                    contenido = entity.contenido,
                    imagen = entity.imagen,
                    fechaInicio = entity.fechaInicio.ToString(),
                    fechaFin = entity.fechaFin.ToString()

                };

                response.Add(item);
            }
            return response;
        }

        public static NoticiaAdminModel NoticiaInfoEntityToModel(NoticiaEntity entity)
        {

            NoticiaAdminModel response = new NoticiaAdminModel
            {
                noticiaID = entity.noticiaID,
                titulo = entity.titulo,
                contenido = entity.contenido,
                imagen = entity.imagen,
                fechaInicio = entity.fechaInicio.ToString(),
                fechaFin = entity.fechaFin.ToString()

            };

            return response;
        }
        #endregion

        #region EventosAdminHelper
        public static List<EventoAdminModel> EventosEntityToModel(List<EventoAdminEntity> entities)
        {

            List<EventoAdminModel> response = new List<EventoAdminModel>();

            foreach (var entity in entities)
            {
                var item = new EventoAdminModel
                {
                    eventoID = entity.eventoID,
                    claseID = entity.claseID,
                    horarioMID = entity.horarioMID,
                    fecha = entity.fecha,
                    salaID = entity.salaID,
                    aforoMax = entity.aforoMax,
                    aforoMin = entity.aforoMin
                };

                response.Add(item);
            }
            return response;
        }

        public static EventoAdminModel EventosInfoEntityToModel(EventoAdminEntity entity)
        {

            EventoAdminModel response = new EventoAdminModel
            {
                eventoID = entity.eventoID,
                claseID = entity.claseID,
                horarioMID = entity.horarioMID,
                fecha = entity.fecha,
                salaID = entity.salaID,
                aforoMax = entity.aforoMax,
                aforoMin = entity.aforoMin
            };

            return response;
        }
        #endregion


        #region SolicitudesMembresiasModel
        public static List<SolicitudesMembresiasModel> EntityToModelSolicitudesMembresias(List<SolicitudesMembresiasEntity> entities)
        {

            List<SolicitudesMembresiasModel> response = new List<SolicitudesMembresiasModel>();

            foreach (var entity in entities)
            {
                SolicitudesMembresiasModel model = new SolicitudesMembresiasModel()
                {
                    solicitud_membresiaPagoID = entity.solicitud_membresiaPagoID,
                    personaID = entity.personaID,
                    nombrePersona = entity.nombrePersona,
                    identificacionPersona = entity.identificacionPersona,
                    membresiaID = entity.membresiaID,
                    nombreMembresia = entity.nombreMembresia,
                    perioridicidadMembresia = entity.perioridicidadMembresia,
                    membresia_persona_pagoID = entity.membresia_persona_pagoID,
                    fechaRegistroSolicitud = entity.fechaRegistroSolicitud.ToString(),
                    comprobante = Convert.ToBase64String(entity.comprobante)
                };

                response.Add(model);
            };

            return response;
        }
        #endregion

        #region ConsultaRepEventoDisciplinaModel
        public static List<ConsultaRepEventoDisciplinaModel> EntityToModelConsultaRepEventoDisciplina(List<ConsultaRepEventoDisciplinaEntity> entities)
        {

            List<ConsultaRepEventoDisciplinaModel> response = new List<ConsultaRepEventoDisciplinaModel>();

            foreach (var entity in entities)
            {
                ConsultaRepEventoDisciplinaModel model = new ConsultaRepEventoDisciplinaModel()
                {
                    CantidadEventos = entity.CantidadEventos,
                    Disciplina = entity.Disciplina,


                };

                response.Add(model);
            };

            return response;
        }
        #endregion

        #region ConsultaPersonaEstadoModel
        public static List<ConsultaPersonaEstadoModel> EntityToModelConsultaPersonaEstado(List<ConsultaPersonaEstadoEntity> entities)
        {

            List<ConsultaPersonaEstadoModel> response = new List<ConsultaPersonaEstadoModel>();

            foreach (var entity in entities)
            {
                ConsultaPersonaEstadoModel model = new ConsultaPersonaEstadoModel()
                {
                    Cantidad = entity.Cantidad,
                    Estado = entity.Estado,


                };

                response.Add(model);
            };

            return response;
        }
        #endregion

        #region ConsultaRepEventoSalaModel
        public static List<ConsultaRepEventoSalaModel> EntityToModelConsultaRepEventoSala(List<ConsultaRepEventoSalaEntity> entities)
        {

            List<ConsultaRepEventoSalaModel> response = new List<ConsultaRepEventoSalaModel>();

            foreach (var entity in entities)
            {
                ConsultaRepEventoSalaModel model = new ConsultaRepEventoSalaModel()
                {
                    CantidadEventos = entity.CantidadEventos,
                    Sala = entity.Sala,


                };

                response.Add(model);
            };

            return response;
        }
        #endregion

        #region TransaccionesAnualesModel
        public static List<TransaccionesAnualesModel> EntityToModelTransaccionesAnuales(List<TransaccionesAnualesEntity> entities)
        {

            List<TransaccionesAnualesModel> response = new List<TransaccionesAnualesModel>();

            foreach (var entity in entities)
            {
                TransaccionesAnualesModel model = new TransaccionesAnualesModel()
                {
                    Transacciones = entity.Transacciones,
                    Anio = entity.Anio,
                    Mes = entity.Mes


                };

                response.Add(model);
            };

            return response;
        }
        #endregion

        #region ConsultaVentasMembresiasModel
        public static List<ConsultaVentasMembresiasModel> EntityToModelConsultaVentasMembresias(List<ConsultaVentasMembresiasEntity> entities)
        {

            List<ConsultaVentasMembresiasModel> response = new List<ConsultaVentasMembresiasModel>();

            foreach (var entity in entities)
            {
                ConsultaVentasMembresiasModel model = new ConsultaVentasMembresiasModel()
                {
                    Membresia = entity.Membresia,
                    TotalVentas= entity.TotalVentas
                };

                response.Add(model);
            };

            return response;
        }
        #endregion

    }

}
