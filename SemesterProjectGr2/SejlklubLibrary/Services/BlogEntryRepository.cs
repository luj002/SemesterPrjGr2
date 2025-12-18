public class BlogEntryRepository : IBlogEntryRepository
{
    #region Instance field
    private Dictionary<string, BlogEntry> _blogEntries;
    #endregion

    #region Properties
    public int Count
	{
		get
		{
			return _blogEntries.Count;
		}
    }
    #endregion

    #region Constructor
    public BlogEntryRepository()
	{
		_blogEntries = new Dictionary<string, BlogEntry>();
    }
    #endregion

    #region Methods
    public void Add(BlogEntry blogEntry)
	{
		if (blogEntry == null)
		{
			throw new RepositoryException(RepositoryExceptionType.Add, "Cannot add a null blog entry.");
		}
		if (!_blogEntries.TryAdd(blogEntry.Id, blogEntry))
		{
			throw new RepositoryException(RepositoryExceptionType.Add, $"A blogEntry with ID: {blogEntry.Id} aldready exists");
		}
	}
	public void Remove(string id)
	{
		if (!_blogEntries.Remove(id))
		{
			throw new RepositoryException(RepositoryExceptionType.Remove, "Blog entry not found in repository.");
		}
	}
	public BlogEntry? GetBlogEntryById(string id)
	{
		if (_blogEntries.TryGetValue(id, out var blogEntry))
		{
			return blogEntry;
		}
		return null;
	}
	public List<BlogEntry> GetAll()
	{
		return _blogEntries.Values.ToList();
	}
    #endregion
}