﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientConsole.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetInfoAbout", ReplyAction="http://tempuri.org/IService/GetInfoAboutResponse")]
        string GetInfoAbout(string station, string cityName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetInfoAbout", ReplyAction="http://tempuri.org/IService/GetInfoAboutResponse")]
        System.Threading.Tasks.Task<string> GetInfoAboutAsync(string station, string cityName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCities", ReplyAction="http://tempuri.org/IService/GetCitiesResponse")]
        string[] GetCities();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCities", ReplyAction="http://tempuri.org/IService/GetCitiesResponse")]
        System.Threading.Tasks.Task<string[]> GetCitiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetStations", ReplyAction="http://tempuri.org/IService/GetStationsResponse")]
        string[] GetStations(string cityName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetStations", ReplyAction="http://tempuri.org/IService/GetStationsResponse")]
        System.Threading.Tasks.Task<string[]> GetStationsAsync(string cityName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : ClientConsole.ServiceReference.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<ClientConsole.ServiceReference.IService>, ClientConsole.ServiceReference.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetInfoAbout(string station, string cityName) {
            return base.Channel.GetInfoAbout(station, cityName);
        }
        
        public System.Threading.Tasks.Task<string> GetInfoAboutAsync(string station, string cityName) {
            return base.Channel.GetInfoAboutAsync(station, cityName);
        }
        
        public string[] GetCities() {
            return base.Channel.GetCities();
        }
        
        public System.Threading.Tasks.Task<string[]> GetCitiesAsync() {
            return base.Channel.GetCitiesAsync();
        }
        
        public string[] GetStations(string cityName) {
            return base.Channel.GetStations(cityName);
        }
        
        public System.Threading.Tasks.Task<string[]> GetStationsAsync(string cityName) {
            return base.Channel.GetStationsAsync(cityName);
        }
    }
}