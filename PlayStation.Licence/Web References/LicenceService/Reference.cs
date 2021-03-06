﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.17929.
// 
#pragma warning disable 1591

namespace PlayStation.Licence.LicenceService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ConsolePlusSoap", Namespace="http://tempuri.org/")]
    public partial class ConsolePlus : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetLicenceCheckOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ConsolePlus() {
            //this.Url = global::PlayStation.Licence.Properties.Settings.Default.PlayStation_Licence_LicenceService_ConsolePlus;
            this.Url = "http://www.nvisionsoft.net/ConsolePlus.asmx";
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
        public event GetLicenceCheckCompletedEventHandler GetLicenceCheckCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetLicenceCheck", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public LicenceDetail GetLicenceCheck(string LicenceKey, string AuthenticationKey, string MotherBoardSerial, string CPUSerial, string HDDSerial) {
            object[] results = this.Invoke("GetLicenceCheck", new object[] {
                        LicenceKey,
                        AuthenticationKey,
                        MotherBoardSerial,
                        CPUSerial,
                        HDDSerial});
            return ((LicenceDetail)(results[0]));
        }
        
        /// <remarks/>
        public void GetLicenceCheckAsync(string LicenceKey, string AuthenticationKey, string MotherBoardSerial, string CPUSerial, string HDDSerial) {
            this.GetLicenceCheckAsync(LicenceKey, AuthenticationKey, MotherBoardSerial, CPUSerial, HDDSerial, null);
        }
        
        /// <remarks/>
        public void GetLicenceCheckAsync(string LicenceKey, string AuthenticationKey, string MotherBoardSerial, string CPUSerial, string HDDSerial, object userState) {
            if ((this.GetLicenceCheckOperationCompleted == null)) {
                this.GetLicenceCheckOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetLicenceCheckOperationCompleted);
            }
            this.InvokeAsync("GetLicenceCheck", new object[] {
                        LicenceKey,
                        AuthenticationKey,
                        MotherBoardSerial,
                        CPUSerial,
                        HDDSerial}, this.GetLicenceCheckOperationCompleted, userState);
        }
        
        private void OnGetLicenceCheckOperationCompleted(object arg) {
            if ((this.GetLicenceCheckCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetLicenceCheckCompleted(this, new GetLicenceCheckCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class LicenceDetail {
        
        private string licenceKeyField;
        
        private int userCountField;
        
        private System.DateTime licenceStartDateField;
        
        private System.DateTime licenceEndDateField;
        
        private System.DateTime beforeCheckDateField;
        
        private int updateDayCountField;
        
        private bool demoField;
        
        private bool activeField;
        
        private string resultMessageField;
        
        private bool resultCodeField;
        
        /// <remarks/>
        public string LicenceKey {
            get {
                return this.licenceKeyField;
            }
            set {
                this.licenceKeyField = value;
            }
        }
        
        /// <remarks/>
        public int UserCount {
            get {
                return this.userCountField;
            }
            set {
                this.userCountField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime LicenceStartDate {
            get {
                return this.licenceStartDateField;
            }
            set {
                this.licenceStartDateField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime LicenceEndDate {
            get {
                return this.licenceEndDateField;
            }
            set {
                this.licenceEndDateField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime BeforeCheckDate {
            get {
                return this.beforeCheckDateField;
            }
            set {
                this.beforeCheckDateField = value;
            }
        }
        
        /// <remarks/>
        public int UpdateDayCount {
            get {
                return this.updateDayCountField;
            }
            set {
                this.updateDayCountField = value;
            }
        }
        
        /// <remarks/>
        public bool Demo {
            get {
                return this.demoField;
            }
            set {
                this.demoField = value;
            }
        }
        
        /// <remarks/>
        public bool Active {
            get {
                return this.activeField;
            }
            set {
                this.activeField = value;
            }
        }
        
        /// <remarks/>
        public string ResultMessage {
            get {
                return this.resultMessageField;
            }
            set {
                this.resultMessageField = value;
            }
        }
        
        /// <remarks/>
        public bool ResultCode {
            get {
                return this.resultCodeField;
            }
            set {
                this.resultCodeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void GetLicenceCheckCompletedEventHandler(object sender, GetLicenceCheckCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetLicenceCheckCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetLicenceCheckCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public LicenceDetail Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((LicenceDetail)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591