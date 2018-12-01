using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace Learning.Grpc.Server.ConsoleHost
{
    class AdderService : Adder.AdderBase
    {
        public override Task<Number> AddSimple(Number request, ServerCallContext context)
        {
            var numberAdd = new Random().NextDouble() - 0.5;
            var numberNew = request.Value + numberAdd;

            return Task.FromResult(new Number { Value = numberNew });
        }
    }
}
