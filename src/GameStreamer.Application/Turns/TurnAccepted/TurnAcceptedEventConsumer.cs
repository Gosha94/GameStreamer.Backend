using MassTransit;
using Newtonsoft.Json;

namespace GameStreamer.Application.Turns.TurnAccepted;

public class TurnAcceptedEventConsumer : IConsumer<TurnAcceptedDto>
{
    public Task Consume(ConsumeContext<TurnAcceptedDto> context)
    {

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Turn was correct!");

        var turnAcceptedDto = JsonConvert.SerializeObject(context.Message); ;
        Console.WriteLine($"TurnAcceptedConsumer consume message: {turnAcceptedDto}");
        
        Console.ResetColor();
        
        return Task.CompletedTask;
    }
}
