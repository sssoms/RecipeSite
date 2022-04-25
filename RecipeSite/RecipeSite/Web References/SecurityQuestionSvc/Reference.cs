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

namespace RecipeSite.SecurityQuestionSvc {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SecurityQuestionSoap", Namespace="http://tempuri.org/")]
    public partial class SecurityQuestion : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetSecurityQuestionsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetSecurityAnswerOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SecurityQuestion() {
            this.Url = global::RecipeSite.Properties.Settings.Default.RecipeSite_SecurityQuestionSvc_SecurityQuestion;
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
        public event GetSecurityQuestionsCompletedEventHandler GetSecurityQuestionsCompleted;
        
        /// <remarks/>
        public event GetSecurityAnswerCompletedEventHandler GetSecurityAnswerCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetSecurityQuestions", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetSecurityQuestions() {
            object[] results = this.Invoke("GetSecurityQuestions", new object[0]);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetSecurityQuestionsAsync() {
            this.GetSecurityQuestionsAsync(null);
        }
        
        /// <remarks/>
        public void GetSecurityQuestionsAsync(object userState) {
            if ((this.GetSecurityQuestionsOperationCompleted == null)) {
                this.GetSecurityQuestionsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSecurityQuestionsOperationCompleted);
            }
            this.InvokeAsync("GetSecurityQuestions", new object[0], this.GetSecurityQuestionsOperationCompleted, userState);
        }
        
        private void OnGetSecurityQuestionsOperationCompleted(object arg) {
            if ((this.GetSecurityQuestionsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSecurityQuestionsCompleted(this, new GetSecurityQuestionsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetSecurityAnswer", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetSecurityAnswer(int userID, int rndNum) {
            object[] results = this.Invoke("GetSecurityAnswer", new object[] {
                        userID,
                        rndNum});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetSecurityAnswerAsync(int userID, int rndNum) {
            this.GetSecurityAnswerAsync(userID, rndNum, null);
        }
        
        /// <remarks/>
        public void GetSecurityAnswerAsync(int userID, int rndNum, object userState) {
            if ((this.GetSecurityAnswerOperationCompleted == null)) {
                this.GetSecurityAnswerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSecurityAnswerOperationCompleted);
            }
            this.InvokeAsync("GetSecurityAnswer", new object[] {
                        userID,
                        rndNum}, this.GetSecurityAnswerOperationCompleted, userState);
        }
        
        private void OnGetSecurityAnswerOperationCompleted(object arg) {
            if ((this.GetSecurityAnswerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSecurityAnswerCompleted(this, new GetSecurityAnswerCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetSecurityQuestionsCompletedEventHandler(object sender, GetSecurityQuestionsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSecurityQuestionsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSecurityQuestionsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetSecurityAnswerCompletedEventHandler(object sender, GetSecurityAnswerCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSecurityAnswerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSecurityAnswerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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