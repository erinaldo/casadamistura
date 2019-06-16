﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.34209.
// 
#pragma warning disable 1591

namespace PdvStock.br.gov.butatan.servicoemail {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="EnviarEmailSoap", Namespace="http://tempuri.org/")]
    public partial class EnviarEmail : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SendEmailOperationCompleted;
        
        private System.Threading.SendOrPostCallback SimplesOperationCompleted;
        
        private System.Threading.SendOrPostCallback SimplesAnexoOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendOneEmailOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendOneEmailAnexosOperationCompleted;
        
        private System.Threading.SendOrPostCallback EnviarAnexoOperationCompleted;
        
        private System.Threading.SendOrPostCallback EnviarOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public EnviarEmail() {
            this.Url = global::PdvStock.Properties.Settings.Default.PdvStock_butantan_servico_enviaremail_EnviarEmail;
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
        public event SendEmailCompletedEventHandler SendEmailCompleted;
        
        /// <remarks/>
        public event SimplesCompletedEventHandler SimplesCompleted;
        
        /// <remarks/>
        public event SimplesAnexoCompletedEventHandler SimplesAnexoCompleted;
        
        /// <remarks/>
        public event SendOneEmailCompletedEventHandler SendOneEmailCompleted;
        
        /// <remarks/>
        public event SendOneEmailAnexosCompletedEventHandler SendOneEmailAnexosCompleted;
        
        /// <remarks/>
        public event EnviarAnexoCompletedEventHandler EnviarAnexoCompleted;
        
        /// <remarks/>
        public event EnviarCompletedEventHandler EnviarCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendEmail", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public EmailObj SendEmail(EmailObj emailObj) {
            object[] results = this.Invoke("SendEmail", new object[] {
                        emailObj});
            return ((EmailObj)(results[0]));
        }
        
        /// <remarks/>
        public void SendEmailAsync(EmailObj emailObj) {
            this.SendEmailAsync(emailObj, null);
        }
        
        /// <remarks/>
        public void SendEmailAsync(EmailObj emailObj, object userState) {
            if ((this.SendEmailOperationCompleted == null)) {
                this.SendEmailOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendEmailOperationCompleted);
            }
            this.InvokeAsync("SendEmail", new object[] {
                        emailObj}, this.SendEmailOperationCompleted, userState);
        }
        
        private void OnSendEmailOperationCompleted(object arg) {
            if ((this.SendEmailCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendEmailCompleted(this, new SendEmailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Simples", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public EmailObj Simples(string Para, string ReplyTo, string Assunto, string NomeSistema, string Body) {
            object[] results = this.Invoke("Simples", new object[] {
                        Para,
                        ReplyTo,
                        Assunto,
                        NomeSistema,
                        Body});
            return ((EmailObj)(results[0]));
        }
        
        /// <remarks/>
        public void SimplesAsync(string Para, string ReplyTo, string Assunto, string NomeSistema, string Body) {
            this.SimplesAsync(Para, ReplyTo, Assunto, NomeSistema, Body, null);
        }
        
        /// <remarks/>
        public void SimplesAsync(string Para, string ReplyTo, string Assunto, string NomeSistema, string Body, object userState) {
            if ((this.SimplesOperationCompleted == null)) {
                this.SimplesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSimplesOperationCompleted);
            }
            this.InvokeAsync("Simples", new object[] {
                        Para,
                        ReplyTo,
                        Assunto,
                        NomeSistema,
                        Body}, this.SimplesOperationCompleted, userState);
        }
        
        private void OnSimplesOperationCompleted(object arg) {
            if ((this.SimplesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SimplesCompleted(this, new SimplesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SimplesAnexo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public EmailObj SimplesAnexo(string Para, string ReplyTo, string Assunto, string NomeSistema, string Body, string Base64Anexo, string NomeArquivo, string MediaType) {
            object[] results = this.Invoke("SimplesAnexo", new object[] {
                        Para,
                        ReplyTo,
                        Assunto,
                        NomeSistema,
                        Body,
                        Base64Anexo,
                        NomeArquivo,
                        MediaType});
            return ((EmailObj)(results[0]));
        }
        
        /// <remarks/>
        public void SimplesAnexoAsync(string Para, string ReplyTo, string Assunto, string NomeSistema, string Body, string Base64Anexo, string NomeArquivo, string MediaType) {
            this.SimplesAnexoAsync(Para, ReplyTo, Assunto, NomeSistema, Body, Base64Anexo, NomeArquivo, MediaType, null);
        }
        
        /// <remarks/>
        public void SimplesAnexoAsync(string Para, string ReplyTo, string Assunto, string NomeSistema, string Body, string Base64Anexo, string NomeArquivo, string MediaType, object userState) {
            if ((this.SimplesAnexoOperationCompleted == null)) {
                this.SimplesAnexoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSimplesAnexoOperationCompleted);
            }
            this.InvokeAsync("SimplesAnexo", new object[] {
                        Para,
                        ReplyTo,
                        Assunto,
                        NomeSistema,
                        Body,
                        Base64Anexo,
                        NomeArquivo,
                        MediaType}, this.SimplesAnexoOperationCompleted, userState);
        }
        
        private void OnSimplesAnexoOperationCompleted(object arg) {
            if ((this.SimplesAnexoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SimplesAnexoCompleted(this, new SimplesAnexoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendOneEmail", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public EmailObj SendOneEmail(string Para, string ReplyTo, string Assunto, string NomeSistema, string Body, string PathAnexo) {
            object[] results = this.Invoke("SendOneEmail", new object[] {
                        Para,
                        ReplyTo,
                        Assunto,
                        NomeSistema,
                        Body,
                        PathAnexo});
            return ((EmailObj)(results[0]));
        }
        
        /// <remarks/>
        public void SendOneEmailAsync(string Para, string ReplyTo, string Assunto, string NomeSistema, string Body, string PathAnexo) {
            this.SendOneEmailAsync(Para, ReplyTo, Assunto, NomeSistema, Body, PathAnexo, null);
        }
        
        /// <remarks/>
        public void SendOneEmailAsync(string Para, string ReplyTo, string Assunto, string NomeSistema, string Body, string PathAnexo, object userState) {
            if ((this.SendOneEmailOperationCompleted == null)) {
                this.SendOneEmailOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendOneEmailOperationCompleted);
            }
            this.InvokeAsync("SendOneEmail", new object[] {
                        Para,
                        ReplyTo,
                        Assunto,
                        NomeSistema,
                        Body,
                        PathAnexo}, this.SendOneEmailOperationCompleted, userState);
        }
        
        private void OnSendOneEmailOperationCompleted(object arg) {
            if ((this.SendOneEmailCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendOneEmailCompleted(this, new SendOneEmailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendOneEmailAnexos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public EmailObj SendOneEmailAnexos(string Para, string ReplyTo, string Assunto, string NomeSistema, string Body, string[] Base64Anexo, string[] NomeArquivo, string[] MimeType) {
            object[] results = this.Invoke("SendOneEmailAnexos", new object[] {
                        Para,
                        ReplyTo,
                        Assunto,
                        NomeSistema,
                        Body,
                        Base64Anexo,
                        NomeArquivo,
                        MimeType});
            return ((EmailObj)(results[0]));
        }
        
        /// <remarks/>
        public void SendOneEmailAnexosAsync(string Para, string ReplyTo, string Assunto, string NomeSistema, string Body, string[] Base64Anexo, string[] NomeArquivo, string[] MimeType) {
            this.SendOneEmailAnexosAsync(Para, ReplyTo, Assunto, NomeSistema, Body, Base64Anexo, NomeArquivo, MimeType, null);
        }
        
        /// <remarks/>
        public void SendOneEmailAnexosAsync(string Para, string ReplyTo, string Assunto, string NomeSistema, string Body, string[] Base64Anexo, string[] NomeArquivo, string[] MimeType, object userState) {
            if ((this.SendOneEmailAnexosOperationCompleted == null)) {
                this.SendOneEmailAnexosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendOneEmailAnexosOperationCompleted);
            }
            this.InvokeAsync("SendOneEmailAnexos", new object[] {
                        Para,
                        ReplyTo,
                        Assunto,
                        NomeSistema,
                        Body,
                        Base64Anexo,
                        NomeArquivo,
                        MimeType}, this.SendOneEmailAnexosOperationCompleted, userState);
        }
        
        private void OnSendOneEmailAnexosOperationCompleted(object arg) {
            if ((this.SendOneEmailAnexosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendOneEmailAnexosCompleted(this, new SendOneEmailAnexosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/EnviarAnexo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public EmailObj EnviarAnexo(string[] Para, string[] ReplyTo, string Assunto, string NomeSistema, string Body, string[] Base64Anexo, string[] NomeArquivo, string[] MimeType) {
            object[] results = this.Invoke("EnviarAnexo", new object[] {
                        Para,
                        ReplyTo,
                        Assunto,
                        NomeSistema,
                        Body,
                        Base64Anexo,
                        NomeArquivo,
                        MimeType});
            return ((EmailObj)(results[0]));
        }
        
        /// <remarks/>
        public void EnviarAnexoAsync(string[] Para, string[] ReplyTo, string Assunto, string NomeSistema, string Body, string[] Base64Anexo, string[] NomeArquivo, string[] MimeType) {
            this.EnviarAnexoAsync(Para, ReplyTo, Assunto, NomeSistema, Body, Base64Anexo, NomeArquivo, MimeType, null);
        }
        
        /// <remarks/>
        public void EnviarAnexoAsync(string[] Para, string[] ReplyTo, string Assunto, string NomeSistema, string Body, string[] Base64Anexo, string[] NomeArquivo, string[] MimeType, object userState) {
            if ((this.EnviarAnexoOperationCompleted == null)) {
                this.EnviarAnexoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEnviarAnexoOperationCompleted);
            }
            this.InvokeAsync("EnviarAnexo", new object[] {
                        Para,
                        ReplyTo,
                        Assunto,
                        NomeSistema,
                        Body,
                        Base64Anexo,
                        NomeArquivo,
                        MimeType}, this.EnviarAnexoOperationCompleted, userState);
        }
        
        private void OnEnviarAnexoOperationCompleted(object arg) {
            if ((this.EnviarAnexoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EnviarAnexoCompleted(this, new EnviarAnexoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Enviar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public EmailObj Enviar(string[] Para, string[] ReplyTo, string Assunto, string NomeSistema, string Body) {
            object[] results = this.Invoke("Enviar", new object[] {
                        Para,
                        ReplyTo,
                        Assunto,
                        NomeSistema,
                        Body});
            return ((EmailObj)(results[0]));
        }
        
        /// <remarks/>
        public void EnviarAsync(string[] Para, string[] ReplyTo, string Assunto, string NomeSistema, string Body) {
            this.EnviarAsync(Para, ReplyTo, Assunto, NomeSistema, Body, null);
        }
        
        /// <remarks/>
        public void EnviarAsync(string[] Para, string[] ReplyTo, string Assunto, string NomeSistema, string Body, object userState) {
            if ((this.EnviarOperationCompleted == null)) {
                this.EnviarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEnviarOperationCompleted);
            }
            this.InvokeAsync("Enviar", new object[] {
                        Para,
                        ReplyTo,
                        Assunto,
                        NomeSistema,
                        Body}, this.EnviarOperationCompleted, userState);
        }
        
        private void OnEnviarOperationCompleted(object arg) {
            if ((this.EnviarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EnviarCompleted(this, new EnviarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34209")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class EmailObj {
        
        private string[] paraField;
        
        private string[] ccField;
        
        private string[] bCcField;
        
        private string[] replyToField;
        
        private string assuntoField;
        
        private string bodyField;
        
        private string[] pathAnexosField;
        
        private AnexosHelper[] anexosField;
        
        private MailPriority priorityField;
        
        private ErrorResult[] errorsField;
        
        private bool errorField;
        
        private string nomeSistemaField;
        
        private string[] base64AnexosField;
        
        private string[] anexosNomesField;
        
        private string[] anexosMimeTypeField;
        
        /// <remarks/>
        public string[] Para {
            get {
                return this.paraField;
            }
            set {
                this.paraField = value;
            }
        }
        
        /// <remarks/>
        public string[] Cc {
            get {
                return this.ccField;
            }
            set {
                this.ccField = value;
            }
        }
        
        /// <remarks/>
        public string[] BCc {
            get {
                return this.bCcField;
            }
            set {
                this.bCcField = value;
            }
        }
        
        /// <remarks/>
        public string[] ReplyTo {
            get {
                return this.replyToField;
            }
            set {
                this.replyToField = value;
            }
        }
        
        /// <remarks/>
        public string Assunto {
            get {
                return this.assuntoField;
            }
            set {
                this.assuntoField = value;
            }
        }
        
        /// <remarks/>
        public string Body {
            get {
                return this.bodyField;
            }
            set {
                this.bodyField = value;
            }
        }
        
        /// <remarks/>
        public string[] PathAnexos {
            get {
                return this.pathAnexosField;
            }
            set {
                this.pathAnexosField = value;
            }
        }
        
        /// <remarks/>
        public AnexosHelper[] Anexos {
            get {
                return this.anexosField;
            }
            set {
                this.anexosField = value;
            }
        }
        
        /// <remarks/>
        public MailPriority Priority {
            get {
                return this.priorityField;
            }
            set {
                this.priorityField = value;
            }
        }
        
        /// <remarks/>
        public ErrorResult[] Errors {
            get {
                return this.errorsField;
            }
            set {
                this.errorsField = value;
            }
        }
        
        /// <remarks/>
        public bool Error {
            get {
                return this.errorField;
            }
            set {
                this.errorField = value;
            }
        }
        
        /// <remarks/>
        public string NomeSistema {
            get {
                return this.nomeSistemaField;
            }
            set {
                this.nomeSistemaField = value;
            }
        }
        
        /// <remarks/>
        public string[] Base64Anexos {
            get {
                return this.base64AnexosField;
            }
            set {
                this.base64AnexosField = value;
            }
        }
        
        /// <remarks/>
        public string[] AnexosNomes {
            get {
                return this.anexosNomesField;
            }
            set {
                this.anexosNomesField = value;
            }
        }
        
        /// <remarks/>
        public string[] AnexosMimeType {
            get {
                return this.anexosMimeTypeField;
            }
            set {
                this.anexosMimeTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34209")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class AnexosHelper {
        
        private string nomeArquivoField;
        
        private string base64BytesField;
        
        private string mimeTypeField;
        
        /// <remarks/>
        public string NomeArquivo {
            get {
                return this.nomeArquivoField;
            }
            set {
                this.nomeArquivoField = value;
            }
        }
        
        /// <remarks/>
        public string Base64Bytes {
            get {
                return this.base64BytesField;
            }
            set {
                this.base64BytesField = value;
            }
        }
        
        /// <remarks/>
        public string MimeType {
            get {
                return this.mimeTypeField;
            }
            set {
                this.mimeTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34209")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ExceptionAcionada {
        
        private string messageField;
        
        private string sourceField;
        
        private string stackTraceField;
        
        private string statusCodeField;
        
        /// <remarks/>
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
        
        /// <remarks/>
        public string Source {
            get {
                return this.sourceField;
            }
            set {
                this.sourceField = value;
            }
        }
        
        /// <remarks/>
        public string StackTrace {
            get {
                return this.stackTraceField;
            }
            set {
                this.stackTraceField = value;
            }
        }
        
        /// <remarks/>
        public string StatusCode {
            get {
                return this.statusCodeField;
            }
            set {
                this.statusCodeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34209")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ErrorResult {
        
        private string nomeField;
        
        private ExceptionAcionada exceptionAcionadaField;
        
        private string urlOrigemField;
        
        private string ipOrigemField;
        
        private string browserOrigemField;
        
        private System.DateTime dataExceptionField;
        
        /// <remarks/>
        public string Nome {
            get {
                return this.nomeField;
            }
            set {
                this.nomeField = value;
            }
        }
        
        /// <remarks/>
        public ExceptionAcionada ExceptionAcionada {
            get {
                return this.exceptionAcionadaField;
            }
            set {
                this.exceptionAcionadaField = value;
            }
        }
        
        /// <remarks/>
        public string UrlOrigem {
            get {
                return this.urlOrigemField;
            }
            set {
                this.urlOrigemField = value;
            }
        }
        
        /// <remarks/>
        public string IpOrigem {
            get {
                return this.ipOrigemField;
            }
            set {
                this.ipOrigemField = value;
            }
        }
        
        /// <remarks/>
        public string BrowserOrigem {
            get {
                return this.browserOrigemField;
            }
            set {
                this.browserOrigemField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DataException {
            get {
                return this.dataExceptionField;
            }
            set {
                this.dataExceptionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34209")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum MailPriority {
        
        /// <remarks/>
        Normal,
        
        /// <remarks/>
        Low,
        
        /// <remarks/>
        High,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void SendEmailCompletedEventHandler(object sender, SendEmailCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendEmailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendEmailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public EmailObj Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((EmailObj)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void SimplesCompletedEventHandler(object sender, SimplesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SimplesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SimplesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public EmailObj Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((EmailObj)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void SimplesAnexoCompletedEventHandler(object sender, SimplesAnexoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SimplesAnexoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SimplesAnexoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public EmailObj Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((EmailObj)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void SendOneEmailCompletedEventHandler(object sender, SendOneEmailCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendOneEmailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendOneEmailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public EmailObj Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((EmailObj)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void SendOneEmailAnexosCompletedEventHandler(object sender, SendOneEmailAnexosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendOneEmailAnexosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendOneEmailAnexosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public EmailObj Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((EmailObj)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void EnviarAnexoCompletedEventHandler(object sender, EnviarAnexoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EnviarAnexoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal EnviarAnexoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public EmailObj Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((EmailObj)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void EnviarCompletedEventHandler(object sender, EnviarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EnviarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal EnviarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public EmailObj Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((EmailObj)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591