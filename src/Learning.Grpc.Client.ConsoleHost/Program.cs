using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleGrpc = global::Grpc;

namespace Learning.Grpc.Client.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            AddSimple();                    // The client sends a random number to the server. The server adds a random number to it and returns the result.
            //AddServerStream();            // 
            //AddClientStream();            // The client streams random numbers to the stream. The server ???.
            //AddBidirectional();           // The client streams random numbers to the stream. The server periodically returns the running total.

            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine();
            }
        }

        static void AddSimple()
        {
            var number = new Random().NextDouble() - 0.5;

            var channel = new GoogleGrpc.Core.Channel("localhost:50000", GoogleGrpc.Core.ChannelCredentials.Insecure);
            var client = new Adder.AdderClient(channel);

            var numberNew = client.AddSimple(new Number { Value = number }).Value;

            channel.ShutdownAsync().Wait();

            Console.WriteLine($"Sent:      {number}");
            Console.WriteLine($"Returned:  {numberNew}");
        }

        static async Task AddServerStream()
        {
            var number = new Random().NextDouble() - 0.5;

            var channel = new GoogleGrpc.Core.Channel("localhost:50000", GoogleGrpc.Core.ChannelCredentials.Insecure);
            var client = new Adder.AdderClient(channel);

            using (var call = client.AddServerStream(new Number { Value = number }))
            {
                var stream = call.ResponseStream;

                //while (await stream.MoveNext())
                //{
                //}
            }
        }

        static void AddClientStream()
        {
        }

        static void AddBidirectional()
        {
        }
    }
}
