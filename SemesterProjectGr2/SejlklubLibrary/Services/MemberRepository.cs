
public class MemberRepository : IMemberRepository
{
    private Dictionary<int, Member> _members;
    public int Count
    {
        get { return _members.Count; }
    }

    public void Add(Member member)
    {
        if (_members.ContainsKey(member.Id))
            throw new Exception($"Members with id already contained in repo");
        else
            _members.Add(member.Id, member);
    }

    public List<Member> GetAll()
    {
        return _members.Values.ToList();
    }

    public Member? GetMemberById(int id)
    {
        return _members.ContainsKey(id) ? _members[id] : null;
    }

    public void Remove(int id)
    {
        _members.Remove(id);
    }
}

