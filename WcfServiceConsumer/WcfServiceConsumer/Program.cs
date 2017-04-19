namespace WcfServiceConsumer
{
    using System;

    using WcfServiceConsumer.EchoServiceProxy;

    public class Program
    {
        public static void Main(string[] args)
        {
            var echoServiceClient = new EchoServiceClient("NetTcpBinding_IEchoService");

            Console.WriteLine("Type to echo: ");
            while (true)
            {
                var message = Console.ReadLine();
                var response = echoServiceClient.Echo(message);
                Console.WriteLine(response);
            }
        }
    }
}
