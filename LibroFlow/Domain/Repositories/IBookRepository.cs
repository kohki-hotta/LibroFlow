using LibroFlow.Domain.Entities;

namespace LibroFlow.Domain.Repositories
{
    public interface IBookRepository
    {
        Book? GetById(Guid id);
        IEnumerable<Book> GetAll();
        void Add(Book book);
        void Update(Book book);
    }
}
