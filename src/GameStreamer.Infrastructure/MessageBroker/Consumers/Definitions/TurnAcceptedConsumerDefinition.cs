using MassTransit;

namespace GameStreamer.Infrastructure.MessageBroker.Consumers.Definitions
{
    public class TurnAcceptedConsumerDefinition : ConsumerDefinition<TurnAcceptedEventConsumer>
    {
        public TurnAcceptedConsumerDefinition()
        {

            EndpointName = "turn-accepted";

            ConcurrentMessageLimit = 2;
        }

        protected override void ConfigureConsumer(
            IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<TurnAcceptedEventConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Interval(5, 1000));
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
}
