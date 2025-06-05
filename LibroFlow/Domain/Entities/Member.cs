namespace LibroFlow.Domain.Entities
{
    public class Member
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Member(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
