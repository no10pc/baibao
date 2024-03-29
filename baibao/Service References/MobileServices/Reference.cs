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
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace baibao.MobileServices {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://WebXml.com.cn/", ConfigurationName="MobileServices.MobileCodeWSSoap")]
    public interface MobileCodeWSSoap {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://WebXml.com.cn/getMobileCodeInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.IAsyncResult BegingetMobileCodeInfo(string mobileCode, string userID, System.AsyncCallback callback, object asyncState);
        
        string EndgetMobileCodeInfo(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://WebXml.com.cn/getDatabaseInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.IAsyncResult BegingetDatabaseInfo(System.AsyncCallback callback, object asyncState);
        
        string[] EndgetDatabaseInfo(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MobileCodeWSSoapChannel : baibao.MobileServices.MobileCodeWSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class getMobileCodeInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public getMobileCodeInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class getDatabaseInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public getDatabaseInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MobileCodeWSSoapClient : System.ServiceModel.ClientBase<baibao.MobileServices.MobileCodeWSSoap>, baibao.MobileServices.MobileCodeWSSoap {
        
        private BeginOperationDelegate onBegingetMobileCodeInfoDelegate;
        
        private EndOperationDelegate onEndgetMobileCodeInfoDelegate;
        
        private System.Threading.SendOrPostCallback ongetMobileCodeInfoCompletedDelegate;
        
        private BeginOperationDelegate onBegingetDatabaseInfoDelegate;
        
        private EndOperationDelegate onEndgetDatabaseInfoDelegate;
        
        private System.Threading.SendOrPostCallback ongetDatabaseInfoCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public MobileCodeWSSoapClient() {
        }
        
        public MobileCodeWSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MobileCodeWSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MobileCodeWSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MobileCodeWSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<getMobileCodeInfoCompletedEventArgs> getMobileCodeInfoCompleted;
        
        public event System.EventHandler<getDatabaseInfoCompletedEventArgs> getDatabaseInfoCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult baibao.MobileServices.MobileCodeWSSoap.BegingetMobileCodeInfo(string mobileCode, string userID, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegingetMobileCodeInfo(mobileCode, userID, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string baibao.MobileServices.MobileCodeWSSoap.EndgetMobileCodeInfo(System.IAsyncResult result) {
            return base.Channel.EndgetMobileCodeInfo(result);
        }
        
        private System.IAsyncResult OnBegingetMobileCodeInfo(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string mobileCode = ((string)(inValues[0]));
            string userID = ((string)(inValues[1]));
            return ((baibao.MobileServices.MobileCodeWSSoap)(this)).BegingetMobileCodeInfo(mobileCode, userID, callback, asyncState);
        }
        
        private object[] OnEndgetMobileCodeInfo(System.IAsyncResult result) {
            string retVal = ((baibao.MobileServices.MobileCodeWSSoap)(this)).EndgetMobileCodeInfo(result);
            return new object[] {
                    retVal};
        }
        
        private void OngetMobileCodeInfoCompleted(object state) {
            if ((this.getMobileCodeInfoCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.getMobileCodeInfoCompleted(this, new getMobileCodeInfoCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void getMobileCodeInfoAsync(string mobileCode, string userID) {
            this.getMobileCodeInfoAsync(mobileCode, userID, null);
        }
        
        public void getMobileCodeInfoAsync(string mobileCode, string userID, object userState) {
            if ((this.onBegingetMobileCodeInfoDelegate == null)) {
                this.onBegingetMobileCodeInfoDelegate = new BeginOperationDelegate(this.OnBegingetMobileCodeInfo);
            }
            if ((this.onEndgetMobileCodeInfoDelegate == null)) {
                this.onEndgetMobileCodeInfoDelegate = new EndOperationDelegate(this.OnEndgetMobileCodeInfo);
            }
            if ((this.ongetMobileCodeInfoCompletedDelegate == null)) {
                this.ongetMobileCodeInfoCompletedDelegate = new System.Threading.SendOrPostCallback(this.OngetMobileCodeInfoCompleted);
            }
            base.InvokeAsync(this.onBegingetMobileCodeInfoDelegate, new object[] {
                        mobileCode,
                        userID}, this.onEndgetMobileCodeInfoDelegate, this.ongetMobileCodeInfoCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult baibao.MobileServices.MobileCodeWSSoap.BegingetDatabaseInfo(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegingetDatabaseInfo(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string[] baibao.MobileServices.MobileCodeWSSoap.EndgetDatabaseInfo(System.IAsyncResult result) {
            return base.Channel.EndgetDatabaseInfo(result);
        }
        
        private System.IAsyncResult OnBegingetDatabaseInfo(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((baibao.MobileServices.MobileCodeWSSoap)(this)).BegingetDatabaseInfo(callback, asyncState);
        }
        
        private object[] OnEndgetDatabaseInfo(System.IAsyncResult result) {
            string[] retVal = ((baibao.MobileServices.MobileCodeWSSoap)(this)).EndgetDatabaseInfo(result);
            return new object[] {
                    retVal};
        }
        
        private void OngetDatabaseInfoCompleted(object state) {
            if ((this.getDatabaseInfoCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.getDatabaseInfoCompleted(this, new getDatabaseInfoCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void getDatabaseInfoAsync() {
            this.getDatabaseInfoAsync(null);
        }
        
        public void getDatabaseInfoAsync(object userState) {
            if ((this.onBegingetDatabaseInfoDelegate == null)) {
                this.onBegingetDatabaseInfoDelegate = new BeginOperationDelegate(this.OnBegingetDatabaseInfo);
            }
            if ((this.onEndgetDatabaseInfoDelegate == null)) {
                this.onEndgetDatabaseInfoDelegate = new EndOperationDelegate(this.OnEndgetDatabaseInfo);
            }
            if ((this.ongetDatabaseInfoCompletedDelegate == null)) {
                this.ongetDatabaseInfoCompletedDelegate = new System.Threading.SendOrPostCallback(this.OngetDatabaseInfoCompleted);
            }
            base.InvokeAsync(this.onBegingetDatabaseInfoDelegate, null, this.onEndgetDatabaseInfoDelegate, this.ongetDatabaseInfoCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override baibao.MobileServices.MobileCodeWSSoap CreateChannel() {
            return new MobileCodeWSSoapClientChannel(this);
        }
        
        private class MobileCodeWSSoapClientChannel : ChannelBase<baibao.MobileServices.MobileCodeWSSoap>, baibao.MobileServices.MobileCodeWSSoap {
            
            public MobileCodeWSSoapClientChannel(System.ServiceModel.ClientBase<baibao.MobileServices.MobileCodeWSSoap> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BegingetMobileCodeInfo(string mobileCode, string userID, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = mobileCode;
                _args[1] = userID;
                System.IAsyncResult _result = base.BeginInvoke("getMobileCodeInfo", _args, callback, asyncState);
                return _result;
            }
            
            public string EndgetMobileCodeInfo(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("getMobileCodeInfo", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BegingetDatabaseInfo(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("getDatabaseInfo", _args, callback, asyncState);
                return _result;
            }
            
            public string[] EndgetDatabaseInfo(System.IAsyncResult result) {
                object[] _args = new object[0];
                string[] _result = ((string[])(base.EndInvoke("getDatabaseInfo", _args, result)));
                return _result;
            }
        }
    }
}
