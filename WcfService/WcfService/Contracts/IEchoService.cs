namespace WcfService
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IEchoService
    {
        [OperationContract]
        string Echo(string payload);
    }
}
