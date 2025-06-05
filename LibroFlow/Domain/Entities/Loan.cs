using LibroFlow.Domain.Events;

namespace LibroFlow.Domain.Entities
{
    public class Loan
    {
        public Guid Id { get; private set; }
        public Guid MemberId { get; private set; }
        public Guid BookId { get; private set; }
        public DateTime BorrowedAt { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime? ReturnedAt { get; private set; }

        public Loan(Guid id, Guid memberId, Guid bookId, DateTime borrowedAt, DateTime dueDate)
        {
            Id = id;
            MemberId = memberId;
            BookId = bookId;
            BorrowedAt = borrowedAt;
            DueDate = dueDate;
        }

        public bool IsReturned => ReturnedAt.HasValue;
        public bool IsOverdue(DateTime asOf) => !IsReturned && asOf.Date > DueDate.Date;

        public void MarkReturned(DateTime returnedAt)
        {
            if (IsReturned)
                throw new InvalidOperationException("Already returned");
            ReturnedAt = returnedAt;
        }
    }
}
