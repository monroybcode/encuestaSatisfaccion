﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EncuestaSatisfaccion.Vlg {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LoginViewModel", Namespace="http://schemas.datacontract.org/2004/07/SistemaDeSesionUnico.Models")]
    [System.SerializableAttribute()]
    public partial class LoginViewModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NipField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordNuevoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordNuevoConfirmadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool RememberMeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nip {
            get {
                return this.NipField;
            }
            set {
                if ((object.ReferenceEquals(this.NipField, value) != true)) {
                    this.NipField = value;
                    this.RaisePropertyChanged("Nip");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PasswordNuevo {
            get {
                return this.PasswordNuevoField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordNuevoField, value) != true)) {
                    this.PasswordNuevoField = value;
                    this.RaisePropertyChanged("PasswordNuevo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PasswordNuevoConfirmado {
            get {
                return this.PasswordNuevoConfirmadoField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordNuevoConfirmadoField, value) != true)) {
                    this.PasswordNuevoConfirmadoField = value;
                    this.RaisePropertyChanged("PasswordNuevoConfirmado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool RememberMe {
            get {
                return this.RememberMeField;
            }
            set {
                if ((this.RememberMeField.Equals(value) != true)) {
                    this.RememberMeField = value;
                    this.RaisePropertyChanged("RememberMe");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ForgotPasswordViewModel", Namespace="http://schemas.datacontract.org/2004/07/SistemaDeSesionUnico.Models")]
    [System.SerializableAttribute()]
    public partial class ForgotPasswordViewModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Vlg.IValidaLogIn")]
    public interface IValidaLogIn {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidaLogIn/LogIn", ReplyAction="http://tempuri.org/IValidaLogIn/LogInResponse")]
        string[] LogIn(EncuestaSatisfaccion.Vlg.LoginViewModel model, string Sis);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidaLogIn/LogIn", ReplyAction="http://tempuri.org/IValidaLogIn/LogInResponse")]
        System.Threading.Tasks.Task<string[]> LogInAsync(EncuestaSatisfaccion.Vlg.LoginViewModel model, string Sis);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidaLogIn/VerificaUsuario", ReplyAction="http://tempuri.org/IValidaLogIn/VerificaUsuarioResponse")]
        string[] VerificaUsuario(string usr, string Sis);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidaLogIn/VerificaUsuario", ReplyAction="http://tempuri.org/IValidaLogIn/VerificaUsuarioResponse")]
        System.Threading.Tasks.Task<string[]> VerificaUsuarioAsync(string usr, string Sis);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidaLogIn/RecuperaContraseña", ReplyAction="http://tempuri.org/IValidaLogIn/RecuperaContraseñaResponse")]
        string RecuperaContraseña(EncuestaSatisfaccion.Vlg.ForgotPasswordViewModel model, string Sis);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidaLogIn/RecuperaContraseña", ReplyAction="http://tempuri.org/IValidaLogIn/RecuperaContraseñaResponse")]
        System.Threading.Tasks.Task<string> RecuperaContraseñaAsync(EncuestaSatisfaccion.Vlg.ForgotPasswordViewModel model, string Sis);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidaLogIn/GuardarContraseniaNueva", ReplyAction="http://tempuri.org/IValidaLogIn/GuardarContraseniaNuevaResponse")]
        string[] GuardarContraseniaNueva(string login, string newPass, string confPass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidaLogIn/GuardarContraseniaNueva", ReplyAction="http://tempuri.org/IValidaLogIn/GuardarContraseniaNuevaResponse")]
        System.Threading.Tasks.Task<string[]> GuardarContraseniaNuevaAsync(string login, string newPass, string confPass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidaLogIn/LogInPHP", ReplyAction="http://tempuri.org/IValidaLogIn/LogInPHPResponse")]
        string[] LogInPHP(string UserName, string Password, string PasswordNuevo, string PasswordNuevoConfirmado, bool RememberMe, string Nip, string Sis);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidaLogIn/LogInPHP", ReplyAction="http://tempuri.org/IValidaLogIn/LogInPHPResponse")]
        System.Threading.Tasks.Task<string[]> LogInPHPAsync(string UserName, string Password, string PasswordNuevo, string PasswordNuevoConfirmado, bool RememberMe, string Nip, string Sis);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IValidaLogInChannel : EncuestaSatisfaccion.Vlg.IValidaLogIn, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ValidaLogInClient : System.ServiceModel.ClientBase<EncuestaSatisfaccion.Vlg.IValidaLogIn>, EncuestaSatisfaccion.Vlg.IValidaLogIn {
        
        public ValidaLogInClient() {
        }
        
        public ValidaLogInClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ValidaLogInClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ValidaLogInClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ValidaLogInClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] LogIn(EncuestaSatisfaccion.Vlg.LoginViewModel model, string Sis) {
            return base.Channel.LogIn(model, Sis);
        }
        
        public System.Threading.Tasks.Task<string[]> LogInAsync(EncuestaSatisfaccion.Vlg.LoginViewModel model, string Sis) {
            return base.Channel.LogInAsync(model, Sis);
        }
        
        public string[] VerificaUsuario(string usr, string Sis) {
            return base.Channel.VerificaUsuario(usr, Sis);
        }
        
        public System.Threading.Tasks.Task<string[]> VerificaUsuarioAsync(string usr, string Sis) {
            return base.Channel.VerificaUsuarioAsync(usr, Sis);
        }
        
        public string RecuperaContraseña(EncuestaSatisfaccion.Vlg.ForgotPasswordViewModel model, string Sis) {
            return base.Channel.RecuperaContraseña(model, Sis);
        }
        
        public System.Threading.Tasks.Task<string> RecuperaContraseñaAsync(EncuestaSatisfaccion.Vlg.ForgotPasswordViewModel model, string Sis) {
            return base.Channel.RecuperaContraseñaAsync(model, Sis);
        }
        
        public string[] GuardarContraseniaNueva(string login, string newPass, string confPass) {
            return base.Channel.GuardarContraseniaNueva(login, newPass, confPass);
        }
        
        public System.Threading.Tasks.Task<string[]> GuardarContraseniaNuevaAsync(string login, string newPass, string confPass) {
            return base.Channel.GuardarContraseniaNuevaAsync(login, newPass, confPass);
        }
        
        public string[] LogInPHP(string UserName, string Password, string PasswordNuevo, string PasswordNuevoConfirmado, bool RememberMe, string Nip, string Sis) {
            return base.Channel.LogInPHP(UserName, Password, PasswordNuevo, PasswordNuevoConfirmado, RememberMe, Nip, Sis);
        }
        
        public System.Threading.Tasks.Task<string[]> LogInPHPAsync(string UserName, string Password, string PasswordNuevo, string PasswordNuevoConfirmado, bool RememberMe, string Nip, string Sis) {
            return base.Channel.LogInPHPAsync(UserName, Password, PasswordNuevo, PasswordNuevoConfirmado, RememberMe, Nip, Sis);
        }
    }
}