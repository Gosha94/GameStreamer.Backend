using MassTransit;
using Newtonsoft.Json;

namespace GameStreamer.Application.Turns.TurnDenied;

public class TurnDeniedEventConsumer : IConsumer<TurnDeniedDto>
{
    public Task Consume(ConsumeContext<TurnDeniedDto> context)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("!!! Turn wasn't correct!");
        
        var turnNotAcceptedDto = JsonConvert.SerializeObject(context.Message); ;
        Console.WriteLine($"TurnNotAcceptedConsumer consume message: {turnNotAcceptedDto}");
        
        Console.ResetColor();

        return Task.CompletedTask;
    }
}