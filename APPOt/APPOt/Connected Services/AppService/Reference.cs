//------------------------------------------------------------------------------
// <generado automáticamente>
//     Este código fue generado por una herramienta.
//     //
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </generado automáticamente>
//------------------------------------------------------------------------------

namespace AppService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AppService.AppServiceSoap")]
    public interface AppServiceSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UploadOTImage", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<AppService.UploadOTImageResponse> UploadOTImageAsync(AppService.UploadOTImageRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SetOperarios", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<AppService.ActionResult> SetOperariosAsync(long actuacionId, string imei, string operarioId, string observaciones);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SetMaterial", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<AppService.ActionResult> SetMaterialAsync(long actuacionId, string imei, string materialId, string observaciones);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/OTStart", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<AppService.ActionResult> OTStartAsync(long actuacionId, string IMEI, System.DateTime dateStart);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/OTFinalize", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<AppService.ActionResult> OTFinalizeAsync(long actuacionId, string IMEI, System.DateTime dateEnd, string observaciones);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ExternalLoginAppOT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<AppService.ActionResult> ExternalLoginAppOTAsync(string code, string pin, long groupId);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ActionResult
    {
        
        private bool successField;
        
        private string messageErrorField;
        
        private object returnValueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool Success
        {
            get
            {
                return this.successField;
            }
            set
            {
                this.successField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string MessageError
        {
            get
            {
                return this.messageErrorField;
            }
            set
            {
                this.messageErrorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public object ReturnValue
        {
            get
            {
                return this.returnValueField;
            }
            set
            {
                this.returnValueField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadOTImage", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class UploadOTImageRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] contents;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string filename;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public long adjudicacionId;
        
        public UploadOTImageRequest()
        {
        }
        
        public UploadOTImageRequest(byte[] contents, string filename, long adjudicacionId)
        {
            this.contents = contents;
            this.filename = filename;
            this.adjudicacionId = adjudicacionId;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadOTImageResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class UploadOTImageResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public AppService.ActionResult UploadOTImageResult;
        
        public UploadOTImageResponse()
        {
        }
        
        public UploadOTImageResponse(AppService.ActionResult UploadOTImageResult)
        {
            this.UploadOTImageResult = UploadOTImageResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public interface AppServiceSoapChannel : AppService.AppServiceSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public partial class AppServiceSoapClient : System.ServiceModel.ClientBase<AppService.AppServiceSoap>, AppService.AppServiceSoap
    {
        
    /// <summary>
    /// Implemente este método parcial para configurar el punto de conexión de servicio.
    /// </summary>
    /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
    /// <param name="clientCredentials">Credenciales de cliente</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public AppServiceSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(AppServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), AppServiceSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AppServiceSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(AppServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AppServiceSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(AppServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AppServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<AppService.UploadOTImageResponse> AppService.AppServiceSoap.UploadOTImageAsync(AppService.UploadOTImageRequest request)
        {
            return base.Channel.UploadOTImageAsync(request);
        }
        
        public System.Threading.Tasks.Task<AppService.UploadOTImageResponse> UploadOTImageAsync(byte[] contents, string filename, long adjudicacionId)
        {
            AppService.UploadOTImageRequest inValue = new AppService.UploadOTImageRequest();
            inValue.contents = contents;
            inValue.filename = filename;
            inValue.adjudicacionId = adjudicacionId;
            return ((AppService.AppServiceSoap)(this)).UploadOTImageAsync(inValue);
        }
        
        public System.Threading.Tasks.Task<AppService.ActionResult> SetOperariosAsync(long actuacionId, string imei, string operarioId, string observaciones)
        {
            return base.Channel.SetOperariosAsync(actuacionId, imei, operarioId, observaciones);
        }
        
        public System.Threading.Tasks.Task<AppService.ActionResult> SetMaterialAsync(long actuacionId, string imei, string materialId, string observaciones)
        {
            return base.Channel.SetMaterialAsync(actuacionId, imei, materialId, observaciones);
        }
        
        public System.Threading.Tasks.Task<AppService.ActionResult> OTStartAsync(long actuacionId, string IMEI, System.DateTime dateStart)
        {
            return base.Channel.OTStartAsync(actuacionId, IMEI, dateStart);
        }
        
        public System.Threading.Tasks.Task<AppService.ActionResult> OTFinalizeAsync(long actuacionId, string IMEI, System.DateTime dateEnd, string observaciones)
        {
            return base.Channel.OTFinalizeAsync(actuacionId, IMEI, dateEnd, observaciones);
        }
        
        public System.Threading.Tasks.Task<AppService.ActionResult> ExternalLoginAppOTAsync(string code, string pin, long groupId)
        {
            return base.Channel.ExternalLoginAppOTAsync(code, pin, groupId);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.AppServiceSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.AppServiceSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.AppServiceSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://ctman.constraula.com/CustomersFramework/Constraula/data/appservice.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.AppServiceSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://ctman.constraula.com/CustomersFramework/Constraula/data/appservice.asmx");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            AppServiceSoap,
            
            AppServiceSoap12,
        }
    }
}
