using MassTransit;
using GameStreamer.Application.Turns.TurnDenied;

namespace GameStreamer.Infrastructure.MessageBroker.Consumers.Definitions
{
    public class TurnNotAcceptedConsumerDefinition : ConsumerDefinition<TurnDeniedEventConsumer>
    {
        public TurnNotAcceptedConsumerDefinition()
        {

            EndpointName = "turn-not-accepted";

            ConcurrentMessageLimit = 2;
        }

        protected override void ConfigureConsumer(
            IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<TurnDeniedEventConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Interval(5, 1000));
            endpointConfigurator.UseInMemoryOutbox();
        }

    }
}
