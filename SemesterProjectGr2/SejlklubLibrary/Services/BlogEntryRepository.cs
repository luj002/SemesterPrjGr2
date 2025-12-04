public class BlogEntryRepository : IBlogEntryRepository
{
	private Dictionary<int, BlogEntry> _blogEntries;

	public int Count
	{
		get
		{
			return _blogEntries.Count;
		}
	}

	public BlogEntryRepository()
	{
		_blogEntries = new Dictionary<int, BlogEntry>();
	}

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
	public void Remove(int id)
	{
		if (!_blogEntries.Remove(id))
		{
			throw new RepositoryException(RepositoryExceptionType.Remove, "Blog entry not found in repository.");
		}
	}
	public BlogEntry? GetBlogEntryById(int id)
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
}