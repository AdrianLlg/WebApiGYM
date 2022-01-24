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
        ///   Looks up a localized string similar to EXEC sp_fkeys &apos;{0}&apos;.
        /// </summary>
        internal static string get_FKRelationships {
            get {
                return ResourceManager.GetString("get FKRelationships", resourceCulture);
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
        ///e.eventoID,
        ///e.fecha,
        ///e.horarioMID,
        ///((SELECT STUFF( CAST(h.horaInicio AS varchar), 3, 0, &apos;:&apos;))+&apos; - &apos;+(SELECT STUFF( CAST(h.horaFin AS varchar), 3, 0, &apos;:&apos;)))as horario,
        ///e.claseID,
        ///c.nombre as nombreClase,      
        ///c.disciplinaID,
        ///d.nombre as nombreDisciplina,
        ///e.salaID,
        ///sl.nombre as nombreSala,
        ///e.aforoMax,
        ///e.aforoMin,
        ///e.personaID,
        ///e.estadoRegistro,
        ///h.horaInicio as horaInicioFormat,
        ///h.horaFin as horaFinFormat
        ///FROM evento e
        ///INNER JOIN clase c ON e.claseID=c.claseID
        ///INNER JOIN horarioM h ON [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string getClasesPendientesInstructor {
            get {
                return ResourceManager.GetString("getClasesPendientesInstructor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT
        ///c.disciplinaID,	
        ///c.claseID	,
        ///c.nombre AS Clase	,
        ///c.descripcion AS DescripcionClase,	
        ///d.nombre as Disciplina	,
        ///d.descripcion as DescripcionDisciplina	
        ///FROM clase c
        ///INNER JOIN disciplina d ON  C.disciplinaID=d.disciplinaID
        ///order by disciplinaID.
        /// </summary>
        internal static string getConsultaDisciplinasDeportistaApp {
            get {
                return ResourceManager.GetString("getConsultaDisciplinasDeportistaApp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT p.nombres,p.apellidos,p.email,c.nombre as clase ,evt.fecha,
        ///((SELECT STUFF( CAST(h.horaInicio AS varchar), 3, 0, &apos;:&apos;))+&apos; - &apos;+(SELECT STUFF( CAST(h.horaFin AS varchar), 3, 0, &apos;:&apos;)))
        ///as horario from evento_persona ep 
        ///inner join persona p on p.personaID=ep.personaID
        ///inner join evento evt on ep.eventoID=evt.eventoID
        ///inner join horarioM h on evt.horarioMID=h.horarioMID
        ///inner join clase c on evt.claseID=c.claseID
        ///where ep.eventoID=&apos;{0}&apos;.
        /// </summary>
        internal static string getConsultaMailCancelacionAlumnos {
            get {
                return ResourceManager.GetString("getConsultaMailCancelacionAlumnos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT p.nombres,p.apellidos,p.email,c.nombre as clase ,evt.fecha,
        ///((SELECT STUFF( CAST(h.horaInicio AS varchar), 3, 0, &apos;:&apos;))+&apos; - &apos;+(SELECT STUFF( CAST(h.horaFin AS varchar), 3, 0, &apos;:&apos;)))
        ///as horario from evento_profesor ep 
        ///inner join persona p on p.personaID=ep.personaID
        ///inner join evento evt on ep.eventoID=evt.eventoID
        ///inner join horarioM h on evt.horarioMID=h.horarioMID
        ///inner join clase c on evt.claseID=c.claseID
        ///where ep.eventoID=&apos;{0}&apos;.
        /// </summary>
        internal static string getConsultaMailCancelacionProfesor {
            get {
                return ResourceManager.GetString("getConsultaMailCancelacionProfesor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///ds.disciplinaID
        ///FROM disciplina ds
        ///INNER JOIN clase cl ON cl.disciplinaID = ds.disciplinaID
        ///INNER JOIN evento ev ON ev.claseID = cl.claseID
        ///INNER JOIN evento_persona ep ON ep.eventoID = ev.eventoID
        ///WHERE evento_personaID = {0}.
        /// </summary>
        internal static string getDisciplinaIDEventoPersona {
            get {
                return ResourceManager.GetString("getDisciplinaIDEventoPersona", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT p.nombres,p.apellidos,p.email,c.nombre as clase ,evt.fecha,
        ///((SELECT STUFF( CAST(h.horaInicio AS varchar), 3, 0, &apos;:&apos;))+&apos; - &apos;+(SELECT STUFF( CAST(h.horaFin AS varchar), 3, 0, &apos;:&apos;)))
        ///
        ///as horario from evento_persona ep 
        ///inner join persona p on p.personaID=ep.personaID
        ///inner join evento evt on ep.eventoID=evt.eventoID
        ///inner join horarioM h on evt.horarioMID=h.horarioMID
        ///inner join clase c on evt.claseID=c.claseID
        ///where ep.eventoID=&apos;{0}&apos;
        ///
        ///;.
        /// </summary>
        internal static string getEventMail {
            get {
                return ResourceManager.GetString("getEventMail", resourceCulture);
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
        ///   Looks up a localized string similar to SELECT nombre as Sala ,COUNT(*)as cantidadEventos FROM evento
        ///  INNER JOIN Sala ON evento.salaID=sala.salaID WHERE evento.fecha between &apos;{0}&apos; and &apos;{1}&apos;
        ///  GROUP BY nombre
        ///HAVING COUNT(*) &gt; 0.
        /// </summary>
        internal static string getEventoSala {
            get {
                return ResourceManager.GetString("getEventoSala", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT nombre as Disciplina ,COUNT(*)as CantidadEventos FROM evento
        ///  INNER JOIN clase ON evento.claseID=clase.claseID WHERE evento.fecha between &apos;{0}&apos; and &apos;{1}&apos;
        ///  GROUP BY nombre
        ///HAVING COUNT(*) &gt; 0.
        /// </summary>
        internal static string getEventosPorDisciplina {
            get {
                return ResourceManager.GetString("getEventosPorDisciplina", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT
        ///fp.fichaPersonaID,
        /// (p.nombres+SPACE(1)+p.apellidos)as Cliente,
        /// fp.PersonaID,
        /// fp.MesoTipo,
        /// fp.NivelActualActividadFisica,
        /// fp.AntecendesMedicos,
        /// fp.Alergias,
        /// fp.Enfermedades              
        ///  FROM fichaPersona fp
        ///  INNER JOIN persona p on fp.PersonaID=p.personaID
        ///  Where p.personaID=&apos;{0}&apos;.
        /// </summary>
        internal static string getFichaPersonaApp {
            get {
                return ResourceManager.GetString("getFichaPersonaApp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT
        ///fe.fichaEntrenamientoID,fe.FechaCreacion,fe.fichaPersonaID,(p.nombres+SPACE(1)+p.apellidos)as Profesor,ProfesorID,
        ///fe.DisciplinaID as DisciplinaID,(d.nombre)as Disciplina,fe.Peso,fe.Altura,fe.IndiceMasaMuscular,
        ///fe.IndiceGrasaCorporal,fe.MedicionBrazos,fe.MedicionPecho,
        ///fe.MedicionEspalda,fe.MedicionPiernas,fe.MedicionCintura,
        ///fe.MedicionCuello,fe.Observaciones
        ///  FROM fichaEntrenamiento fe
        ///  INNER JOIN fichaPersona fp ON fe.fichaPersonaID=fp.fichaPersonaID
        ///  INNER JOIN persona p on fe.Profeso [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string getFichasEntrenamientoPersona {
            get {
                return ResourceManager.GetString("getFichasEntrenamientoPersona", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///  (p.nombres+SPACE(1)+p.apellidos)as Cliente,
        ///  cl.nombre as Clase,
        ///  dsp.nombre as Disciplina,
        ///  (pro.nombres+SPACE(1)+pro.apellidos)as Profesor,
        ///  ((SELECT STUFF( CAST(hm.horaInicio AS varchar), 3, 0, &apos;:&apos;))+&apos; - &apos;+(SELECT STUFF( CAST(hm.horaFin AS varchar), 3, 0, &apos;:&apos;)))as Horario , 
        ///  evt.fecha as Fecha,
        ///  sl.nombre as Sala,
        ///  (SELECT CASE WHEN ep.asistencia = 1 THEN &apos;Si&apos; ELSE &apos;No&apos; END ) as Asistencia,
        ///  ep.estadoRegistro as Estado
        ///  FROM evento evt
        ///  INNER JOIN evento_persona  ep ON evt [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string getHistorialAsistenciaClienteApp {
            get {
                return ResourceManager.GetString("getHistorialAsistenciaClienteApp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///ev.fecha,
        ///hm.horarioMID,
        ///ev.salaID,
        ///ev.personaID
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
        ///    ep.evento_personaID as eventoPersonaID,
        ///	ep.personaID,
        ///	ep.asistencia,
        ///    (p.nombres+SPACE(1)+p.apellidos)as nombre,
        ///	p.identificacion	
        ///	FROM evento_persona ep
        ///	INNER JOIN evento e ON e.eventoID=ep.eventoID 
        ///	INNER JOIN persona p ON p.personaID=ep.personaID 
        ///	WHERE e.eventoID=&apos;{0}&apos; AND e.estadoRegistro=&apos;A&apos; AND ep.estadoRegistro=&apos;A&apos;.
        /// </summary>
        internal static string getListaAsistenciaApp {
            get {
                return ResourceManager.GetString("getListaAsistenciaApp", resourceCulture);
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
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT* FROM noticia nt
        ///  where nt.fechaInicio&lt;=Convert(date, getdate()) and nt.fechaFin&gt;=Convert(date, getdate()) and nt.estadoRegistro=&apos;A&apos;.
        /// </summary>
        internal static string getNoticiasApp {
            get {
                return ResourceManager.GetString("getNoticiasApp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT u.usuarioID,p.personaID,rolePID,nombres,apellidos,identificacion,u.email,u.password,telefono,edad,sexo,fechaNacimiento,fechaCreacion,estado
        ///  FROM persona p
        ///  INNER JOIN usuario u ON p.personaID=u.personaID
        ///  WHERE p.personaID=&apos;{0}&apos;.
        /// </summary>
        internal static string getPerfil {
            get {
                return ResourceManager.GetString("getPerfil", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT estado as Estado,Count(*)as Cantidad
        ///FROM persona 
        ///GROUP BY estado
        ///HAVING COUNT(*) &gt; 0.
        /// </summary>
        internal static string getPersonasEstado {
            get {
                return ResourceManager.GetString("getPersonasEstado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///  (p.nombres+SPACE(1)+p.apellidos)as Persona,
        ///  cl.nombre as Clase,
        ///  dsp.nombre as Disciplina,
        ///  evt.fecha as Fecha,
        ///  (SELECT CASE WHEN ep.asistencia = 1 THEN &apos;Si&apos; ELSE &apos;No&apos; END ) as Asistencia
        ///  FROM evento evt
        ///  INNER JOIN evento_persona  ep ON evt.eventoID=ep.eventoID 
        ///  INNER JOIN persona p ON  ep.personaID=p.personaID
        ///  INNER JOIN clase cl ON evt.claseID=cl.claseID 
        ///  INNER JOIN disciplina dsp ON cl.disciplinaID=dsp.disciplinaID
        ///  Where p.personaID=&apos;{0}&apos; and evt.fecha&gt;=&apos;{1}&apos; and ev [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string getReporteAsistenciaLog {
            get {
                return ResourceManager.GetString("getReporteAsistenciaLog", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///  (p.nombres+SPACE(1)+p.apellidos)as Persona,
        ///  cl.nombre as Clase,
        ///  dsp.nombre as Disciplina,
        ///  evt.fecha as Fecha,
        ///  (SELECT CASE WHEN ep.asistencia = 1 THEN &apos;Si&apos; ELSE &apos;No&apos; END ) as Asistencia
        ///  FROM evento evt
        ///  INNER JOIN evento_profesor ep ON evt.eventoID=ep.eventoID 
        ///  INNER JOIN persona p ON  ep.personaID=p.personaID
        ///  INNER JOIN clase cl ON evt.claseID=cl.claseID 
        ///  INNER JOIN disciplina dsp ON cl.disciplinaID=dsp.disciplinaID
        ///  Where p.personaID=&apos;{0}&apos; and evt.fecha&gt;=&apos;{1}&apos; and ev [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string getReporteAsistenciaLogProf {
            get {
                return ResourceManager.GetString("getReporteAsistenciaLogProf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///  dsp.nombre as Disciplina,
        ///   COUNT(*)as ClasesAsistidas
        ///  FROM evento evt
        ///  INNER JOIN evento_persona  ep ON evt.eventoID=ep.eventoID 
        ///  INNER JOIN persona p ON  ep.personaID=p.personaID
        ///  INNER JOIN clase cl ON evt.claseID=cl.claseID 
        ///  INNER JOIN disciplina dsp ON cl.disciplinaID=dsp.disciplinaID
        ///  Where p.personaID=&apos;{0}&apos; and evt.fecha&gt;=&apos;{1}&apos; and evt.fecha&lt;=&apos;{2}&apos; and ep.asistencia=1
        ///  GROUP BY dsp.nombre,ep.asistencia
        ///  HAVING COUNT(*) &gt; 0 
        ///  
        ///  .
        /// </summary>
        internal static string getReporteGeneralAsistenciaCA {
            get {
                return ResourceManager.GetString("getReporteGeneralAsistenciaCA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///  dsp.nombre as Disciplina,
        ///   COUNT(*)as ClasesAsistidas
        ///  FROM evento evt
        ///  INNER JOIN evento_profesor  ep ON evt.eventoID=ep.eventoID 
        ///  INNER JOIN persona p ON  ep.personaID=p.personaID
        ///  INNER JOIN clase cl ON evt.claseID=cl.claseID 
        ///  INNER JOIN disciplina dsp ON cl.disciplinaID=dsp.disciplinaID
        ///  Where p.personaID=&apos;{0}&apos; and evt.fecha&gt;=&apos;{1}&apos; and evt.fecha&lt;=&apos;{2}&apos; and ep.asistencia=1
        ///  GROUP BY dsp.nombre,ep.asistencia
        ///  HAVING COUNT(*) &gt; 0.
        /// </summary>
        internal static string getReporteGeneralAsistenciaCAProf {
            get {
                return ResourceManager.GetString("getReporteGeneralAsistenciaCAProf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///  dsp.nombre as Disciplina,
        ///   COUNT(*)as ClasesNoAsistidas
        ///  FROM evento evt
        ///  INNER JOIN evento_persona  ep ON evt.eventoID=ep.eventoID 
        ///  INNER JOIN persona p ON  ep.personaID=p.personaID
        ///  INNER JOIN clase cl ON evt.claseID=cl.claseID 
        ///  INNER JOIN disciplina dsp ON cl.disciplinaID=dsp.disciplinaID
        ///  Where p.personaID=&apos;{0}&apos; and evt.fecha&gt;=&apos;{1}&apos; and evt.fecha&lt;=&apos;{2}&apos; and ep.asistencia=0
        ///  GROUP BY dsp.nombre,ep.asistencia
        ///  HAVING COUNT(*) &gt; 0.
        /// </summary>
        internal static string getReporteGeneralAsistenciaCNA {
            get {
                return ResourceManager.GetString("getReporteGeneralAsistenciaCNA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///  dsp.nombre as Disciplina,
        ///   COUNT(*)as ClasesNoAsistidas
        ///  FROM evento evt
        ///  INNER JOIN evento_profesor  ep ON evt.eventoID=ep.eventoID 
        ///  INNER JOIN persona p ON  ep.personaID=p.personaID
        ///  INNER JOIN clase cl ON evt.claseID=cl.claseID 
        ///  INNER JOIN disciplina dsp ON cl.disciplinaID=dsp.disciplinaID
        ///  Where p.personaID=&apos;{0}&apos; and evt.fecha&gt;=&apos;{1}&apos; and evt.fecha&lt;=&apos;{2}&apos; and ep.asistencia=0
        ///  GROUP BY dsp.nombre,ep.asistencia
        ///  HAVING COUNT(*) &gt; 0.
        /// </summary>
        internal static string getReporteGeneralAsistenciaCNAProf {
            get {
                return ResourceManager.GetString("getReporteGeneralAsistenciaCNAProf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT Mes , Anio,COUNT(*) as Transacciones  FROM (SELECT (DATENAME(month,fechaTransaccion)) AS Mes,(YEAR(fechaTransaccion)) AS Anio FROM membresia_persona_pago as MPP WHERE YEAR(MPP.fechaTransaccion) = {0} AND MPP.estado=&apos;A&apos;)AS TABLA
        ///group by Mes,Anio
        ///HAVING count(*) &gt;0.
        /// </summary>
        internal static string getTransaccionesAnuales {
            get {
                return ResourceManager.GetString("getTransaccionesAnuales", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT nombre as Membresia,(precio*Cantidad)AS TotalVentas FROM(
        ///  SELECT membresia.nombre ,membresia.precio ,COUNT(*)as Cantidad from membresia_persona_pago
        ///  INNER JOIN membresia ON membresia_persona_pago.membresiaID=membresia.membresiaID
        ///  WHERE fechaTransaccion &gt;= &apos;{0}&apos; AND fechaTransaccion&lt;= &apos;{1}&apos;
        ///  GROUP BY membresia.nombre,membresia.precio
        ///  HAVING COUNT(*)&gt;0)as S1.
        /// </summary>
        internal static string getVentasMembresias {
            get {
                return ResourceManager.GetString("getVentasMembresias", resourceCulture);
            }
        }
    }
}
