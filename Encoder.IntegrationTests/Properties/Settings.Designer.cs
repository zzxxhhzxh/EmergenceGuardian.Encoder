﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmergenceGuardian.Encoder.IntegrationTests.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\GitHub\\NaturalGroundingPlayer\\Encoder\\ffmpeg.exe")]
        public string FFmpegPath {
            get {
                return ((string)(this["FFmpegPath"]));
            }
            set {
                this["FFmpegPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\GitHub\\NaturalGroundingPlayer\\Encoder\\x264-10bit.exe")]
        public string X264Path {
            get {
                return ((string)(this["X264Path"]));
            }
            set {
                this["X264Path"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("E:\\AVSMeter\\x265.exe")]
        public string X265Path {
            get {
                return ((string)(this["X265Path"]));
            }
            set {
                this["X265Path"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\GitHub\\NaturalGroundingPlayer\\Encoder\\avs2pipemod.exe")]
        public string Avs2PipeMod {
            get {
                return ((string)(this["Avs2PipeMod"]));
            }
            set {
                this["Avs2PipeMod"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Program Files (x86)\\VapourSynth\\core32\\vspipe.exe")]
        public string VsPipePath {
            get {
                return ((string)(this["VsPipePath"]));
            }
            set {
                this["VsPipePath"] = value;
            }
        }
    }
}
