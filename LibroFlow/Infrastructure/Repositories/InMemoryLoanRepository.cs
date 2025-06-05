using LibroFlow.Domain.Entities;
using LibroFlow.Domain.Repositories;

namespace LibroFlow.Infrastructure.Repositories
{
    public class InMemoryLoanRepository : ILoanRepository
    {
        private readonly Dictionary<Guid, Loan> _loans = new();

        public Loan? GetById(Guid id) => _loans.TryGetValue(id, out var l) ? l : null;
        public IEnumerable<Loan> GetActiveLoans() => _loans.Values.Where(l => !l.IsReturned);
        public void Add(Loan loan) => _loans[loan.Id] = loan;
        public void Update(Loan loan) => _loans[loan.Id] = loan;
    }
}
