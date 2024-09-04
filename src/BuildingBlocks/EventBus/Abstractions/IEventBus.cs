namespace Awc.Dapr.BuildingBlocks.EventBus.Abstractions
{
    public interface IEventBus
    {
        Task PublishAsync(IntegrationEvent integrationEvent);  
    }
}