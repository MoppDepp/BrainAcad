namespace WcfService
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;

    using WcfService.Services;

    public class Program
    {
        private static ServiceHost host;

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Do you want to start a WCF service y/n?");
                var command = Console.ReadLine();
                if (command == "y")
                {
                    Console.WriteLine("Starting WCF service...");
                    HostService();

                    while (true)
                    {
                        Console.WriteLine("To close service hit enter");
                        Console.ReadLine();
                        CloseHost();
                        return;
                    }
                }
            }
        }

        public static void HostService()
        {
            if (host != null)
            {
                throw new Exception("Host is already running");
            }

            var address = new Uri("http://localhost:9090/myservice");
            var address2 = new Uri("net.tcp://localhost:9091/myservice2");
            host = new ServiceHost(typeof(EchoService), address);

            // Setup metadata
            var smb = new ServiceMetadataBehavior
                          {
                              HttpGetEnabled = true,
                              MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 }
                          };

            host.Description.Behaviors.Add(smb);

            host.AddServiceEndpoint(typeof(IEchoService), new NetTcpBinding(), address2);

            host.Open();
            Console.WriteLine("Service listening on {0}", address);
        }

        public static void CloseHost()
        {
            if (host == null)
            {
                throw new Exception("Host is not started");
            }

            host.Close();
        }
    }
}
