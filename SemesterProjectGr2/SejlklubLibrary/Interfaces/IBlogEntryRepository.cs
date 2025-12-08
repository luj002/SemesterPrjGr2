public interface IBlogEntryRepository
{
    int Count { get; }
    List<BlogEntry> GetAll();
    void Add(BlogEntry blogEntry);
    BlogEntry? GetBlogEntryById(string id);
    void Remove(string id);
}
