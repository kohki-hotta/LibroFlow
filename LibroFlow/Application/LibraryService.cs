using LibroFlow.Domain.Entities;
using LibroFlow.Domain.Events;
using LibroFlow.Domain.Repositories;

namespace LibroFlow.Application
{
    public class LibraryService
    {
        private readonly IBookRepository _books;
        private readonly IMemberRepository _members;
        private readonly ILoanRepository _loans;
        private readonly IReservationRepository _reservations;
        private readonly IDomainEventDispatcher _dispatcher;

        public LibraryService(
            IBookRepository books,
            IMemberRepository members,
            ILoanRepository loans,
            IReservationRepository reservations,
            IDomainEventDispatcher dispatcher)
        {
            _books = books;
            _members = members;
            _loans = loans;
            _reservations = reservations;
            _dispatcher = dispatcher;
        }

        public Loan BorrowBook(Guid memberId, Guid bookId, int loanDays)
        {
            var member = _members.GetById(memberId) ?? throw new ArgumentException("Member not found");
            var book = _books.GetById(bookId) ?? throw new ArgumentException("Book not found");

            if (!book.IsAvailable)
                throw new InvalidOperationException("Book is not available");

            book.Borrow();
            _books.Update(book);

            var loan = new Loan(Guid.NewGuid(), memberId, bookId, DateTime.UtcNow, DateTime.UtcNow.AddDays(loanDays));
            _loans.Add(loan);

            return loan;
        }

        public void ReturnBook(Guid loanId)
        {
            var loan = _loans.GetById(loanId) ?? throw new ArgumentException("Loan not found");
            if (loan.IsReturned)
                return;

            var book = _books.GetById(loan.BookId) ?? throw new ArgumentException("Book not found");

            loan.MarkReturned(DateTime.UtcNow);
            _loans.Update(loan);

            book.Return();
            _books.Update(book);
        }

        public Reservation ReserveBook(Guid memberId, Guid bookId)
        {
            var member = _members.GetById(memberId) ?? throw new ArgumentException("Member not found");
            var book = _books.GetById(bookId) ?? throw new ArgumentException("Book not found");

            var reservation = new Reservation(Guid.NewGuid(), member.Id, book.Id, DateTime.UtcNow);
            _reservations.Add(reservation);
            return reservation;
        }

        public IEnumerable<Loan> CheckOverdue(DateTime asOf)
        {
            var overdue = new List<Loan>();
            foreach (var loan in _loans.GetActiveLoans())
            {
                if (loan.IsOverdue(asOf))
                {
                    overdue.Add(loan);
                    _dispatcher.Dispatch(new LoanOverdueEvent(loan));
                }
            }
            return overdue;
        }
    }
}
