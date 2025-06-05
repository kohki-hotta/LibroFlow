using LibroFlow.Domain.Entities;
using LibroFlow.Domain.Repositories;

namespace LibroFlow.Infrastructure.Repositories
{
    public class InMemoryBookRepository : IBookRepository
    {
        private readonly Dictionary<Guid, Book> _books = new();

        public Book? GetById(Guid id) => _books.TryGetValue(id, out var b) ? b : null;
        public IEnumerable<Book> GetAll() => _books.Values;
        public void Add(Book book) => _books[book.Id] = book;
        public void Update(Book book) => _books[book.Id] = book;
    }
}
