using System.Collections.Generic;
using WebAPIBusiness.Entities.Membresia;
using WebAPIUI.Models.Membresias;
using WebAPIUI.Models.EventoClasePersona;
using WebAPIBusiness.Entities.EventoClasePersona;
using WebAPIUI.Models.EventoRecursoEspecial;
using WebAPIBusiness.Entities.EvetoRecursoEspecial;
using WebAPIUI.Models.RegistroAdmin;
using WebAPIBusiness.Entities.RegistroAdmin;
using WebAPIUI.Models.MembresiasAdmin;
using WebAPIBusiness.Entities.MembresiaAdmin;
using WebAPIUI.Models.RolAdmin;
using WebAPIBusiness.Entities.RolAdmin;
using WebAPIUI.Models.DisciplinaAdmin;
using WebAPIBusiness.Entities.DisciplinaAdmin;
using WebAPIUI.Models.RecursoAdmin;
using WebAPIBusiness.Entities.RecursoAdmin;
using WebAPIUI.Models.SalaAdmin;
using WebAPIBusiness.Entities.SalaAdmin;
using WebAPIUI.Models.HorarioAdmin;
using WebAPIBusiness.Entities.HorarioAdmin;
using WebAPIUI.Models.HorarioMAdmin;
using WebAPIBusiness.Entities.HorarioMAdmin;
using WebAPIUI.Models.RecursoEspecialAdmin;
using WebAPIBusiness.Entities.RecursoEspecialAdmin;
using WebAPIUI.Models.ClaseAdmin;
using WebAPIBusiness.Entities.ClasesAdmin;

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
                    disciplinaID = entity.disciplinaID,
                    nombreDisciplina = entity.nombreDisciplina,
                    fechaLimite = entity.fechaLimite.ToString("yyyy-MM-dd"),
                    fechaPago = entity.fechaPago.ToString("yyyy-MM-dd"),
                    nombreMembresia = entity.nombreMembresia,
                    numClasesDisponibles = entity.numClasesDisponibles,
                    precio = entity.precio
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
                    Precio = entity.precio
                };

                response.Add(item);
            }
            return response;
        }
       

        public static MembresiaAdminModel MembresiaInfoEntityToModel(MembresiaAdminEntity entity)
        {

            MembresiaAdminModel response = new MembresiaAdminModel
            {
                MembresiaID = entity.membresiaID,
                Nombre = entity.nombre,
                Descripcion = entity.descripcion,
                Precio = entity.precio
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

        #region DisciplinasHelper
        public static List<DisciplinaAdminModel> DisciplinasEntityToModel(List<DisciplinaAdminEntity> entities)
        {

            List<DisciplinaAdminModel> response = new List<DisciplinaAdminModel>();

            foreach (var entity in entities)
            {
                var item = new DisciplinaAdminModel
                {
                    DisciplinaID = entity.disciplinaID,
                    Nombre = entity.nombre,
                    Descripcion = entity.descripcion,
                    NumeroDeClases = entity.numClases.ToString()
                };

                response.Add(item);
            }
            return response;
        }

        public static DisciplinaAdminModel DisciplinaInfoEntityToModel(DisciplinaAdminEntity entity)
        {

            DisciplinaAdminModel response = new DisciplinaAdminModel
            {
                DisciplinaID = entity.disciplinaID,
                Nombre = entity.nombre,
                Descripcion = entity.descripcion,
                NumeroDeClases = entity.numClases.ToString()
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
                    descripcion=entity.descripcion
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

    }

}
