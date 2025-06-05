using LibroFlow.Domain.Entities;

namespace LibroFlow.Domain.Repositories
{
    public interface IMemberRepository
    {
        Member? GetById(Guid id);
        void Add(Member member);
        IEnumerable<Member> GetAll();
    }
}
