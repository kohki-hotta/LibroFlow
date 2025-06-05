using LibroFlow.Domain.Entities;

namespace LibroFlow.Domain.Repositories
{
    public interface ILoanRepository
    {
        Loan? GetById(Guid id);
        IEnumerable<Loan> GetActiveLoans();
        void Add(Loan loan);
        void Update(Loan loan);
    }
}
