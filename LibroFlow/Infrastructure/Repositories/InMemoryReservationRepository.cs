using LibroFlow.Domain.Entities;
using LibroFlow.Domain.Repositories;

namespace LibroFlow.Infrastructure.Repositories
{
    public class InMemoryReservationRepository : IReservationRepository
    {
        private readonly Dictionary<Guid, Reservation> _reservations = new();

        public Reservation? GetById(Guid id) => _reservations.TryGetValue(id, out var r) ? r : null;
        public void Add(Reservation reservation) => _reservations[reservation.Id] = reservation;
        public IEnumerable<Reservation> GetPendingForBook(Guid bookId) => _reservations.Values.Where(r => r.BookId == bookId && !r.Completed);
        public void Update(Reservation reservation) => _reservations[reservation.Id] = reservation;
    }
}
