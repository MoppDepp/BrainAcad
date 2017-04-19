namespace WcfService.Services
{
    public class EchoService : IEchoService
    {
        public string Echo(string payload)
        {
            return $"Echo: {payload}";
        }
    }
}
