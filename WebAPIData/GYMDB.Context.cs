﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GYMDBEntities : DbContext
    {
        public GYMDBEntities()
            : base("name=GYMDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<clase> clase { get; set; }
        public virtual DbSet<configuraciones_Sistema> configuraciones_Sistema { get; set; }
        public virtual DbSet<disciplina> disciplina { get; set; }
        public virtual DbSet<evento> evento { get; set; }
        public virtual DbSet<evento_persona> evento_persona { get; set; }
        public virtual DbSet<fichaEntrenamiento> fichaEntrenamiento { get; set; }
        public virtual DbSet<fichaPersona> fichaPersona { get; set; }
        public virtual DbSet<horarioM> horarioM { get; set; }
        public virtual DbSet<membresia> membresia { get; set; }
        public virtual DbSet<membresia_disciplina> membresia_disciplina { get; set; }
        public virtual DbSet<membresia_persona_disciplina> membresia_persona_disciplina { get; set; }
        public virtual DbSet<membresia_persona_pago> membresia_persona_pago { get; set; }
        public virtual DbSet<noticia> noticia { get; set; }
        public virtual DbSet<persona> persona { get; set; }
        public virtual DbSet<recurso> recurso { get; set; }
        public virtual DbSet<recursoEspecial> recursoEspecial { get; set; }
        public virtual DbSet<roleP> roleP { get; set; }
        public virtual DbSet<sala> sala { get; set; }
        public virtual DbSet<salaRecurso> salaRecurso { get; set; }
        public virtual DbSet<salaRecursoEspecial> salaRecursoEspecial { get; set; }
        public virtual DbSet<sol_membresiaPago> sol_membresiaPago { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    }
}
