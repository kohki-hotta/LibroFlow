using Microsoft.Extensions.Logging;

namespace LibroFlow.Domain.Events
{
    public class LoggingEventDispatcher : IDomainEventDispatcher
    {
        private readonly ILogger<LoggingEventDispatcher> _logger;

        public LoggingEventDispatcher(ILogger<LoggingEventDispatcher> logger)
        {
            _logger = logger;
        }

        public void Dispatch(IDomainEvent domainEvent)
        {
            _logger.LogInformation("Domain event dispatched: {Event}", domainEvent.GetType().Name);
        }
    }
}
