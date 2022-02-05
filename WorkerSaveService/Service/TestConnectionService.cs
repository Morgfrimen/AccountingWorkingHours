using Grpc.Core;

namespace HostedService.Service;

public class TestConnectionService : TestConnection.TestConnectionBase
{
    public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        Console.WriteLine($"Привет, {request.Name}");
        return new HelloReply() { Message = $"Привет, {request.Name}" };
    }


}