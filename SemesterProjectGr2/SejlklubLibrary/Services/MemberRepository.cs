
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
    
    /// <summary>
    /// Adds a member to the repository
    /// </summary>
    /// <param name="member">The member to add</param>
    public void Add(Member member)
    {
        if (!_members.TryAdd(member.Id, member))
            throw new RepositoryException(RepositoryExceptionType.Add, "Members with id already contained in repo");
    }

    /// <summary>
    /// Gets all members in the repository.
    /// </summary>
    /// <returns>List of all members</returns>
    public List<Member> GetAll()
    {
        return _members.Values.ToList();
    }

    /// <summary>
    /// Gets member by id.
    /// </summary>
    /// <param name="id">The id of the member to return</param>
    /// <returns>The member with the given id or null if none was found</returns>
    public Member? GetMemberById(string id)
    {
        return _members.ContainsKey(id) ? _members[id] : null;
    }

    /// <summary>
    /// Removes a member from the repository by id.
    /// </summary>
    /// <param name="id">The id of the member to remove</param>
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

