using System;
using GoogleGrpc = global::Grpc;

namespace Learning.Grpc.Client.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = new Random().NextDouble() - 0.5;

            var channel = new GoogleGrpc.Core.Channel("localhost:50000", GoogleGrpc.Core.ChannelCredentials.Insecure);
            var client = new Adder.AdderClient(channel);

            var numberNew = client.AddSimple(new Number { Value = number }).Value;

            channel.ShutdownAsync().Wait();

            Console.WriteLine($"Sent:      {number}");
            Console.WriteLine($"Returned:  {numberNew}");
        }
    }
}
