namespace LibroFlow.Domain.Events
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(IDomainEvent domainEvent);
    }
}
