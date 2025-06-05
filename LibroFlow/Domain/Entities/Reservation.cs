namespace LibroFlow.Domain.Entities
{
    public class Reservation
    {
        public Guid Id { get; private set; }
        public Guid MemberId { get; private set; }
        public Guid BookId { get; private set; }
        public DateTime ReservedAt { get; private set; }
        public bool Completed { get; private set; }

        public Reservation(Guid id, Guid memberId, Guid bookId, DateTime reservedAt)
        {
            Id = id;
            MemberId = memberId;
            BookId = bookId;
            ReservedAt = reservedAt;
        }

        public void Complete()
        {
            Completed = true;
        }
    }
}
