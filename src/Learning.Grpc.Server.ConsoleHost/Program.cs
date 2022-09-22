using System;
using GoogleGrpc = global::Grpc;

namespace Learning.Grpc.Server.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The gRPC server is starting.");

            var server = new GoogleGrpc.Core.Server
            {
                Services = { Adder.BindService(new AdderService()) },
                Ports = { new GoogleGrpc.Core.ServerPort("localhost", 50000, GoogleGrpc.Core.ServerCredentials.Insecure) }
            };

            server.Start();

            Console.WriteLine("The gRPC server is listening.");
            Console.WriteLine();
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            server.ShutdownAsync().Wait();
        }
    }
}
