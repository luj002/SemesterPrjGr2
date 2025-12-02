
using System.Net.Sockets;

public class MemberRepository : IMemberRepository
{
    #region Instance fields
    private Dictionary<int, Member> _members;
    #endregion

    #region Properties
    public int Count
    {
        get { return _members.Count; }
    }
    #endregion

    #region Constructor
    public MemberRepository()
    {
        _members = new Dictionary<int, Member>();
    }
    #endregion

    #region Methods
    public void Create(string name, string address, string email, DateTime dateOfBirth, RepositoryExceptionType type)
    {
        Member memberToAdd = new Member(name, address, email, dateOfBirth, type);
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
    #endregion
}

