public interface IMemberRepository
{
    int Count { get; }
    List<Member> GetAll();
    void Add(Member member);
    Member? GetMemberById(string id);
    void Remove(string id);
}