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
    internal class ScripCreacionGYMDB {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ScripCreacionGYMDB() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WebAPIBusiness.Resources.ScripCreacionGYMDB", typeof(ScripCreacionGYMDB).Assembly);
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
        ///   Looks up a localized string similar to --CREATE DATABASE GYMDB
        ///USE GYMDB
        ///GO
        ///IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = &apos;configuraciones_Sistema &apos;) DROP TABLE configuraciones_Sistema ;
        ///IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = &apos;noticia &apos;) DROP TABLE noticia ;
        ///IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = &apos;membresia_persona_disciplina &apos;) DROP TABLE membresia_persona_disciplina ;
        ///IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = &apos;evento_recurso&apos; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Creacion_2_0 {
            get {
                return ResourceManager.GetString("Creacion 2.0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to USE [master]
        ///GO
        ////****** Object:  Database [GYMDB]    Script Date: 28/09/2021 23:28:08 ******/
        ///CREATE DATABASE [GYMDB]
        /// CONTAINMENT = NONE
        /// ON  PRIMARY 
        ///( NAME = N&apos;GYMDB&apos;, FILENAME = N&apos;C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GYMDB.mdf&apos; , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
        /// LOG ON 
        ///( NAME = N&apos;GYMDB_log&apos;, FILENAME = N&apos;C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GYMDB_log.ldf&apos; , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Script {
            get {
                return ResourceManager.GetString("Script", resourceCulture);
            }
        }
    }
}
