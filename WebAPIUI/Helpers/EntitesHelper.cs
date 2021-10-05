using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBusiness.Entities.Membresia;

using System.Globalization;
using WebAPIUI.Models.Membresias;
using WebAPIUI.Models.EventoClasePersona;
using WebAPIBusiness.Entities.EventoClasePersona;

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
                    NombreInstructor = entity.NombreInstructor,
                    Descripcion = entity.Descripcion,
                    fecha = entity.fecha.ToString("yyyy-MM-dd"),
                    horaInicio = entity.horaInicio,
                    horaFin = entity.horaFin,
                    Asistentes = entity.Asistentes,
                    AforoMaximoClase = entity.AforoMaximoClase,
                    AforoMinimoClase = entity.AforoMinimoClase,
                    ClaseAgendada = entity.ClaseAgendada,
                    recursosEspeciales=entity.recursosEspeciales
                };


                response.Add(item);
            }
            return response;
        }
    }
}
