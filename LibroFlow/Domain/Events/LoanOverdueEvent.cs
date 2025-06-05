using LibroFlow.Domain.Entities;

namespace LibroFlow.Domain.Events
{
    public class LoanOverdueEvent : IDomainEvent
    {
        public Loan Loan { get; }

        public LoanOverdueEvent(Loan loan)
        {
            Loan = loan;
        }
    }
}
