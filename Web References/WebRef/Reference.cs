﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace OshoPortal.WebRef {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="PortalLogin_Binding", Namespace="urn:microsoft-dynamics-schemas/codeunit/PortalLogin")]
    public partial class PortalLogin : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ChangeEmployeePasswordOperationCompleted;
        
        private System.Threading.SendOrPostCallback ConfirmEmployeePasswordOperationCompleted;
        
        private System.Threading.SendOrPostCallback RecoverLostPasswordOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public PortalLogin() {
            this.Url = global::OshoPortal.Properties.Settings.Default.OshoPortal_WebRef_PortalLogin;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ChangeEmployeePasswordCompletedEventHandler ChangeEmployeePasswordCompleted;
        
        /// <remarks/>
        public event ConfirmEmployeePasswordCompletedEventHandler ConfirmEmployeePasswordCompleted;
        
        /// <remarks/>
        public event RecoverLostPasswordCompletedEventHandler RecoverLostPasswordCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/PortalLogin:ChangeEmployeePassword", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/PortalLogin", ResponseElementName="ChangeEmployeePassword_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/PortalLogin", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public string ChangeEmployeePassword(string employeeNo, string oldPassword, string newPassword) {
            object[] results = this.Invoke("ChangeEmployeePassword", new object[] {
                        employeeNo,
                        oldPassword,
                        newPassword});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ChangeEmployeePasswordAsync(string employeeNo, string oldPassword, string newPassword) {
            this.ChangeEmployeePasswordAsync(employeeNo, oldPassword, newPassword, null);
        }
        
        /// <remarks/>
        public void ChangeEmployeePasswordAsync(string employeeNo, string oldPassword, string newPassword, object userState) {
            if ((this.ChangeEmployeePasswordOperationCompleted == null)) {
                this.ChangeEmployeePasswordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnChangeEmployeePasswordOperationCompleted);
            }
            this.InvokeAsync("ChangeEmployeePassword", new object[] {
                        employeeNo,
                        oldPassword,
                        newPassword}, this.ChangeEmployeePasswordOperationCompleted, userState);
        }
        
        private void OnChangeEmployeePasswordOperationCompleted(object arg) {
            if ((this.ChangeEmployeePasswordCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ChangeEmployeePasswordCompleted(this, new ChangeEmployeePasswordCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/PortalLogin:ConfirmEmployeePassword", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/PortalLogin", ResponseElementName="ConfirmEmployeePassword_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/PortalLogin", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public string ConfirmEmployeePassword(string employeeNo, string password) {
            object[] results = this.Invoke("ConfirmEmployeePassword", new object[] {
                        employeeNo,
                        password});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ConfirmEmployeePasswordAsync(string employeeNo, string password) {
            this.ConfirmEmployeePasswordAsync(employeeNo, password, null);
        }
        
        /// <remarks/>
        public void ConfirmEmployeePasswordAsync(string employeeNo, string password, object userState) {
            if ((this.ConfirmEmployeePasswordOperationCompleted == null)) {
                this.ConfirmEmployeePasswordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConfirmEmployeePasswordOperationCompleted);
            }
            this.InvokeAsync("ConfirmEmployeePassword", new object[] {
                        employeeNo,
                        password}, this.ConfirmEmployeePasswordOperationCompleted, userState);
        }
        
        private void OnConfirmEmployeePasswordOperationCompleted(object arg) {
            if ((this.ConfirmEmployeePasswordCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConfirmEmployeePasswordCompleted(this, new ConfirmEmployeePasswordCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/PortalLogin:RecoverLostPassword", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/PortalLogin", ResponseElementName="RecoverLostPassword_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/PortalLogin", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public string RecoverLostPassword(string employeeNo) {
            object[] results = this.Invoke("RecoverLostPassword", new object[] {
                        employeeNo});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RecoverLostPasswordAsync(string employeeNo) {
            this.RecoverLostPasswordAsync(employeeNo, null);
        }
        
        /// <remarks/>
        public void RecoverLostPasswordAsync(string employeeNo, object userState) {
            if ((this.RecoverLostPasswordOperationCompleted == null)) {
                this.RecoverLostPasswordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRecoverLostPasswordOperationCompleted);
            }
            this.InvokeAsync("RecoverLostPassword", new object[] {
                        employeeNo}, this.RecoverLostPasswordOperationCompleted, userState);
        }
        
        private void OnRecoverLostPasswordOperationCompleted(object arg) {
            if ((this.RecoverLostPasswordCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RecoverLostPasswordCompleted(this, new RecoverLostPasswordCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void ChangeEmployeePasswordCompletedEventHandler(object sender, ChangeEmployeePasswordCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ChangeEmployeePasswordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ChangeEmployeePasswordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void ConfirmEmployeePasswordCompletedEventHandler(object sender, ConfirmEmployeePasswordCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConfirmEmployeePasswordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConfirmEmployeePasswordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void RecoverLostPasswordCompletedEventHandler(object sender, RecoverLostPasswordCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RecoverLostPasswordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RecoverLostPasswordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591