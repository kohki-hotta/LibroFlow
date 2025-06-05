namespace LibroFlow.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int TotalCopies { get; private set; }
        public int AvailableCopies { get; private set; }

        public Book(Guid id, string title, string author, int copies)
        {
            Id = id;
            Title = title;
            Author = author;
            TotalCopies = copies;
            AvailableCopies = copies;
        }

        public bool IsAvailable => AvailableCopies > 0;

        public void Borrow()
        {
            if (AvailableCopies <= 0)
                throw new InvalidOperationException("No copies available");
            AvailableCopies--;
        }

        public void Return()
        {
            if (AvailableCopies >= TotalCopies)
                throw new InvalidOperationException("All copies already returned");
            AvailableCopies++;
        }
    }
}
