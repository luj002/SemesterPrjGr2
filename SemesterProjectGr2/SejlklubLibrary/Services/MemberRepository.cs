
using System.Net.Sockets;

public class MemberRepository : IMemberRepository
{
    #region Instance fields
    private Dictionary<string, Member> _members;
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
        _members = new Dictionary<string, Member>();
    }
    #endregion

    #region Methods
    public void Create(string name, string address, string email, DateTime dateOfBirth, MemberType type)
    {
        //TODO MAKE MEMBERS PASSWORDS CUSTOMIZABLE
        Add(new Member(name, address, email, dateOfBirth, type, "placeholder"));
    }
    
    public void Add(Member member)
    {
        if (!_members.TryAdd(member.Id, member))
            throw new RepositoryException(RepositoryExceptionType.Add, "Members with id already contained in repo");
    }

    public List<Member> GetAll()
    {
        return _members.Values.ToList();
    }

    public Member? GetMemberById(string id)
    {
        return _members.ContainsKey(id) ? _members[id] : null;
    }

    public void Remove(string id)
    {
        if(_members.TryGetValue(id, out Member? value))
        {
            _members.Remove(id);
        }
        else
        {
            throw new RepositoryException(RepositoryExceptionType.Remove, "No member with the given id found.");
        }
    }
    #endregion
}

