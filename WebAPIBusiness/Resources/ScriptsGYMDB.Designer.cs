﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIBusiness.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ScriptsGYMDB {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ScriptsGYMDB() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WebAPIBusiness.Resources.ScriptsGYMDB", typeof(ScriptsGYMDB).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///SELECT 
        ///CL.nombre AS Clase,
        ///P.nombres AS Instructor,
        ///CL.descripcion AS Descripcion,
        ///CR.fecha,
        ///HM.horaInicio,
        ///HM.horaFin
        ///FROM cronograma CR
        ///INNER JOIN horarioM HM ON CR.horarioMID = HM.horarioMID
        ///INNER JOIN clase CL ON CR.claseID = CL.claseID
        ///INNER JOIN sala S ON CR.salaID = S.salaID
        ///INNER JOIN clase_persona CLP ON CR.claseID = CLP.claseID
        ///INNER JOIN persona P ON  CLP.personaID=P.personaID
        ///WHERE CL.disciplinaID in (
        ///SELECT disciplinaID FROM membresia_persona_disciplina WHERE personaID = &apos;1&apos; A [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string getClasesDisicplinaFecha {
            get {
                return ResourceManager.GetString("getClasesDisicplinaFecha", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT
        ///EV.eventoID AS EventoID,
        ///CL.nombre AS Clase,
        ///S.nombre AS Sala,
        ///nombres+SPACE(2)+apellidos AS NombreInstructor,
        ///CL.descripcion AS Descripcion,
        ///EV.fecha,
        ///HM.horaInicio,
        ///HM.horaFin,
        ///(SELECT COUNT(*) FROM evento_persona INNER JOIN persona P1 ON evento_persona.personaID=P1.personaID WHERE p1.rolePID=3)AS Asistentes,
        ///EV.aforoMax AS AforoMaximoClase,
        ///EV.aforoMin AS AforoMinimoClase,
        ///(SELECT COUNT(*) FROM evento_persona INNER JOIN persona P2 ON evento_persona.personaID=P2.personaID WHERE p2.perso [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string getEventoClasePersona {
            get {
                return ResourceManager.GetString("getEventoClasePersona", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT
        ///RE.nombre,
        ///RE.descripcion,
        ///CASE WHEN personaID = {0} /*Parametro*/ THEN &apos;RESERVADO&apos; WHEN personaID = &apos;&apos; THEN &apos;DISPONIBLE&apos; ELSE &apos;OCUPADO&apos; END AS reservado
        ///FROM evento_recursoEspecial ERE
        ///INNER JOIN recursoEspecial RE ON ERE.recursoEspecialID = RE.recursoEspecialID
        ///WHERE ERE.eventoID = {1}/*Parametro*/.
        /// </summary>
        internal static string getEventoRecursoEspecial {
            get {
                return ResourceManager.GetString("getEventoRecursoEspecial", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///ev.fecha,
        ///hm.horarioMID,
        ///ev.salaID
        ///FROM evento ev
        ///INNER JOIN horarioM hm ON hm.horarioMID = ev.horarioMID 
        ///WHERE 
        ///fecha &gt;= &apos;{0}&apos; and fecha &lt;= &apos;{1}&apos;.
        /// </summary>
        internal static string getHorariosFecha {
            get {
                return ResourceManager.GetString("getHorariosFecha", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT DISTINCT HM.horarioMID ,HM.horaInicio,HM.horaFin FROM clase CL
        ///INNER JOIN cronograma CR ON CR.cronogramaID = CL.cronogramaID
        ///INNER JOIN horarioM HM ON HM.horarioMID = CR.horarioMID
        ///WHERE CL.disciplinaID = &apos;&apos;.
        /// </summary>
        internal static string getHorasDisciplina {
            get {
                return ResourceManager.GetString("getHorasDisciplina", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to --CONSULTA CLASES DE DISCIPLINA EN UNA FECHA 
        ///SELECT 
        ///CR.cronogramaID AS CronoID,
        ///CL.nombre AS Clase,
        ///P.nombres AS Nombre,
        ///CL.descripcion AS Descripcion,
        ///CR.fecha,
        ///HM.horaInicio,
        ///HM.horaFin,
        ///(SELECT COUNT(*) FROM clase_persona INNER JOIN persona P1 ON  clase_persona.personaID=P1.personaID  WHERE p1.rolePID=3)AS Asistentes,
        ///(SELECT COUNT(*) FROM clase_persona INNER JOIN persona P2 ON  clase_persona.personaID=P2.personaID  WHERE p2.personaID={0})AS REG
        ///FROM cronograma CR
        ///INNER JOIN horarioM HM ON  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string getHorasFechaDisciplina {
            get {
                return ResourceManager.GetString("getHorasFechaDisciplina", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///D.disciplinaID,
        ///D.nombre as nombreDisciplina,
        ///M.precio,
        ///MPD.numClasesDisponibles,
        ///MPD.fechaPago,
        ///MPD.fechaLimite,
        ///M.nombre as nombreMembresia
        ///FROM membresia_persona_disciplina MPD
        ///INNER JOIN membresia M ON M.membresiaID = MPD.membresiaID 
        ///INNER JOIN disciplina D ON D.disciplinaID = MPD.disciplinaID
        ///WHERE MPD.personaID = {0}.
        /// </summary>
        internal static string getMembresiasUsuario {
            get {
                return ResourceManager.GetString("getMembresiasUsuario", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT m.nombre as nombreMembresia, 
        ///m.precio as precioMembresia,
        ///d.nombre as nombreDisciplina,
        ///MPD.fechaPago,
        ///MPD.fechaLimite,
        ///MPD.numClasesDisponibles
        ///FROM membresia_persona_disciplina MPD INNER JOIN membresia_disciplina MD 
        ///on MPD.membresia_disciplinaID = MD.membresia_disciplinaID
        ///INNER JOIN membresia M on MD.membresiaID = M.membresiaID 
        ///INNER JOIN disciplina D on MD.disciplinaID = D.disciplinaID
        ///WHERE MPD.personaID = {0}.
        /// </summary>
        internal static string getMembresiasUsuario2 {
            get {
                return ResourceManager.GetString("getMembresiasUsuario2", resourceCulture);
            }
        }
    }
}
