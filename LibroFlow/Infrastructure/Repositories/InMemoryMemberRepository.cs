using LibroFlow.Domain.Entities;
using LibroFlow.Domain.Repositories;

namespace LibroFlow.Infrastructure.Repositories
{
    public class InMemoryMemberRepository : IMemberRepository
    {
        private readonly Dictionary<Guid, Member> _members = new();

        public Member? GetById(Guid id) => _members.TryGetValue(id, out var m) ? m : null;
        public void Add(Member member) => _members[member.Id] = member;
        public IEnumerable<Member> GetAll() => _members.Values;
    }
}
