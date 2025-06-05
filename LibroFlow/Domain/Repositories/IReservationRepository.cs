using LibroFlow.Domain.Entities;

namespace LibroFlow.Domain.Repositories
{
    public interface IReservationRepository
    {
        Reservation? GetById(Guid id);
        void Add(Reservation reservation);
        IEnumerable<Reservation> GetPendingForBook(Guid bookId);
        void Update(Reservation reservation);
    }
}
