﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.239
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.239 版自动生成。
// 
#pragma warning disable 1591

namespace forDemo.myTV {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ChinaTVprogramWebServiceSoap", Namespace="http://WebXml.com.cn/")]
    public partial class ChinaTVprogramWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback getAreaDataSetOperationCompleted;
        
        private System.Threading.SendOrPostCallback getAreaStringOperationCompleted;
        
        private System.Threading.SendOrPostCallback getTVstationDataSetOperationCompleted;
        
        private System.Threading.SendOrPostCallback getTVstationStringOperationCompleted;
        
        private System.Threading.SendOrPostCallback getTVchannelDataSetOperationCompleted;
        
        private System.Threading.SendOrPostCallback getTVchannelStringOperationCompleted;
        
        private System.Threading.SendOrPostCallback getTVprogramDateSetOperationCompleted;
        
        private System.Threading.SendOrPostCallback getTVprogramStringOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ChinaTVprogramWebService() {
            this.Url = global::forDemo.Properties.Settings.Default.forDemo_myTV_ChinaTVprogramWebService;
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
        public event getAreaDataSetCompletedEventHandler getAreaDataSetCompleted;
        
        /// <remarks/>
        public event getAreaStringCompletedEventHandler getAreaStringCompleted;
        
        /// <remarks/>
        public event getTVstationDataSetCompletedEventHandler getTVstationDataSetCompleted;
        
        /// <remarks/>
        public event getTVstationStringCompletedEventHandler getTVstationStringCompleted;
        
        /// <remarks/>
        public event getTVchannelDataSetCompletedEventHandler getTVchannelDataSetCompleted;
        
        /// <remarks/>
        public event getTVchannelStringCompletedEventHandler getTVchannelStringCompleted;
        
        /// <remarks/>
        public event getTVprogramDateSetCompletedEventHandler getTVprogramDateSetCompleted;
        
        /// <remarks/>
        public event getTVprogramStringCompletedEventHandler getTVprogramStringCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://WebXml.com.cn/getAreaDataSet", RequestNamespace="http://WebXml.com.cn/", ResponseNamespace="http://WebXml.com.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet getAreaDataSet() {
            object[] results = this.Invoke("getAreaDataSet", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void getAreaDataSetAsync() {
            this.getAreaDataSetAsync(null);
        }
        
        /// <remarks/>
        public void getAreaDataSetAsync(object userState) {
            if ((this.getAreaDataSetOperationCompleted == null)) {
                this.getAreaDataSetOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetAreaDataSetOperationCompleted);
            }
            this.InvokeAsync("getAreaDataSet", new object[0], this.getAreaDataSetOperationCompleted, userState);
        }
        
        private void OngetAreaDataSetOperationCompleted(object arg) {
            if ((this.getAreaDataSetCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getAreaDataSetCompleted(this, new getAreaDataSetCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://WebXml.com.cn/getAreaString", RequestNamespace="http://WebXml.com.cn/", ResponseNamespace="http://WebXml.com.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] getAreaString() {
            object[] results = this.Invoke("getAreaString", new object[0]);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void getAreaStringAsync() {
            this.getAreaStringAsync(null);
        }
        
        /// <remarks/>
        public void getAreaStringAsync(object userState) {
            if ((this.getAreaStringOperationCompleted == null)) {
                this.getAreaStringOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetAreaStringOperationCompleted);
            }
            this.InvokeAsync("getAreaString", new object[0], this.getAreaStringOperationCompleted, userState);
        }
        
        private void OngetAreaStringOperationCompleted(object arg) {
            if ((this.getAreaStringCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getAreaStringCompleted(this, new getAreaStringCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://WebXml.com.cn/getTVstationDataSet", RequestNamespace="http://WebXml.com.cn/", ResponseNamespace="http://WebXml.com.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet getTVstationDataSet(int theAreaID) {
            object[] results = this.Invoke("getTVstationDataSet", new object[] {
                        theAreaID});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void getTVstationDataSetAsync(int theAreaID) {
            this.getTVstationDataSetAsync(theAreaID, null);
        }
        
        /// <remarks/>
        public void getTVstationDataSetAsync(int theAreaID, object userState) {
            if ((this.getTVstationDataSetOperationCompleted == null)) {
                this.getTVstationDataSetOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetTVstationDataSetOperationCompleted);
            }
            this.InvokeAsync("getTVstationDataSet", new object[] {
                        theAreaID}, this.getTVstationDataSetOperationCompleted, userState);
        }
        
        private void OngetTVstationDataSetOperationCompleted(object arg) {
            if ((this.getTVstationDataSetCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getTVstationDataSetCompleted(this, new getTVstationDataSetCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://WebXml.com.cn/getTVstationString", RequestNamespace="http://WebXml.com.cn/", ResponseNamespace="http://WebXml.com.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] getTVstationString(int theAreaID) {
            object[] results = this.Invoke("getTVstationString", new object[] {
                        theAreaID});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void getTVstationStringAsync(int theAreaID) {
            this.getTVstationStringAsync(theAreaID, null);
        }
        
        /// <remarks/>
        public void getTVstationStringAsync(int theAreaID, object userState) {
            if ((this.getTVstationStringOperationCompleted == null)) {
                this.getTVstationStringOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetTVstationStringOperationCompleted);
            }
            this.InvokeAsync("getTVstationString", new object[] {
                        theAreaID}, this.getTVstationStringOperationCompleted, userState);
        }
        
        private void OngetTVstationStringOperationCompleted(object arg) {
            if ((this.getTVstationStringCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getTVstationStringCompleted(this, new getTVstationStringCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://WebXml.com.cn/getTVchannelDataSet", RequestNamespace="http://WebXml.com.cn/", ResponseNamespace="http://WebXml.com.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet getTVchannelDataSet(int theTVstationID) {
            object[] results = this.Invoke("getTVchannelDataSet", new object[] {
                        theTVstationID});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void getTVchannelDataSetAsync(int theTVstationID) {
            this.getTVchannelDataSetAsync(theTVstationID, null);
        }
        
        /// <remarks/>
        public void getTVchannelDataSetAsync(int theTVstationID, object userState) {
            if ((this.getTVchannelDataSetOperationCompleted == null)) {
                this.getTVchannelDataSetOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetTVchannelDataSetOperationCompleted);
            }
            this.InvokeAsync("getTVchannelDataSet", new object[] {
                        theTVstationID}, this.getTVchannelDataSetOperationCompleted, userState);
        }
        
        private void OngetTVchannelDataSetOperationCompleted(object arg) {
            if ((this.getTVchannelDataSetCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getTVchannelDataSetCompleted(this, new getTVchannelDataSetCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://WebXml.com.cn/getTVchannelString", RequestNamespace="http://WebXml.com.cn/", ResponseNamespace="http://WebXml.com.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] getTVchannelString(int theTVstationID) {
            object[] results = this.Invoke("getTVchannelString", new object[] {
                        theTVstationID});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void getTVchannelStringAsync(int theTVstationID) {
            this.getTVchannelStringAsync(theTVstationID, null);
        }
        
        /// <remarks/>
        public void getTVchannelStringAsync(int theTVstationID, object userState) {
            if ((this.getTVchannelStringOperationCompleted == null)) {
                this.getTVchannelStringOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetTVchannelStringOperationCompleted);
            }
            this.InvokeAsync("getTVchannelString", new object[] {
                        theTVstationID}, this.getTVchannelStringOperationCompleted, userState);
        }
        
        private void OngetTVchannelStringOperationCompleted(object arg) {
            if ((this.getTVchannelStringCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getTVchannelStringCompleted(this, new getTVchannelStringCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://WebXml.com.cn/getTVprogramDateSet", RequestNamespace="http://WebXml.com.cn/", ResponseNamespace="http://WebXml.com.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet getTVprogramDateSet(int theTVchannelID, string theDate, string userID) {
            object[] results = this.Invoke("getTVprogramDateSet", new object[] {
                        theTVchannelID,
                        theDate,
                        userID});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void getTVprogramDateSetAsync(int theTVchannelID, string theDate, string userID) {
            this.getTVprogramDateSetAsync(theTVchannelID, theDate, userID, null);
        }
        
        /// <remarks/>
        public void getTVprogramDateSetAsync(int theTVchannelID, string theDate, string userID, object userState) {
            if ((this.getTVprogramDateSetOperationCompleted == null)) {
                this.getTVprogramDateSetOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetTVprogramDateSetOperationCompleted);
            }
            this.InvokeAsync("getTVprogramDateSet", new object[] {
                        theTVchannelID,
                        theDate,
                        userID}, this.getTVprogramDateSetOperationCompleted, userState);
        }
        
        private void OngetTVprogramDateSetOperationCompleted(object arg) {
            if ((this.getTVprogramDateSetCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getTVprogramDateSetCompleted(this, new getTVprogramDateSetCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://WebXml.com.cn/getTVprogramString", RequestNamespace="http://WebXml.com.cn/", ResponseNamespace="http://WebXml.com.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] getTVprogramString(int theTVchannelID, string theDate, string userID) {
            object[] results = this.Invoke("getTVprogramString", new object[] {
                        theTVchannelID,
                        theDate,
                        userID});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void getTVprogramStringAsync(int theTVchannelID, string theDate, string userID) {
            this.getTVprogramStringAsync(theTVchannelID, theDate, userID, null);
        }
        
        /// <remarks/>
        public void getTVprogramStringAsync(int theTVchannelID, string theDate, string userID, object userState) {
            if ((this.getTVprogramStringOperationCompleted == null)) {
                this.getTVprogramStringOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetTVprogramStringOperationCompleted);
            }
            this.InvokeAsync("getTVprogramString", new object[] {
                        theTVchannelID,
                        theDate,
                        userID}, this.getTVprogramStringOperationCompleted, userState);
        }
        
        private void OngetTVprogramStringOperationCompleted(object arg) {
            if ((this.getTVprogramStringCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getTVprogramStringCompleted(this, new getTVprogramStringCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getAreaDataSetCompletedEventHandler(object sender, getAreaDataSetCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getAreaDataSetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getAreaDataSetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getAreaStringCompletedEventHandler(object sender, getAreaStringCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getAreaStringCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getAreaStringCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getTVstationDataSetCompletedEventHandler(object sender, getTVstationDataSetCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getTVstationDataSetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getTVstationDataSetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getTVstationStringCompletedEventHandler(object sender, getTVstationStringCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getTVstationStringCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getTVstationStringCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getTVchannelDataSetCompletedEventHandler(object sender, getTVchannelDataSetCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getTVchannelDataSetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getTVchannelDataSetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getTVchannelStringCompletedEventHandler(object sender, getTVchannelStringCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getTVchannelStringCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getTVchannelStringCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getTVprogramDateSetCompletedEventHandler(object sender, getTVprogramDateSetCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getTVprogramDateSetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getTVprogramDateSetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getTVprogramStringCompletedEventHandler(object sender, getTVprogramStringCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getTVprogramStringCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getTVprogramStringCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
}

#pragma warning restore 1591