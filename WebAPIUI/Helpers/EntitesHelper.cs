using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBusiness.Entities.Membresia;
using WebAPIUI.Models;
using System.Globalization;

namespace WebAPIUI.Helpers
{
    public static class EntitesHelper
    {
        public static List<MembresiasModel> EntityToModel(List<MembresiaEntity> entities)
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

    }
}