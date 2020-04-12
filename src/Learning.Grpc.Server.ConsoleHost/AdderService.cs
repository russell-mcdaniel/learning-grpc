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

        public override Task AddServerStream(Number request, IServerStreamWriter<Number> responseStream, ServerCallContext context)
        {
            //return base.AddServerStream(request, responseStream, context);
            throw new NotImplementedException();
        }

        public override Task<Number> AddClientStream(IAsyncStreamReader<Number> requestStream, ServerCallContext context)
        {
            //return base.AddClientStream(requestStream, context);
            throw new NotImplementedException();
        }

        public override Task AddBidirectional(IAsyncStreamReader<Number> requestStream, IServerStreamWriter<Number> responseStream, ServerCallContext context)
        {
            //return base.AddBidirectional(requestStream, responseStream, context);
            throw new NotImplementedException();
        }
    }
}
