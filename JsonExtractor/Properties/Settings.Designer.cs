﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JsonExtractor.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("oledbConn")]
        public string OleDbConnStr {
            get {
                return ((string)(this["OleDbConnStr"]));
            }
            set {
                this["OleDbConnStr"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("oledbquery")]
        public string OleDbQuery {
            get {
                return ((string)(this["OleDbQuery"]));
            }
            set {
                this["OleDbQuery"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool lcasePropNames {
            get {
                return ((bool)(this["lcasePropNames"]));
            }
            set {
                this["lcasePropNames"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LastUsedProvider {
            get {
                return ((string)(this["LastUsedProvider"]));
            }
            set {
                this["LastUsedProvider"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("odbcconn")]
        public string OdbcConnStr {
            get {
                return ((string)(this["OdbcConnStr"]));
            }
            set {
                this["OdbcConnStr"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("odbcquery")]
        public string OdbcQuery {
            get {
                return ((string)(this["OdbcQuery"]));
            }
            set {
                this["OdbcQuery"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sqlconn")]
        public string SqlConnStr {
            get {
                return ((string)(this["SqlConnStr"]));
            }
            set {
                this["SqlConnStr"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sqlquery")]
        public string SqlQuery {
            get {
                return ((string)(this["SqlQuery"]));
            }
            set {
                this["SqlQuery"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("csvFileName")]
        public string CSVFileName {
            get {
                return ((string)(this["CSVFileName"]));
            }
            set {
                this["CSVFileName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("OleDbConnection;OdbcConnection;SqlConnection;Comma-separated values")]
        public string providers {
            get {
                return ((string)(this["providers"]));
            }
            set {
                this["providers"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool proptyNamesInQuotes {
            get {
                return ((bool)(this["proptyNamesInQuotes"]));
            }
            set {
                this["proptyNamesInQuotes"] = value;
            }
        }
    }
}
