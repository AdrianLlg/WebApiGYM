using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBusiness.Entities.Membresia;

using System.Globalization;
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

namespace WebAPIUI.Helpers
{
    public static class EntitesHelper
    {
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
    }

}
