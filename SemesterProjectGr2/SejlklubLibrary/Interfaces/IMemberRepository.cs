public interface IMemberRepository
{
    int Count { get; }
    List<Member> GetAll();
    void Add(Member member);
    Member? GetMemberById(int id);
    void Remove(int id);
}